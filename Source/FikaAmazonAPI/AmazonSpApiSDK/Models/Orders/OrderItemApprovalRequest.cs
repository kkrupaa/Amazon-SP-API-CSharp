﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// Order item apecific approval request.
    /// </summary>
    [DataContract]
    public partial class OrderItemApprovalRequest : IEquatable<OrderItemApprovalRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemApprovalRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public OrderItemApprovalRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemApprovalRequest" /> class.
        /// </summary>
        /// <param name="orderItemId">The unique identifier of the order item. (required).</param>
        /// <param name="approvalAction">Approval action that defines the behavior of the ItemApproval. (required).</param>
        public OrderItemApprovalRequest(string orderItemId = default(string), ItemApprovalAction approvalAction = default(ItemApprovalAction))
        {
            // to ensure "orderItemId" is required (not null)
            if (orderItemId == null)
            {
                throw new InvalidDataException("orderItemId is a required property for OrderItemApprovalRequest and cannot be null");
            }
            else
            {
                this.OrderItemId = orderItemId;
            }
            // to ensure "approvalAction" is required (not null)
            if (approvalAction == null)
            {
                throw new InvalidDataException("approvalAction is a required property for OrderItemApprovalRequest and cannot be null");
            }
            else
            {
                this.ApprovalAction = approvalAction;
            }
        }

        /// <summary>
        /// The unique identifier of the order item.
        /// </summary>
        /// <value>The unique identifier of the order item.</value>
        [DataMember(Name = "OrderItemId", EmitDefaultValue = false)]
        public string OrderItemId { get; set; }

        /// <summary>
        /// Approval action that defines the behavior of the ItemApproval.
        /// </summary>
        /// <value>Approval action that defines the behavior of the ItemApproval.</value>
        [DataMember(Name = "ApprovalAction", EmitDefaultValue = false)]
        public ItemApprovalAction ApprovalAction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemApprovalRequest {\n");
            sb.Append("  OrderItemId: ").Append(OrderItemId).Append("\n");
            sb.Append("  ApprovalAction: ").Append(ApprovalAction).Append("\n");
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
            return this.Equals(input as OrderItemApprovalRequest);
        }

        /// <summary>
        /// Returns true if OrderItemApprovalRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemApprovalRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemApprovalRequest input)
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
                    this.ApprovalAction == input.ApprovalAction ||
                    (this.ApprovalAction != null &&
                    this.ApprovalAction.Equals(input.ApprovalAction))
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
                if (this.ApprovalAction != null)
                    hashCode = hashCode * 59 + this.ApprovalAction.GetHashCode();
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