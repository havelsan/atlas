using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DiagnosisGrid
    {
        public Guid ObjectId { get; set; }
        public string FreeDiagnosis { get; set; }
        public DateTime? DiagnoseDate { get; set; }
        public DiagnosisTypeEnum? DiagnosisType { get; set; }
        public ActionTypeEnum? EntryActionType { get; set; }
        public bool? AddToHistory { get; set; }
        public DateTime? StartTimeOfInfectious { get; set; }
        public string DiagnosisDefinition { get; set; }
        public bool? AllDiagnosisDefTeshis { get; set; }
        public string taniKodu { get; set; }
        public bool? IsMainDiagnose { get; set; }
        public Guid? SubactionProcedureRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? SKRSVakaTipiRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? ImportantMedicalInformationRef { get; set; }
        public Guid? DiagnoseRef { get; set; }
        public Guid? ResponsibleUserRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? ExaminationInfoByBransRef { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }

        #region Parent Relations
        public virtual SubactionProcedureWithDiagnosis SubactionProcedure { get; set; }
        public virtual EpisodeActionWithDiagnosis EpisodeAction { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual DiagnosisDefinition Diagnose { get; set; }
        public virtual ResUser ResponsibleUser { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser ResponsibleDoctor { get; set; }
        #endregion Parent Relations
    }
}