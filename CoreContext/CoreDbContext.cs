using CoreDomain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace CoreContext
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}