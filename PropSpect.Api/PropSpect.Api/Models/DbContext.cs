using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(nameOrConnectionString: "test")
        {

        }

        public DbSet<Landlord> LandLords { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaItem> AreaItems { get; set; }
        public DbSet<Entity> Enities { get; set; }
        public DbSet<InspectionArea> InspectionAreas { get; set; }
        public DbSet<InspectionAreaItem> InspectionAreaItems { get; set; }
        public DbSet<LandlordTemplate> LandlordTemplates { get; set; }
        public DbSet<LandlordTemplateArea> LandlordTemplateAreas { get; set; }
        public DbSet<LandlordTemplateAreaItem> LandlordTemplateAreaItems { get; set; }
        public DbSet<PropertyTenant> PropertyTenants { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<EnvironmentValue> EnvironmentValues { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("alpha");
            base.OnModelCreating(modelBuilder);
        }
    }
}