using LvovS.WebUI.DTO.Contacts;
using LvovS.WebUI.DTO.Incidents;
using LvovS.WebUI.Interfaces.Facade;
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
        public ActionResult<ContactViewModel> GetByName(string email)
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
            var _resultIdentity = await _acountFacade.Add(accountContactViewModel);

            var data = await _acountFacade.FindByEmail(accountContactViewModel.Email);

            var _resultContactFacade = await _contactFacade.Add(data.Id, accountContactViewModel);

            if (_resultIdentity.Succeeded & _resultContactFacade.Id != null)
            {
                return Ok("operation completed successfully");

                #endregion ::GUID::
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
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountContactViewModel"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> Update(string id, [FromBody] GenericModelViewModel genericModelViewModel)
        {
            var _resultAcountFacade = await _acountFacade.Update(id, genericModelViewModel);

            var _resultContactFacade = await _contactFacade.Update(id, genericModelViewModel);

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
            return BadRequest();
        }
    }
}