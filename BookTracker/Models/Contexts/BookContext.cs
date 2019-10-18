using Microsoft.EntityFrameworkCore;

namespace BookTracker.Models.Contexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> BookItems { get; set; }
    }
}
