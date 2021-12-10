using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QuoteRatingApi.QuoteRatingEngine;
using QuoteRatingApi.QuoteRatingEngine.Premium;
using QuoteRatingApi.Service;
using System.Text.Json.Serialization;

namespace QuoteRatingApi
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
            // Added to convert strings to enums during model binding for RequestDTO and provides validation
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quote Ratings Api", Version = "v1" });
            });

            // Set up dependency injection:
            services.AddSingleton<IQuoteRatingService, QuoteRatingService>();
            services.AddSingleton<IQuoteRatingEngine, QuoteRatingEngine.QuoteRatingEngine>();
            services.AddSingleton<IPremiumQuoteCalculator, PremiumQuoteCalculator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quote Ratings Engine v1"));
            }
            
            //app.UseHttpsRedirection(); HTTPs disabled for testing convenience (QuoteRatingApi properties -> Debug -> Web Server Settings -> Enable SSL)
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
