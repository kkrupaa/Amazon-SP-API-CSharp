﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.Sellers;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class SellerService : RequestService
    {
        public SellerService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, loggerFactory, rateLimitingHandler)
        {

        }



        public List<MarketplaceParticipation> GetMarketplaceParticipations() =>
                Task.Run(() => GetMarketplaceParticipationsAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<MarketplaceParticipation>> GetMarketplaceParticipationsAsync(CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(SellersApiUrls.GetMarketplaceParticipations, RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetMarketplaceParticipationsResponse>(RateLimitType.Sellers_GetMarketplaceParticipations, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
