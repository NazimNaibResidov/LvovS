using LvovS.WebUI.DTO.AccountContacts;
using LvovS.WebUI.Interfaces.Facade;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Facades
{
    public class AccountContactFacade : IAccountContactFacade
    {
        #region ::CTOR::

        public AccountContactFacade(IAccountContactService accountContactService, IUnitOfWork unitOfWork)
        {
            _accountContactService = accountContactService;
            _unitOfWork = unitOfWork;
        }

        #endregion ::CTOR::

        #region ::FILDS::

        private readonly IAccountContactService _accountContactService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion ::FILDS::

        #region ::GRUD::

        public List<AccountContact> Get()
        {
            return _accountContactService.GetAll()
                 .ToList();
        }

        public async Task Add(AddAccountContactEntityDTO addAccountContactEntityDTO)
        {
            await _accountContactService.CreateAsync(addAccountContactEntityDTO);
            await _unitOfWork.Commit();
        }

        #endregion ::GRUD::
    }
}