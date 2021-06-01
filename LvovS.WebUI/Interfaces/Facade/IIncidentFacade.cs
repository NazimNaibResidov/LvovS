using LvovS.WebUI.DTO.Incidents;
using System.Threading.Tasks;

namespace LvovS.WebUI.Interfaces.Facade
{
    public interface IIncidentFacade
    {
        Task<bool> Add(AddIncidentEntityDTO addIncidentEntityDTO);

        Task<bool> Delete(UpdateAndDeleteIncidentEntityDTO updateAndDeleteIncidentEntityDTO);

        Task<bool> Update(UpdateAndDeleteIncidentEntityDTO updateAndDeleteIncidentEntityDTO);
    }
}