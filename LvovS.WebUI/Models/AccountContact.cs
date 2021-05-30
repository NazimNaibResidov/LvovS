using LvovS.WebUI.DTO.Core;

namespace LvovS.WebUI.Models
{
    public class AccountContact: BaseEntity<int>
    {
        
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}