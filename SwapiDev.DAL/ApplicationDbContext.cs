using Microsoft.EntityFrameworkCore;
using SwapiDev.DAL.Entities;

namespace SwapiDev.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EpisodeRating> EpisodesRatings { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
