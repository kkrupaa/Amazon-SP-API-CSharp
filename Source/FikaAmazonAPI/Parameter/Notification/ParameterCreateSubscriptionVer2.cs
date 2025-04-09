using FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications;
using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Notification
{
	public class ParameterCreateSubscriptionVer2 : ParameterBased
	{
		public string payloadVersion { get; set; }
		public string destinationId { get; set; }
		public NotificationType notificationType { get; set; }
		public ProcessingDirectiveVer2 processingDirective { get; set; }

	}

}
