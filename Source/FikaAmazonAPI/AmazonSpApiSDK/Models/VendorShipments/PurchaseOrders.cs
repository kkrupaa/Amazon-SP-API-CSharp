using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	public class PurchaseOrders
	{
		public PurchaseOrders() { }

		[DataMember(Name = "purchaseOrderNumber", EmitDefaultValue = false)]
		public string PurchaseOrderNumber { get; set; }

		[DataMember(Name = "purchaseOrderDate", EmitDefaultValue = false)]
		public DateTime? PurchaseOrderDate { get; set; }

		[DataMember(Name = "shipWindow", EmitDefaultValue = false)]
		public string ShipWindow { get; set; }

		[DataMember(Name = "items", EmitDefaultValue = false)]
		public List<PurchaseOrderItems> Items { get; set; }
	}
}
