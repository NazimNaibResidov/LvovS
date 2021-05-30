using System;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //IAccountContactRepstory accountContactRepstory { get; }
        //IIncidentRepstory incidentRepstory { get; }
        //IContactRepstory contactRepstory { get; }

        IBaseRepstory<T> Repository<T>() where T : class;

        Task<bool> Commit();

        void Rollback();
    }
}