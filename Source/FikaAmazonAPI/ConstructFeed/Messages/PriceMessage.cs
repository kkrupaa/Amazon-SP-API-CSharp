using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class PriceMessage
    {
        public string SKU { get; set; }
        public StandardPrice StandardPrice { get; set; }
        public decimal? BusinessPrice { get; set; }
        public QuantityPriceTypes? QuantityPriceType { get; set; }
        [XmlIgnore]
        public bool QuantityPriceTypeSpecified { get { return this.QuantityPriceType != null; } }
        public QuantityPrice QuantityPrice { get; set; }
        public StandardPrice MinimumSellerAllowedPrice { get; set; }
        public StandardPrice MaximumSellerAllowedPrice { get; set; }
        public StandardPrice MAP { get; set; }
        public StandardPrice DepositAmount { get; set; }
        public Sale Sale { get; set; }
    }

    public enum QuantityPriceTypes
    {
        [XmlEnum(Name = "fixed")]
        Fixed,
        [XmlEnum(Name = "percent")]
        Percent
    }
}
