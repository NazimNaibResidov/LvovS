using AutoMapper;
using LvovS.WebUI.Extensions;
using LvovS.WebUI.Interfaces;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using LvovS.WebUI.Repsotry;
using LvovS.WebUI.Repsotry.Abstaract;
using LvovS.WebUI.Repsotry.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace LvovS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<Account> _UserManager;
        
        public HomeController(IUnitOfWork unitOfWork, UserManager<Account> UserManager)
        {
            this._unitOfWork = unitOfWork;
            _UserManager = UserManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddViewModel accountContactViewModel)
        {
            Account account = new Account
            {
                Email = accountContactViewModel.Email,
                UserName = $"{accountContactViewModel.FirstName} {accountContactViewModel.LastName}"

            };

            Contact contact = new Contact
            {
                Email = accountContactViewModel.Email,
                FirstName = accountContactViewModel.FirstName,
                LastName = accountContactViewModel.LastName,

            };
           
            Incident incident = new Incident
            {
                DateTime = DateTime.Now
            };
            

            var ideresult=   await _UserManager.CreateAsync(account, accountContactViewModel.Email);
           

            if (ideresult.Succeeded)
            {
                await _unitOfWork.contactRepstory.CreateAsync(contact);
                if (!await _unitOfWork.CommitAsync())
                {
                    
                   await _unitOfWork.incidentRepstory.CreateAsync(incident);
                   await _unitOfWork.CommitAsync();
                    _unitOfWork.Rollback();
                }

            }
            else
            {
                incident.Description = ideresult.Errors.Select(x => x.Description).FirstOrDefault();
            }
           
           
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

    }
}