using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FikaAmazonAPI.Parameter.CatalogItems20201201
{
    public class ParameterSearchCatalogItems : ParameterBased
    {
        public bool Check()
        {
            if (keywords == null || !keywords.Any())
            {
                throw new InvalidDataException("Keywords is a required property for ParameterSearchCatalogItems and cannot be null");
            }
            if (marketplaceIds == null || !marketplaceIds.Any())
            {
                throw new InvalidDataException("MarketplaceIds is a required property for ParameterSearchCatalogItems and cannot be null");
            }
            if (includedData is null)
            {
                includedData = new List<Constants.IncludedData>();
            }
            if (includedData.Count == 0)
            {
                includedData.Add(Constants.IncludedData.summaries);
            }
            if (pageSize == null)
            {
                pageSize = 10;
            }

            return true;
        }

        /// <summary>
        /// A comma-delimited list of words or item identifiers to search the Amazon catalog for.
        /// </summary>
        public IList<string> keywords { get; set; }

        /// <summary>
        /// A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces. Max count : 50
        /// </summary>
        public IList<string> marketplaceIds { get; set; }

        /// <summary>
        /// A comma-delimited list of data sets to include in the response. Default: summaries.
        /// </summary>
        public IList<Constants.IncludedData> includedData { get; set; }

        /// <summary>
        /// A comma-delimited list of brand names to limit the search to.
        /// </summary>
        public IList<string> brandNames { get; set; }

        /// <summary>
        /// A comma-delimited list of classification identifiers to limit the search to.
        /// </summary>
        public IList<string> classificationIds { get; set; }

        /// <summary>
        /// Number of results to be returned per page.
        /// Maximum : 20
        /// </summary>
        public int? pageSize { get; set; }

        /// <summary>
        /// A token to fetch a certain page when there are multiple pages worth of results.
        /// </summary>
        public string pageToken { get; set; }

        /// <summary>
        /// The language the keywords are provided in. Defaults to the primary locale of the marketplace.
        /// </summary>
        public string keywordsLocale { get; set; }

        /// <summary>
        /// Locale for retrieving localized summaries. Defaults to the primary locale of the marketplace.
        /// </summary>
        public string locale { get; set; }
    }
}
