using LvovS.WebUI.Models.ViewModels;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces
{
    public interface IAccountContactFacade
    {
        Task<bool> Add(AddViewModel contactViewModel);
        Task<bool> Delete(AddViewModel contactViewModel);
        Task<bool> Update(AddViewModel contactViewModel);
    }
}
