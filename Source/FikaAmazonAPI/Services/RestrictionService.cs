﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.Restrictions;
using FikaAmazonAPI.Parameter.Restrictions;
using FikaAmazonAPI.Utils;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class RestrictionService : RequestService
    {
        public RestrictionService(AmazonCredential amazonCredential,ILoggerFactory? loggerFactory, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, loggerFactory, rateLimitingHandler)
        {

        }


        public RestrictionList GetListingsRestrictions(ParameterGetListingsRestrictions parameter) =>
            Task.Run(() => GetListingsRestrictionsAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<RestrictionList> GetListingsRestrictionsAsync(ParameterGetListingsRestrictions parameter, CancellationToken cancellationToken = default)
        {
            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
            {
                parameter.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }
            var param = parameter.getParameters();
            await CreateAuthorizedRequestAsync(RestrictionsApiUrls.GetListingsRestrictions, RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<RestrictionList>(Utils.RateLimitType.Restrictions_GetListingsRestrictions, cancellationToken);
        }
    }
}
