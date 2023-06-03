using System.Collections.Generic;
using System.Linq;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;

namespace Business.Services
{
    public class TasksByTeamServices : ITasksByTeamServices
    {
        private ITaskServices _taskServices;
        private ITeamServices _teamServices;

        public TasksByTeamServices(TaskServices taskServices, TeamServices teamServices)
        {
            _taskServices = taskServices;

            _teamServices = teamServices;
        }

        public GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO)
        {
            List<ITWorker> workers = _teamServices.GetITWorkersByTeam(getTasksByTeamRequestDTO);

            return GenerateResponseDTO(workers, _taskServices.GetAssignedTasks(workers));
        }

        private GetTaskByTeamResponseDTO GenerateResponseDTO(List<ITWorker> workers, List<TaskEntity> tasks)
        {
            GetTaskByTeamResponseDTO response = new GetTaskByTeamResponseDTO();

            foreach (var task in tasks)
            {
                var worker = workers.FirstOrDefault(w => w.Id == task.IdWorker);
                if (task.IdWorker == worker.Id)
                {
                    response.IdITWorkers.Add(worker.Id);
                    response.NamesITWorkers.Add(worker.Name);
                    response.IdTasks.Add(task.Id);
                    response.DescTasks.Add(task.Description);
                }
            }

            return response;
        }
    }
}
