using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterPatchListingItem : ParameterBased
    {
        public bool Check()
        {
            if (TestCase == Constants.TestCase400)
                sku = "BadSKU";
            if (string.IsNullOrWhiteSpace(this.sellerId))
            {
                throw new InvalidDataException("SellerId is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.sku))
            {
                throw new InvalidDataException("Sku is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (this.marketplaceIds == null || !this.marketplaceIds.Any())
            {
                marketplaceIds = new List<string>();
                throw new InvalidDataException("MarketplaceIds is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (this.listingsItemPatchRequest == null)
            {
                throw new InvalidDataException("ListingsItemPutRequest is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.listingsItemPatchRequest.productType)) 
            {
                throw new InvalidDataException("ListingsItemPutRequest is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (this.listingsItemPatchRequest.patches==null|| !this.listingsItemPatchRequest.patches.Any())
            {
                throw new InvalidDataException("Patches is a required property for ParameterPatchListingItem and cannot be null");
            }
            return true;    
        }

        [IgnoreToAddParameter]
        public string sellerId { get; set; }

        [IgnoreToAddParameter]
        public string sku { get; set; }

        public IList<string> marketplaceIds { get; set; }

        public string issueLocale { get; set; }

        [IgnoreToAddParameter]
        public ListingsItemPatchRequest  listingsItemPatchRequest { get; set; }

    }

    public class ListingsItemPatchRequest
    {
        public ListingsItemPatchRequest()
        {
            patches = new List<PatchOperation>();
        }
        
        public string productType { get; set; }

        public IList<PatchOperation> patches { get; set; }
    }

    public class PatchOperation
    {
        public PatchOperation()
        {
            value = new List<object>();
        }

        public Op op { get; set; }

        public string path { get; set; }

        public IList<object> value { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    [DataContract]
    public enum Op
    {
        [EnumMember(Value = "add")]
        add,
        [EnumMember(Value = "replace")]
        replace,
        [EnumMember(Value = "delete")]
        delete
    }
}
