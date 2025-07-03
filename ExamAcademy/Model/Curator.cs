using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Model
{
    public class Curator
    {
        public int Id { get; set; }
        public string Name { get; set; } = "default";
        public string Surname { get; set; } = "default";

<<<<<<< HEAD
        public List<Group> GroupsList { get; set; } = new List<Group>();
=======
        public List<Groups> GroupsList { get; set; } = new List<Groups>();
>>>>>>> 3125c14 (1)
    }
}
