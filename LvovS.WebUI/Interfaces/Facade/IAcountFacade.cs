using LvovS.WebUI.DTO.Accounts;
using LvovS.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces.Facade
{
    public interface IAcountFacade
    {
        Task<List<AccountViewModel>> GetAsync();

        List<AccountViewModel> Get();

        Task<IdentityResult> Add(AddAccountEntityDTO addAccountEntityDTO);

        Task<IdentityResult> Delete(UpdateAndDeleteAccountEntityDTO updateAndDeleteAccountEntityDTO);

        Task<IdentityResult> Update(UpdateAndDeleteAccountEntityDTO updateAndDeleteAccountEntityDTO);

        Task<Account> FindByEmail(string email);

        Task<Account> FindByName(string name);
    }
}