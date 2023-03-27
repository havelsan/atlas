using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InpatientResponsibleNurse
    {
        public Guid ObjectId { get; set; }
        public DateTime? SDateTime { get; set; }
        public Guid? NurseRef { get; set; }
        public Guid? InPatientTreatmentClinicAppRef { get; set; }

        #region Parent Relations
        public virtual ResUser Nurse { get; set; }
        public virtual InPatientTreatmentClinicApplication InPatientTreatmentClinicApp { get; set; }
        #endregion Parent Relations
    }
}