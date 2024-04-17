using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	public class ShipmentStatusDetails
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum ShipmentStatusEnum
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

		[DataMember(Name = "shipmentStatus", EmitDefaultValue = false)]
		public ShipmentStatusEnum? ShipmentStatus { get; set; }

		[DataMember(Name = "shipmentStatusDate", EmitDefaultValue = false)]
		public DateTime? ShipmentStatusDate { get; set; }
	}
}
