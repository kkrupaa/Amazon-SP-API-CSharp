using System;
using System.Collections.Generic;
using System.Text;
using FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems20201201;
using FikaAmazonAPI.AmazonSpApiSDK.Api.CatalogItems20201201;
using System.IO;
using System.Threading.Tasks;
using FikaAmazonAPI.Utils;
using FikaAmazonAPI.Parameter.CatalogItems20201201;

namespace FikaAmazonAPI.Services
{
    public class CatalogItem20201201Service : RequestService
    {
        public CatalogItem20201201Service(AmazonCredential amazonCredential) : base(amazonCredential)
        {
        }

        public async Task<Item> GetCatalogItem(string asin, ParameterGetCatalogItem20201201 getCatalogItemParameters)
        {
            getCatalogItemParameters.Check();
            var queryParameters = getCatalogItemParameters.getParameters();
            await CreateAuthorizedRequestAsync(CategoryApiUrls.GetCatalogItem202012(asin), RestSharp.Method.GET, queryParameters: queryParameters);
            var response = await ExecuteRequestAsync<Item>(RateLimitType.CatalogItems20201201_GetCatalogItem);
            if (response != null)
                return response;

            return null;
        }

        public async Task<ItemSearchResults> SearchCatalogItems(ParameterSearchCatalogItems searchCatalogItemsParameters)
        {
            if (searchCatalogItemsParameters.marketplaceIds == null)
            {
                searchCatalogItemsParameters.marketplaceIds = new List<string>();
            }

            if (searchCatalogItemsParameters.marketplaceIds.Count == 0)
            {
                searchCatalogItemsParameters.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }

            searchCatalogItemsParameters.Check();
            var queryParameters = searchCatalogItemsParameters.getParameters();
            await CreateAuthorizedRequestAsync(CategoryApiUrls.SearchCatalogItems, RestSharp.Method.GET, queryParameters: queryParameters);
            var response = await ExecuteRequestAsync<ItemSearchResults>(RateLimitType.CatalogItems20201201_SearchCatalogItems);
            if (response != null)
                return response;

            return null;
        }
    }
}
