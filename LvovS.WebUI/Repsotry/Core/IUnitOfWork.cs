using LvovS.WebUI.Repsotry.Abstaract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Core
{
    public interface IUnitOfWork:IDisposable
    {
         IAccountContactRepstory accountContactRepstory { get; }
         IIncidentRepstory incidentRepstory { get; }
         IContactRepstory contactRepstory { get; }
        Task<bool> CommitAsync();

       

        void Rollback();
    }
}
