using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using LvovS.WebUI.Repsotry.Abstaract;
using LvovS.WebUI.Repsotry.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        
       private UserManager<Account> _UserManager;

        [HttpGet]
        public async Task<IActionResult> Get(string Name)
        {
            var result = await _UserManager.FindByNameAsync(Name);
            if (result == null)
                return NotFound();
            else
            {
                return RedirectToAction("Create");
            }

        }
        public TestController(IUnitOfWork unitOfWork,UserManager<Account> UserManager)
        {
            this._unitOfWork = unitOfWork;
            _UserManager = UserManager;
        }
        [HttpPost]
        public async Task Create(AddViewModel accountContactViewModel)
        {

            Account account = new Account
            {
                Email = accountContactViewModel.Email,
                UserName = $"{accountContactViewModel.FirstName} {accountContactViewModel.LastName}"

            };

            Contact contact = new Contact
            {
                Id=Guid.NewGuid().ToString(),
                Email = accountContactViewModel.Email,
                FirstName = accountContactViewModel.FirstName,
                LastName = accountContactViewModel.LastName,

            };

            Incident incident = new Incident
            {
                Id = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now
            };

            

            var identityResult = await _UserManager.CreateAsync(account, accountContactViewModel.Password);
            await _unitOfWork.contactRepstory.CreateAsync(contact);
            var contactResult = await _unitOfWork.CommitAsync();
            if (identityResult.Succeeded&contactResult)
            {

                AccountContact accountContact = new AccountContact
                {
                    AccountId = _UserManager.FindByEmailAsync(accountContactViewModel.Email).Id.ToString(),
                    ContactId = contact.Id
                };

                await _unitOfWork.accountContactRepstory.CreateAsync(accountContact);
               
                
            }
            else
            {
                incident.Description = identityResult.Errors.Select(x => x.Description).FirstOrDefault();
                await _unitOfWork.incidentRepstory.CreateAsync(incident);
                _unitOfWork.Rollback();

            }
            await _unitOfWork.CommitAsync();

        }
       
        [HttpPut]
        public async Task Update(AddViewModel accountContactViewModel)
        {
            var resultEmail=await  _UserManager.FindByEmailAsync(accountContactViewModel.Email);
            resultEmail.Email = accountContactViewModel.Email;
            resultEmail.UserName = accountContactViewModel.FirstName + " " + accountContactViewModel.LastName;
            var  resultIdentity= await _UserManager.UpdateAsync(resultEmail);

            var resultContact = _unitOfWork.accountContactRepstory.GetAll()
              .FirstOrDefault(x => x.AccountId == resultEmail.Id)
              .Contact;

            resultContact.FirstName = accountContactViewModel.FirstName;
            resultContact.LastName = accountContactViewModel.LastName;
            resultContact.Email = accountContactViewModel.Email;
            await _unitOfWork.contactRepstory.UpdateAsync(resultContact);

            var resultaccountContact = _unitOfWork.accountContactRepstory.GetAll().FirstOrDefault(x => x.ContactId == resultContact.Id);

            await  _unitOfWork.accountContactRepstory.UpdateAsync(resultaccountContact);
            var result=await _unitOfWork.CommitAsync();
            if (!result)
            {
                
                await  _unitOfWork.incidentRepstory.CreateAsync(new Incident
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTime = DateTime.UtcNow,
                    Description = "save has been error"
                });
                await _unitOfWork.CommitAsync();
            }
               
                
            
                
            //var resultContact= await _unitOfWork.contactRepstory.FindAsync(x => x.Email == accountContactViewModel.Email);
            //resultContact.FirstName = accountContactViewModel.FirstName;
            //resultContact.LastName = accountContactViewModel.LastName;
            //resultContact.Email = accountContactViewModel.Email;
            //var result=  await _unitOfWork.contactRepstory.UpdateAsync(resultContact);
            //if (resultIdentity.Succeeded&)
            //{

            //}
           
        }
     
    }
}
