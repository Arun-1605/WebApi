using NZwalks.API.Model.Domain;
using NZwalks.API.Model.DTO;

namespace NZwalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Regions>> GetallRegionsAsync();

        Task<Regions> GetRegionsbyId(Guid id);

        Task<Regions> AddRegion(Regions regions);

        Task<Regions> DeleteRegion(Guid id);
    }
}
