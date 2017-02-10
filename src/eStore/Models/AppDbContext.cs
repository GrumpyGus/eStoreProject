using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace eStore.Models
{

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Brand>().ForSqlServerToTable("Brands")
                .Property(b => b.Id).UseSqlServerIdentityColumn();
            builder.Entity<Branch>().ForSqlServerToTable("Branches")
                .Property(s => s.Id).UseSqlServerIdentityColumn();
            builder.Entity<Orders>().ForSqlServerToTable("Orders")
                .Property(o => o.Id).UseSqlServerIdentityColumn();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderLineItems> OrderLineItems { get; set; }
    }
}
