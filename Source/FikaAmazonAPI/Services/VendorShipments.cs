using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders;
using FikaAmazonAPI.Parameter.VendorOrders;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FikaAmazonAPI.Parameter.VendorShipments;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
	public class VendorShipmentService : RequestService
	{
		public VendorShipmentService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, loggerFactory, rateLimitingHandler)
		{

		}

		public List<Shipment> GetShipmentDetails(ParameterVendorShipmentsGetShipmentDetails searchOrderList) =>
			Task.Run(() => GetShipmentDetailsAsync(searchOrderList)).ConfigureAwait(false).GetAwaiter().GetResult();
		public async Task<List<Shipment>> GetShipmentDetailsAsync(ParameterVendorShipmentsGetShipmentDetails searchOrderList, CancellationToken cancellationToken = default)
		{
			var ShipmentList = new List<Shipment>();
			string nextToken;
			do
			{
				var queryParameters = searchOrderList.getParameters();
				await CreateAuthorizedRequestAsync(VendorShipmentsApiUrls.GetShipmentDetails, RestSharp.Method.Get, queryParameters, parameter: searchOrderList, cancellationToken: cancellationToken);
				//GetPurchaseOrdersResponse
				GetShipmentDetailsResponse response = await ExecuteRequestAsync<GetShipmentDetailsResponse>(RateLimitType.VendorShipmentsV1_GetShipmentDetails, cancellationToken);
				nextToken = response.Payload?.Pagination?.NextToken;
				searchOrderList.nextToken = nextToken;
				ShipmentList.AddRange(response.Payload.Shipments);
			} while (!string.IsNullOrEmpty(nextToken));
			return ShipmentList;
		}
	}
}
