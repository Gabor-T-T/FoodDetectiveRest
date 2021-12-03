using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDetectiveRest
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class FoodFamily
    {
        public int id { get; set; }
        public string name { get; set; }
        public double prob { get; set; }
    }

    public class FoodType
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ModelVersions
    {
        public string foodType { get; set; }
        public string foodgroups { get; set; }
        public string foodrec { get; set; }
        public string ingredients { get; set; }
    }

    public class RecognitionResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public double prob { get; set; }
        public List<object> subclasses { get; set; }
    }

    public class Root
    {
        public List<FoodFamily> foodFamily { get; set; }
        public List<FoodType> foodType { get; set; }
        public int imageId { get; set; }
        public ModelVersions model_versions { get; set; }
        public List<RecognitionResult> recognition_results { get; set; }
    }




}
