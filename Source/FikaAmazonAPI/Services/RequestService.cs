using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Filters;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class RequestService : ApiUrls
    {
        public static readonly string AccessTokenHeaderName = "x-amz-access-token";
        public static readonly string SecurityTokenHeaderName = "x-amz-security-token";
        public static readonly string ShippingBusinessIdHeaderName = "x-amzn-shipping-business-id";
        protected RestClient RequestClient { get; set; }
        protected RestRequest Request { get; set; }
        protected AmazonCredential AmazonCredential { get; set; }
        protected string AmazonSandboxUrl { get; set; }
        protected string AmazonProductionUrl { get; set; }
        protected string AccessToken { get; set; }
        protected IList<KeyValuePair<string, string>> LastHeaders { get; set; }
        public int? Timeout
        {
            //get { return RequestClient.Timeout; }   // get method
            //set { RequestClient.Timeout = value; }  // set method

            get;
            set;
        }
        private IRateLimitingHandler RateLimitingHandler { get; }

        protected string ApiBaseUrl
        {
            get
            {
                return AmazonCredential.Environment == Environments.Sandbox ? AmazonSandboxUrl : AmazonProductionUrl;
            }
        }

        private ILogger<RequestService>? _logger = null;

        /// <summary>
        /// Creates request base service
        /// </summary>
        /// <param name="amazonCredential">A credential containing the API user's information and cached token values</param>
        /// <param name="rateLimitingHandler">A singleton designed to handle concurrent requests based on the rate limiting policy</param>
        public RequestService(AmazonCredential amazonCredential,ILoggerFactory? loggerFactory, IRateLimitingHandler rateLimitingHandler = null)
        {
            RateLimitingHandler = rateLimitingHandler ?? new RateLimitingHandler();

            _logger = loggerFactory?.CreateLogger<RequestService>();
            AmazonCredential = amazonCredential;
            AmazonSandboxUrl = amazonCredential.MarketPlace.Region.SandboxHostUrl;
            AmazonProductionUrl = amazonCredential.MarketPlace.Region.HostUrl;
        }

        private void CreateRequest(string url, RestSharp.Method method)
        {
            if (string.IsNullOrWhiteSpace(AmazonCredential.ProxyAddress))
            {
                var options = new RestClientOptions(ApiBaseUrl);
                RequestClient = new RestClient(options,
                    configureSerialization: s => s.UseNewtonsoftJson());
            }
            else
            {
                var options = new RestClientOptions(ApiBaseUrl)
                {
                    Proxy = new System.Net.WebProxy()
                    {
                        Address = new Uri(AmazonCredential.ProxyAddress)
                    }
                };

                if (Timeout.HasValue)
                {
                    options.MaxTimeout = Timeout.Value;
                }

                RequestClient = new RestClient(options, 
                    configureSerialization: s => s.UseNewtonsoftJson() /*s.UseSerializer(() => new CustomSerializer())*/
                    );
                RequestClient = new RestClient(options,
                    configureSerialization: s => s.UseNewtonsoftJson());
            }

            //RequestClient.UseNewtonsoftJson();
            //if (Timeout.HasValue)
            //{
            //    RequestClient.Options.MaxTimeout = Timeout.Value;
            //}
            Request = new RestRequest(url, method);
            
        }

        protected async Task CreateAuthorizedRequestAsync(string url, RestSharp.Method method,
            List<KeyValuePair<string, string>> queryParameters = null, object postJsonObj = null,
            TokenDataType tokenDataType = TokenDataType.Normal, object parameter = null,
            CancellationToken cancellationToken = default)
        {
            var PiiObject = parameter as IParameterBasedPII;
            if (PiiObject != null && PiiObject.IsNeedRestrictedDataToken)
                await RefreshTokenAsync(TokenDataType.PII, PiiObject.RestrictedDataTokenRequest, cancellationToken);
            else
                await RefreshTokenAsync(tokenDataType, cancellationToken: cancellationToken);
            CreateRequest(url, method);
            if (postJsonObj != null)
                AddJsonBody(postJsonObj);
            if (queryParameters != null)
                AddQueryParameters(queryParameters);
        }

        protected void CreateAuthorizedPagedRequest(AmazonFilter filter, string url, RestSharp.Method method)
        {
            RefreshToken();
            if (filter.NextPage != null)
                CreateRequest(filter.NextPage, method);
            else
            {
                CreateRequest(url, method);
                AddLimitHeader(filter.Limit);
            }

            AddAccessToken();
        }

        /// <summary>
        /// Executes the request
        /// </summary>
        /// <typeparam name="T">Type to parse response to</typeparam>
        /// <returns>Returns data of T type</returns>
        protected async Task<T> ExecuteRequestTry<T>(
            RateLimitType rateLimitType = RateLimitType.UNSET,
            CancellationToken cancellationToken = default) where T : new()
        {
            RestHeader();
            AddAccessToken();
            AddShippingBusinessId();

            //Remove AWS authorization
            //Request = await TokenGeneration.SignWithSTSKeysAndSecurityTokenAsync(Request, RequestClient.Options.BaseUrl.Host, AmazonCredential, cancellationToken);
            var response = await RateLimitingHandler.SafelyExecuteRequestAsync<T>(
                RequestClient,
                Request,
                AmazonCredential,
                rateLimitType,
                responseCallback: response =>
                {
                    LogRequest(Request, response);
                    SaveLastRequestHeader(response.Headers);
                },
                cancellationToken: cancellationToken);

            ParseResponse(response);

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content) &&
                response.Data == null)
            {
                response.Data = JsonConvert.DeserializeObject<T>(response.Content);
            }

            return response.Data;
        }

        private void SaveLastRequestHeader(IReadOnlyCollection<RestSharp.HeaderParameter> parameters)
        {
            LastHeaders = new List<KeyValuePair<string, string>>();
            foreach (RestSharp.Parameter parameter in parameters ?? Enumerable.Empty<HeaderParameter>())
            {
                if (parameter != null && parameter.Name != null && parameter.Value != null)
                {
                    LastHeaders.Add(new KeyValuePair<string, string>(parameter.Name.ToString(),
                        parameter.Value.ToString()));
                }
            }
        }

        private void LogRequest(RestRequest request, RestResponse response)
        {
            var requestToLog = new
            {
                resource = request.Resource,
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }).ToList(),
                // ToString() here to have the method as a nice string otherwise it will just show the enum value
                method = request.Method.ToString(),
                // This will generate the actual Uri used in the request
                //uri = request. _restClient.BuildUri(request),
            };
            
            //remove the access token from the headers
            requestToLog.parameters.RemoveAll(p => p.name == "x-amz-access-token");

            var responseToLog = new
            {
                statusCode = response.StatusCode,
                content = response.Content,
                headers = response.Headers.Select(h => new
                {
                    name = h.Name,
                    value = h.Value
                }),
                // The Uri that actually responded (could be different from the requestUri if a redirection occurred)
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage,
            };
            //There are PII considerations here
            _logger?.LogInformation("Request completed, \nRequest: {@request} \n\nResponse: {@response}", requestToLog, responseToLog);
        }

        private void RestHeader()
        {
            lock (Request)
            {
                //Request?.Parameters?.RemoveParameter(AWSSignerHelper.XAmzDateHeaderName);
                //Request?.Parameters?.RemoveParameter(AWSSignerHelper.AuthorizationHeaderName);
                Request?.Parameters?.RemoveParameter(AccessTokenHeaderName);
                Request?.Parameters?.RemoveParameter(SecurityTokenHeaderName);
                Request?.Parameters?.RemoveParameter(ShippingBusinessIdHeaderName);
            }
        }

        //public T ExecuteRequest<T>(RateLimitType rateLimitType = RateLimitType.UNSET) where T : new()
        //{
        //    return this.ExecuteRequestAsync<T>(rateLimitType)).ConfigureAwait(false).GetAwaiter().GetResult();
        //}

        public async Task<T> ExecuteRequestAsync<T>(RateLimitType rateLimitType = RateLimitType.UNSET,
            CancellationToken cancellationToken = default) where T : new()
        {
            var tryCount = 0;
            while (true)
            {
                try
                {
                    return await ExecuteRequestTry<T>(rateLimitType, cancellationToken);
                }
                catch (AmazonQuotaExceededException ex)
                {
                    if (tryCount >= AmazonCredential.MaxThrottledRetryCount)
                    {                        
                        _logger?.LogWarning("Throttle max try count reached");

                        throw;
                    }

                    cancellationToken.ThrowIfCancellationRequested();

                    await RateLimitingHandler.WaitForLimitTypeAsync(AmazonCredential, rateLimitType, cancellationToken);
                    tryCount++;
                }
            }
        }

        protected void ParseResponse(RestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted ||
                response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent)
                return;
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new AmazonNotFoundException("Resource that you are looking for is not found", response);
            }
            else
            {
                
                _logger?.LogWarning("Amazon Api didn't respond with Okay, see exception for more details: {content}", response.Content);

                var errorResponse = response.Content.ConvertToErrorResponse();
                if (errorResponse != null)
                {
                    var error = errorResponse.Errors.FirstOrDefault();

                    switch (error.Code)
                    {
                        case "Unauthorized":
                            throw new AmazonUnauthorizedException(error.Message, response);
                        case "InvalidSignature":
                            throw new AmazonInvalidSignatureException(error.Message, response);
                        case "InvalidInput":
                            throw new AmazonInvalidInputException(error.Message, error.Details, response);
                        case "QuotaExceeded":
                            throw new AmazonQuotaExceededException(error.Message, response);
                        case "InternalFailure":
                            throw new AmazonInternalErrorException(error.Message, response);
                    }
                }
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new AmazonBadRequestException(
                    "BadRequest see https://developer-docs.amazon.com/sp-api/changelog/api-request-validation-for-400-errors-with-html-response for advice",
                    response);
            }

            throw new AmazonException("Amazon Api didn't respond with Okay, see exception for more details", response);
        }

        protected void AddQueryParameters(List<KeyValuePair<string, string>> queryParameters)
        {
            if (queryParameters != null)
                queryParameters.ForEach(qp => Request.AddQueryParameter(qp.Key, qp.Value));
        }

        protected void AddLimitHeader(int limit)
        {
            Request.AddQueryParameter("limit", limit.ToString());
        }

        protected void AddJsonBody(object jsonData)
        {
            var json = JsonConvert.SerializeObject(jsonData);
            Request.AddJsonBody(json);
        }

        protected void AddAccessToken()
        {
            lock (Request)
            {
                Request.AddOrUpdateHeader(AccessTokenHeaderName, AccessToken);
            }
        }

        protected void AddShippingBusinessId()
        {
            if (AmazonCredential.ShippingBusiness.HasValue)
                Request.AddOrUpdateHeader(ShippingBusinessIdHeaderName,
                    AmazonCredential.ShippingBusiness.Value.GetEnumMemberValue());
        }

        protected async Task RefreshToken(TokenDataType tokenDataType = TokenDataType.Normal,
            CreateRestrictedDataTokenRequest requestPII = null)
        {
            var token = AmazonCredential.GetToken(tokenDataType);
            if (token == null)
            {
                if (tokenDataType == TokenDataType.PII)
                {
                    var pii = await CreateRestrictedDataTokenAsync(requestPII);
                    if (pii != null)
                    {
                        token = new TokenResponse()
                        {
                            access_token = pii.RestrictedDataToken,
                            expires_in = pii.ExpiresIn
                        };
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(pii));
                    }
                }
                else
                {
                    token = await TokenGeneration.RefreshAccessTokenAsync(AmazonCredential, tokenDataType);
                }

                AmazonCredential.SetToken(tokenDataType, token);
            }


            AccessToken = token.access_token;
        }

        protected async Task RefreshTokenAsync(TokenDataType tokenDataType = TokenDataType.Normal,
            CreateRestrictedDataTokenRequest requestPII = null, CancellationToken cancellationToken = default)
        {
            var token = AmazonCredential.GetToken(tokenDataType);
            if (token == null)
            {
                if (tokenDataType == TokenDataType.PII)
                {
                    var pii = await CreateRestrictedDataTokenAsync(requestPII, cancellationToken);
                    if (pii != null)
                    {
                        token = new TokenResponse()
                        {
                            access_token = pii.RestrictedDataToken,
                            expires_in = pii.ExpiresIn
                        };
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(pii));
                    }
                }
                else
                {
                    token = await TokenGeneration.RefreshAccessTokenAsync(AmazonCredential, tokenDataType,
                        cancellationToken);
                }

                AmazonCredential.SetToken(tokenDataType, token);
            }


            AccessToken = token.access_token;
        }

        public IList<KeyValuePair<string, string>> LastResponseHeader => LastHeaders;

        public CreateRestrictedDataTokenResponse CreateRestrictedDataToken(
            CreateRestrictedDataTokenRequest createRestrictedDataTokenRequest)
        {
            return Task.Run(() => CreateRestrictedDataTokenAsync(createRestrictedDataTokenRequest))
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<CreateRestrictedDataTokenResponse> CreateRestrictedDataTokenAsync(
            CreateRestrictedDataTokenRequest createRestrictedDataTokenRequest,
            CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(TokenApiUrls.RestrictedDataToken, RestSharp.Method.Post,
                postJsonObj: createRestrictedDataTokenRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<CreateRestrictedDataTokenResponse>(
                RateLimitType.Token_CreateRestrictedDataToken, cancellationToken: cancellationToken);
            return response;
        }
    }
}