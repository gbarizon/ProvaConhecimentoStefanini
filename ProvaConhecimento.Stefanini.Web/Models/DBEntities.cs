using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProvaConhecimento.Stefanini.Web.Models
{
    public class DBEntities : DbContext
    {
        public DBEntities() : base("Database") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Classification> Classifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            modelBuilder.Entity<Region>().ToTable("Regions");
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Classification>().ToTable("Classifications");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Customer>()
             .HasRequired<Region>(s => s.Region)
             .WithMany()
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
            .HasRequired<City>(s => s.City)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
            .HasRequired<Gender>(s => s.Gender)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
            .HasRequired<Classification>(s => s.Classification)
            .WithMany()
            .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}