using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Key_Product_repet.Filters
{

    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {

        //private const string ApiKeyName = "key";

        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

           


            //tar key som jag try to get in to api
            if (!context.HttpContext.Request.Query.TryGetValue("myKey", out var providedAccessKeyValue))
            {
                context.Result = new UnauthorizedResult();//401 error
                return;
            }


            var _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var _apiAccessKeyValue = _configuration.GetValue<string>(key: "ApiAccessKey");



            if (!_apiAccessKeyValue.Equals(providedAccessKeyValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
