﻿using GarageManager.Models;
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

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
    }
}