using Microsoft.EntityFrameworkCore;

namespace BookTracker.Models.Contexts
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options)
            : base(options)
        {
        }

        public DbSet<Series> SeriesItems { get; set; }
    }
}
