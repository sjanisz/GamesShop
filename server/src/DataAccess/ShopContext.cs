using System.Data.Entity;
using DataAccess.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("name=GameShopDBConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pegi> Pegis { get; set; }
        public DbSet<Producent> Producents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product_Order> Product_Orders { get; set; }
    }
}
