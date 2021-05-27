using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Core
{
    public interface IBaseRepstory<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> CreateAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task<T> DeleteAsync(T Entity);
       

        Task<T> GetByIdAsync(int id);

        

        Task<T> FindAsync(Expression<Func<T, bool>> predecat);

       

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predecat);

        Task<bool> Save();
    }
}
