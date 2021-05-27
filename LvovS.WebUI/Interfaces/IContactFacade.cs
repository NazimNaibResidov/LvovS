using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces
{
    public interface IContactFacade
    {
        Task<int> Add(AddViewModel contactViewModel);
        Task<bool> Delete(AddViewModel contactViewModel);
        Task<bool> Update(UpdateViewModel updateViewModel);
    }
}
