using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamAcademy.Interfaces;

namespace ExamAcademy.Repository
{
    public class CuratorGroup : IBaseRepository
        <CuratorGroup>
    {
        public bool Delete(CuratorGroup entity)
        {
            throw new NotImplementedException();
        }

        public CuratorGroup GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(CuratorGroup entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CuratorGroup> Select()
        {
            throw new NotImplementedException();
        }

        public CuratorGroup Update(CuratorGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
