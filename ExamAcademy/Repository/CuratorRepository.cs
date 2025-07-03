using Dapper;
using ExamAcademy.Interfaces;
using ExamAcademy.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace ExamAcademy.Repository
{
    internal class CuratorRepository:IBaseRepository<Curator>
    {
        IDbConnection connection = new SqlConnection(@"Server=DESKTOP-O6DMGPJ\SQLEXPRESS;Database=EF_Academy;TrustServerCertificate=true;Trusted_Connection=True;");

        public bool Delete(Curator entity)
        {
            var sql = "DELETE FROM Curators WHERE Id=@Id";
            connection.Execute(sql, new { @Id = entity.Id });
            return true;
        }

        public Curator GetById(int id)
        {
            var sql = "SELECT * FROM Departments WHERE Departments.Id=@Id";
            return connection.Query<Curator>(sql, new { @id = id }).Single();
        }

        public int Insert(Curator entity)
        {
            int c = 0;
            using (var scope = new TransactionScope())
            {
                string query = "INSERT INTO Curators (Name,Surname)  VALUES (@Name, @Surname)";

                 c = connection.Query<Curator>(query, new { @Name = entity.Name, @Surname = entity.Surname }).Count();
                if (entity.GroupsList.Count > 0)
                {
                    InsertGroupList(entity);
                }
                scope.Complete();
            }
            
            return c;
        }

        public int InsertGroupList(Curator curator)
        {
            string query = "INSERT INTO CuratorGroups (CuratorListId,GroupsListId) VALUES (@CuratorId,@GroupId)"; 
           
            
                foreach (var curatorGroup in curator.GroupsList) {
                connection.Query(query, new
                {
                    @CuratorId =GetIdByName(curator.Name+","+curator.Surname),
                    @GroupId = new GroupRepository().GetIdByName(curatorGroup.Name)
                });


               
                }


            return 0;


        }
        public int GetIdByName(string nameSurname)
        {
            string[] n_s=nameSurname.Split(',');

            string query = "select Id from Curators as c where c.Name=@name and c.Surname=@surname";
            int id = connection.Query<int>(query, new { @name = n_s[0], @surname = n_s[1] }).FirstOrDefault();
            return id;
        }

        public IEnumerable<Curator> Select()
        {
            throw new NotImplementedException();
        }

        public Curator Update(Curator entity)
        {
            throw new NotImplementedException();
        }
    }
}
