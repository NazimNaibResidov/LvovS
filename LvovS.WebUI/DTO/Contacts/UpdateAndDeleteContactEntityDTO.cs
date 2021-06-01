using LvovS.WebUI.DTO.Core;

namespace LvovS.WebUI.DTO.Contacts
{
    public class UpdateAndDeleteContactEntityDTO : BaseDto<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
    }
}