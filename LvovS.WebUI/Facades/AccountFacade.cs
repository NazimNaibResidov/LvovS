using LvovS.WebUI.DTO.Accounts;
using LvovS.WebUI.Extensions;
using LvovS.WebUI.Interfaces.Facade;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Facades
{
    public class AccountFacade : IAcountFacade
    {
        #region ::CTOR::

        public AccountFacade(UserManager<Account> userManager, IAccountContactFacade accountContactFacade, IContactService contactService)
        {
            _userManager = userManager;
            _accountContactFacade = accountContactFacade;

            _contactService = contactService;
        }

        #endregion ::CTOR::

        #region ::FILDS::

        private UserManager<Account> _userManager;
        private readonly IContactService _contactService;
        private readonly IAccountContactFacade _accountContactFacade;

        #endregion ::FILDS::

        #region ::CRUD::

        public List<AccountViewModel> Get()
        {
            return _userManager.Users
                  .Select(x => x.Mapped<AccountViewModel>())
                  .ToList();
        }

        public async Task<List<AccountViewModel>> GetAsync()
        {
            return await _userManager.Users
                 .Select(x => x.Mapped<AccountViewModel>())
                 .ToListAsync();
        }

        public async Task<IdentityResult> Add(AddAccountEntityDTO addAccountEntityDTO)
        {
            var _resultMapper = addAccountEntityDTO.Mapped<Account>();
            var _resultIdentity = await _userManager.CreateAsync(_resultMapper, addAccountEntityDTO.Password);
            return _resultIdentity;
        }
       

        public async Task<IdentityResult> Delete(UpdateAndDeleteAccountEntityDTO updateAndDeleteAccountEntityDTO)
        {
            var _resultAccount = await _userManager.FindByIdAsync(updateAndDeleteAccountEntityDTO.Id);
            return await _userManager.DeleteAsync(_resultAccount);
        }

        public async Task<IdentityResult> Update(UpdateAndDeleteAccountEntityDTO updateAndDeleteAccountEntityDTO)
        {
            var resultContactId = _contactService.GetAll().First(x => x.Id == updateAndDeleteAccountEntityDTO.Id).Id;
            var _id= _accountContactFacade.Get().Find(x => x.ContactId == resultContactId).AccountId;
            var resultEmail = await _userManager.FindByIdAsync(_id);
            var resultIdentity = await _userManager.UpdateAsync(resultEmail);
            return resultIdentity;
        }

        #endregion ::CRUD::

        #region ::FINDS::

        public async Task<Account> FindByEmail(string conitinol)
        {
            return await _userManager.FindByEmailAsync(conitinol);
        }

        public async Task<Account> FindByName(string conitinol)
        {
            return await _userManager.FindByNameAsync(conitinol);
        }

        #endregion ::FINDS::
    }
}