using LvovS.WebUI.DTO.Incidents;
using LvovS.WebUI.Interfaces.Facade;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Repsotry.Core;
using System.Threading.Tasks;

namespace LvovS.WebUI.Facades
{
    public class IncidentFacade : IIncidentFacade
    {
        #region ::CTOR::

        public IncidentFacade(IIncidentService incidentEntityService, IUnitOfWork unitOfWork)
        {
            _incidentEntityService = incidentEntityService;
            _unitOfWork = unitOfWork;
        }

        #endregion ::CTOR::

        #region ::FILDS::

        private readonly IIncidentService _incidentEntityService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion ::FILDS::

        #region ::GRUD

        public async Task<bool> Add(AddIncidentEntityDTO addIncidentEntityDTO)
        {
            await _incidentEntityService.CreateAsync(addIncidentEntityDTO);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(UpdateAndDeleteIncidentEntityDTO updateAndDeleteIncidentEntityDTO)
        {
            _incidentEntityService.Remvoe(updateAndDeleteIncidentEntityDTO);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> Update(UpdateAndDeleteIncidentEntityDTO updateAndDeleteIncidentEntityDTO)
        {
            _incidentEntityService.Update(updateAndDeleteIncidentEntityDTO);
            return await _unitOfWork.Commit();
        }

        #endregion ::GRUD
    }
}