using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Pathology
    {
        public Guid ObjectId { get; set; }
        public Guid? MacroscopyInspection { get; set; }
        public string MaterialPrtNoPrefix { get; set; }
        public DateTime? ResultEntryDate { get; set; }
        public string AdditionalInfo { get; set; }
        public int? BlockCount { get; set; }
        public bool? IntraoperativeConsultation { get; set; }
        public int? LamCount { get; set; }
        public string FreeDiagnoseEntry { get; set; }
        public string ReasonForRepeatation { get; set; }
        public string MaterialPrtNoPostFix { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public string MatPrtNoString { get; set; }
        public DateTime? ReportDate { get; set; }
        public long? SeqNo { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? Liquid { get; set; }
        public string MaterialResponsible { get; set; }
        public Guid? RemoteSpecialDoctor { get; set; }
        public bool? HasSpecialProcedures { get; set; }
        public string birim { get; set; }
        public string raporTakipNo { get; set; }
        public int? SubMatPrtNoSuffixNo { get; set; }
        public string SubMatPrtNoSuffixString { get; set; }
        public string drAnesteziTescilNo { get; set; }
        public string Description { get; set; }
        public string SendedMaterial { get; set; }
        public string TechnicianNote { get; set; }
        public int? NumberOfMaterials { get; set; }
        public DateTime? SendToApproveDate { get; set; }
        public bool? IsBiopsy { get; set; }
        public bool? IsCytology { get; set; }
        public string PathologyArchiveNo { get; set; }
        public long? BiopsySeqNo { get; set; }
        public long? CytologySeqNo { get; set; }
        public Guid? SpecialDoctorRef { get; set; }
        public Guid? AssistantDoctorRef { get; set; }
        public Guid? PathologyRequestRef { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? SagSolRef { get; set; }
        public Guid? PathologyAdditionalReportRef { get; set; }
        public Guid? PathologyPanicAlertRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser SpecialDoctor { get; set; }
        public virtual ResUser AssistantDoctor { get; set; }
        public virtual PathologyRequest PathologyRequest { get; set; }
        public virtual ResUser ResponsibleDoctor { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        #endregion Parent Relations
    }
}