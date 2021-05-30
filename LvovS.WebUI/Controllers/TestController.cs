using LvovS.WebUI.DTO.AccountContacts;
using LvovS.WebUI.DTO.Accounts;
using LvovS.WebUI.DTO.Contacts;
using LvovS.WebUI.DTO.Incidents;
using LvovS.WebUI.Interfaces.Facade;
using LvovS.WebUI.Models;
using LvovS.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        #region ::CTOR::

        public TestController(
                                  IContactFacade contactFacade,
                    IAccountContactFacade accountContactFacade,
                                IIncidentFacade incidentFacade,
                                   IAcountFacade acountFacade
           )
        {
            _acountFacade = acountFacade;
            _contactFacade = contactFacade;
            _accountContactFacade = accountContactFacade;
            _incidentFacade = incidentFacade;
        }

        #endregion ::CTOR::

        #region ::FILDS::

        private readonly IContactFacade _contactFacade;
        private readonly IAccountContactFacade _accountContactFacade;
        private readonly IIncidentFacade _incidentFacade;
        private readonly IAcountFacade _acountFacade;

        #endregion ::FILDS::

        #region ::GUID::

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ContactViewModel> Get()
        {
            return _contactFacade.Get();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet("email")]
        public  ActionResult<ContactViewModel> GetByName(string email)
        {
            var result = _contactFacade.FindEmail(email);
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("Id")]
        public ActionResult<ContactViewModel> GetById(string Id)
        {
            var result = _contactFacade.Get()
                .Find(x => x.Id == Id);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountContactViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(AddViewModel accountContactViewModel)
        {
            #region ::Identety::

            AddAccountEntityDTO addAccountEntityDTO = new AddAccountEntityDTO
            {
                Email = accountContactViewModel.Email,
                UserName = $"{accountContactViewModel.FirstName} {accountContactViewModel.LastName}",
                Password = accountContactViewModel.Password
            };
            var _resultIdentity = await _acountFacade.Add(addAccountEntityDTO);

            #endregion ::Identety::

            #region ::AddContactEntityDTO::

            AddContactEntityDTO addContactEntityDTO = new AddContactEntityDTO
            {
                FirstName = accountContactViewModel.FirstName,
                LastName = accountContactViewModel.LastName,
                Email = accountContactViewModel.Email
            };
            var _resultContactFacade = await _contactFacade.Add(addContactEntityDTO);

            #endregion ::AddContactEntityDTO::

            #region ::Conditionals::

            if (_resultIdentity.Succeeded & _resultContactFacade.Id != null)
            {
                #region :: AddAccountContactEntityDTO::

                var _resultAccount = await _acountFacade.FindByEmail(addAccountEntityDTO.Email);

                AddAccountContactEntityDTO addAccountContactEntityDTO = new AddAccountContactEntityDTO
                {
                    AccountId = _resultAccount.Id,
                    ContactId = _resultContactFacade.Id
                };
                await _accountContactFacade.Add(addAccountContactEntityDTO);
                return Ok("operation completed successfully");

                #endregion :: AddAccountContactEntityDTO::
            }
            else

            {
                #region ::AddIncidentEntityDTO::
                
                AddIncidentEntityDTO addIncidentEntityDTO = new AddIncidentEntityDTO
                {
                    DateTime = DateTime.Now
                };
                addIncidentEntityDTO.Description = _resultIdentity.Errors.Select(x => x.Description).FirstOrDefault();
                var result = await _incidentFacade.Add(addIncidentEntityDTO);
                return BadRequest("operation completed with errors");

                #endregion ::AddIncidentEntityDTO::
            }

            #endregion ::Conditionals::
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountContactViewModel"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> Update(string id,[FromBody] UpdateAndDeleteContactEntityDTO _updateAndDeleteContactEntityDTO)
        {
            if (id != _updateAndDeleteContactEntityDTO.Id)
                return BadRequest();

            #region ::UpdateAndDeleteAccountEntityDTO::

            UpdateAndDeleteAccountEntityDTO updateAndDeleteAccountEntityDTO = new UpdateAndDeleteAccountEntityDTO
            {
                Email = _updateAndDeleteContactEntityDTO.Email,
                UserName = $"{_updateAndDeleteContactEntityDTO.FirstName} {_updateAndDeleteContactEntityDTO.LastName}"
            };
            var _resultAcountFacade = await _acountFacade.Update(updateAndDeleteAccountEntityDTO);

            #endregion ::UpdateAndDeleteAccountEntityDTO::

            #region :: UpdateAndDeleteContactEntityDTO::

            UpdateAndDeleteContactEntityDTO updateAndDeleteContactEntityDTO = new UpdateAndDeleteContactEntityDTO
            {
                Email = _updateAndDeleteContactEntityDTO.Email,
                FirstName = _updateAndDeleteContactEntityDTO.FirstName,
                LastName = _updateAndDeleteContactEntityDTO.LastName,
            };
            var _resultContactFacade = await _contactFacade.Update(updateAndDeleteContactEntityDTO);

            #endregion :: UpdateAndDeleteContactEntityDTO::

            if (_resultAcountFacade.Succeeded & _resultContactFacade)
            {
                return Ok();
            }
            else
            {
                #region ::AddIncidentEntityDTO::

                AddIncidentEntityDTO addIncidentEntityDTO = new AddIncidentEntityDTO
                {
                    DateTime = DateTime.UtcNow,
                };
                foreach (var item in _resultAcountFacade.Errors)
                {
                    addIncidentEntityDTO.Description = item.Description;
                }
                await _incidentFacade.Add(addIncidentEntityDTO);

                #endregion ::AddIncidentEntityDTO::

                return BadRequest();
            }
        }

        #endregion ::GUID::
    }
}