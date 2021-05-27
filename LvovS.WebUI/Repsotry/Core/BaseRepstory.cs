using LvovS.WebUI.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Core
{
    public class BaseRepstory<T> : IBaseRepstory<T> where T : class
    {
        private AccountContactDBContext context;
        public BaseRepstory(AccountContactDBContext context)
        {
            this.context = context;
        }
        public async Task<T> CreateAsync(T Entity)
        {
            await context.AddAsync(Entity);
            return Entity;
        }

        public async Task<T> DeleteAsync(T Entity)
        {
            context.Remove(Entity);
            return Entity;
        }

        public async Task<bool> Save()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<T> UpdateAsync(T Entity)
        {
            context.Update(Entity);
            return Entity;
        }
        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predecat)
        {
            return await context.Set<T>().Where(predecat).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predecat)
        {
            return await context.Set<T>().SingleOrDefaultAsync(predecat);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return  context.Set<T>().AsQueryable(); ;
        }
    }
}
