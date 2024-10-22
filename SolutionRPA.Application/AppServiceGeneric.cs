
using System;
using System.Collections.Generic;
using SolutionRPA.Application.Interface;
using SolutionRPA.Domain.Interfaces.Services;

namespace SolutionRPA.Application
{
    public class AppServiceGeneric<T> : IDisposable, IAppServiceGeneric<T> where T : class
    {
        private readonly IGenericService<T> _serviceGeneric;

        public AppServiceGeneric(IGenericService<T> serviceGeneric)
        {
            _serviceGeneric = serviceGeneric;
        }

        public T Add(T entity)
        {
            return _serviceGeneric.Add(entity);
        }

        public void Dispose()
        {
            _serviceGeneric.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceGeneric.GetAll();
        }

        public T GetById(int id)
        {
            return _serviceGeneric.GetById(id);
        }

        public void Remove(T obj)
        {
            _serviceGeneric.Remove(obj);
        }

        public void Update(T obj)
        {
            _serviceGeneric.Update(obj);
        }
    }
}
