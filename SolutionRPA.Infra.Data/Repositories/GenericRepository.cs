
using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SolutionRPA.Infra.Data.Context;
using System.Data.Entity.Migrations;
using SolutionRPA.Domain.Interfaces;
using System.Collections.Generic;

namespace SolutionRPA.Infra.Data.Repositories
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        protected readonly BancoContext _context = new BancoContext();

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
