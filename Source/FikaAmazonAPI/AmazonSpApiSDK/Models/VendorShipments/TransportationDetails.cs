using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	[DataContract]
	public class TransportationDetails
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum ShipModeEnum
		{
			[EnumMember(Value = "TruckLoad")]
			TruckLoad,

			[EnumMember(Value = "LessThanTruckLoad")]
			LessThanTruckLoad,

			[EnumMember(Value = "SmallParcel")]
			SmallParcel,
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public enum TransportationModeEnum
		{
			[EnumMember(Value = "Road")]
			Road,

			[EnumMember(Value = "Air")]
			Air,

			[EnumMember(Value = "Ocean")]
			Ocean,
		}


		[DataMember(Name = "shipMode", EmitDefaultValue = false)]
		public ShipModeEnum? ShipMode { get; set; }

		[DataMember(Name = "transportationMode", EmitDefaultValue = false)]
		public TransportationModeEnum? TransportationMode { get; set; }

		[DataMember(Name = "shippedDate", EmitDefaultValue = false)]
		public DateTime? ShippedDate { get; set; }

		[DataMember(Name = "estimatedDeliveryDate", EmitDefaultValue = false)]
		public DateTime? EstimatedDeliveryDate { get; set; }

		[DataMember(Name = "shipmentDeliveryDate", EmitDefaultValue = false)]
		public DateTime? ShipmentDeliveryDate { get; set; }

		[DataMember(Name = "carrierDetails", EmitDefaultValue = false)]
		public CarrierDetails CarrierDetails { get; set; }

		[DataMember(Name = "billOfLadingNumber", EmitDefaultValue = false)]
		public string BillOfLadingNumber { get; set; }
	}
}
