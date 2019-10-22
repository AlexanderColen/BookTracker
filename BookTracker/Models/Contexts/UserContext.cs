using Microsoft.EntityFrameworkCore;

namespace BookTracker.Models.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> UserItems { get; set; }
    }
}
