﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// For partial shipment status updates, the list of order items and quantities to be updated.
    /// </summary>
    [DataContract]
    public partial class OrderItems : List<OrderItemsInner>, IEquatable<OrderItems>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItems" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public OrderItems() : base()
        {
        }

        //Int64 _value;
        //public UnsignedIntType(Int64 value)
        //{
        //    this._value = value;
        //}
        //public static implicit operator Int64(UnsignedIntType d)
        //{
        //    return d._value;
        //}
        //public static implicit operator UnsignedIntType(Int64 d)
        //{
        //    return new UnsignedIntType(d);
        //}

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItems {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return this.Equals(input as OrderItems);
        }

        /// <summary>
        /// Returns true if OrderItems instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItems to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItems input)
        {
            if (input == null)
                return false;

            return base.Equals(input);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
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
