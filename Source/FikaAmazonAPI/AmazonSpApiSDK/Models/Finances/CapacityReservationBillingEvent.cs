/* 
 * Selling Partner API for Finances
 *
 * The Selling Partner API for Finances helps you obtain financial information relevant to a seller's business. You can obtain financial events for a given order, financial event group, or date range without having to wait until a statement period closes. You can also obtain financial event groups for a given date range.
 *
 * OpenAPI spec version: v0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Finances
{
    /// <summary>
    /// An event related to a capacity reservation billing charge.
    /// </summary>
    [DataContract]
    public partial class CapacityReservationBillingEvent : IEquatable<CapacityReservationBillingEvent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapacityReservationBillingEvent" /> class.
        /// </summary>
        /// <param name="transactionType">Indicates the type of transaction. For example, FBA Inventory Fee.</param>
        /// <param name="postedDate">The date and time when the financial event was posted..</param>
        /// <param name="description">A short description of the capacity reservation billing event..</param>
        /// <param name="transactionAmount">The amount of the capacity reservation billing event..</param>
        public CapacityReservationBillingEvent(string transactionType = default(string), DateTime? postedDate = default(DateTime?), string description = default(string), Currency transactionAmount = default(Currency))
        {
            this.TransactionType = transactionType;
            this.PostedDate = postedDate;
            this.Description = description;
            this.TransactionAmount = transactionAmount;
        }

        /// <summary>
        /// Indicates the type of transaction. For example, FBA Inventory Fee
        /// </summary>
        /// <value>Indicates the type of transaction. For example, FBA Inventory Fee</value>
        [DataMember(Name = "TransactionType", EmitDefaultValue = false)]
        public string TransactionType { get; set; }

        /// <summary>
        /// The date and time when the financial event was posted.
        /// </summary>
        /// <value>The date and time when the financial event was posted.</value>
        [DataMember(Name = "PostedDate", EmitDefaultValue = false)]
        public DateTime? PostedDate { get; set; }

        /// <summary>
        /// A short description of the capacity reservation billing event.
        /// </summary>
        /// <value>A short description of the capacity reservation billing event.</value>
        [DataMember(Name = "Description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The amount of the capacity reservation billing event.
        /// </summary>
        /// <value>The amount of the capacity reservation billing event.</value>
        [DataMember(Name = "TransactionAmount", EmitDefaultValue = false)]
        public Currency TransactionAmount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CapacityReservationBillingEvent {\n");
            sb.Append("  TransactionType: ").Append(TransactionType).Append("\n");
            sb.Append("  PostedDate: ").Append(PostedDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TransactionAmount: ").Append(TransactionAmount).Append("\n");
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
            return this.Equals(input as CapacityReservationBillingEvent);
        }

        /// <summary>
        /// Returns true if CapacityReservationBillingEvent instances are equal
        /// </summary>
        /// <param name="input">Instance of CapacityReservationBillingEvent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CapacityReservationBillingEvent input)
        {
            if (input == null)
                return false;

            return
                (
                    this.TransactionType == input.TransactionType ||
                    (this.TransactionType != null &&
                    this.TransactionType.Equals(input.TransactionType))
                ) &&
                (
                    this.PostedDate == input.PostedDate ||
                    (this.PostedDate != null &&
                    this.PostedDate.Equals(input.PostedDate))
                ) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) &&
                (
                    this.TransactionAmount == input.TransactionAmount ||
                    (this.TransactionAmount != null &&
                    this.TransactionAmount.Equals(input.TransactionAmount))
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
                if (this.TransactionType != null)
                    hashCode = hashCode * 59 + this.TransactionType.GetHashCode();
                if (this.PostedDate != null)
                    hashCode = hashCode * 59 + this.PostedDate.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.TransactionAmount != null)
                    hashCode = hashCode * 59 + this.TransactionAmount.GetHashCode();
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