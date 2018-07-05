using Newtonsoft.Json;
using NT.Integration.Medicus;
using NT.Integration.Medicus.Domain;
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
        public static async Task<Response> ManageOrder(List<Order> body)
        {
            Response jsonObj = null;   
            try
            {
                //Map domain to entity
                List<Integration.Medicus.Entities.Order> medicalReport = ApiHelper.CreateMap<Order, Integration.Medicus.Entities.Order>(body);
                jsonObj = await PostAsync(body, UrlType.ManageOrder);
            }
            catch (Exception e)
            {
                logger.Fatal(e.Message);
             
            }

            return jsonObj;
        }
      
    }
}
