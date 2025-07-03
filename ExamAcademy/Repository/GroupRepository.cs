using Dapper;
using ExamAcademy.Interfaces;
using ExamAcademy.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamAcademy.Repository
{
    internal class GroupRepository : IBaseRepository<Groups>
    {
        ///Dapper
        IDbConnection connection = new SqlConnection(@"Server=DESKTOP-O6DMGPJ\SQLEXPRESS;Database=EF_Academy;TrustServerCertificate=true;Trusted_Connection=True;");
        public bool Delete(Groups entity)
        {
            throw new NotImplementedException();
        }

        public Groups GetById(int id)
        {
            var sql = "SELECT * FROM Groups WHERE Group.Id=@Id";
            return connection.Query<Groups>(sql, new { @id = id }).Single();
        }

        public int Insert(Groups entity)
        {
            string query = "INSERT INTO Groups (Name,Cours, DepartmentId)  VALUES (@Name, @Cours,@DepartmentId)";
          /*  int idDep=new DepartmentRepository().GetIdByName(entity.Department.Name)*/;

            int idDep = entity.DepartmentId;
            var c = connection.Query<Curator>(query, new { @Name = entity.Name, @Cours = entity.Cours, @DepartmentId = idDep }).Count();
            return c;
        }

        public IEnumerable<Groups> Select()
        {
            throw new NotImplementedException();
        }

        public Groups Update(Groups entity)
        {
            throw new NotImplementedException();
        }
        public int GetIdByName(string name)
        {
            string query = "select Id from Groups as g where g.Name=@name";
            int id = connection.Query<int>(query, new { @name = name }).Single();
            return id;
        }
    }
}
