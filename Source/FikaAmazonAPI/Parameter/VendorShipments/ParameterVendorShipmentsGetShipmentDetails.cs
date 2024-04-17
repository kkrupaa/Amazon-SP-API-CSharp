using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders.Constants;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.VendorShipments
{
	public class ParameterVendorShipmentsGetShipmentDetails : ParameterBased
	{
			public long? limit { get; set; }
			public DateTime? createdAfter { get; set; }
			public DateTime? createdBefore { get; set; }
			public SortOrderEnum? sortOrder { get; set; }
			public string nextToken { get; set; }
			public DateTime? shipmentConfirmedBefore { get; set; }
			public DateTime? shipmentConfirmedAfter { get; set; }
			public DateTime? packageLabelCreatedBefore { get; set; }
			public DateTime? packageLabelCreatedAfter { get; set; }
			public DateTime? shippedBefore { get; set; }
			public DateTime? shippedAfter { get; set; }
			public DateTime? estimatedDeliveryBefore { get; set; }
			public DateTime? estimatedDeliveryAfter { get; set; }
			public DateTime? shipmentDeliveryBefore { get; set; }
			public DateTime? shipmentDeliveryAfter { get; set; }
			public DateTime? requestedPickUpBefore { get; set; }
			public DateTime? requestedPickUpAfter { get; set; }
			public DateTime? scheduledPickUpBefore { get; set; }
			public DateTime? scheduledPickUpAfter { get; set; }
			public string currentShipmentStatus { get; set; }
			public string vendorShipmentIdentifier { get; set; }
			public string buyerReferenceNumber { get; set; }
			public string buyerWarehouseCode { get; set; }
			public string sellerWarehouseCode { get;}


	}
}
