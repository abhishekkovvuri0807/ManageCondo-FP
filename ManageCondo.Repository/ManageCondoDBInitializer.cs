//using ManageCondo.DomainModels;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ManageCondo.Repository
//{
//    public class ManageCondoDBInitializer : DropCreateDatabaseAlways<ManageCondoContext>
//    {
//        protected override void Seed(ManageCondoContext context)
//        {
//            List<Role> roles = new List<Role>
//            {
//                new Role {Name="Admin", Description = "Admin" },
//                new Role {Name="Abh", Description = "Abh" },
//                new Role {Name="Abhi", Description = "Abhi" },

//            };
//            context.Roles.AddRange(roles);
//            base.Seed(context);
//        }
//    }
//}
