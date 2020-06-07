using Weekdays.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weekdays.Models;
using Amazon.DynamoDBv2;
using Amazon.XRay.Recorder.Core;
using Amazon.XRay.Recorder.Handlers.AwsSdk;

namespace Weekdays
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AWSXRayRecorder.InitializeInstance(configuration);
        }

        public static IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.Configure<AwsSettingsModel>(Configuration.GetSection("AWS"));
            AWSSDKHandler.RegisterXRayForAllServices();
            services.AddTransient<ICalculationService, CalculationService>();
            services.AddTransient<IDBDataService<IData>, DBDataService<IData>>();
            services.AddTransient<IHolidaysCalculationService, HolidaysCalculationService>();
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
