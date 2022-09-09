using Pacco.Services.Availability.Core.Entities;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Core.Repositories
{
    public interface IResourceRepository
    {
        Task<Resource> GetAsync (AggregateId aggregateId);
        Task AddAsync(Resource resource);
        Task UpdateAsync(Resource resource);
        Task DeleteAsync(AggregateId aggregateId);
    }
}
