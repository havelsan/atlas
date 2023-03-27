using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InpatientResponsibleDoctor
    {
        public Guid ObjectId { get; set; }
        public DateTime? SDateTime { get; set; }
        public Guid? DoctorRef { get; set; }
        public Guid? InPatientTreatmentClinicAppRef { get; set; }

        #region Parent Relations
        public virtual ResUser Doctor { get; set; }
        public virtual InPatientTreatmentClinicApplication InPatientTreatmentClinicApp { get; set; }
        #endregion Parent Relations
    }
}