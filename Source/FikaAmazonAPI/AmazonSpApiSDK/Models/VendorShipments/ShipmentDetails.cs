using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments
{
	[DataContract]
	public partial class ShipmentDetails: IEquatable<ShipmentDetails>, IValidatableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ShipmentDetails" /> class.
		/// </summary>
		/// <param name="pagination">pagination.</param>
		/// <param name="shipments">orders.</param>
		public ShipmentDetails(Pagination pagination = default(Pagination), List<Shipment> shipments = default(List<Shipment>))
		{
			this.Pagination = pagination;
			this.Shipments = shipments;
		}

		/// <summary>
		/// Gets or Sets Pagination
		/// </summary>
		[DataMember(Name = "pagination", EmitDefaultValue = false)]
		public Pagination Pagination { get; set; }

		/// <summary>
		/// Gets or Sets Orders
		/// </summary>
		[DataMember(Name = "shipments", EmitDefaultValue = false)]
		public List<Shipment> Shipments { get; set; }

		/// <summary>
		/// Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("class ShipmentDetails {\n");
			sb.Append("  Pagination: ").Append(Pagination).Append("\n");
			sb.Append("  Shipments: ").Append(Shipments).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}

		/// <summary>
		/// Returns the JSON string presentation of the object
		/// </summary>
		/// <returns>JSON string presentation of the object</returns>
		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}

		/// <summary>
		/// Returns true if objects are equal
		/// </summary>
		/// <param name="input">Object to be compared</param>
		/// <returns>Boolean</returns>
		public override bool Equals(object input)
		{
			return this.Equals(input as ShipmentDetails);
		}

		/// <summary>
		/// Returns true if OrderList instances are equal
		/// </summary>
		/// <param name="input">Instance of OrderList to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(ShipmentDetails input)
		{
			if (input == null)
				return false;

			return
				(
					this.Pagination == input.Pagination ||
					(this.Pagination != null &&
					this.Pagination.Equals(input.Pagination))
				) &&
				(
					this.Shipments == input.Shipments ||
					this.Shipments != null &&
					this.Shipments.SequenceEqual(input.Shipments)
				);
		}

		/// <summary>
		/// Gets the hash code
		/// </summary>
		/// <returns>Hash code</returns>
		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				int hashCode = 41;
				if (this.Pagination != null)
					hashCode = hashCode * 59 + this.Pagination.GetHashCode();
				if (this.Shipments != null)
					hashCode = hashCode * 59 + this.Shipments.GetHashCode();
				return hashCode;
			}
		}

		/// <summary>
		/// To validate all properties of the instance
		/// </summary>
		/// <param name="validationContext">Validation context</param>
		/// <returns>Validation Result</returns>
		IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
		{
			yield break;
		}
	}
}
