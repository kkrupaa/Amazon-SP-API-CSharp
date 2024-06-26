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
    /// The regulated information collected during purchase and used to verify the order.
    /// </summary>
    [DataContract]
    public partial class RegulatedInformation : IEquatable<RegulatedInformation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedInformation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public RegulatedInformation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedInformation" /> class.
        /// </summary>
        /// <param name="fields">A list of regulated information fields as collected from the regulatory form. (required).</param>
        public RegulatedInformation(List<RegulatedInformationField> fields = default(List<RegulatedInformationField>))
        {
            // to ensure "fields" is required (not null)
            if (fields == null)
            {
                throw new InvalidDataException("fields is a required property for RegulatedInformation and cannot be null");
            }
            else
            {
                this.Fields = fields;
            }
        }

        /// <summary>
        /// A list of regulated information fields as collected from the regulatory form.
        /// </summary>
        /// <value>A list of regulated information fields as collected from the regulatory form.</value>
        [DataMember(Name = "Fields", EmitDefaultValue = false)]
        public List<RegulatedInformationField> Fields { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RegulatedInformation {\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");
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
            return this.Equals(input as RegulatedInformation);
        }

        /// <summary>
        /// Returns true if RegulatedInformation instances are equal
        /// </summary>
        /// <param name="input">Instance of RegulatedInformation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RegulatedInformation input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Fields == input.Fields ||
                    this.Fields != null
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
                if (this.Fields != null)
                    hashCode = hashCode * 59 + this.Fields.GetHashCode();
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