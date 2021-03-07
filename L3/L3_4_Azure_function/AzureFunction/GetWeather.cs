using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using L3_AzureFunction.Models;

namespace L3_AzureFunction
{
    public static class GetWeather
    {
        [FunctionName("GetWeather")]


        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "weather")] HttpRequest req,
            ILogger log)
        {
           

            //copy from api
            var rng = new Random();
            var result= Enumerable.Range(1, 5).Select(index => new weather
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return new OkObjectResult(result ); 


            //log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];   //https://aspnetfa.azurewebsites.net/api/weather?name=natlee

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            //dynamic data = JsonConvert.DeserializeObject(requestBody);

            //name = name ?? data?.name; //om det finns ingenting i name , tar data.name

            //string responseMessage = string.IsNullOrEmpty(name) //
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";
            //return new OkObjectResult(responseMessage);//tilbacka 200 msg och object
        }
        private static readonly string[] Summaries = new[]
      {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
