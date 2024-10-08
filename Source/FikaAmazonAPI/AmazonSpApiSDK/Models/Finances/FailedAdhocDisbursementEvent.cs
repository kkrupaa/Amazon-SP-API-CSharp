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
    /// Failed ad hoc disbursement event list.
    /// </summary>
    [DataContract]
    public partial class FailedAdhocDisbursementEvent : IEquatable<FailedAdhocDisbursementEvent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedAdhocDisbursementEvent" /> class.
        /// </summary>
        /// <param name="fundsTransfersType">The type of fund transfer.   Example \&quot;Refund\&quot;.</param>
        /// <param name="transferId">The transfer identifier..</param>
        /// <param name="disbursementId">The disbursement identifier..</param>
        /// <param name="paymentDisbursementType">The type of payment for disbursement.   Example &#x60;CREDIT_CARD&#x60;.</param>
        /// <param name="status">The status of the failed &#x60;AdhocDisbursement&#x60;.   Example &#x60;HARD_DECLINED&#x60;.</param>
        /// <param name="transferAmount">The amount of the Adhoc Disbursement..</param>
        /// <param name="postedDate">The date and time when the financial event was posted..</param>
        public FailedAdhocDisbursementEvent(string fundsTransfersType = default(string), string transferId = default(string), string disbursementId = default(string), string paymentDisbursementType = default(string), string status = default(string), Currency transferAmount = default(Currency), DateTime? postedDate = default(DateTime?))
        {
            this.FundsTransfersType = fundsTransfersType;
            this.TransferId = transferId;
            this.DisbursementId = disbursementId;
            this.PaymentDisbursementType = paymentDisbursementType;
            this.Status = status;
            this.TransferAmount = transferAmount;
            this.PostedDate = postedDate;
        }

        /// <summary>
        /// The type of fund transfer.   Example \&quot;Refund\&quot;
        /// </summary>
        /// <value>The type of fund transfer.   Example \&quot;Refund\&quot;</value>
        [DataMember(Name = "FundsTransfersType", EmitDefaultValue = false)]
        public string FundsTransfersType { get; set; }

        /// <summary>
        /// The transfer identifier.
        /// </summary>
        /// <value>The transfer identifier.</value>
        [DataMember(Name = "TransferId", EmitDefaultValue = false)]
        public string TransferId { get; set; }

        /// <summary>
        /// The disbursement identifier.
        /// </summary>
        /// <value>The disbursement identifier.</value>
        [DataMember(Name = "DisbursementId", EmitDefaultValue = false)]
        public string DisbursementId { get; set; }

        /// <summary>
        /// The type of payment for disbursement.   Example &#x60;CREDIT_CARD&#x60;
        /// </summary>
        /// <value>The type of payment for disbursement.   Example &#x60;CREDIT_CARD&#x60;</value>
        [DataMember(Name = "PaymentDisbursementType", EmitDefaultValue = false)]
        public string PaymentDisbursementType { get; set; }

        /// <summary>
        /// The status of the failed &#x60;AdhocDisbursement&#x60;.   Example &#x60;HARD_DECLINED&#x60;
        /// </summary>
        /// <value>The status of the failed &#x60;AdhocDisbursement&#x60;.   Example &#x60;HARD_DECLINED&#x60;</value>
        [DataMember(Name = "Status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// The amount of the Adhoc Disbursement.
        /// </summary>
        /// <value>The amount of the Adhoc Disbursement.</value>
        [DataMember(Name = "TransferAmount", EmitDefaultValue = false)]
        public Currency TransferAmount { get; set; }

        /// <summary>
        /// The date and time when the financial event was posted.
        /// </summary>
        /// <value>The date and time when the financial event was posted.</value>
        [DataMember(Name = "PostedDate", EmitDefaultValue = false)]
        public DateTime? PostedDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FailedAdhocDisbursementEventList {\n");
            sb.Append("  FundsTransfersType: ").Append(FundsTransfersType).Append("\n");
            sb.Append("  TransferId: ").Append(TransferId).Append("\n");
            sb.Append("  DisbursementId: ").Append(DisbursementId).Append("\n");
            sb.Append("  PaymentDisbursementType: ").Append(PaymentDisbursementType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  TransferAmount: ").Append(TransferAmount).Append("\n");
            sb.Append("  PostedDate: ").Append(PostedDate).Append("\n");
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
            return this.Equals(input as FailedAdhocDisbursementEvent);
        }

        /// <summary>
        /// Returns true if FailedAdhocDisbursementEventList instances are equal
        /// </summary>
        /// <param name="input">Instance of FailedAdhocDisbursementEventList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FailedAdhocDisbursementEvent input)
        {
            if (input == null)
                return false;

            return
                (
                    this.FundsTransfersType == input.FundsTransfersType ||
                    (this.FundsTransfersType != null &&
                    this.FundsTransfersType.Equals(input.FundsTransfersType))
                ) &&
                (
                    this.TransferId == input.TransferId ||
                    (this.TransferId != null &&
                    this.TransferId.Equals(input.TransferId))
                ) &&
                (
                    this.DisbursementId == input.DisbursementId ||
                    (this.DisbursementId != null &&
                    this.DisbursementId.Equals(input.DisbursementId))
                ) &&
                (
                    this.PaymentDisbursementType == input.PaymentDisbursementType ||
                    (this.PaymentDisbursementType != null &&
                    this.PaymentDisbursementType.Equals(input.PaymentDisbursementType))
                ) &&
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) &&
                (
                    this.TransferAmount == input.TransferAmount ||
                    (this.TransferAmount != null &&
                    this.TransferAmount.Equals(input.TransferAmount))
                ) &&
                (
                    this.PostedDate == input.PostedDate ||
                    (this.PostedDate != null &&
                    this.PostedDate.Equals(input.PostedDate))
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
                if (this.FundsTransfersType != null)
                    hashCode = hashCode * 59 + this.FundsTransfersType.GetHashCode();
                if (this.TransferId != null)
                    hashCode = hashCode * 59 + this.TransferId.GetHashCode();
                if (this.DisbursementId != null)
                    hashCode = hashCode * 59 + this.DisbursementId.GetHashCode();
                if (this.PaymentDisbursementType != null)
                    hashCode = hashCode * 59 + this.PaymentDisbursementType.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.TransferAmount != null)
                    hashCode = hashCode * 59 + this.TransferAmount.GetHashCode();
                if (this.PostedDate != null)
                    hashCode = hashCode * 59 + this.PostedDate.GetHashCode();
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
