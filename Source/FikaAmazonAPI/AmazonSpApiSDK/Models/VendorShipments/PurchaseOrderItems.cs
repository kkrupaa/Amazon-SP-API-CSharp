using FikaAmazonAPI.AmazonSpApiSDK.Models.Sales;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	public class PurchaseOrderItems
	{
		public PurchaseOrderItems() { }

		[DataMember(Name = "itemSequenceNumber", EmitDefaultValue = false)]
		public string ItemSequenceNumber { get; set; }

		[DataMember(Name = "buyerProductIdentifier", EmitDefaultValue = false)]
		public string BuyerProductIdentifier { get; set; }

		[DataMember(Name = "vendorProductIdentifier", EmitDefaultValue = false)]
		public string VendorProductIdentifier { get; set; }

		[DataMember(Name = "shippedQuantity", EmitDefaultValue = false)]
		public ItemQuantity ShippedQuantity { get; set; }

		[DataMember(Name = "maximumRetailPrice", EmitDefaultValue = false)]
		public Money MaximumRetailPrice { get; set; }
	}
}
