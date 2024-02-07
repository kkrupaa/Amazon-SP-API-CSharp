using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class QuantityPrice
    {
        public decimal? QuantityPrice1 { get; set; }
        public int? QuantityLowerBound1 { get; set; }
        public decimal? QuantityPrice2 { get; set; }
        public int? QuantityLowerBound2 { get; set; }
        public decimal? QuantityPrice3 { get; set; }
        public int? QuantityLowerBound3 { get; set; }
        public decimal? QuantityPrice4 { get; set; }
        public int? QuantityLowerBound4 { get; set; }
        public decimal? QuantityPrice5 { get; set; }
        public int? QuantityLowerBound5 { get; set; }
        public bool ShouldSerializeQuantityPrice1()
        {
            return QuantityPrice1.HasValue;
        }
        public bool ShouldSerializeQuantityLowerBound1()
        {
            return QuantityLowerBound1.HasValue;
        }
        public bool ShouldSerializeQuantityPrice2()
        {
            return QuantityPrice2.HasValue;
        }
        public bool ShouldSerializeQuantityLowerBound2()
        {
            return QuantityLowerBound2.HasValue;
        }
        public bool ShouldSerializeQuantityPrice3()
        {
            return QuantityPrice3.HasValue;
        }
        public bool ShouldSerializeQuantityLowerBound3()
        {
            return QuantityLowerBound3.HasValue;
        }
        public bool ShouldSerializeQuantityPrice4()
        {
            return QuantityPrice4.HasValue;
        }
        public bool ShouldSerializeQuantityLowerBound4()
        {
            return QuantityLowerBound4.HasValue;
        }
        public bool ShouldSerializeQuantityPrice5()
        {
            return QuantityPrice5.HasValue;
        }
        public bool ShouldSerializeQuantityLowerBound5()
        {
            return QuantityLowerBound5.HasValue;
        }
    }
   
}
