using FoodDetectiveRest.Manager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodDetectiveRest.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        FoodManager foodManager = new FoodManager();

       
        // comments changes 
        public static IWebHostEnvironment _environment;
        public FoodController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        public  List<RecognitionResult> Post([FromForm]FileUploadAPI objFile)
        {
            try
            {

                return foodManager.GetFood(objFile);
              
            }
            catch (Exception )
            {

                return null;
            }

        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
