using LvovS.WebUI.DTO.Core;
using System;

namespace LvovS.WebUI.DTO.Incidents
{
    public class UpdateAndDeleteIncidentEntityDTO : BaseDto<string>
    {
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}