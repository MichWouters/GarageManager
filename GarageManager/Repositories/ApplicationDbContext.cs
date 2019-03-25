using GarageManager.Models;
using System.Data.Entity;

namespace GarageManager.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("defaultConnection")
        {
            Database.SetInitializer(new GarageDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<CartModel> Carts { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<ProductTypeModel> ProductTypes { get; set; }
        public virtual DbSet<UserDetailModel> UserDetails { get; set; }
    }
}