using Convey.CQRS.Commands;
using Pacco.Services.Availability.Application.Exceptions;
using Pacco.Services.Availability.Core.Entities;
using Pacco.Services.Availability.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Application.Commands.Handlers
{
    public class AddResourceHandler : ICommandHandler<AddResource>
    {
        private readonly IResourceRepository _resourceRepository;

        public AddResourceHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task HandleAsync(AddResource command)
        {
            var resource = await _resourceRepository.GetAsync(command.ResourceId);

            if (resource is { })
            {
                throw new ResourceAlreadyExistsException(command.ResourceId);
            }

            resource = Resource.Create(command.ResourceId, command.Tags);
            await _resourceRepository.AddAsync(resource);
        }
    }
}
