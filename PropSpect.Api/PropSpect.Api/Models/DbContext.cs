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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("alpha");
            base.OnModelCreating(modelBuilder);
        }
    }
}