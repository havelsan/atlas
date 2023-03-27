using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TreatmentDischarge
    {
        public Guid ObjectId { get; set; }
        public Guid? Conclusion { get; set; }
        public long? ProtocolNo { get; set; }
        public DateTime? DischargeDate { get; set; }
        public Guid? DischargeTypeRef { get; set; }
        public Guid? InPatientTreatmentClinicAppRef { get; set; }
        public Guid? DispatchedSpecialityRef { get; set; }
        public Guid? TransferTreatmentClinicRef { get; set; }
        public Guid? DispatchToOtherHospitalRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InPatientTreatmentClinicApplication InPatientTreatmentClinicApp { get; set; }
        public virtual ResClinic TransferTreatmentClinic { get; set; }
        public virtual DispatchToOtherHospital DispatchToOtherHospital { get; set; }
        #endregion Parent Relations
    }
}