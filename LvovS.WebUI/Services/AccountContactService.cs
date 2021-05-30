using AutoMapper;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Core;
using LvovS.WebUI.Services.Core;

namespace LvovS.WebUI.Services
{
    public class AccountContactService : BaseService<AccountContact>, IAccountContactService
    {
        public AccountContactService(IUnitOfWork unitOfWork) : base( unitOfWork)
        {
        }
    }
}