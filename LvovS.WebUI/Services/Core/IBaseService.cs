using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace LvovS.WebUI.Services.Core
{
    public interface IBaseService<T> where T : class
    {

        #region ::FIND::
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match);
        Task<T> FindByIdAsync(object id);
        Task<T> FindFirstAsync(Expression<Func<T, bool>> match);
        #endregion
        IQueryable<T> GetAll();

        Task<T> CreateAsync<K>(K dto);

        T Remvoe<K>(K dto);

        T Update<K>(K dto);
    }
}