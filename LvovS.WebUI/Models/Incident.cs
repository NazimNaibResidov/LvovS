using LvovS.WebUI.DTO.Core;
using System;

namespace LvovS.WebUI.Models
{
    public class Incident: BaseEntity<string>
    {
        
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}