
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SolutionRPA.Domain.Services
{
    public class GenericService<T> : IDisposable, IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
           return _repository.GetById(id);
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);    
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
