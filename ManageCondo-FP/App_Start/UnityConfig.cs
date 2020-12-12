using DAL;
using ManageCondo.Repository;
using ManageCondo.Repository.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ManageCondo_FP
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<ManageCondoContext, ManageCondoContext>();
            container.RegisterType<IPropertyRepository, PropertyRepository>();
            container.RegisterType<IUnitRepository, UnitRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IResidentRepository, ResidentRepository>();



            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}