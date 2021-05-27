using LvovS.WebUI.Core;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Abstaract;
using LvovS.WebUI.Repsotry.Core;

namespace LvovS.WebUI.Repsotry.Concreate
{
    public class AccountContactRepstory : BaseRepstory<AccountContact>, IAccountContactRepstory
    {
        public AccountContactRepstory(AccountContactDBContext context) : base(context)
        {

        }
    }
}
