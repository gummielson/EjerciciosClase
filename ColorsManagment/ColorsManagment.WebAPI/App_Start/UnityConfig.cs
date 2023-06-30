using System.Web.Http;
using ColorsManagment.Domain.RepositoriesContracts;
using ColorsManagment.Domain.Services;
using ColorsManagment.Domain.ServicesContracts;
using ColorsManagment.Infrastructure.Data.Repositories;
using Unity;
using Unity.WebApi;

namespace ColorsManagment.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IColorServices, ColorService>();
            container.RegisterType<IColorRepository, ColorRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}