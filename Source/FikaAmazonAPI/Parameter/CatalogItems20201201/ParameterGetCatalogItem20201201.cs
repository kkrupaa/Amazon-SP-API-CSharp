using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FikaAmazonAPI.Parameter.CatalogItems20201201
{
    public class ParameterGetCatalogItem20201201 : ParameterBased
    {
        public bool Check()
        {
            if (marketplaceIds == null || !marketplaceIds.Any())
            {
                throw new InvalidDataException("MarketplaceIds is a required property for ParameterGetCatalogItem20201201 and cannot be null");
            }
            if (includedData is null)
            {
                includedData = new List<Constants.IncludedData>();
                includedData.Add(Constants.IncludedData.summaries);
            }
            if (includedData.Count == 0)
                includedData.Add(Constants.IncludedData.summaries);

            return true;
        }

        /// <summary>
        /// A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces. Max count : 50
        /// </summary>
        public IList<string> marketplaceIds { get; set; }

        /// <summary>
        /// A comma-delimited list of data sets to include in the response. Default: summaries.
        /// </summary>
        public IList<Constants.IncludedData> includedData { get; set; }
    }
}
