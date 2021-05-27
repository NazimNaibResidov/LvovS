using AutoMapper;
using LvovS.WebUI.Interfaces;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using LvovS.WebUI.Repsotry.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LvovS.WebUI.Facade
{
    public class AcountFacade : IAcountFacade
    {
       
        public Task<bool> Add(AddViewModel contactViewModel)
        {
            return default;
        }

        public Task<bool> Delete(AddViewModel contactViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AddViewModel contactViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
