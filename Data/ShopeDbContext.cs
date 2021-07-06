using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ShopeDbContext : DbContext
    {
        public ShopeDbContext(DbContextOptions<ShopeDbContext> opt) : base(opt)
        {
        }
        public DbSet<User> User { get; set; }

        public DbSet<Group> Group { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductProperty> ProductPropertiy { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<ProductPropertyRelation> ProductPropertyRelations { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Reviews> Reviews { get; set; }

        public DbSet<Gallery> Gallery { get; set; }
        
        public DbSet<Cart> Cart { get; set; }
        
        public DbSet<WhishList> WhishList { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}