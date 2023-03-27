using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EmergencyPatientStatusInfo
    {
        public Guid ObjectId { get; set; }
        public EmergencyPatientStatusInfoEnum? PatientStatus { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}