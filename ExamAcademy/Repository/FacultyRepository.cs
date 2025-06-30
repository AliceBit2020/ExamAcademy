using Dapper;
using ExamAcademy.Interfaces;
using ExamAcademy.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ExamAcademy.Repository
{
    public class FacultyRepository : IBaseRepository<Faculty>
    {
        IDbConnection connection = new SqlConnection(@"Server=DESKTOP-O6DMGPJ\SQLEXPRESS;Database=EF_Academy;TrustServerCertificate=true;Trusted_Connection=True;");
        public bool Delete(Faculty entity)
        {
            throw new NotImplementedException();
        }

        public Faculty GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string name)
        {
            string query = "select Id from Facultys as f where f.Name=@name";
            int id = connection.Query<int>(query, new { @name=name}).Single();
            return id;
        }
        public int Insert(Faculty entity)
        {
            string query = "INSERT INTO Facultys (Name) VALUES ( @name)";
            var id = connection.Query(query,new { @name= entity.Name });
            return id.Count();
        }

        public IEnumerable<Faculty> Select()
        {
            throw new NotImplementedException();
        }

        public Faculty Update(Faculty entity)
        {
            throw new NotImplementedException();
        }
    }
}
