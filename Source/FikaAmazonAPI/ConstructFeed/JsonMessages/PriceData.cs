using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed.JsonMessages
{
    public class PriceData
    {
        public IList<SchedulePriceData> schedule { get; set; }
    }
    public class SchedulePriceData
    {
        public decimal value_with_tax { get; set; }
        public string start_at { get; set; }
        public string end_at { get; set; }
        public string discount_type { get; set; }
        public IList<ShedulePriceLevel> levels { get; set; }
    }

    public class ShedulePriceLevel
    {
        public int? lower_bound { get; set; }
        public decimal? value { get; set; } 
    }
}
