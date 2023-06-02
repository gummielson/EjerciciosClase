using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Activation;
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

        public void CreatingMockWorkerData()
        {
            workers = new List<ITWorker>()
            {
                new ITWorker()
                {
                    Name = "Ada",
                    Surname = "Lovelace",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior
                },

                new ITWorker()
                {
                    Name = "Alan",
                    Surname = "Turing",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior
                },

                new ITWorker()
                {
                    Name = "Linus",
                    Surname = "Torvalds",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior
                },

                new ITWorker()
                {
                    Name = "Bill",
                    Surname = "Gates",
                    BirthDate = new DateTime(1990, 5, 15),
                    YearsOfExperience = 7,
                    ITLevel = Level.Senior
                }
            };
        }
    }
}
