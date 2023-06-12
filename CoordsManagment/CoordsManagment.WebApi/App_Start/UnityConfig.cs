using System.Web.Http;
using CoordsManagment.Domain.RepositoryContracts;
using CoordsManagment.Domain.Services;
using CoordsManagment.Domain.ServicesContracts;
using CoordsManagment.Infrastructure.Data.Repositories;
using Unity;
using Unity.WebApi;

namespace CoordsManagment.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<ICoordinateService, CoordinatesService>();
            container.RegisterType<ICoordinateRepository, CoordinatesRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}