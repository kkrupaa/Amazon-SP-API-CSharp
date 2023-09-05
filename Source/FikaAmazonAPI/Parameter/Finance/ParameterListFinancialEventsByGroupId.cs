﻿using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.Finance
{
    public class ParameterListFinancialEventsByGroupId : ParameterBased
    {
        public string GroupId { get; set; }
        public int? MaxResultsPerPage { get; set; } = 100;
        public DateTime? PostedAfter { get; set; }
        public DateTime? PostedBefore { get; set; }
        public string NextToken { get; set; }
    }
}
