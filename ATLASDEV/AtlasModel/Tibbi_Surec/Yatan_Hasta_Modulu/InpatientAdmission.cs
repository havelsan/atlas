using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InpatientAdmission
    {
        public Guid ObjectId { get; set; }
        public long? DischargeNumber { get; set; }
        public long? QuarantineProtocolNo { get; set; }
        public string ReturnToClinicReason { get; set; }
        public Guid? ReturnToQuarantineReason { get; set; }
        public Guid? ReturnToRequestReason { get; set; }
        public long? ReportNo { get; set; }
        public long? NumberOfEmptyBeds { get; set; }
        public bool? IsPatientApprovalFormGiven { get; set; }
        public long? MutatDisiAracRaporId { get; set; }
        public DateTime? MutatDisiAracRaporTarihi { get; set; }
        public string MutatDisiGerekcesi { get; set; }
        public bool? MedulaRefakatciDurumu { get; set; }
        public string MedulaRefakatciGerekcesi { get; set; }
        public string MedulaESevkNo { get; set; }
        public string MedulaMutatDisiAracRaporNo { get; set; }
        public DateTime? MutatDisiAracBaslangicTarihi { get; set; }
        public DateTime? MutatDisiAracBitisTarihi { get; set; }
        public Guid? ActiveInPatientTrtmentClcAppRef { get; set; }
        public Guid? MedulaSevkDonusVasitasiRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseInpatientAdmission BaseInpatientAdmission { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InPatientTreatmentClinicApplication ActiveInPatientTrtmentClcApp { get; set; }
        #endregion Parent Relations
    }
}