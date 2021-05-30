using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LvovS.WebUI.Models
{
    public class Account : IdentityUser
    {

        public virtual ICollection<AccountContact> AccountContacts { get; set; }
    }
    
}