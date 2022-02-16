using Application.Repositories;
using EC_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EC_Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll(string [] arr=null)
        {
            return (arr.Length>0)? await entities.Include(arr[0]).Include(arr[1]).Include(arr[2]).ToListAsync()
                :await entities.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await entities.FindAsync(id);
        }
        public async Task<T> Find(params object[] keyValues)
        {
            return await entities.FindAsync(keyValues);
        }
        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, params string[] includes)
        {
            IQueryable<T> query = entities;
            foreach(string include in includes)
            {
                query = entities.Include(include);
            }
            
            return await query.FirstOrDefaultAsync(expression);
        }
    }

}
