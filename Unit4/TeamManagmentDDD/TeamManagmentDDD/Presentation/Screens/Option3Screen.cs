using System;
using Business.Controllers;
using Business.DTO.RequestDTO;

namespace Presentation.Screens
{
    public class Option3Screen
    {
        private readonly ITaskController _taskController;

        public Option3Screen(TaskController taskController)
        {
            _taskController = taskController;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {

            CreateTaskRequestDTO taskRequest = new CreateTaskRequestDTO()
            {
                Description = GetDescription(),
                Technology = GetTechnology()
            };

            Console.WriteLine(_taskController.CreateTask(taskRequest).ResultMessage);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            Console.WriteLine("Enter the task name:");
            return Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetTechnology()
        {
            Console.WriteLine("Enter the technology:");
            return Console.ReadLine();
        }
    }
}
