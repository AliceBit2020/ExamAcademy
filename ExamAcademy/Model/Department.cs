using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Model
{
    public class Department
    {
        public int Id { get; set; }
         
        public int Building {  get; set; }

        public double Financing { get; set; }   

        public string Name { get; set; }=string.Empty;

        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; } = new Faculty();

<<<<<<< HEAD
        public List<Group> GroupList { get; set; }=new List<Group>();
=======
        public List<Groups> GroupList { get; set; }=new List<Groups>();
>>>>>>> 3125c14 (1)

        
    }
}
