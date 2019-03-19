using GarageManager.Models;
using System;
using System.Data.Entity;

namespace GarageManager.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name = GarageDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<CartModel> Carts { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<ProductTypeModel> ProductTypes { get; set; }
        public virtual DbSet<UserDetailModel> UserDetails { get; set; }
    }
}