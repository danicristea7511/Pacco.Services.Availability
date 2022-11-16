using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pacco.Services.Availability.Application.Commands;
using Pacco.Services.Availability.Application.DTO;
using Pacco.Services.Availability.Application.Queries;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldResourcesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public OldResourcesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{resourceId}")]
        public async Task<ActionResult<ResourceDto>> Get([FromRoute] GetResource query)
        {
            var resource =  await _queryDispatcher.QueryAsync(query);

            if (resource is {})
            {
                return resource;
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult> Post(AddResource command)
        {
            await _commandDispatcher.SendAsync(command);

            return Created($"api/resources/{command.ResourceId}", null);
        }
    }
}
