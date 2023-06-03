using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Controllers;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Presentation.Screens
{
    public class Option6Screen
    {
        private readonly ITaskController _taskController;

        public Option6Screen(TaskController taskController)
        {
            _taskController = taskController;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            GetUnassignedTasks();
        }

        public void GetUnassignedTasks()
        {
            Console.WriteLine(_taskController.GetUnassignedTasks().ToString());
        }
    }
}
