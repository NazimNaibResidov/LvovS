using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LvovS.WebUI.Models
{
    public class Account : IdentityUser
    {

        public string Name { get; set; }
        // public virtual ICollection<AccountContact> AccountContacts { get; set; }
        public Contact Contact { get; set; }
    }
    
}