using GarageManager.Models;
using Microsoft.EntityFrameworkCore;


namespace GarageManager.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<ProductTypeModel>().HasData(
                new ProductTypeModel { ID = 1, Name = "Brakes" },
                new ProductTypeModel { ID = 2, Name = "Lubricants & Fluids" },
                new ProductTypeModel { ID = 3, Name = "Cleaning" },
                new ProductTypeModel { ID = 4, Name = "Engine Parts" },
                new ProductTypeModel { ID = 5, Name = "Suspension" },
                new ProductTypeModel { ID = 6, Name = "Transmission" },
                new ProductTypeModel { ID = 7, Name = "Cooling & Heating" },
                new ProductTypeModel { ID = 8, Name = "Electrical" },
                new ProductTypeModel { ID = 9, Name = "Body & Exhaust" },
                new ProductTypeModel { ID = 10, Name = "Accessories" }
                );

            builder.Entity<ProductModel>().HasData(
                new ProductModel { ID = 1, Name = "Brake Discs", Price = 100, Description = "A major component of your cars braking system", Image = "BrakeDiscs.jpg" },
                new ProductModel { ID = 2, Name = "Cylinder Heads", Price = 150, Description = "The cylinder head is the metal casing which covers the engine. It seals the main cylinders of the engine and prevents oil and other substances from finding their way inside. ", Image = "Cylinder Heads.jpg" },
                new ProductModel { ID = 3, Name = "Shock Absorbers", Price = 100, Description = "The shock absorber is a vital part of the vehicle suspension, its prime function is to keep your wheels in contact with the ground at all times by absorbing the energy from the coil spring.", Image = "Clutch kits.jpg" },
                new ProductModel { ID = 4, Name = "Clutch kits", Price = 100, Description = "Your engine is constantly on the go, constantly spinning. The clutch is the system by which the engine is engaged and the car drives. It is the job of the clutch to create a smooth engagement between the engine and a non-spinning transmission.", Image = "BrakeDiscs.jpg" },
                new ProductModel { ID = 5, Name = "Fans & Parts", Price = 100, Description = "Car Fans help to maintain the comfortable temperature inside the car. Their maintenance requires various car fan parts like car fan coupling, fan blade, car fan switches and many more.", Image = "Fans.jpg" },
                new ProductModel { ID = 6, Name = "Body Panels", Price = 100, Description = "A body panel refers to a part of the car body such as a rear wing, a front wing or a bonnet.", Image = "Body Panels.jpg" },
                new ProductModel { ID = 7, Name = "Engine Oil", Price = 100, Description = "Engine oil is the life blood of your car. It is a vital component of the engine system, lubricating moving parts and ensuring your car has a long and happy life. The grade and type of oil you use can also impact your car economy and emissions, so it is essential that you use the correct grade of oil.", Image = "Engine Oil.jpg" },
                new ProductModel { ID = 8, Name = "Car Battery", Price = 50, Description = "The main function of a car battery is to supply electricity to various car systems. It powers the starting system through the starter motor and the ignition system. It also provides energy for the lights. In older cars, leaving car lights on was a sure way to run down the energy in car battery, but in modern cars an alarm system prevents you from doing this. If you keep your car long enough, you will probably have to replace the battery at some point", Image = "Car Battery.jpg" }
                );
        }

        public virtual DbSet<CartModel> Carts { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<ProductTypeModel> ProductTypes { get; set; }
        public virtual DbSet<UserDetailModel> UserDetails { get; set; }
    }
}