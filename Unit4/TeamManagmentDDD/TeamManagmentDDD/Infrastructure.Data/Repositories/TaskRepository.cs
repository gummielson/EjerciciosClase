using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<TaskEntity> GetUnassignedTasks() 
        {
            return tasks.Where(task => task.IdWorker == 0).ToList();
        }

        public List<TaskEntity> GetAssignedTasks(List<ITWorker> iTWorkers)
        {
            List<TaskEntity> taskEntities = new List<TaskEntity>();

            foreach (ITWorker worker in iTWorkers)
            {
                TaskEntity task = tasks.FirstOrDefault(t => t.IdWorker == worker.Id);

                if(task != null) 
                {
                    taskEntities.Add(task);
                }
            }

            return taskEntities;
        }

        private void CreatingMockTaskData()
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
