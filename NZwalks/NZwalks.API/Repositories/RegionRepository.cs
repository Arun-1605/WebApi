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

        public async Task<Regions> UpdateRegion(Guid id, Regions region)
        {
           var RegionUpdate = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            RegionUpdate.Code = region.Code;
            RegionUpdate.Name = region.Name;
            RegionUpdate.Area = region.Area;
            RegionUpdate.Lat = region.Lat;
            RegionUpdate.Long = region.Long;
            RegionUpdate.Population = region.Population;

            await _dbContext.SaveChangesAsync();

            return RegionUpdate;




            return RegionUpdate;
        }
    }
}
