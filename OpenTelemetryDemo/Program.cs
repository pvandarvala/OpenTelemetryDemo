using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Logs;

namespace OpenTelemetryDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddEndpointsApiExplorer();
                    services.AddSwaggerGen();

                    services.AddOpenTelemetry()
                        .WithTracing(builder =>
                        {
                            builder
                                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("OpenTelemetryDemo"))
                                .AddAspNetCoreInstrumentation()
                                .AddHttpClientInstrumentation()
                                .AddConsoleExporter()
                                .SetSampler(new AlwaysOnSampler());
                            //.SetSampler(new AlwaysOffSampler());
                            //.SetSampler(new TraceIdRatioBasedSampler(0.5));
                            // .SetSampler(new ParentBasedSampler(new TraceIdRatioBasedSampler(0.5)));

                        });
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole(options =>
                    {
                        options.IncludeScopes = true;
                        options.TimestampFormat = "yyyy-MM-dd HH:mm:ss.fff ";
                    });
                    //logging.AddConsole();
                    // logging.AddDebug();
                    // logging.AddEventSourceLogger();
                    //logging.AddOpenTelemetry(options =>
                    //{
                    //    options.IncludeFormattedMessage = true;
                    //    options.IncludeScopes = true;
                    //    options.ParseStateValues = true;                        
                    //    //options.AddConsoleExporter();
                    //});
                    //logging.SetMinimumLevel(LogLevel.Trace); // Adjust the log level as needed
                });

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        })
        //        .ConfigureServices(services =>
        //        {
        //            services.AddEndpointsApiExplorer();
        //            services.AddSwaggerGen();
        //            services.AddOpenTelemetry()
        //                .WithTracing(builder =>
        //                {
        //                    builder
        //                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("OpenTelemetryDemo"))
        //                        .AddAspNetCoreInstrumentation()
        //                        .AddHttpClientInstrumentation()
        //                        .AddConsoleExporter();
        //                }); 

        //        });
    }
}




//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
