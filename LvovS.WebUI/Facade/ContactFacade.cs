using AutoMapper;
using LvovS.WebUI.Interfaces;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using LvovS.WebUI.Repsotry.Abstaract;
using LvovS.WebUI.Repsotry.Core;
using System.Threading.Tasks;

namespace LvovS.WebUI.Facade
{
    public class ContactFacade :IContactFacade
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ContactFacade(IUnitOfWork unitOfWork, IMapper _mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = _mapper;
        }

        public Task<int> Add(AddViewModel contactViewModel)
        {
            var result=  _mapper.Map<Contact>(contactViewModel);
            _unitOfWork.contactRepstory.CreateAsync(result);
            return Task.FromResult(0);
        }

        public Task<bool> Delete(AddViewModel contactViewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(UpdateViewModel updateViewModel)
        {
            var result= _mapper.Map<Contact>(updateViewModel);
            _unitOfWork.contactRepstory.UpdateAsync(result);
            return _unitOfWork.CommitAsync();
        }
    }
}
