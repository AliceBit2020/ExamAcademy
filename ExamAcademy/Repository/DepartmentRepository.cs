using Dapper;
using ExamAcademy.Interfaces;
using ExamAcademy.Model;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Repository
{
    internal class DepartmentRepository : IBaseRepository<Department>
    {
        IDbConnection connection = new SqlConnection(@"Server=DESKTOP-O6DMGPJ\SQLEXPRESS;Database=EF_Academy;TrustServerCertificate=true;Trusted_Connection=True;");




        /// new Department() {Building= 1,Financing= 50000, Name="Computer Science",Faculty= faculties[0] }
        public int Insert(Department entity)
        {
            FacultyRepository fr = new FacultyRepository();
            
            int fId=fr.GetIdByName(entity.Faculty.Name);
          
            string query = "INSERT INTO Departments (Building, Financing,Name,FacultyId) VALUES (@build, @financing, @name,@FacultyId)";
          var id= connection.Query(query, new { @build=entity.Building, @financing=entity.Financing, @name=entity.Name,@FacultyId=fId});
            return id.Count();
            
        }

<<<<<<< HEAD
=======
        public int GetIdByName(string name)
        {
            string query = "select Id from Departments as d where d.Name=@name";
            int id = connection.Query<int>(query, new { @name = name }).Single();
            return id;
        }
>>>>>>> 3125c14 (1)
        public bool Delete(Department dep)
        {
            var sql = "DELETE FROM Departments WHERE Id=@Id";
            connection.Execute(sql, new { @Id = dep.Id });
            return true;
        }

        public Department GetById(int id)
        {
            var sql = "SELECT * FROM Departments WHERE Departments.Id=@Id";
            return connection.Query<Department>(sql, new { @id=id }).Single();
        }

        public IEnumerable<Department> Select()
        {
            var sql = "SELECT * FROM Departments as d JOIN Facultys as f ON d.FacultyId=f.Id";


            return connection.Query<Department, Faculty, Department>(sql, (dep, faculty) => { dep.Faculty = faculty;return dep; },splitOn: "FacultyId").ToList();
        }

       public Department Update(Department dep)
        {
            var sql = "UPDATE Department SET Name=@Name,Building =@Building , Financing=@Financing FacultyId=@FacultyId WHERE Id=@Id  ";
            connection.Execute(sql, dep);
            return dep; 
        }
    }
}
