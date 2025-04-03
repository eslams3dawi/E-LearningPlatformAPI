using ELearningPlatform.DAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ELearningContext _context;
        public readonly DbSet<T> _DbSet;
        public GenericRepository(ELearningContext context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
        public IQueryable<T> Get()
        {
            return _DbSet.AsQueryable();
        }
        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }
        public void Update(T entity)
        {
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
