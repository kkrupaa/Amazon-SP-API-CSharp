using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using static FikaAmazonAPI.AmazonSpApiSDK.Services.ApiUrls;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ProductPricing
{
    public class ItemOffersRequest
    {
        /// <summary>
        /// The full URI corresponding to the API intended for request, including path parameter substitutions.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri
        {
            get
            {
                return ProductPricingApiUrls.GetItemOffers(this.QueryParams.Asin);
            }
        }

        /// <summary>
        /// The HTTP method associated with the individual APIs being called as part of the batch request.
        /// </summary>
        [JsonProperty("method")]
        public HttpMethodEnum HttpMethod { get; set; }

        //[JsonProperty("headers")]
        //public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Input holder for the per-request parameters. NOT serialized as a "queryParams" object — Amazon's
        /// getItemOffersBatch expects MarketplaceId / ItemCondition / CustomerType as TOP-LEVEL fields on each
        /// request (a "queryParams" wrapper is ignored, which made the API report the marketplace as missing).
        /// The three properties below project those values to the top level.
        /// </summary>
        [JsonIgnore]
        public ParameterGetItemOffers QueryParams { get; set; }

        /// <summary>
        /// A marketplace identifier. Specifies the marketplace for which prices are returned.
        /// </summary>
        [JsonProperty("MarketplaceId")]
        public string MarketplaceId => QueryParams?.MarketplaceId;

        [JsonProperty("ItemCondition")]
        public ItemCondition ItemCondition => QueryParams != null ? QueryParams.ItemCondition : default;

        [JsonProperty("CustomerType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerType? CustomerType => QueryParams?.CustomerType;
    }
}
