using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NT.MedicusIntegration.Dll
{
  public class OrderApi :BaseObj
    {
        /// <summary>
        /// add new order of existing patient.
        /// </summary>
        /// <param name="body"> OrderBody object that has list of Orders</param>
        /// <returns> Response object with status code and message</returns>
        public static async Task<Response> ManageOrder(OrderBody body)
        {
            Response jsonObj;
            try
            {
                var Content = JsonConvert.SerializeObject(body);
                var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
                var byteContent = new ByteArrayContent(buffer);
                using (HttpResponseMessage response = await Client.PostAsync("http://104.155.18.156/aggregator/api/web/v1/manage-orders/manage", byteContent))
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    jsonObj = JsonConvert.DeserializeObject<Response>(responseBody);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return jsonObj;
        }
      
    }
}
