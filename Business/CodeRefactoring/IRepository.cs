using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Business.CodeRefactoring
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(ref T entity); 
        void Insert(T obj);
        void Update(ref T obj);
        void Delete(ref T id);
        void Save();
    }
}