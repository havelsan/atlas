using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EmergencyInterventionDoctorGroup
    {
        public Guid ObjectId { get; set; }
        public DateTime? ActionDate { get; set; }
        public Guid? DoctorRef { get; set; }
        public Guid? EmergencyInterventionRef { get; set; }

        #region Parent Relations
        public virtual ResUser Doctor { get; set; }
        public virtual EmergencyIntervention EmergencyIntervention { get; set; }
        #endregion Parent Relations
    }
}