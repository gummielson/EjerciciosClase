using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Business.Controllers;
using Business.DTO.RequestDTO;
using Domain.Entities;

namespace Presentation.Screens
{
    public class Option8Screen
    {
        private readonly IITWorkerController _workerController;
        private readonly ITeamController _teamController;

        private static int _idWorker;
        private static int _idTeam;
        private static bool _invalidInput = false;

        public Option8Screen(TeamController teamController, ITWorkerController iTWorkerController)
        {
            _workerController = iTWorkerController;
            _teamController = teamController;
        }

        /// <summary>
        //
        /// </summary>
        public void Start()
        {
            GetWorkers();
            _idTeam = SelectId("worker");
            ValidateEntries();

            if(!_invalidInput) 
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                _teamController.AssignITWorkerToTeam(GenerateAssignITWorkerRequest());
            }
        }

        private void ValidateEntries()
        {
            if (_idWorker < 0)
            {
                _invalidInput = true;
            }
            else
            {
                _idTeam = SelectId("team");
                if (_idTeam < 0)
                {
                    _invalidInput = true;
                }
            };
        }

        private AssignITWorkerToTeamRequestDTO GenerateAssignITWorkerRequest()
        {
            return new AssignITWorkerToTeamRequestDTO
            {
                IdTeam = _idTeam,
                IdWorker = _idWorker,
                Manager = true
            };
        }

        private int SelectId(string type)
        {
            Console.WriteLine($"Enter a {type} id: ");
            int id;
            return int.TryParse(Console.ReadLine(), out id) ? id : -1;
        }

        private void GetWorkers()
        {
            Console.WriteLine("These are the workers:");
            foreach(var worker in _workerController.GetWorkers())
            {
                Console.WriteLine(worker.ToString());
            }
        }
    }
}
