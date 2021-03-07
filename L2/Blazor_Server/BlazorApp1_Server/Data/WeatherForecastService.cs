using BlazorApp1_Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



//install  Microsoft.AspNet.WebApi.Client 5.2.7.

namespace BlazorApp1_Server.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {

            ////++
            //HttpClient http = new HttpClient();

            //var responce = http.GetAsync(new Uri("https://recapwebapi.azurewebsites.net/api/products")).GetAwaiter().GetResult();//request URI
            //var result = responce.Content.ReadAsStringAsync();



            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        //++
        public async Task<IEnumerable<ProductModel>> GetProductAsync()//++productmodel
        {            
            //används for att hämta info- göra om 

            using(var client =new HttpClient())
            {
                var responce =await client.GetAsync(new Uri("https://recapwebapi.azurewebsites.net/api/products"));//request URI
                var result =await  responce.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>( result );//göra om info

                return products;
            }             

        }
    }
}
