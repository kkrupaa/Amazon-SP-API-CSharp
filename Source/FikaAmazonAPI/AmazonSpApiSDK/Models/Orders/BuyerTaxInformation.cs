﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// Contains the business invoice tax information. Available only in the TR marketplace.
    /// </summary>
    [DataContract]
    public partial class BuyerTaxInformation : IEquatable<BuyerTaxInformation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuyerTaxInformation" /> class.
        /// </summary>
        /// <param name="buyerLegalCompanyName">Business buyer&#39;s company legal name..</param>
        /// <param name="buyerBusinessAddress">Business buyer&#39;s address..</param>
        /// <param name="buyerTaxRegistrationId">Business buyer&#39;s tax registration ID..</param>
        /// <param name="buyerTaxOffice">Business buyer&#39;s tax office..</param>
        public BuyerTaxInformation(string buyerLegalCompanyName = default(string), string buyerBusinessAddress = default(string), string buyerTaxRegistrationId = default(string), string buyerTaxOffice = default(string))
        {
            this.BuyerLegalCompanyName = buyerLegalCompanyName;
            this.BuyerBusinessAddress = buyerBusinessAddress;
            this.BuyerTaxRegistrationId = buyerTaxRegistrationId;
            this.BuyerTaxOffice = buyerTaxOffice;
        }
        public BuyerTaxInformation()
        {
        }
        /// <summary>
        /// Business buyer&#39;s company legal name.
        /// </summary>
        /// <value>Business buyer&#39;s company legal name.</value>
        [DataMember(Name = "BuyerLegalCompanyName", EmitDefaultValue = false)]
        public string BuyerLegalCompanyName { get; set; }

        /// <summary>
        /// Business buyer&#39;s address.
        /// </summary>
        /// <value>Business buyer&#39;s address.</value>
        [DataMember(Name = "BuyerBusinessAddress", EmitDefaultValue = false)]
        public string BuyerBusinessAddress { get; set; }

        /// <summary>
        /// Business buyer&#39;s tax registration ID.
        /// </summary>
        /// <value>Business buyer&#39;s tax registration ID.</value>
        [DataMember(Name = "BuyerTaxRegistrationId", EmitDefaultValue = false)]
        public string BuyerTaxRegistrationId { get; set; }

        /// <summary>
        /// Business buyer&#39;s tax office.
        /// </summary>
        /// <value>Business buyer&#39;s tax office.</value>
        [DataMember(Name = "BuyerTaxOffice", EmitDefaultValue = false)]
        public string BuyerTaxOffice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuyerTaxInformation {\n");
            sb.Append("  BuyerLegalCompanyName: ").Append(BuyerLegalCompanyName).Append("\n");
            sb.Append("  BuyerBusinessAddress: ").Append(BuyerBusinessAddress).Append("\n");
            sb.Append("  BuyerTaxRegistrationId: ").Append(BuyerTaxRegistrationId).Append("\n");
            sb.Append("  BuyerTaxOffice: ").Append(BuyerTaxOffice).Append("\n");
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
            return this.Equals(input as BuyerTaxInformation);
        }

        /// <summary>
        /// Returns true if BuyerTaxInformation instances are equal
        /// </summary>
        /// <param name="input">Instance of BuyerTaxInformation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BuyerTaxInformation input)
        {
            if (input == null)
                return false;

            return
                (
                    this.BuyerLegalCompanyName == input.BuyerLegalCompanyName ||
                    (this.BuyerLegalCompanyName != null &&
                    this.BuyerLegalCompanyName.Equals(input.BuyerLegalCompanyName))
                ) &&
                (
                    this.BuyerBusinessAddress == input.BuyerBusinessAddress ||
                    (this.BuyerBusinessAddress != null &&
                    this.BuyerBusinessAddress.Equals(input.BuyerBusinessAddress))
                ) &&
                (
                    this.BuyerTaxRegistrationId == input.BuyerTaxRegistrationId ||
                    (this.BuyerTaxRegistrationId != null &&
                    this.BuyerTaxRegistrationId.Equals(input.BuyerTaxRegistrationId))
                ) &&
                (
                    this.BuyerTaxOffice == input.BuyerTaxOffice ||
                    (this.BuyerTaxOffice != null &&
                    this.BuyerTaxOffice.Equals(input.BuyerTaxOffice))
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
                if (this.BuyerLegalCompanyName != null)
                    hashCode = hashCode * 59 + this.BuyerLegalCompanyName.GetHashCode();
                if (this.BuyerBusinessAddress != null)
                    hashCode = hashCode * 59 + this.BuyerBusinessAddress.GetHashCode();
                if (this.BuyerTaxRegistrationId != null)
                    hashCode = hashCode * 59 + this.BuyerTaxRegistrationId.GetHashCode();
                if (this.BuyerTaxOffice != null)
                    hashCode = hashCode * 59 + this.BuyerTaxOffice.GetHashCode();
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