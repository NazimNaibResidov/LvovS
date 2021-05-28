using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LvovS.WebUI.Services.interf
{
    public interface IEntityService<T> where T : class
    {
        IQueryable<T> Query();

        #region .:: CRUD ::.

        #region add

        Task<T> AddAsync<TK>(TK dto, bool isUnCommitted = false);
        T Add<TK>(TK dto, bool isUnCommitted = false);
        T Add(T entity, bool isUnCommitted = false);
        Task AddRangeAsync(ICollection<T> entities, bool isUnCommitted = false);
        Task<T> AddAsync(T entity, bool isUnCommitted = false);
        Task<TK> AddMappedAsync<TK>(TK dto);

        #endregion

        #region update

        Task UpdateAsync<TK>(TK dto, bool isUnCommitted = false);

        Task UpdateRangeAsync(ICollection<T> entities, bool isUnCommitted = false);

        #endregion

        #region delete

        Task DeleteAsync(object id, bool isUnCommitted = false);

        Task DeleteRangeAsync(ICollection<T> entities, bool isUnCommitted = false);
        #endregion

        #endregion

        #region .:: Find ::.

        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match);
        Task<ICollection<TK>> FindByMappedAsync<TK>(Expression<Func<T, bool>> match);
        Task<bool> FindAnyAsync(Expression<Func<T, bool>> match);
        Task<T> FindByIdAsync(object id);
        Task<TK> FindByIdAsync<TK>(object id);
        Task<T> FindFirstAsync(Expression<Func<T, bool>> match);
        Task<TK> FindFirstAsync<TK>(Expression<Func<T, bool>> match);
        bool FindAny(Expression<Func<T, bool>> match);

        #endregion
    }
}
