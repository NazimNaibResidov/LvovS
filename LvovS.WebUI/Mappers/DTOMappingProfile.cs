using AutoMapper;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;

namespace LvovS.WebUI.Mappers
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<Account, AddViewModel>();
            CreateMap<AccountContact, AddViewModel>();
            CreateMap<Contact, AddViewModel>();
            CreateMap<Incident, AddViewModel>();
        }
    }
}