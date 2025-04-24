using FikaAmazonAPI.ConstructFeed.JsonMessages;
using FikaAmazonAPI.ConstructFeed.Messages;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed
{
    public class ConstructJSONFeedService
    {
        JsonMessagesData jsonMessagesData = new JsonMessagesData();
        public ConstructJSONFeedService(string sellerId, string version = "2.0", string issueLocale = "en_US")
        {
            jsonMessagesData.header = new HeaderData()
            {
                issueLocale = issueLocale,
                sellerId = sellerId,
                version = version
            };

        }


        public void AddPriceMessage(IList<PriceMessage> messages)
        {
            int index = jsonMessagesData.messages.Count;
            foreach (var itm in messages)
            {
                var patcheValueData = new PatcheValueData()
                {
                    currency = itm.StandardPrice.currency,
                    our_price = new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.StandardPrice.Value }  } }
                    },
                };

                if (itm.MinimumSellerAllowedPrice != null)
                {
                    patcheValueData.minimum_seller_allowed_price = new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.MinimumSellerAllowedPrice.Value }  } }
                    };
                }
                //else
                //{
                //    patcheValueData.minimum_seller_allowed_price = null;
                //}

                if (itm.MaximumSellerAllowedPrice != null)
                {
                    patcheValueData.maximum_seller_allowed_price = new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.MaximumSellerAllowedPrice.Value }  } }
                    };
                }
                //else
                //{
                //    patcheValueData.maximum_seller_allowed_price = null;
                //}

                if (itm.MAP != null)
                { 
                    patcheValueData.map_price = new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.MAP.Value }  } }
                    };
                }

                if (itm.Sale != null)
                {
                    patcheValueData.discounted_price =  new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.Sale.SalePrice.Value, start_at = itm.Sale.StartDate, end_at = itm.Sale.EndDate }  } }
                    };
                }

                var msg = new MessagesData()
                {
                    messageId = ++index,
                    sku = itm.SKU,
                    operationType = "PATCH",
                    productType = "PRODUCT",
                    patches = new List<PatcheData>{
                        new PatcheData()
                        {
                            op = "replace",
                            path = "/attributes/purchasable_offer",
                            value =new List<PatcheValueData>{ patcheValueData }
                        }
                    }
                };

                if (itm.IncludeBusinessPriceInFeed)
                {
                    patcheValueData = new PatcheValueData()
                    {
                        currency = itm.StandardPrice.currency,
                        audience = "B2B",
                        our_price = new List<PriceData>()
                        {
                            new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.BusinessPrice }  } }
                        }
                    };

                    if (itm.QuantityPrice != null)
                    {
                        patcheValueData.quantity_discount_plan = new List<PriceData>()
                        {
                            new PriceData(){ schedule = new List<SchedulePriceData>()
                                { new SchedulePriceData()
                                    {
                                        discount_type = "fixed",
                                        levels = new List<ShedulePriceLevel>()
                                        {
                                            new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound1, value=itm.QuantityPrice.QuantityPrice1 },
                                            //new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound2, value=itm.QuantityPrice.QuantityPrice2 },
                                            //new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound3, value=itm.QuantityPrice.QuantityPrice3 },
                                            //new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound4, value=itm.QuantityPrice.QuantityPrice4 },
                                            //new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound5, value=itm.QuantityPrice.QuantityPrice5 }
                                        }
                                    }
                                }
                            }
                        };

                        if (itm.QuantityPrice.QuantityLowerBound2 != null)
                        {
                            patcheValueData.quantity_discount_plan[0].schedule[0].levels.Add
                                (
                                    new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound2, value = itm.QuantityPrice.QuantityPrice2 }
                                );
                        }

                        if (itm.QuantityPrice.QuantityLowerBound3 != null)
                        {
                            patcheValueData.quantity_discount_plan[0].schedule[0].levels.Add
                                (
                                    new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound3, value = itm.QuantityPrice.QuantityPrice3 }
                                );
                        }

                        if (itm.QuantityPrice.QuantityLowerBound4 != null)
                        {
                            patcheValueData.quantity_discount_plan[0].schedule[0].levels.Add
                                (
                                    new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound4, value = itm.QuantityPrice.QuantityPrice4 }
                                );
                        }

                        if (itm.QuantityPrice.QuantityLowerBound5 != null)
                        {
                            patcheValueData.quantity_discount_plan[0].schedule[0].levels.Add
                                (
                                    new ShedulePriceLevel() { lower_bound = itm.QuantityPrice.QuantityLowerBound5, value = itm.QuantityPrice.QuantityPrice5 }
                                );
                        }

                    }
                    else
                    {
                        patcheValueData.quantity_discount_plan = new List<PriceData>();
                    }

                    msg.patches[0].value.Add(patcheValueData);

                }

                

                jsonMessagesData.messages.Add(msg);
            }
        }

        public string GetJSON()
        {
            string jsonString = JsonConvert.SerializeObject(jsonMessagesData, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return jsonString;
        }
    }
}
