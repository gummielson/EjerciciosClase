using System;
using System.Collections.Generic;
using Domain.Entities;
using static Infrastructure.Utils.Enums.Enums;

namespace Domain.Repositories
{
    public class ITWorkerRepository : IITWorkerRepository
    {
        private List<ITWorker> workers;

        public ITWorkerRepository()
        {
            CreatingMockWorkerData();
        }

        public void CreateWorker(ITWorker worker)
        {
            workers.Add(worker);
        }

        public ITWorker GetITWorkerById(int id)
        {
            int index = workers.FindIndex(worker => worker.Id == id);

            return index != -1 ? workers[index] : null;
        }

        public void UpdateWorker(ITWorker workerEntry)
        {
            int index = workers.FindIndex(worker => worker.Id == workerEntry.Id);

            if(index != -1) 
            {
                workers[index] = workerEntry;
            }
        }

        public List<ITWorker> GetWorkers()
        {
            return workers;
        }

        private void CreatingMockWorkerData()
        {
            workers = new List<ITWorker>()
            {
                new ITWorker()
                {
                    Name = "Ada",
                    Surname = "Lovelace",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior,
                    TechKnowledges = new List<string>()
                    {
                        "Python", "Java"
                    }
                },

                new ITWorker()
                {
                    Name = "Alan",
                    Surname = "Turing",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior,
                    TechKnowledges = new List<string>()
                    {
                        "Angular"
                    }
                },

                new ITWorker()
                {
                    Name = "Linus",
                    Surname = "Torvalds",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior,
                    TechKnowledges = new List<string>()
                    {
                        ".NET", "Java"
                    }
                },

                new ITWorker()
                {
                    Name = "Bill",
                    Surname = "Gates",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior,
                    TechKnowledges = new List<string>()
                    {
                        "Android", "React"
                    }
                }
            };
        }
    }
}
