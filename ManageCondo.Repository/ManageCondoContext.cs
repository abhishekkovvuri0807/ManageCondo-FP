using ManageCondo.DomainModels;
using ManageCondo.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.Repository
{
    public class ManageCondoContext : DbContext
    {
        public ManageCondoContext() : base("ManageCondoContextName")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ManageCondoContext, Configuration>());
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
