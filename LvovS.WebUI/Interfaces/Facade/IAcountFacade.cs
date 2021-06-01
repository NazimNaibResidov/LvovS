using LvovS.WebUI.DTO.Accounts;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces.Facade
{
    public interface IAcountFacade
    {
        Task<List<AccountViewModel>> GetAsync();

        List<AccountViewModel> Get();

        Task<IdentityResult> Add(AddViewModel accountContactViewModel);

        Task<IdentityResult> Delete(UpdateAndDeleteAccountEntityDTO updateAndDeleteAccountEntityDTO);

        Task<IdentityResult> Update(object id, GenericModelViewModel genericModelViewModel);

        Task<Account> FindByIdAsync(object id);

        Task<Account> FindByEmail(string email);

        Task<Account> FindByName(string name);
    }
}