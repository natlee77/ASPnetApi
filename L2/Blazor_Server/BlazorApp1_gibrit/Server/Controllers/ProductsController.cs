using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorApp1_gibrit.Shared;
using System.Net.Http;
using Newtonsoft.Json;

namespace BlazorApp1_gibrit.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
      
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductModel>> Get() //kan anropa DB
        {

            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(new Uri("https://recapwebapi.azurewebsites.net/api/products "));//request URI
                var result = await responce.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(result);

                return products;
            }

        }
    }
}
