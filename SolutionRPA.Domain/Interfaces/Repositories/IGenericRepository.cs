using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolutionRPA.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //CRUD
        T Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
        void Dispose();
    }
}
