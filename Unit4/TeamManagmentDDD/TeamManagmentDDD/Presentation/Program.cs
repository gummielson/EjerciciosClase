using System;
using Business.Controllers;
using Business.Services;
using Domain.Repositories;
using Infrastructure.Data.Repositories;
using Presentation.Screens;
using Unity;

namespace Presentation
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Registering dependencies ...");
            IUnityContainer container = new UnityContainer();

            MainMenuScreen mainMenu = container.Resolve<MainMenuScreen>();

            mainMenu.Start();

            Console.Write("Pulse cualquier tecla para terminar...");
            Console.ReadKey();
        }

        static void RegisterTypes(IUnityContainer container)
        {
            #region repositories dependency
            container.RegisterType<ITaskServices, TaskServices>(TypeLifetime.Singleton);
            container.RegisterType<ITeamRepository, TeamRepository>(TypeLifetime.Singleton);
            container.RegisterType<IITWorkerRepository, ITWorkerRepository>(TypeLifetime.Singleton);
            #endregion

            #region services dependency
            container.RegisterType<IMultiEntityController, MultiEntityController>();
            container.RegisterType<ITaskServices, TaskServices>();
            container.RegisterType<ITeamServices, TeamServices>();
            container.RegisterType<IITWorkerServices, ITWorkerServices>();
            #endregion

            #region controllers dependency
            container.RegisterType<IMultiEntityController, MultiEntityController>();
            container.RegisterType<ITaskController, TaskController>();
            container.RegisterType<ITeamController, TeamController>();
            container.RegisterType<IITWorkerController, ITWorkerController>();
            #endregion

            container.RegisterType<MainMenuScreen>();
        }
    }
}
