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
using Pacco.Services.Availability.Application.Queries;
using Pacco.Services.Availability.Application.DTO;
using Pacco.Services.Availability.Application.Commands;

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
                    .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build();
            })
            .Configure(app => app.            
                UseInfrastructure()
                //UseRouting()
                // .UseEndpoints(e => e.MapControllers());
                .UseDispatcherEndpoints(endpoints => endpoints
                    .Get<GetResources, IEnumerable<ResourceDto>>("resources")
                    .Get<GetResource, ResourceDto>("resources/{resourceId}")
                    .Post<ReserveResource>("resources/{resourceId}/reservations/{dateTime}")
                    .Post<AddResource>("resources", afterDispatch: (cmd, ctx) =>
                        ctx.Response.Created($"resources/{cmd.ResourceId}"))));
                
    }
}