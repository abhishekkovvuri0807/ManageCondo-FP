namespace ManageCondo.Repository.Migrations
{
    using ManageCondo.DomainModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManageCondo.Repository.ManageCondoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ManageCondo.Repository.ManageCondoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            List<Role> roles = new List<Role>
            {
                new Role {Name="Admin", Description = "Admin" },
                new Role {Name="Abh", Description = "Abh" },
                new Role {Name="Abhi", Description = "Abhi" },
                new Role {Name="sdfsf", Description = "sdfsd" },
                new Role {Name="sdfdssf", Description = "sdsdfdfsd" },



            };
            roles.ForEach(r => context.Roles.AddOrUpdate(r));
        }
    }
}
