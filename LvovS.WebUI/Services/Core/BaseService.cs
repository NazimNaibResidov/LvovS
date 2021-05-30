using AutoMapper;
using LvovS.WebUI.Extensions;
using LvovS.WebUI.Repsotry.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LvovS.WebUI.Services.Core
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region ::FILDS::

        private readonly IBaseRepstory<T> _repository;
        private readonly IMapper _mapper;

        #endregion ::FILDS::

        #region ::CTOR::

        public BaseService(IUnitOfWork _unitOfWork)
        {
            
            _repository = _unitOfWork.Repository<T>();
        }

        #endregion ::CTOR::

        #region ::GRUD::
        public IQueryable<T> GetAll()
        {
            return _repository.GetAll()
                .AsQueryable();
        }
        #region .:: Find methods ::.


        public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match)
        {
            return await _repository.FindByAsync(match);
        }
        public virtual async Task<T> FindByIdAsync(object id)
        {
            return await _repository.FindByIdAsync(id);
        }
        public virtual async Task<T> FindFirstAsync(Expression<Func<T, bool>> match)
        {
            return await _repository.FindFirstAsync(match);
        }



        #endregion
        public async Task<T> CreateAsync<K>(K dto)
        {
            var resultDTO = dto.Mapped<T>();
            //var resultDTO = CreateEntityInstance(dto);
            return await _repository.CreateAsync(resultDTO);
        }

        public T Remvoe<K>(K dto)
        {
            var resultDTO = FindId(dto);
            resultDTO = dto.Mapped<T>();
            return _repository.Delete(resultDTO);
        }

        public T Update<K>(K dto)
        {
            var resultDTO = FindId(dto);

            resultDTO = dto.Mapped<T>();
            return _repository.Update(resultDTO);
        }

        #endregion ::GRUD::

        #region ::HELPER::

        private T FindId<K>(K dto)
        {
            var id = typeof(K).GetProperty("Id").GetValue(dto);

            var resultDTO = _repository.FindById(id);
            if (resultDTO == null) throw new ArgumentNullException($"On Update {typeof(T).FullName} is null.");
            return resultDTO;
        }

        private TL Map<TK, TL>(TK source, TL destination)
        {
            _mapper.Map(source, destination);

            return destination;
        }

        private T CreateEntityInstance<TK>(TK source)
        {
            var destination = Activator.CreateInstance<T>();

            _mapper.Map(source, destination);

            return destination;
        }

       

        #endregion ::HELPER::
    }
}