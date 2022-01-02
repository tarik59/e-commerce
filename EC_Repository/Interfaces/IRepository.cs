using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC_Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        void Remove(T entity);
        Task SaveChanges();
    }
}
