using LibraryManagment.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class Repoistory<T> : IRepository<T> where T : class
    {
        protected LibraryContext _context;
        public Repoistory(LibraryContext context)
        {
            _context = context;
        }
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        protected void Save() => _context.SaveChanges();
    }
}
