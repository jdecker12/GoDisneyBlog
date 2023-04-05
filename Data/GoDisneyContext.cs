using Microsoft.EntityFrameworkCore;
using GoDisneyBlog.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GoDisneyBlog.Data
{
    public class GoDisneyContext : IdentityDbContext<StoreUser>
    {
        public GoDisneyContext(DbContextOptions<GoDisneyContext> options) : base(options)
        { }

        public DbSet<Card>? Cards { get; set; }
        public DbSet<CardList>? CardLists { get; set; }
        public DbSet<RememberMe>? DecryptionKeys { get; set; }
    }
}
