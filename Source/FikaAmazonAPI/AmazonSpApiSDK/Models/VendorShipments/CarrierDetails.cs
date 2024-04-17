using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	[DataContract]
	public class CarrierDetails
	{
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; set; }

		[DataMember(Name = "code", EmitDefaultValue = false)]
		public string Code { get; set; }

		[DataMember(Name = "phone", EmitDefaultValue = false)]
		public string Phone { get; set; }

		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string Email { get; set; }

		[DataMember(Name = "shipmentReferenceNumber", EmitDefaultValue = false)]
		public string ShipmentReferenceNumber { get; set; }

			
	}
}
