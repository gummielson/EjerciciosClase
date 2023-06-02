using System;
using System.Collections.Generic;
using Domain.Entities;
using static Infrastructure.Utils.Enums.Enums;

namespace Infrastructure.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public List<TaskEntity> tasks;

        public TaskRepository()
        {
            CreatingMockTaskData();
        }

        public void CreateTask(TaskEntity task)
        {
            tasks.Add(task);
        }

        public void CreatingMockTaskData()
        {
            tasks = new List<TaskEntity>()
            {
                new TaskEntity()
                {
                    Description = "Task1",
                    Technology = "c#"
                },

                new TaskEntity()
                {
                    Description = "Task2",
                    Technology = "Java"
                },

                new TaskEntity()
                {
                    Description = "Task3",
                    Technology = "Python"
                },

                new TaskEntity()
                {
                    Description = "Task4",
                    Technology = "Angular"
                }
            };
        }
    }
}
