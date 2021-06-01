using LvovS.WebUI.DTO.Contacts;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces.Facade
{
    public interface IContactFacade
    {
        ContactViewModel FindName(string cond);

        ContactViewModel FindEmail(string cond);

        Task<Contact> FindByIdAsync(object id);

        List<ContactViewModel> Get();

        Task<Contact> Add(string userId, AddViewModel accountContactViewModel);

        Task<bool> Delete(UpdateAndDeleteContactEntityDTO updateAndDeleteContactEntityDTO);

        Task<bool> Update(string id, GenericModelViewModel genericModelViewModel);
    }
}