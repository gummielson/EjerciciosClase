using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Utils.Enums.Enums;

namespace Business.DTO.ResponseDTO
{
    public class GetWorkersResponseDTO
    {
        public int IdWorker { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new List<string>();
        public Level ITLevel { get; set; } = new Level();
        public Rol WorkerRol { get; set; } = new Rol();
        public int IdTask { get; set; } = -1;

        public override string ToString()
        {
            string task = IdTask > 0 ? IdTask.ToString() : "Doesn´t have any task";
            return $"Id: {IdWorker}, Name: {Name}, Surname: {Surname}, Technologies: {string.Join(", ", Technologies)}, ITLevel: {ITLevel}, Rol: {WorkerRol}, Id task: {task}";
        }

    }
}
