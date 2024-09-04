﻿using Amazon.Auth.AccessControlPolicy;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FinancialService : RequestService
    {
        public FinancialService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public IList<FinancialEventGroup> ListFinancialEventGroups(ParameterListFinancialEventGroup parameterListFinancialEventGroup) =>
            Task.Run(() => ListFinancialEventGroupsAsync(parameterListFinancialEventGroup)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<FinancialEventGroup>> ListFinancialEventGroupsAsync(ParameterListFinancialEventGroup parameterListFinancialEventGroup, CancellationToken cancellationToken = default)
        {
            List<FinancialEventGroup> list = new List<FinancialEventGroup>();

            var parameter = parameterListFinancialEventGroup.getParameters();

            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups, cancellationToken);

            list.AddRange(response.Payload.FinancialEventGroupList);
            var nextToken = response.Payload.NextToken;

            while (!string.IsNullOrEmpty(nextToken))
            {
                var data = await GetFinancialEventGroupListByNextTokenAsync(nextToken, cancellationToken);
                list.AddRange(data.FinancialEventGroupList);
                nextToken = data.NextToken;
            }

            return list;
        }

        public ListFinancialEventGroupsPayload GetFinancialEventGroupListByNextToken(string nextToken) =>
            Task.Run(() => GetFinancialEventGroupListByNextTokenAsync(nextToken)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListFinancialEventGroupsPayload> GetFinancialEventGroupListByNextTokenAsync(string nextToken, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups, cancellationToken);
            return response.Payload;
        }


        public List<FinancialEvents> ListFinancialEventsByGroupId(ParameterListFinancialEventsByGroupId parameterListFinancialEventsByGroupId) =>
                Task.Run(() => ListFinancialEventsByGroupIdAsync(parameterListFinancialEventsByGroupId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<FinancialEvents>> ListFinancialEventsByGroupIdAsync(ParameterListFinancialEventsByGroupId parameterListFinancialEventsByGroupId, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("PostedAfter", parameterListFinancialEventsByGroupId.PostedAfter?.ToString("yyyy-MM-dd")));
            queryParameters.Add(new KeyValuePair<string, string>("PostedBefore", parameterListFinancialEventsByGroupId.PostedBefore?.ToString("yyyy-MM-dd")));

            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByGroupId(parameterListFinancialEventsByGroupId.GroupId), RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByGroupId, cancellationToken);

            var nextToken = response.Payload.NextToken;

            var list = new List<FinancialEvents>();
            list.Add(response.Payload.FinancialEvents);
            int retriesCount = 0;
            while (!string.IsNullOrEmpty(nextToken))
            {
                try
                {
                    var data = await ListFinancialEventsByGroupIdByNextTokenAsync(parameterListFinancialEventsByGroupId.GroupId, nextToken, cancellationToken);
                    if (data.Payload != null && data.Payload.FinancialEvents != null)
                    {
                        list.Add(data.Payload.FinancialEvents);
                    }
                    nextToken = data.Payload.NextToken;
                    retriesCount = 0;
                }
                catch (System.Exception ex)
                {
                    /*TextWriter writer = null;
                    try
                    {
                        var contentsToWriteToFile = JsonConvert.SerializeObject("test");
                        writer = new StreamWriter(@"c:\temp\error.txt", false);
                        writer.Write(contentsToWriteToFile);
                    }
                    finally
                    {
                        if (writer != null)
                            writer.Close();
                    }*/

                    //if (ex.Message == "$errorResponse.Message" || ex.Message.Contains("quota"))
                    {
                        retriesCount++;
                        Thread.Sleep(3000);
                        if (retriesCount < 5)
                        {
                            continue;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            return list;
        }
        private async Task<ListFinancialEventsResponse> ListFinancialEventsByGroupIdByNextTokenAsync(string eventGroupId, string nextToken, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByGroupId(eventGroupId), RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByGroupId, cancellationToken);
        }

        public FinancialEvents ListFinancialEventsByOrderId(string orderId) =>
            Task.Run(() => ListFinancialEventsByOrderIdAsync(orderId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FinancialEvents> ListFinancialEventsByOrderIdAsync(string orderId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByOrderId(orderId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByOrderId, cancellationToken);
            return response.Payload.FinancialEvents;
        }

        public FinancialEvents ListFinancialEvents() =>
            Task.Run(() => ListFinancialEventsAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FinancialEvents> ListFinancialEventsAsync(CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents, cancellationToken);
            return response.Payload.FinancialEvents;
        }

        public IList<FinancialEvents> ListFinancialEvents(ParameterListFinancialEvents parameterListFinancials) =>
            Task.Run(() => ListFinancialEventsAsync(parameterListFinancials)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<FinancialEvents>> ListFinancialEventsAsync(ParameterListFinancialEvents parameterListFinancials, CancellationToken cancellationToken = default)
        {
            List<FinancialEvents> list = new List<FinancialEvents>();

            var parameter = parameterListFinancials.getParameters();

            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents, cancellationToken);

            list.Add(response.Payload.FinancialEvents);
            var nextToken = response.Payload.NextToken;
            int countPages = 1;
            while (!string.IsNullOrEmpty(nextToken) &&
                        ((!parameterListFinancials.MaxNumberOfPages.HasValue)
                            || (parameterListFinancials.MaxNumberOfPages.HasValue && parameterListFinancials.MaxNumberOfPages > countPages)))
            {
                var data = await GetFinancialEventsByNextTokenAsync(nextToken, cancellationToken);
                list.Add(data.FinancialEvents);
                nextToken = data.NextToken;
                countPages++;
            }

            return list;
        }

        private ListFinancialEventsPayload GetFinancialEventsByNextToken(string nextToken) =>
            Task.Run(() => GetFinancialEventsByNextTokenAsync(nextToken)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListFinancialEventsPayload> GetFinancialEventsByNextTokenAsync(string nextToken, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents, cancellationToken);
            return response.Payload;
        }


    }
}
