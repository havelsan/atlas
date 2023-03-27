using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingApplication
    {
        public Guid ObjectId { get; set; }
        public Guid? InPatientTreatmentClinicAppRef { get; set; }
        public Guid? EmergencyInterventionRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InPatientTreatmentClinicApplication InPatientTreatmentClinicApp { get; set; }
        public virtual EmergencyIntervention EmergencyIntervention { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<BaseNursingDataEntry> BaseNursingDataEntries { get; set; }
        #endregion Child Relations
    }
}