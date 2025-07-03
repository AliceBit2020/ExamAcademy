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
           //  AddData1();
           // Select();


            AddCuratorsGroups();
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
        public static void AddCuratorsGroups()
        {
            CuratorRepository curator_repo = new CuratorRepository();
            GroupRepository group_repo = new GroupRepository();

            List<Curator> curators = new List<Curator>()
            {
                new Curator(){ Name="Curator1", Surname="Curator1Surname1"},
                 new Curator(){ Name="Curator2", Surname="Curator2Surname2"},
                  new Curator(){ Name="Curator3", Surname="Curator3Surname3"},
                   new Curator(){ Name="Curator4", Surname="Curator4Surname4"}
            };

            List<Groups> groups = new List<Groups>()
            {
                new Groups(){Name="Group1",Cours=1,DepartmentId=3},
                new Groups(){Name="Group2",Cours=1,DepartmentId=4},
                new Groups(){Name="Group3",Cours=2,DepartmentId=5},
                new Groups(){Name="Group4",Cours=2,DepartmentId=3},
                new Groups(){Name="Group5",Cours=3,DepartmentId=6},
                new Groups(){Name="Group6",Cours=3,DepartmentId=4}
            };

            //foreach (var g in groups)
            //{
            //    group_repo.Insert(g);
            //}

            curators[0].GroupsList.Add(groups[0]);
            curators[0].GroupsList.Add(groups[1]);

            curators[1].GroupsList.Add(groups[0]);
            curators[1].GroupsList.Add(groups[2]);

            curators[2].GroupsList.Add(groups[4]);
            curators[2].GroupsList.Add(groups[5]);

            curators[3].GroupsList.Add(groups[4]);
            curators[3].GroupsList.Add(groups[3]);

            //foreach (var c in curators)
            //{
            //    curator_repo.Insert(c);
            //}


            

            //foreach (var c in curators)
            //{
            //    curator_repo.InsertGroupList(c);
            //}

            //Curator curator = new Curator() { Name = "Curator5", Surname = "Curator5Surname5" };
            //curator.GroupsList.Add(groups[4]);

            //curator_repo.Insert(curator);

            Curator curator2 = new Curator() { Name = "Curator6", Surname = "Curator6Surname6" };
            curator2.GroupsList.Add(groups[1]);

            curator_repo.Insert(curator2);

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
