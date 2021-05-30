using LvovS.WebUI.DTO.Contacts;
using LvovS.WebUI.Extensions;
using LvovS.WebUI.Interfaces.Facade;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Facades
{
    public class ContactFacade : IContactFacade
    {
        #region ::CTOR::

        public ContactFacade(IContactService contactEntityService, IUnitOfWork unitOfWork)
        {
            _contactEntityService = contactEntityService;
            _unitOfWork = unitOfWork;
        }

        #endregion ::CTOR::

        #region ::FILDS::

        private readonly IContactService _contactEntityService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion ::FILDS::

        #region ::GRUD::

        public List<ContactViewModel> Get()
        {
            return _contactEntityService.GetAll()
                  .Select(x => x.Mapped<ContactViewModel>())
                 .ToList();
        }

        public async Task<Contact> Add(AddContactEntityDTO addContactEntityDTO)
        {
            var result = await _contactEntityService.CreateAsync(addContactEntityDTO);
            await _unitOfWork.Commit();
            return result;
        }

        public async Task<bool> Delete(UpdateAndDeleteContactEntityDTO updateAndDeleteContactEntityDTO)
        {
            _contactEntityService.Remvoe(updateAndDeleteContactEntityDTO);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> Update(UpdateAndDeleteContactEntityDTO updateAndDeleteContactEntityDTO)
        {
            _contactEntityService.Update(updateAndDeleteContactEntityDTO);
            return await _unitOfWork.Commit();
        }
        public ContactViewModel FindName(string cond)
        {
           return _contactEntityService.GetAll()
                .First(x => x.FirstName == cond)
                .Mapped<ContactViewModel>()
                ;
        }
        public  ContactViewModel FindEmail(string cond)
        {
            return  _contactEntityService.GetAll()
                 .First(x => x.Email == cond)
                 .Mapped<ContactViewModel>()
                 ;
        }
        #endregion ::GRUD::
    }
}