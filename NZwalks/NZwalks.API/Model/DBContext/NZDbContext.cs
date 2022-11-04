using Microsoft.EntityFrameworkCore;
using NZwalks.API.Model.Domain;

namespace NZwalks.API.Model.DBContext


{
    public class NZDbContext : DbContext
    {
        public NZDbContext(DbContextOptions<NZDbContext> options) : base(options)
        {

        }

        public DbSet<Regions> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
    }
}
