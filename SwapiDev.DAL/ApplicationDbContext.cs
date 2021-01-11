using Microsoft.EntityFrameworkCore;
using SwapiDev.DAL.Entities;

namespace SwapiDev.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
