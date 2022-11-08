using Microsoft.EntityFrameworkCore;
using NZwalks.API.Model.DBContext;
using NZwalks.API.Model.Domain;
using NZwalks.API.Model.DTO;

namespace NZwalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZDbContext _dbContext;

        public RegionRepository(NZDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Regions> AddRegion(Regions regions)
        {
            regions.Id = Guid.NewGuid();
            await  _dbContext.Regions.AddAsync(regions);
            _dbContext.SaveChanges();

            return regions;

        }

        public async Task<Regions> DeleteRegion(Guid id)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

              _dbContext.Regions.Remove(region);

            await _dbContext.SaveChangesAsync();

            return region;


        }

        public async Task<IEnumerable<Regions>> GetallRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Regions> GetRegionsbyId(Guid id)

        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
