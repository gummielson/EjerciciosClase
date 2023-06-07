using System;
using Business.Controllers;

namespace Presentation.Screens
{
    public class MainMenuScreen
    {
        #region private fields

        private string _option;

        private readonly IITWorkerController _iITWorkerController;
        private readonly ITeamController _teamController;
        private readonly ITaskController _taskController;
        private readonly IMultiEntityController _tasksByTeamController;

        private readonly Option1Screen _option1Screen;
        private readonly Option2Screen _option2Screen;
        private readonly Option3Screen _option3Screen;
        private readonly Option4Screen _option4Screen;
        private readonly Option5Screen _option5Screen;
        private readonly Option6Screen _option6Screen;
        private readonly Option7Screen _option7Screen;
        private readonly Option8Screen _option8Screen;
        #endregion

        public MainMenuScreen(ITWorkerController iTWorkerController, TeamController teamController, TaskController taskController, MultiEntityController multiEntityController)
        {
            _teamController = teamController;
            _taskController = taskController;
            _iITWorkerController = iTWorkerController;
            _tasksByTeamController = multiEntityController;

            #region screens
            _option1Screen = new Option1Screen(iTWorkerController);
            _option2Screen = new Option2Screen(teamController);
            _option3Screen = new Option3Screen(taskController);
            _option4Screen = new Option4Screen(teamController);
            _option5Screen = new Option5Screen(teamController);
            _option6Screen = new Option6Screen(taskController);
            _option7Screen = new Option7Screen(multiEntityController);
            _option8Screen = new Option8Screen(teamController, iTWorkerController);
            #endregion
        }

        public void Start()
        {
            do
            {
                PrintOptions();
                ProcessOption();
            } while (_option != "12");

            Console.Write("\nPress any key to close the program: ");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrintOptions()
        {
            Console.WriteLine("\n1. Register new IT worker");
            Console.WriteLine("2. Register new team");
            Console.WriteLine("3. Register new task (unassigned to anyone)");
            Console.WriteLine("4. List all team names");
            Console.WriteLine("5. List team members by team name");
            Console.WriteLine("6. List unassigned tasks");
            Console.WriteLine("7. List task assignments by team name");
            Console.WriteLine("8. Assign IT worker to a team as manager");
            Console.WriteLine("9. Assign IT worker to a team as technician");
            Console.WriteLine("10. Assign task to IT worker");
            Console.WriteLine("11. Unregister worker");
            Console.WriteLine("12. Exit");

            Console.Write("Choose the number of the option: ");
            _option = Console.ReadLine();
            Console.WriteLine("\n");

        }

        /// <summary>
        /// 
        /// </summary>
        private void ProcessOption() 
        {
            switch (_option)
            {
                case "1":
                    _option1Screen.Start();
                    break;
                case "2":
                    _option2Screen.Start();
                    break;
                case "3":
                    _option3Screen.Start();
                    break;
                case "4":
                    _option4Screen.Start();
                    break;
                case "5":
                    _option5Screen.Start();
                    break;
                case "6":
                    _option6Screen.Start();
                    break;
                case "7":
                    _option7Screen.Start();
                    break;
                case "8":
                    _option8Screen.Start();
                    break;
                case "12":
                    break;
            }
        }
    }
}
