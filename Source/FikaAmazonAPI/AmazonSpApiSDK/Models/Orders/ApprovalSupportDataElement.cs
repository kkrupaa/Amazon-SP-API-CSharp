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
    /// &lt;Name, Value&gt; tuple to define item approval support data elements.
    /// </summary>
    [DataContract]
    public partial class ApprovalSupportDataElement : IEquatable<ApprovalSupportDataElement>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalSupportDataElement" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ApprovalSupportDataElement() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalSupportDataElement" /> class.
        /// </summary>
        /// <param name="name">Name of the approval support element. Allowed names are defined in specific approval types schemas. (required).</param>
        /// <param name="value">String value of the approval support element. (required).</param>
        public ApprovalSupportDataElement(string name = default(string), string value = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for ApprovalSupportDataElement and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new InvalidDataException("value is a required property for ApprovalSupportDataElement and cannot be null");
            }
            else
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// Name of the approval support element. Allowed names are defined in specific approval types schemas.
        /// </summary>
        /// <value>Name of the approval support element. Allowed names are defined in specific approval types schemas.</value>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// String value of the approval support element.
        /// </summary>
        /// <value>String value of the approval support element.</value>
        [DataMember(Name = "Value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApprovalSupportDataElement {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as ApprovalSupportDataElement);
        }

        /// <summary>
        /// Returns true if ApprovalSupportDataElement instances are equal
        /// </summary>
        /// <param name="input">Instance of ApprovalSupportDataElement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApprovalSupportDataElement input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
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