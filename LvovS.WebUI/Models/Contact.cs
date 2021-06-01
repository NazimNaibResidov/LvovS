using LvovS.WebUI.DTO.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LvovS.WebUI.Models
{
    public class Contact: BaseEntity<string>
    {
        

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [UIHint("email")]
        public string Email { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
        // public virtual ICollection<AccountContact> AccountContacts { get; set; }

    }
}