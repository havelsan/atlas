using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AppointmentDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? StateOnly { get; set; }
        public int? AppointmentDefinitionID { get; set; }
        public string AppDefNameDisplayText { get; set; }
        public bool? GiveFromResource { get; set; }
        public bool? GiveToMaster { get; set; }
        public string FormDefID { get; set; }
        public bool? OverlapAllowed { get; set; }
        public AppointmentDefinitionEnum? AppointmentDefinitionName { get; set; }
        public string AppDefNameDisplayText_Shad { get; set; }
        public bool? IsDescReqForNonScheduledApps { get; set; }
        public bool? ScheduleOverlapAllowed { get; set; }
        public bool? SentToMHRS { get; set; }
    }
}