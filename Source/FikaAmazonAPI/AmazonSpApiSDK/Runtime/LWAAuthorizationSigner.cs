using RestSharp;
using System.Threading.Tasks;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class LWAAuthorizationSigner
    {
        public const string AccessTokenHeaderName = "x-amz-access-token";

        public LWAClient LWAClient { get; set; }

        /// <summary>
        /// Constructor for LWAAuthorizationSigner
        /// </summary>
        /// <param name="lwaAuthorizationCredentials">LWA Authorization Credentials for token exchange</param>
        public LWAAuthorizationSigner(LWAAuthorizationCredentials lwaAuthorizationCredentials)
        {
            LWAClient = new LWAClient(lwaAuthorizationCredentials);
        }

        /// <summary>
        /// Signs a request with LWA Access Token
        /// </summary>
        /// <param name="restRequest">Request to sign</param>
        /// <returns>restRequest with LWA signature</returns>
        public async Task<RestRequest> Sign(RestRequest restRequest)
        {
            string accessToken = (await LWAClient.GetAccessTokenAsync()).access_token;

            restRequest.AddHeader(AccessTokenHeaderName, accessToken);

            return restRequest;
        }
    }
}
