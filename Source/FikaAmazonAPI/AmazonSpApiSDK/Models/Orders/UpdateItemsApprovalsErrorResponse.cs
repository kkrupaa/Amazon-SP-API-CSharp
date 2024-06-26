﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// The error response schema for the updateOrderItemsApprovals operation.
    /// </summary>
    [DataContract]
    public partial class UpdateItemsApprovalsErrorResponse : IEquatable<UpdateItemsApprovalsErrorResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemsApprovalsErrorResponse" /> class.
        /// </summary>
        /// <param name="errors">One or more unexpected errors occurred during the updateOrderItemsApprovals operation..</param>
        public UpdateItemsApprovalsErrorResponse(ErrorList errors = default(ErrorList))
        {
            this.Errors = errors;
        }
        public UpdateItemsApprovalsErrorResponse()
        {
        }

        /// <summary>
        /// One or more unexpected errors occurred during the updateOrderItemsApprovals operation.
        /// </summary>
        /// <value>One or more unexpected errors occurred during the updateOrderItemsApprovals operation.</value>
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        public ErrorList Errors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateItemsApprovalsErrorResponse {\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
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
            return this.Equals(input as UpdateItemsApprovalsErrorResponse);
        }

        /// <summary>
        /// Returns true if UpdateItemsApprovalsErrorResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateItemsApprovalsErrorResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateItemsApprovalsErrorResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Errors == input.Errors ||
                    (this.Errors != null &&
                    this.Errors.Equals(input.Errors))
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
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
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
