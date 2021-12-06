using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static FoodDetectiveRest.Controllers.FoodController;

namespace FoodDetectiveRest.Manager
{
    public class FoodManager
    {
        public List<FoodFamily> _foods = new List<FoodFamily>();


        public List<RecognitionResult> GetFood(FileUploadAPI objFile)
        {
            
            var client = new RestClient("https://api.logmeal.es/v2/recognition/dish");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer d966275a74bb1cc9667cff093852a34ba4f7a0df");
            request.AddFile("image", GetBytes(objFile),  "test.jpeg");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content);

            return myDeserializedClass.recognition_results;
        }
        public static byte[] GetBytes(FileUploadAPI s)
        {
            using (var ms = new MemoryStream())
            {
                s.files.CopyTo(ms);
                return ms.ToArray();
            }
        }



    }
}
