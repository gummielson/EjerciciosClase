using System.Web.Http;
using System.Web.Mvc;
using Application.Services;
using Domain.IRepositories;
using Domain.IServices;
using Infrastructure.Repositories;
using Unity;
using Unity.AspNet.Mvc;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            IUnityContainer container = new UnityContainer();
            RegisterTypes(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        static void RegisterTypes(IUnityContainer container)
        {
            #region IoC
            container.RegisterType<ISchoolRepository, SchoolRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IClassroomRepository, ClassroomRepository>();

            container.RegisterType<ISchoolService, SchoolService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IClassroomService, ClassroomService>();
            #endregion
        }
    }
}
