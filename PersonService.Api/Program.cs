using Microsoft.EntityFrameworkCore;
using PersonService.Api.Common;
using PersonService.Api.Services;
using PersonService.Infrastructure.Data;

namespace PersonService.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                var env = hostingContext.HostingEnvironment;

                configuration.AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<PersonDbContext>(options =>
                options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
            });

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(5001, listenOptions => // 5001 for HTTPS
            {
                listenOptions.UseHttps();   // certificate from dev store
            });
        });

        // Add services to the container.
        builder.Services
            .AddGrpc((options =>
            {
                options.Interceptors.Add<GrpcErrorHandlingInterceptor>();
            }));


        builder.Services.SetupDI();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<GrpcPersonService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}