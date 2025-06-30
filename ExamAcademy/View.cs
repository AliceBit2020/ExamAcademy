using ExamAcademy.Model;
using ExamAcademy.Repository;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.VisualBasic;

namespace ExamAcademy
{
    internal class View
    {
        static void Main(string[] args)
        {
           // AddData1();
            Select();
        }
        public static void Select()
        {
            DepartmentRepository dep_repo = new DepartmentRepository();
            List<Department> list = dep_repo.Select().ToList();

            foreach (var dep in list)
            {
                Console.WriteLine($"Department: {dep.Name}  on Faculty {dep.Faculty.Name}");
            }

        }

        public void UpdateDep ()
        {



        }
        public static void AddData1()
        {
            DepartmentRepository dep_repo = new DepartmentRepository();
            FacultyRepository faculty_repo = new FacultyRepository();

            List<Faculty> faculties = new List<Faculty>()
            {
                new Faculty() { Name = "Computer Science" },
                new Faculty() { Name = "Software Development" },
                new Faculty() { Name = "Engineering" }
            };
            foreach (var item in faculties)
            {
                faculty_repo.Insert(item);
            }


            List<Department> departments = new List<Department>()
            {
                new Department() {Building= 1,Financing= 50000, Name="Computer Science",Faculty= faculties[0] },
                new Department() {Building= 2,Financing= 40000, Name="Software Engineering",Faculty= faculties[2] },
                 new Department() {Building= 2,Financing= 120000, Name="Software Development",Faculty= faculties[1] },
                  new Department() {Building= 3,Financing= 40000, Name=" Engineering",Faculty= faculties[2] }


            };

            foreach (var dep in departments)
            {
                dep_repo.Insert(dep);
            }
        }
    }
}
