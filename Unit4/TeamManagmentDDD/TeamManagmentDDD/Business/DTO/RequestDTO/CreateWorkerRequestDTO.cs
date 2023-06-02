using System;
using System.Collections.Generic;
using static Infrastructure.Utils.Enums.Enums;

namespace Business.DTO.RequestDTO
{
    public class CreateWorkerRequestDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; } = new DateTime();

        public int YearsOfExperience { get; set; }

        public List<string> Technologies { get; set; } = new List<string>();

        public Level ITLevel { get; set; }
    }
}
