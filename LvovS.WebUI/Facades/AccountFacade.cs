using LvovS.WebUI.DTO.Accounts;
using LvovS.WebUI.Extensions;
using LvovS.WebUI.Interfaces.Facade;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
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

        public AccountFacade(UserManager<Account> userManager, IAccountService accountService, IContactService contactService, IAccountContactService accountContactService)
        {
            _userManager = userManager;
            _contactService = contactService;
            _accountService = accountService;
        }

        #endregion ::CTOR::

        #region ::FILDS::

        private UserManager<Account> _userManager;
        private readonly IContactService _contactService;
        private readonly IAccountService _accountService;

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

        public async Task<IdentityResult> Add(AddViewModel accountContactViewModel)
        {
            AddAccountEntityDTO addAccountEntityDTO = new AddAccountEntityDTO
            {
                Email = accountContactViewModel.Email,
                UserName = $"{accountContactViewModel.FirstName} {accountContactViewModel.LastName}",
                Password = accountContactViewModel.Password,
            };
            var _resultMapper = addAccountEntityDTO.Mapped<Account>();
            var _resultIdentity = await _userManager.CreateAsync(_resultMapper, addAccountEntityDTO.Password);

            return _resultIdentity;
        }

        public async Task<IdentityResult> Delete(UpdateAndDeleteAccountEntityDTO updateAndDeleteAccountEntityDTO)
        {
            var _resultAccount = await _userManager.FindByIdAsync(updateAndDeleteAccountEntityDTO.Id);
            return await _userManager.DeleteAsync(_resultAccount);
        }

        public async Task<IdentityResult> Update(object id, GenericModelViewModel genericModelViewModel)
        {
            var _accountId = _contactService.FindByIdAsync(id).Result.AccountId;
            var account = await _userManager.FindByIdAsync(_accountId);
            account.Email = genericModelViewModel.Email;
            account.UserName = genericModelViewModel.FirstName + " " + genericModelViewModel.LastName;
            return await _userManager.UpdateAsync(account);
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

        public async Task<Account> FindByIdAsync(object id)
        {
            return await _accountService.FindByIdAsync(id);
        }

        #endregion ::FINDS::
    }
}