using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Key.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]  //
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
      
        private const string ApiKeyName = "key";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            StringValues providedApiKey;

            // i Query   ---context.HttpContext.Request.Query.TryGetValue(ApiKeyName, out var providedApiKey))----i kan provide key value i link-browser   ?key=.....
            // if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out   providedApiKey)|| !context.HttpContext.Request.Query.TryGetValue(ApiKeyName, out providedApiKey)) //tar typed i postman key
            //try
            //{
            //    context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out providedApiKey);
            //}
            //catch
            //{
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}
            //i Headers->key !!!! 
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out providedApiKey))
             {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();//likcardat  Iconfiguration som DI i startup
            var apiKey = configuration.GetValue<string>(key: "key");//hämta värde som nyckel= key-constant(appsettings)

            if (!apiKey.Equals(providedApiKey))//om de !lika-->unauthor
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            //att go to next del
            await next();
        }
    }
} //-->controller
