using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MHRSAdmissionAppointment
    {
        public Guid ObjectId { get; set; }
        public string RandevuHrn { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsForlorn { get; set; }
        public bool? IsHighRiskPregnancy { get; set; }
        public bool? IsVirtuleUniqueRefNo { get; set; }
        public bool? IsWantedCompanion { get; set; }

        #region Base Object Navigation Property
        public virtual AdmissionAppointment AdmissionAppointment { get; set; }
        #endregion Base Object Navigation Property
    }
}