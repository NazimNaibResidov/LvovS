using AutoMapper;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Core;
using LvovS.WebUI.Services.Core;

namespace LvovS.WebUI.Services
{
    public class ContactService : BaseService<Contact>, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}