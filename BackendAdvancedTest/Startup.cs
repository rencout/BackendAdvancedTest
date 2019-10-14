using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liquid;
using Liquid.Middleware;
using Liquid.OnAzure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BackendAdvancedTest
{
    /// <summary>
    /// Startup class of API
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration parameters</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Instance of Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services">Service Collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Add the configuration on WorkBench
            services.AddWorkBench(Configuration);
            services.AddMvc();
        }

        /// <summary>
        /// /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Start the configuration on WorkBench
            ConfigureWorkBench();
            app.UseWorkBench();

            app.UseMvc();
        }

        /// <summary>
        /// Initializes selected cartridges for WorkBench
        /// </summary>
        public static void ConfigureWorkBench()
        {
            WorkBench.UseTelemetry<AppInsights>();
            WorkBench.UseEnventHandler<AzureEventHub>();
        }
    }
}
