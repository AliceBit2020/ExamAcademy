using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Model
{
<<<<<<< HEAD
    public class Group
=======
    public class Groups
>>>>>>> 3125c14 (1)
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;

        public int Cours { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }=new Department();

        public List<Curator> CuratorList { get; set; } = new List<Curator>();



    }
}
