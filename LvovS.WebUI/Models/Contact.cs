using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LvovS.WebUI.Models
{


    public class Contact
    {
        
        public string Id { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [UIHint("email")]
        public string Email { get; set; }

        


    }
}