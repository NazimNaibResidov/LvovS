using LvovS.WebUI.DTO;
using LvovS.WebUI.DTO.Contacts;
using LvovS.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces.Facade
{
    public interface IContactFacade
    {
        List<ContactViewModel> Get();
        ContactViewModel FindName(string cond);
        ContactViewModel FindEmail(string cond);

        Task<Contact> Add(AddContactEntityDTO addContactEntityDTO);

        Task<bool> Delete(UpdateAndDeleteContactEntityDTO updateAndDeleteContactEntityDTO);

        Task<bool> Update(UpdateAndDeleteContactEntityDTO updateAndDeleteContactEntityDTO);
    }
}