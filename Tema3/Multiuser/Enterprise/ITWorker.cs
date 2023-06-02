using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Exercise1.Enums.Enum;

namespace Exercise1.Enterprise
{
    public class ITWorker : Worker
    {
        [Range(0, 50, ErrorMessage = "The field years of experience can´t be less than 0 and greater than 50.")]
        public int YearsOfExperience { get; set; } = 0;

        public List<string> TechKnowledges { get; set; } = new List<string>();

        public Level ITLevel { get; set; } = new Level();
    }
}
