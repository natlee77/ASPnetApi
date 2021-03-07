using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using L3_AzureFunction.Data;
using System.Linq;

namespace L3_AzureFunction
{
    public   class GetProducts
    {


        private readonly SqlDbContext _context;

        public GetProducts(SqlDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetProducts")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {


          //  _context.Products.ToList();//få all product
          


            return new OkObjectResult(_context.Products);

        }
          
        
       
         
    }
}
