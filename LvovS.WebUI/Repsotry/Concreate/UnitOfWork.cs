using LvovS.WebUI.Core;
using LvovS.WebUI.Repsotry.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Concreate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        private AccountContactDBContext _context;

        public UnitOfWork(AccountContactDBContext context)
        {
            _context = context;
        }

        public IBaseRepstory<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IBaseRepstory<T>;
            }

            IBaseRepstory<T> repo = new BaseRepstory<T>(_context);

            Repositories.Add(typeof(T), repo);

            return repo;
        }

        // private AccountContactDBContext _context;

        //private AccountContactDBContext _context;
        //public IAccountContactRepstory _accountContactRepstory;

        //public IIncidentRepstory _incidentRepstory;

        //public IContactRepstory _contactRepstory;

        //public UnitOfWork(AccountContactDBContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException("is null");
        //}

        //public IAccountContactRepstory accountContactRepstory
        //{
        //    get
        //    {
        //        return _accountContactRepstory ?? (_accountContactRepstory = new AccountContactRepstory(_context));
        //    }
        //}
        //public IIncidentRepstory incidentRepstory
        //{
        //    get
        //    {
        //        return _incidentRepstory ?? (_incidentRepstory = new IncidentRepstory(_context));
        //    }
        //}
        //public IContactRepstory contactRepstory
        //{
        //    get
        //    {
        //        return _contactRepstory ?? (_contactRepstory = new ContactRepstory(_context));
        //    }
        //}

        public async Task<bool> Commit()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch 
            {
                Rollback();
                return false;
            }
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}