using Amazon.SecurityToken.Model;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Shipping;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	[DataContract]
	public partial class Shipment
	{
		[JsonConstructorAttribute]
		public Shipment() { }

		[JsonConverter(typeof(StringEnumConverter))]
		public enum TransactionTypeEnum
		{
			[EnumMember(Value = "New")]
			New,

			[EnumMember(Value = "Cancel")]
			Cancel,

		}

		[JsonConverter(typeof(StringEnumConverter))]
		public enum CurrentShipmentStatusEnum
		{
			[EnumMember(Value = "Created")]
			Created,

			[EnumMember(Value = "TransportationRequested")]
			TransportationRequested,

			[EnumMember(Value = "CarrierAssigned")]
			CarrierAssigned,

			[EnumMember(Value = "Shipped")]
			Shipped,
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public enum ShipmentFreightTermEnum
		{
			[EnumMember(Value = "Collect")]
			Collect,

			[EnumMember(Value = "Prepaid")]
			Prepaid,
		}

		[DataMember(Name = "vendorShipmentIdentifier", EmitDefaultValue = false)]
		public string VendorShipmentIdentifier { get; set; }

		[DataMember(Name = "transactionType", EmitDefaultValue = false)]
		public TransactionTypeEnum? TransactionType { get; set; }

		[DataMember(Name = "buyerReferenceNumber", EmitDefaultValue = false)]
		public string BuyerReferenceNumber { get; set; }

		[DataMember(Name = "transactionDate", EmitDefaultValue = false)]
		public DateTime? TransactionDate { get; set; }

		[DataMember(Name = "currentshipmentStatusDate", EmitDefaultValue = false)]
		public DateTime? CurrentshipmentStatusDate { get; set; }

		[DataMember(Name = "currentShipmentStatus", EmitDefaultValue = false)]
		public CurrentShipmentStatusEnum? CurrentShipmentStatus { get; set; }

		[DataMember(Name = "shipmentStatusDetails", EmitDefaultValue = false)]
		public List<ShipmentStatusDetails> ShipmentStatusDetails {get; set;}

		[DataMember(Name = "shipmentCreateDate", EmitDefaultValue = false)]
		public DateTime? ShipmentCreateDate { get; set; }

		[DataMember(Name = "shipmentConfirmDate", EmitDefaultValue = false)]
		public DateTime? ShipmentConfirmDate { get; set; }

		[DataMember(Name = "packageLabelCreateDate", EmitDefaultValue = false)]
		public DateTime? PackageLabelCreateDate { get; set; }

		[DataMember(Name = "shipmentFreightTerm", EmitDefaultValue = false)]
		public ShipmentFreightTermEnum? ShipmentFreightTerm { get; set; }

		[DataMember(Name = "sellingParty", EmitDefaultValue = false)]
		public PartyIdentification SellingParty { get; set; }

		[DataMember(Name = "shipFromParty", EmitDefaultValue = false)]
		public PartyIdentification ShipFromParty { get; set; }

		[DataMember(Name = "shipToParty", EmitDefaultValue = false)]
		public PartyIdentification ShipToParty { get; set; }

		[DataMember(Name = "collectFreightPickupDetails", EmitDefaultValue = false)]
		public CollectFreightPickupDetails CollectFreightPickupDetails { get; set; }

		[DataMember(Name = "purchaseOrders", EmitDefaultValue = false)]
		public List<PurchaseOrders> PurchaseOrders { get; set; } 

		[DataMember(Name = "transportationDetails", EmitDefaultValue = false)]
		public TransportationDetails TransportationDetails {get; set;}
	}
}
