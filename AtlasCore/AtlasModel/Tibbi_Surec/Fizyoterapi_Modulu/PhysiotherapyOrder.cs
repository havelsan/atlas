using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PhysiotherapyOrder
    {
        public Guid ObjectId { get; set; }
        public string TreatmentProperties { get; set; }
        public string ApplicationArea { get; set; }
        public long? Duration { get; set; }
        public int? SeansGunSayisi { get; set; }
        public string drAnesteziTescilNo { get; set; }
        public string Dose { get; set; }
        public int? StartSession { get; set; }
        public int? FinishSession { get; set; }
        public bool? IncludeSaturday { get; set; }
        public bool? IncludeSunday { get; set; }
        public bool? IsAdditionalTreatment { get; set; }
        public bool? IsChangedAutomatically { get; set; }
        public bool? IncludeTuesday { get; set; }
        public bool? IncludeMonday { get; set; }
        public bool? IncludeWednesday { get; set; }
        public bool? IncludeThursday { get; set; }
        public bool? IncludeFriday { get; set; }
        public bool? IsPaidTreatment { get; set; }
        public string raporTakipNo { get; set; }
        public long? ProtocolNo { get; set; }
        public string DoseDurationInfo { get; set; }
        public int? SessionCount { get; set; }
        public DateTime? PhysiotherapyStartDate { get; set; }
        public Guid? PhysiotherapyRequestRef { get; set; }
        public Guid? TreatmentDiagnosisUnitRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? FTRApplicationAreaDefRef { get; set; }
        public Guid? TreatmentRoomRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? PackageProcedureRef { get; set; }

        #region Base Object Navigation Property
        public virtual BasePhysiotherapyOrder BasePhysiotherapyOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PhysiotherapyRequest PhysiotherapyRequest { get; set; }
        public virtual ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual PackageProcedureDefinition PackageProcedure { get; set; }
        #endregion Parent Relations
    }
}