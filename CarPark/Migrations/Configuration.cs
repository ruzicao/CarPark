namespace CarPark.Migrations
{
    using CarPark.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarPark.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarPark.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Manufacturers.AddOrUpdate(x => x.Id,
                new Manufacturer() { Id = 1, Name="Kia Motors", Address= "Main Road Sidcup Kent, 225-335, London", Country= "United Kingdom", FoundationYear= 1944},
                new Manufacturer() { Id = 2, Name = "Tesla", Address = "Boulevard Malesherbes 3, Paris", Country = "France", FoundationYear = 2003},
                new Manufacturer() { Id = 3, Name = "Volkswagen", Address = "Stone Harbor Blvd, Berlin", Country = "Germany", FoundationYear = 1937 }
            );
            context.SaveChanges();

            context.Cars.AddOrUpdate(x => x.Id,
                new Car() { Id = 1, Name="Stinger", Color="WHITE", Year=2017, Buy=false, ManufacturerId= 1 },
                new Car() { Id = 2, Name = "Sportage", Color = "RED", Year = 2018, Buy = false, ManufacturerId = 1 },
                new Car() { Id = 3, Name = "XCeed", Color = "YELLOW", Year = 2019, Buy = false, ManufacturerId = 1 },
                new Car() { Id = 4, Name = "Model S", Color = "RED", Year = 2016, Buy = false, ManufacturerId =2},
                new Car() { Id = 5, Name = "Model 3", Color = "BLUE", Year = 2017, Buy = false, ManufacturerId =2},
                new Car() { Id = 6, Name = "Model X", Color = "WHITE", Year = 2018, Buy = false, ManufacturerId =2},
                new Car() { Id = 7, Name = "Arteon SE", Color = "BLACK", Year = 2019, Buy = false, ManufacturerId =3},
                new Car() { Id = 8, Name = "Atlas Cross Sport", Color = "GRAY", Year = 2016, Buy = false, ManufacturerId =3},
                new Car() { Id = 9, Name = "Taos", Color = "BLACK", Year = 2019, Buy = false, ManufacturerId = 3 }
            );
            context.SaveChanges();

        }
    }
}
