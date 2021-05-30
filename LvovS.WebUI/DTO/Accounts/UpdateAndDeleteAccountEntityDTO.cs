using LvovS.WebUI.DTO.Core;

namespace LvovS.WebUI.DTO.Accounts
{
    public class UpdateAndDeleteAccountEntityDTO : BaseDto<string>
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}