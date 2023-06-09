using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net.Sockets;
using Domain.Entities;
using Infrastructure.Data.DataModel;
using static Infrastructure.Utils.Enums.Enums;

namespace Domain.Repositories
{
    public class ITWorkerRepository : IITWorkerRepository
    {
        private ITWorkers workers;

        public ITWorkerRepository()
        {

        }

        public void CreateWorker(ITWorker worker)
        {
            using(TeamManagmentEntities sqlconnection = new TeamManagmentEntities())
            {
                sqlconnection.ITWorkers.Add(worker);
            }
        }

        public ITWorker GetITWorkerById(int id)
        {
            using (TeamManagmentEntities sqlconnection = new TeamManagmentEntities())
            {
                return DataEntityToEntity(sqlconnection.ITWorkers.Find(id));
            }
        }

        public void UpdateWorker(ITWorker workerEntry)
        {
            using (TeamManagmentEntities sqlconnection = new TeamManagmentEntities())
            {
                var worker = sqlconnection.ITWorkers.Find(workerEntry.Id);

            }
        }

        public List<ITWorker> GetWorkers()
        {
            using (TeamManagmentEntities sqlconnection = new TeamManagmentEntities())
            {
                return sqlconnection.ITWorkers
                    .Select(worker => DataEntityToEntity(worker))
                    .ToList();
            };
        }

        public ITWorker DataEntityToEntity(ITWorkers worker)
        {
            return new ITWorker
            {
                Id = worker.IdWorker,
                Name = worker.Name,
                Surname = worker.Name,
                BirthDate = worker.BirthDate,
                LeavingDate = worker.LeavingDate,
                ITLevel = AssignEnumLevel(worker.LevelEnum),
                IdTask = worker.IdTask,
                TechKnowledges = worker.Technologies.Select(t => t.Name).ToList(),
                WorkerRol = AssignEnumRol(worker.RolEnum),
                YearsOfExperience = worker.Experience
            };
        }

        public ITWorkers EntityToDataEntity(ITWorker worker)
        {
            return new ITWorkers
            {
                IdWorker = worker.Id,
                Name = $"{worker.Name} {worker.Surname}",
                BirthDate = worker.BirthDate,
                LeavingDate = worker.LeavingDate,
                LevelEnum = ((int)worker.ITLevel),
                IdTask = worker.IdTask,
                Technologies = worker.TechKnowledges,
                WorkerRol = AssignEnumRol(worker.RolEnum),
                YearsOfExperience = worker.Experience
            };
        }

        public Level AssignEnumLevel(int  level) 
        {
            switch(level) 
            {
                case 1:
                    return Level.Junior;
                case 2:
                    return Level.Medium;
                case 3:
                    return Level.Senior;
                default:
                    throw new Exception("Invalid level");
            }
        }

        public Rol AssignEnumRol(int rol)
        {
            switch (rol)
            {
                case 1:
                    return Rol.Worker;
                case 2:
                    return Rol.Manager;
                case 3:
                    return Rol.Admin;
                default:
                    throw new Exception("Invalid rol");
            }
        }
    }
}
