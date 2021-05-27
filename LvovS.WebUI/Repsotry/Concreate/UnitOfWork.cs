using LvovS.WebUI.Core;
using LvovS.WebUI.Repsotry.Abstaract;
using LvovS.WebUI.Repsotry.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Concreate
{
    public class UnitOfWork:IUnitOfWork
    {
        private  AccountContactDBContext _context;

        public IAccountContactRepstory _accountContactRepstory;

        public IIncidentRepstory _incidentRepstory;

        public IContactRepstory _contactRepstory;

        public UnitOfWork(AccountContactDBContext context)
        {
            _context = context ?? throw new ArgumentNullException("is null");
        }

        public IAccountContactRepstory accountContactRepstory
        {
            get
            {
                return _accountContactRepstory ?? (_accountContactRepstory = new AccountContactRepstory(_context));
            }
        }
        public IIncidentRepstory incidentRepstory
        {
            get
            {
                return _incidentRepstory ?? (_incidentRepstory = new IncidentRepstory(_context));
            }
        }
        public IContactRepstory contactRepstory
        {
            get
            {
                return _contactRepstory ?? (_contactRepstory = new ContactRepstory(_context));
            }
        }



        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
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
