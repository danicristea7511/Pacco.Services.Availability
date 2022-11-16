using Convey;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Availability.Core.Repositories;
using Pacco.Services.Availability.Infrastructure.Exceptions;
using Pacco.Services.Availability.Infrastructure.Mongo.Documents;
using Pacco.Services.Availability.Infrastructure.Mongo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Infrastructure.Mongo
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure (this IConveyBuilder builder)
        {
            var document = builder.Services.AddTransient<IResourcesRepository, ResourcesMongoRepository>();

            builder
                    .AddErrorHandler<ExceptionToResponseMapper>()
                    .AddMongo()
                    .AddMongoRepository<ResourceDocument, Guid>("resources")
                   .AddQueryHandlers()
                   .AddInMemoryQueryDispatcher(); ;

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler();
            app.UseConvey();
            return app;
        }
    }
}
