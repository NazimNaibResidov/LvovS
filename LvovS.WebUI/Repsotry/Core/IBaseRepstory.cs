using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Core
{
    public interface IBaseRepstory<T> where T : class
    {
        #region ::FIND::
        bool FindAny(Expression<Func<T, bool>> match);
        Task<bool> FindAnyAsync(Expression<Func<T, bool>> match);
        ICollection<T> FindBy(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match);
        T FindFirst(Expression<Func<T, bool>> match);
        Task<T> FindFirstAsync(Expression<Func<T, bool>> match);
        T FindById(object id);
        Task<T> FindByIdAsync(object id);
        #endregion
        IQueryable<T> GetAll();

        Task<T> CreateAsync(T Entity);

        T Update(T Entity);

        T Delete(T Entity);

       
        Task<bool> Save();
    }
}