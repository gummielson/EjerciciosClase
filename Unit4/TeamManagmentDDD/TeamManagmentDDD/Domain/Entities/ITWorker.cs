using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Infrastructure.Utils.Enums.Enums;

namespace Domain.Entities
{
    public class ITWorker : Worker
    {
        [Range(0, 50, ErrorMessage = "The field years of experience can´t be less than 0 and greater than 50.")]
        public int YearsOfExperience { get; set; }

        public List<string> TechKnowledges { get; set; } = new List<string>();

        public Level ITLevel { get; set; } = new Level();

        #region validations

        /// <summary>
        /// Validate if a worker can be a senior
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void CanBeSenior()
        {
            if(YearsOfExperience >= 5 && ITLevel == Level.Senior)
            {
                throw new Exception("This worker can't be senior because of his years of experience are less than 5.");
            }
        }
        #endregion
    }
}
