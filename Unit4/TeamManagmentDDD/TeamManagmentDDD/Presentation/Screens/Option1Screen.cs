using System;
using System.Collections.Generic;
using Business.Controllers;
using Business.DTO.RequestDTO;
using static Infrastructure.Utils.Enums.Enums;

namespace Presentation.Screens
{
    public class Option1Screen
    {        
        private readonly IITWorkerController _workerController;

        public Option1Screen(ITWorkerController workerController)
        {
            _workerController = workerController;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {

            CreateWorkerRequestDTO worker = new CreateWorkerRequestDTO()
            {
                Name = GetName(),
                Surname = GetSurname(),
                BirthDate = GetBirthDate(),
                YearsOfExperience = GetYearsOfExperience(),
                Technologies = GetTechKnowledges(),
                ITLevel = GetItLevel()
            };

            Console.WriteLine(_workerController.CreateWorker(worker).ResultMessage);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            Console.WriteLine("Enter a name:");
            return Console.ReadLine();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetSurname()
        {
            Console.WriteLine("Enter a surname:");
            return Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime GetBirthDate()
        {
            Console.WriteLine("Enter a birth date (dd/mm/yyyy), must be of legal age: ");
            return DateTime.TryParseExact(
                Console.ReadLine(),
                "dd/MM/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime birthday) ? birthday : new DateTime();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetYearsOfExperience()
        {
            Console.WriteLine("Enter years of experience, must be postive and numeric: ");
            return int.TryParse(Console.ReadLine(), out int years) ? years : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetTechKnowledges()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public Level GetItLevel()
        {
            Console.WriteLine("Enter a level (Junior, Medium and Senior are the accepted values): ");
            switch (Console.ReadLine())
            {
                case "Junior":
                    return Level.Junior;
                case "Medium":
                    return Level.Medium;
                case "Senior":
                    return Level.Senior;
                default:
                    Console.WriteLine("Invalid option. Returns junior level by default.");
                    return Level.Junior;
            }
        }
    }
}
