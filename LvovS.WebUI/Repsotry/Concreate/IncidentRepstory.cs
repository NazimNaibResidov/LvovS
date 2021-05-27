using LvovS.WebUI.Core;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Abstaract;
using LvovS.WebUI.Repsotry.Core;

namespace LvovS.WebUI.Repsotry.Concreate
{
    public class IncidentRepstory : BaseRepstory<Incident>, Abstaract.IIncidentRepstory
    {
        public IncidentRepstory(AccountContactDBContext context) : base(context)
        {

        }
    }
}
