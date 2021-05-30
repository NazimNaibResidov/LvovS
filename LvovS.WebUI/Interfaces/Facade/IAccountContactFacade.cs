using LvovS.WebUI.DTO.AccountContacts;
using LvovS.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces.Facade
{
    public interface IAccountContactFacade
    {
        List<AccountContact> Get();

        Task Add(AddAccountContactEntityDTO addAccountContactEntityDTO);

        //Task Delete(AccountContactEntityDTO contactViewModel);

        //Task Update(AccountContactEntityDTO contactViewModel);
    }

    //public interface IdentityFacade
    //{
    //    Task<AddAccountContactEntityDTO> Add(AddAccountContactEntityDTO addAccountContactEntityDTO);

    //    //Task Delete(AccountContactEntityDTO contactViewModel);

    //    //Task Update(AccountContactEntityDTO contactViewModel);
    //}
}