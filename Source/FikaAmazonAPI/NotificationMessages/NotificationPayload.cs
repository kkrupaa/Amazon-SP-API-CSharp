﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public class NotificationPayload
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("AnyOfferChangedNotification")]
        public AnyOfferChangedNotification AnyOfferChangedNotification { get; set; }

        [JsonProperty("b2bAnyOfferChangedNotification")]
        public B2BAnyOfferChangedNotification B2BAnyOfferChangedNotification { get; set; }
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public FeePromotionNotification FeePromotionNotification { get; set; }

        public FbaOutboundShipmentStatusNotification FbaOutboundShipmentStatusNotification { get; set; }
        public FulfillmentOrderStatusNotification FulfillmentOrderStatusNotification { get; set; }


        [JsonProperty("reportProcessingFinishedNotification")]
        public ReportProcessingFinishedNotification ReportProcessingFinishedNotification { get; set; }
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string Asin { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public List<object> AttributesChanged { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string MarketplaceId { get; set; }
        public string PreviousProductType { get; set; }
        public string CurrentProductType { get; set; }
    }
}
