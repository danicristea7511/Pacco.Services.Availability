using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Convey;
using Pacco.Services.Availability.Application;
using Pacco.Services.Availability.Infrastructure.Mongo;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Pacco.Services.Availability.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddControllers().AddNewtonsoftJson();
                services.AddConvey()
                    // .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build();
            })
            .Configure(app => //app
            {
                app.UseInfrastructure();
                app.UseRouting()
                    .UseEndpoints(e => e.MapControllers());
                //.UseDispatcherEndpoints(endpoints => endpoints.Get<GetResources, IEnumerable<ResourceDto>>("resources"))
                }
            );
    }
}