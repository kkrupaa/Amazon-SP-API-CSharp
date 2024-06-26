﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// OrderItemsInner
    /// </summary>
    [DataContract]
    public partial class OrderItemsInner : IEquatable<OrderItemsInner>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemsInner" /> class.
        /// </summary>
        /// <param name="orderItemId">The unique identifier of the order item..</param>
        /// <param name="quantity">The quantity for which to update the shipment status..</param>
        public OrderItemsInner(string orderItemId = default(string), int? quantity = default(int?))
        {
            this.OrderItemId = orderItemId;
            this.Quantity = quantity;
        }
        public OrderItemsInner()
        {
        }
        /// <summary>
        /// The unique identifier of the order item.
        /// </summary>
        /// <value>The unique identifier of the order item.</value>
        [DataMember(Name = "orderItemId", EmitDefaultValue = false)]
        public string OrderItemId { get; set; }

        /// <summary>
        /// The quantity for which to update the shipment status.
        /// </summary>
        /// <value>The quantity for which to update the shipment status.</value>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemsInner {\n");
            sb.Append("  OrderItemId: ").Append(OrderItemId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
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
            return this.Equals(input as OrderItemsInner);
        }

        /// <summary>
        /// Returns true if OrderItemsInner instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemsInner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemsInner input)
        {
            if (input == null)
                return false;

            return
                (
                    this.OrderItemId == input.OrderItemId ||
                    (this.OrderItemId != null &&
                    this.OrderItemId.Equals(input.OrderItemId))
                ) &&
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
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
                if (this.OrderItemId != null)
                    hashCode = hashCode * 59 + this.OrderItemId.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
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