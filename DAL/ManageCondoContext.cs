using ManageCondo.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManageCondoContext : DbContext
    {
        public ManageCondoContext() : base("ManageCondoContextName")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ManageCondoContext, Configuration>());
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Resident> Residents { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
