using EC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(string[] includes =null);
        Task<T> Get(int id);
        Task<T> Find(params object[] keyValues);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        void Remove(T entity);
        Task<T> Get(Expression<Func<T, bool>> expression, params string[] includes);
        Task SaveChanges();
    }
}
