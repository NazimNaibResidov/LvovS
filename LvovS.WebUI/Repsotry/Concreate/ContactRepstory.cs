using LvovS.WebUI.Core;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Abstaract;
using LvovS.WebUI.Repsotry.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Repsotry.Concreate
{
    public class ContactRepstory : BaseRepstory<Contact>, IContactRepstory
    {
        public ContactRepstory(AccountContactDBContext context) : base(context)
        {

        }
    }
}
