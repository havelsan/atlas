using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InPatientPhysicianApplication
    {
        public Guid ObjectId { get; set; }
        public Guid? InPatientFolder { get; set; }
        public Guid? EmergencyInterventionRef { get; set; }
        public Guid? InPatientTreatmentClinicAppRef { get; set; }

        #region Base Object Navigation Property
        public virtual PhysicianApplication PhysicianApplication { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual EmergencyIntervention EmergencyIntervention { get; set; }
        public virtual InPatientTreatmentClinicApplication InPatientTreatmentClinicApp { get; set; }
        #endregion Parent Relations
    }
}