using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments;
using FikaAmazonAPI.Parameter.VendorShipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
	public class VendorShipmentsSample
	{
		AmazonConnection amazonConnection;

		public VendorShipmentsSample(AmazonConnection amazonConnection)
		{
			this.amazonConnection = amazonConnection;
		}

		public async Task<List<Shipment>> GetShipmentDetails(DateTime? createdFrom, DateTime? createdTo)
		{
			List<Shipment> result = null;
			try
			{

				var parameters = new ParameterVendorShipmentsGetShipmentDetails();

				parameters.limit = 50;
				parameters.sortOrder = FikaAmazonAPI.Utils.Constants.SortOrderEnum.DESC;

				parameters.shippedAfter = createdFrom.Value;

				result = await amazonConnection.VendorShipments.GetShipmentDetailsAsync(parameters);


			}
			catch (Exception ex)
			{
				string msh = ex.Message;
			}
			return result;
		}
	}
}
