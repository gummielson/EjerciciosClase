using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Infrastructure.Utils.Enums.Enums;

namespace Domain.Entities
{
    public class Team
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ITWorker Manager { get; set; }

        public List<ITWorker> Technicians { get; set; } = new List<ITWorker>();

        public void AssignManager(ITWorker worker)
        {
            if(worker.ITLevel == Level.Senior)
            {
                Manager = worker;
            }
            else
            {
                throw new Exception("The selected worker can´t be manager");
            }
        }

        public void AddTechnician(ITWorker worker) 
        {
            Technicians.Add(worker);
        }

        public void HasAManager()
        {
            if(Manager != null) 
            {
                throw new Exception("Team already has a manager");
            }
        }
    }
}
