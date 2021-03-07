using System;
using System.Collections.Generic;
using System.Text;
using L3_AzureFunction.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



[assembly: FunctionsStartup(typeof(L3_AzureFunction.Startup))]

namespace L3_AzureFunction
{

    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //string SqlConnection = Environment.GetEnvironmentVariable("SqlConnection");
            //builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer());
 
            builder.Services.AddDbContext<SqlDbContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnection")));//egen startup file
        }




    }
}
