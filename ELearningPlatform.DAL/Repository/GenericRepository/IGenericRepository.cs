using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        IQueryable<T> Get();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
    }
}
