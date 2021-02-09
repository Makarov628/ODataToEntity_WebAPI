using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdataToEntity.AspNetCore;
using OdataToEntity.Linq2Db;

using ODataToEntity_WebAPI.DB;

namespace ODataToEntity_WebAPI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
            var dataAdapter = new OeLinq2DbDataAdapter<ExampleDB>();
            services.AddOdataToEntityMvc(dataAdapter.BuildEdmModelFromLinq2DbModel());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
