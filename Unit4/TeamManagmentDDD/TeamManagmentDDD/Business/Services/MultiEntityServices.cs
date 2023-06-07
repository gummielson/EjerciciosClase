using System.Collections.Generic;
using System.Linq;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;
using static Infrastructure.Utils.Enums.Enums;

namespace Business.Services
{
    public class MultiEntityServices : IMultiEntityServices
    {
        private ITaskServices _taskServices;
        private ITeamServices _teamServices;
        private IITWorkerServices _workerServices;

        public MultiEntityServices(TaskServices taskServices, TeamServices teamServices, ITWorkerServices iTWorkerServices)
        {
            _taskServices = taskServices;
            _teamServices = teamServices;
            _workerServices = iTWorkerServices;
        }

        public GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO)
        {
            List<ITWorker> workers = _teamServices.GetITWorkersByTeam(getTasksByTeamRequestDTO);

            return null; // GenerateResponseDTO(workers, _taskServices.GetAssignedTasks(workers));
        }

        public void AssignITWorkerToTeam(AssignITWorkerToTeamRequestDTO assignITWorkerToTeamRequestDTO)
        {
            ITWorker worker = _workerServices.GetITWorkerById(assignITWorkerToTeamRequestDTO.IdWorker);
            Team team = _teamServices.GetTeamById(assignITWorkerToTeamRequestDTO.IdTeam);

            if (assignITWorkerToTeamRequestDTO.Manager)
            {
                AssignManagerToTeam(worker, team);
            }
            else
            {
                team.Technicians.Add(worker);
            }

            _teamServices.UpdateTeam(team);
        }

        public void AssignTaskToWorker()
        {

        }

        private void AssignManagerToTeam(ITWorker worker, Team team)
        {
            worker.WorkerRol = Rol.Manager;
            team.Manager = worker;
            _workerServices.UpdateITWorker(worker);
        }

        //private GetTaskByTeamResponseDTO GenerateResponseDTO(List<ITWorker> workers, List<TaskEntity> tasks)
        //{
        //    GetTaskByTeamResponseDTO response = new GetTaskByTeamResponseDTO();

        //    foreach (var task in tasks)
        //    {
        //        var worker = workers.FirstOrDefault(w => w.Id == task.IdWorker);
        //        if (task.IdWorker == worker.Id)
        //        {
        //            response.IdITWorkers.Add(worker.Id);
        //            response.NamesITWorkers.Add(worker.Name);
        //            response.IdTasks.Add(task.Id);
        //            response.DescTasks.Add(task.Description);
        //        }
        //    }

        //    return response;
        //}
    }
}
