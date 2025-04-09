using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications
{
	public class ProcessingDirectiveVer2
	{
		/// <summary>
		/// A notificationType specific filter.
		/// </summary>
		/// <value>A notificationType specific filter.</value>
		[DataMember(Name = "eventFilter", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "eventFilter")]
		public EventFilterVer2 EventFilter { get; set; }


		/// <summary>
		/// Get the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("class ProcessingDirective {\n");
			sb.Append("  EventFilter: ").Append(EventFilter).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}

		/// <summary>
		/// Get the JSON string presentation of the object
		/// </summary>
		/// <returns>JSON string presentation of the object</returns>
		public string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
}
