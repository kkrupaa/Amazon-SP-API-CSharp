using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorTransactions;
using FikaAmazonAPI.Parameter.VendorShipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
	public class VendorTransactionsSample
	{
		AmazonConnection amazonConnection;

		public VendorTransactionsSample(AmazonConnection amazonConnection)
		{
			this.amazonConnection = amazonConnection;
		}

		public async Task<Transaction> GetTransaction(string TransactionId = "")
		{
			Transaction result = null;
			try
			{
				result = amazonConnection.VendorTransactionStatus.GetTransaction(TransactionId);
			}
			catch (Exception ex)
			{
				string msh = ex.Message;
			}
			return result;
		}
	}
}
