using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using SentimentAnalysisWebApi.DataModels;

namespace SentimentAnalysisWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // LOCAL Deployment
            /*services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
    .FromFile(modelName: "SentimentAnalysisModel", filePath:"MLModels/SentimentAnalysisModel.zip", watchForChanges: true);
    */
            // CLOUD Deployment
            services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
            .FromUri(
                modelName: "SentimentAnalysisModel",
                uri:"https://techsessionsstorage.blob.core.windows.net/models/SentimentAnalysisModel.zip",
                period: TimeSpan.FromMinutes(1));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
