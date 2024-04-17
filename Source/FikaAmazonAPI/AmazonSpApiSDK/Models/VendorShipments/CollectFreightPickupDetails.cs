using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	[DataContract]
	public class CollectFreightPickupDetails
	{
		[JsonConstructorAttribute]
		public CollectFreightPickupDetails() { }


		[DataMember(Name = "requestedPickUp", EmitDefaultValue = false)]
		public DateTime? RequestedPickUp { get; set; }

		[DataMember(Name = "scheduledPickUp", EmitDefaultValue = false)]
		public DateTime? ScheduledPickUp { get; set; }

		[DataMember(Name = "carrierAssignmentDate", EmitDefaultValue = false)]
		public DateTime? CarrierAssignmentDate { get; set; }
	}
}
