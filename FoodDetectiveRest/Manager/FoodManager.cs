using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDetectiveRest.Manager
{
    public class FoodManager
    {
        public List<FoodFamily> _foods = new List<FoodFamily>();


        public List<FoodFamily> GetFood()
        {
            
            var client = new RestClient("https://api.logmeal.es/v2/recognition/dish");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer d966275a74bb1cc9667cff093852a34ba4f7a0df");
            request.AddFile("image", "/Users/torna/Desktop/food1.jpg");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            var list = JsonConvert.DeserializeObject<List<FoodFamily>>(response.Content);

            return new List<FoodFamily>(list);
        }
        



    }
}
