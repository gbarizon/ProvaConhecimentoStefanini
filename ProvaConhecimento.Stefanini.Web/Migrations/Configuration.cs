namespace ProvaConhecimento.Stefanini.Web.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProvaConhecimento.Stefanini.Web.Models;
    using ProvaConhecimento.Stefanini.Web.Utils;

    internal sealed class Configuration : DbMigrationsConfiguration<ProvaConhecimento.Stefanini.Web.Models.DBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProvaConhecimento.Stefanini.Web.Models.DBEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var users = new List<User>()
            {
                new User() { Email = "admin@app.com", Role = "Administrador", Password = Cryptography.GetMD5("admin@123"), FullName = "Mario Jose"},
                new User() { Email = "seller1@app.com", Role = "Seller", Password = Cryptography.GetMD5("seller@1"), FullName = "Alexandre Santos"},
                new User() { Email = "seller2@app.com", Role = "Seller", Password = Cryptography.GetMD5("seller@2"), FullName = "Ana Maria Braga"}
            };

            foreach (var user in users)
            {
                context.Users.AddOrUpdate(user);
            }

            context.SaveChanges();            

            var genders = new List<Gender>()
            {
                new Gender() { Code = 1 , Description = "Male"},
                new Gender() { Code = 2 , Description = "Female"}
            };

            foreach (var gender in genders)
            {
                context.Genders.AddOrUpdate(gender);
            }

            context.SaveChanges();

            var regions = new List<Region>()
            {
                new Region() { Name = "Rio Grande do Sul" , Country="Brasil"},

            };

            foreach (var region in regions)
            {
                context.Regions.AddOrUpdate(region);
            }

            context.SaveChanges();

            var cities = new List<City>()
            {
                new City() { Name = "Porto Alegre", IdRegion = 1}

            };

            foreach (var city in cities)
            {
                context.Cities.AddOrUpdate(city);
            }

            context.SaveChanges();

            var classifications = new List<Classification>()
            {
                new Classification() { Code = 1, Name = "VIP"},
                new Classification() { Code = 2, Name = "Regular"},
                new Classification() { Code = 3, Name = "Sporadic"}
            };

            foreach (var classification in classifications)
            {
                context.Classifications.AddOrUpdate(classification);
            }

            context.SaveChanges();

            var customers = new List<Customer>()
            {
                new Customer() { IdClassification = 1, Name = "João da Silva", IdGender = 1, IdCity = 1, IdRegion = 1, IdUser = 2, Phone = "81-99699-0303", LastPurchase = new DateTime(2020, 09, 01)},
                new Customer() { IdClassification = 1, Name = "Maria Célia", IdGender = 2, IdCity = 1, IdRegion = 1, IdUser = 3, Phone = "81-99699-1920", LastPurchase = new DateTime(2020, 08, 01)},
                new Customer() { IdClassification = 3, Name = "Ana Maria", IdGender = 2, IdCity = 1, IdRegion = 1, IdUser = 2, Phone = "81-99699-0101", LastPurchase = new DateTime(2020, 02, 01)},
                new Customer() { IdClassification = 2, Name = "Arnaldo Junior", IdGender = 1, IdCity = 1, IdRegion = 1, IdUser = 2, Phone = "81-99699-0404", LastPurchase = new DateTime(2020, 09, 01)},
                new Customer() { IdClassification = 2, Name = "Ana Julia", IdGender = 2, IdCity = 1, IdRegion = 1, IdUser = 3, Phone = "81-99699-0333", LastPurchase = new DateTime(2020, 07, 01)},
                new Customer() { IdClassification = 2, Name = "José Luiz", IdGender = 1, IdCity = 1, IdRegion = 1, IdUser = 3, Phone = "81-99699-0845", LastPurchase = new DateTime(2020, 10, 01)},
            };

            foreach (var customer in customers)
            {
                context.Customers.AddOrUpdate(customer);
            }

            context.SaveChanges();
        }
    }
}
