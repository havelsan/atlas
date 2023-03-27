using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AnesthesiaAndReanimation
    {
        public Guid ObjectId { get; set; }
        public DateTime? PlannedAnesthesiaDate { get; set; }
        public DateTime? AnesthesiaStartDateTime { get; set; }
        public Guid? AnesthesiaReport { get; set; }
        public DateTime? AnesthesiaEndDateTime { get; set; }
        public AnesthesiaASATypeEnum? ASAType { get; set; }
        public DateTime? AnesthesiaReportDate { get; set; }
        public long? AnesthesiaReportNo { get; set; }
        public string RequestNote { get; set; }
        public AnesthesiaTechniqueEnum? AnesthesiaTechnique { get; set; }
        public bool? IsTreatmentMaterialEmpty { get; set; }
        public long? ProtocolNo { get; set; }
        public bool? CancelledBySurgery { get; set; }
        public Guid? AnesthesiaNote { get; set; }
        public bool? IsPatientApprovalFormGiven { get; set; }
        public string drAnesteziTescilNo { get; set; }
        public bool? HasComplication { get; set; }
        public string ComplicationDescription { get; set; }
        public AnesthesiaASAScoreEnum? ASAScore { get; set; }
        public AnesthesiaScarEnum? ScarType { get; set; }
        public AnesthesiaLaparoscopyEnum? Laparoscopy { get; set; }
        public Guid? MainSurgeryRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? ProcedureDoctor2Ref { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Surgery MainSurgery { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser ProcedureDoctor2 { get; set; }
        #endregion Parent Relations
    }
}