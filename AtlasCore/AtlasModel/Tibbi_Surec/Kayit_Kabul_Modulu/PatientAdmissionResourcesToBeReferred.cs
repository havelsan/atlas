using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientAdmissionResourcesToBeReferred
    {
        public Guid ObjectId { get; set; }
        public string AdmissionQueueNumber { get; set; }
        public Guid? SpecialityRef { get; set; }
        public Guid? PatientAdmissionRef { get; set; }
        public Guid? ProcedureDoctorToBeReferredRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResourcesToBeReferredGrid ResourcesToBeReferredGrid { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PatientAdmission PatientAdmission { get; set; }
        public virtual ResUser ProcedureDoctorToBeReferred { get; set; }
        #endregion Parent Relations
    }
}