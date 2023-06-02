using System;
using System.Collections.Generic;
using System.Linq;
using Exercise1.Enterprise;
using Multiuser.Validations;
using static Exercise1.Enums.Enum;
using System.ComponentModel.DataAnnotations;
using System.Activities.Expressions;

namespace Multiuser
{
    public class Program
    {
        static List<Team> teams = new List<Team>();
        static List<ITWorker> iTWorkers = new List<ITWorker>();
        private readonly Validation _validations = new Validation();

        static List<Task> tasks = new List<Task>();

        public static void Main(string[] args)
        {
            bool exit = false;

            Dictionary<Rol, ITWorker> dict = Login();
            Rol rol = dict.Keys.FirstOrDefault();
            ITWorker worker = dict[rol];

            while (!exit)
            {
                switch (rol)
                {
                    case Rol.Admin:
                        Console.WriteLine("Choice an option:");
                        Console.WriteLine("1. Register new IT worker");
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
                        break;

                    case Rol.Worker:
                        Console.WriteLine("6. List unassigned tasks");
                        Console.WriteLine("7. List task assignments by team name");
                        Console.WriteLine("10. Assign task to IT worker");
                        Console.WriteLine("12. Exit");
                        break;

                    case Rol.Manager:
                        Console.WriteLine("5. List team members by team name");
                        Console.WriteLine("6. List unassigned tasks");
                        Console.WriteLine("7. List task assignments by team name");
                        Console.WriteLine("9. Assign IT worker to a team as technician");
                        Console.WriteLine("10. Assign task to IT worker");
                        Console.WriteLine("12. Exit");
                        break;
                }

                Console.Write("Choose the number of the option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        if (rol == Rol.Admin)
                        {
                            CreateITWorker();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "2":
                        if (rol == Rol.Admin)
                        {
                            CreateTeam();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "3":
                        if (rol == Rol.Admin)
                        {
                            tasks.Add(CreateTask());
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "4":
                        if (rol == Rol.Admin)
                        {
                            ListAllTeamNames();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "5":
                        if (rol == Rol.Admin || rol == Rol.Manager)
                        {
                            ListTeamMembersByTeam(SelectATeam());
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "6":
                        ListUnassignedTasks();
                        break;
                    case "7":
                        ListTasksByTeam();
                        break;
                    case "8":
                        if (rol == Rol.Admin)
                        {
                            AssignManager(SelectATeam(true));
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "9":
                        if (rol == Rol.Admin || rol == Rol.Manager)
                        {
                            AssignTechnician(SelectATeam());
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "10":
                        AssignTask(SelectAWorkerTask());
                        break;
                    case "11":
                        if (rol == Rol.Admin)
                        {
                            UnregisterWorker(SelectAWorker());
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "12":
                        if (rol == Rol.Admin)
                        {
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        Login();
                        break;
                }

                Console.Write("\nDo you want to make other operation? Write 'Yes' if you want to make another operation. Write 'No' if you dont want to make other operation.");
                switch (Console.ReadLine())
                {
                    case "Yes":
                        break;
                    case "No":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            Console.WriteLine("Write a key to end the program.");
            Console.ReadLine();
        }

        #region login

        /// <summary>
        /// Performs the login process for IT workers.
        /// </summary>
        /// <returns>A dictionary containing the login result with the corresponding role and IT worker.</returns>
        public static Dictionary<Rol, ITWorker> Login()
        {
            bool login = false;
            const int maxTries = 4;
            int tries = 0;
            Dictionary<Rol, ITWorker> dict = new Dictionary<Rol, ITWorker>();

            while (!login && tries < maxTries)
            {
                tries++;
                Console.WriteLine("Enter your id:");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid input. Try again.");
                }

                if (id == 0)
                {
                    dict.Add(Rol.Admin, null);
                    login = true;
                }
                else
                {
                    foreach (var worker in iTWorkers)
                    {
                        if (worker.Id == id)
                        {
                            if (worker.ITLevel == Level.Senior)
                            {
                                dict.Add(Rol.Manager, worker);
                            }
                            else
                            {
                                dict.Add(Rol.Worker, worker);
                            }

                            login = true;
                        }
                    }
                }
            }

            return dict;
        }
        #endregion

        #region creates

        /// <summary>
        /// Creates a new IT worker.
        /// </summary>
        public static void CreateITWorker()
        {
            try
            {
                ITWorker.Count++;
                ITWorker worker = new ITWorker();

                worker.Id = ITWorker.Count;
                worker.Name = GetName();
                worker.Surname = GetSurname();
                worker.BirthDate = GetBirthDate();
                worker.YearsOfExperience = GetYearsOfExperience();
                worker.TechKnowledges = GetTechKnowledges();
                worker.ITLevel = GetItLevel(worker.YearsOfExperience);

                _validations.ValidateObject(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nInvalid data: \n{ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new team.
        /// </summary>
        public static void CreateTeam()
        {
            Team team = new Team();

            ListAllTeamNames();

            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("Enter a team name (Can't be two teams with the same name):");
                string name = Console.ReadLine();
                if (teams.Where(team1 => team1.Name == name).Any())
                {
                    Console.WriteLine("There is already an existing team with that name. Please, introduce a different one.");
                }
                else
                {
                    loop = true;
                    team.Name = name;
                }
            }

            teams.Add(team);
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        public static Task CreateTask()
        {
            Task task = new Task();

            Console.WriteLine("Write a description for the task:");
            task.Description = Console.ReadLine();

            Console.WriteLine("Introduce task technology:");
            task.Technology = Console.ReadLine();

            return task;
        }

        #endregion

        #region lists

        /// <summary>
        /// List all team names.
        /// </summary>
        public static void ListAllTeamNames()
        {
            Console.WriteLine("These are the teams: ");

            foreach (var team in teams)
            {
                Console.WriteLine(team.Name);
            }
        }

        /// <summary>
        /// Lists the team members of a given team.
        /// </summary>
        /// <param name="team">The team to list the members for.</param>
        public static void ListTeamMembersByTeam(Team team)
        {
            if (iTWorkers.Where(mng => mng == team.Manager).Any())
            {
                ITWorker manager = iTWorkers.Where(mng => mng == team.Manager).FirstOrDefault();
                Console.WriteLine($"{manager.Name} {manager.Surname}");

            }

            foreach (var member in team.Technicians)
            {
                ITWorker currentWorker = iTWorkers.Where(worker => worker == member).FirstOrDefault();
                Console.WriteLine($"{currentWorker.Name} {currentWorker.Surname}");
            }
        }

        /// <summary>
        /// Lists all aunassigned tasks.
        /// </summary>
        public static void ListUnassignedTasks()
        {
            Console.WriteLine("Unassigned tasks: ");
            foreach (var task in tasks.Where(task1 => task1.IdWorker == 0))
            {
                Console.WriteLine($"Id: {task.Id} Description: {task.Description} Task: {task.Technology}");
            }
        }

        /// <summary>
        /// Lists tasks by team.
        /// </summary>
        public static void ListTasksByTeam()
        {
            List<ITWorker> workers = new List<ITWorker>();
            foreach (var tecnician in SelectATeam().Technicians)
            {
                workers.Add(iTWorkers.Where(iTWorker => iTWorker == tecnician).ToList().FirstOrDefault());
            }

            Console.WriteLine("These are the team tasks");
            foreach (var worker in workers)
            {
                foreach (var task in tasks.Where(task => task.IdWorker == worker.Id))
                {
                    Console.WriteLine(task.Description);
                }
            }
        }
        #endregion

        #region assignments

        /// <summary>
        /// Assigns a manager to a team.
        /// </summary>
        /// <param name="team">The team to assign the manager to.</param>
        public static void AssignManager(Team team)
        {
            Console.WriteLine("Choose a manager for your team. These are the avaliable managers.");
            List<ITWorker> avaibleManagers = new List<ITWorker>();

            foreach (var worker in iTWorkers.Where(manager => manager.ITLevel == Level.Senior))
            {
                if (teams.Any())
                {
                    if (!teams.Where(team1 => team1.Manager == worker).Any())
                    {
                        if (!avaibleManagers.Contains(worker))
                        {
                            avaibleManagers.Add(worker);
                        }
                    }
                }
                else
                {
                    avaibleManagers.Add(worker);
                }
            }

            foreach (var mng in avaibleManagers)
            {
                Console.WriteLine($"Id: {mng.Id} Name: {mng.Name} {mng.Surname}");
            }

            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("Enter the id of the avaible manager:");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                else if (avaibleManagers.Where(avbMng => avbMng.Id == id).Any())
                {
                    team.Manager.Id = id;
                    loop = true;
                }
                else
                {
                    Console.WriteLine("The input id doesn't match with any of the available ids");
                }

            }
        }


        /// <summary>
        /// Assigns a technician to a team.
        /// </summary>
        /// <param name="team">The team to assign the technician to.</param>
        public static void AssignTechnician(Team team)
        {
            ITWorker worker = SelectAWorker();
            team.Technicians.Add(worker);
        }


        /// <summary>
        /// Assigns a task to a worker.
        /// </summary>
        /// <param name="worker">The worker to assign the task to.</param>
        public static void AssignTask(ITWorker worker)
        {
            ListUnassignedTasks();
            Task task = new Task();
            bool loop = false;

            while (!loop)
            {
                Console.WriteLine("Select a task by ID");
                string id = Console.ReadLine();

                if (!tasks.Where(task1 => task1.Id == id).Any())
                {
                    Console.WriteLine("The input id doesn't match with any of the avaliable ids");
                }
                else
                {
                    task = tasks.Where(task1 => task1.Id == id).FirstOrDefault();
                    loop = true;
                }
            }

            foreach (var tech1 in worker.TechKnowledges)
            {
                if (tech1 == task.Technology)
                {
                    task.IdWorker = worker.Id;
                }
                else
                {
                    Console.WriteLine("The selected worker doesn't knows the task technology");
                }
            }



        }
        #endregion

        #region unregister

        /// <summary>
        /// Unregister a worker.
        /// </summary>
        /// <param name="team">The worker to unregsiter.</param>
        public static void UnregisterWorker(ITWorker worker)
        {
            iTWorkers.Remove(worker);
            if (tasks.Where(task => task.IdWorker == worker.Id).Any())
            {
                tasks.Where(task => task.IdWorker == worker.Id).FirstOrDefault().IdWorker = 0;
            }
        }
        #endregion

        #region assits methods

        /// <summary>
        /// Selects a team.
        /// </summary>
        /// <param name="manager">Flag indicating if the selection is for a manager.</param>
        /// <returns>The selected team.</returns>
        public static Team SelectATeam(bool manager = false)
        {
            Team team = new Team();
            bool loop = false;
            List<Team> teamsNoMng = new List<Team>();

            if (!manager)
            {
                ListAllTeamNames();
            }
            else
            {
                Console.WriteLine("These are the teams without an assigned manager");
                teamsNoMng = teams.Where(team2 => team2.Manager.Id == 0).ToList();
                foreach (var team1 in teamsNoMng)
                {
                    Console.WriteLine(team1.Name);
                }
            }

            while (!loop)
            {
                Console.WriteLine("Enter the team:");
                string name = Console.ReadLine();
                bool foundTeam = false;

                if (!manager)
                {
                    foundTeam = teams.Where(team1 => team1.Name == name).Any();
                }
                else
                {
                    foundTeam = teamsNoMng.Where(team1 => team1.Name == name).Any();
                }

                if (!foundTeam)
                {
                    Console.WriteLine("There is no team with that name. Please, introduce a different one.");
                }
                else
                {
                    team = teams.Where(team1 => team1.Name == name).FirstOrDefault();
                    loop = true;
                }
            }

            return team;
        }

        /// <summary>
        /// Selects an IT worker for a team.
        /// </summary>
        /// <returns>The selected IT worker.</returns>
        public static ITWorker SelectAWorkerTeam()
        {
            ITWorker worker = new ITWorker();
            bool loop = false;

            while (!loop)
            {
                Console.WriteLine("Choose a worker for your team. These are the avaliable workers.");
                List<ITWorker> avaibleWorkers = new List<ITWorker>();
                foreach (var worker1 in iTWorkers)
                {
                    foreach (var currentTeam in teams)
                    {
                        if (!currentTeam.Technicians.Contains(worker1))
                        {
                            Console.WriteLine($"Id: {worker1.Id} Name: {worker1.Name} {worker1.Surname}");
                            avaibleWorkers.Add(worker1);
                        }
                    }
                }

                bool loop1 = false;
                while (!loop1)
                {
                    Console.WriteLine("Enter the id of the avaliable worker:");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                    else if (avaibleWorkers.Where(foundWorker => foundWorker.Id == id).Any())
                    {
                        worker = avaibleWorkers.Where(foundWorker => foundWorker.Id == id).FirstOrDefault();
                        loop1 = true;
                    }
                    else
                    {
                        Console.WriteLine("The input id doesn't match with any of the avaliable ids");
                    }
                }
            }

            return worker;
        }

        /// <summary>
        /// Selects an IT worker for a task.
        /// </summary>
        /// <returns>The selected IT worker.</returns>
        public static ITWorker SelectAWorkerTask()
        {
            ITWorker worker = new ITWorker();
            bool loop = false;

            while (!loop)
            {
                Console.WriteLine("Choose a worker for your task. These are the avaliable workers.");
                List<ITWorker> avaibleWorkers = new List<ITWorker>();
                foreach (var worker1 in iTWorkers)
                {
                    if (!tasks.Where(currentTask => currentTask.IdWorker == worker1.Id).Any())
                    {
                        Console.WriteLine($"Id: {worker1.Id} Name: {worker1.Name} {worker1.Surname}");
                        avaibleWorkers.Add(worker1);
                    }
                }

                bool loop1 = false;
                while (!loop1)
                {
                    Console.WriteLine("Enter the id of the avaliable worker:");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                    else if (!avaibleWorkers.Where(foundWorker => foundWorker.Id == id).Any())
                    {
                        worker = avaibleWorkers.Where(foundWorker => foundWorker.Id == id).FirstOrDefault();
                        loop1 = true;
                    }
                    else
                    {
                        Console.WriteLine("The input id doesn't match with any of the avaliable ids");
                    }
                }
            }

            return worker;
        }

        /// <summary>
        /// Selects an IT worker.
        /// </summary>
        /// <returns>The selected IT worker.</returns>
        public static ITWorker SelectAWorker()
        {
            ITWorker worker = new ITWorker();
            bool loop = false;

            while (!loop)
            {
                Console.WriteLine("Choose a worker.");
                foreach (var worker1 in iTWorkers)
                {
                    Console.WriteLine($"Id: {worker1.Id} Name: {worker1.Name} {worker1.Surname}");
                }


                bool loop1 = false;
                while (!loop1)
                {
                    Console.WriteLine("Enter the id of the avaliable worker:");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                    else if (iTWorkers.Where(foundWorker => foundWorker.Id == id).Any())
                    {
                        worker = iTWorkers.Where(foundWorker => foundWorker.Id == id).FirstOrDefault();
                        loop1 = true;
                        loop = true;
                    }
                    else
                    {
                        Console.WriteLine("The input id doesn't match with any of the avaliable ids");
                    }
                }
            }

            return worker;
        }
        #endregion

        #region get data
        public static string GetName()
        {
            Console.WriteLine("Enter a name:");
            return Console.ReadLine();
        }

        public static string GetSurname()
        {
            Console.WriteLine("Enter a surname:");
            return Console.ReadLine();
        }

        public static DateTime GetBirthDate()
        {
            Console.WriteLine("Enter a birth date (MM/dd/yyyy), must be of legal age: ");
            return DateTime.TryParseExact(
                Console.ReadLine(),
                "MM/dd/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime birthday) ? birthday : new DateTime();
        }

        public static int GetYearsOfExperience()
        {
            Console.WriteLine("Enter years of experience, must be postive and numeric: ");
            return int.TryParse(Console.ReadLine(), out int years) ? years : 0;
        }

        public static List<string> GetTechKnowledges()
        {
            List<string> techs = new List<string>();

            string input;
            do
            {
                Console.WriteLine("Enter a tecch (or 'No' to continue): ");
                input = Console.ReadLine();
                if (input != "No")
                {
                    techs.Add(input);
                }
            } while (input != "No");

            return techs;
        }

        public static Level GetItLevel(int years)
        {
            Console.WriteLine("Enter a level (Junior, Medium and Senior are the accepted values): ");
            switch (Console.ReadLine())
            {
                case "Junior":
                    return Level.Junior;
                case "Medium":
                    return Level.Medium;
                case "Senior":
                    if (years >= 5)
                    {
                        return Level.Senior;
                    }
                    else
                    {
                        Console.WriteLine("A senior dev has to have at least 5 years of expirience. Returning junior level by default.");
                        return Level.Junior;
                    }
                default:
                    Console.WriteLine("Invalid option. Returns junior level by default.");
                    return Level.Junior;
            }
        }
        #endregion

        #region validations
        #endregion

    }
}
