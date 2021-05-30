using AutoMapper;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Core;
using LvovS.WebUI.Services.Core;

namespace LvovS.WebUI.Services
{
    public class IncidentService : BaseService<Incident>, IIncidentService
    {
        public IncidentService(IUnitOfWork unitOfWork) : base( unitOfWork)
        {
        }
    }
}