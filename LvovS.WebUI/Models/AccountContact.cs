using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Models
{
    public class AccountContact
    {
        
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
