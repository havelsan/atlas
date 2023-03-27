using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Manipulation
    {
        public Guid ObjectId { get; set; }
        public string ReturnReason { get; set; }
        public Guid? TechnicianNote { get; set; }
        public Guid? PreInformation { get; set; }
        public Guid? ProcedureReport { get; set; }
        public long? ProtocolNo { get; set; }
        public string ReasonToContinue { get; set; }
        public bool? IsPatientApprovalFormGiven { get; set; }
        public bool? IsGunubirlikTakip { get; set; }
        public Guid? ReportPDF { get; set; }
        public Guid? Report { get; set; }
        public Guid? ManipulationRequestRef { get; set; }
        public Guid? TechnicianRef { get; set; }
        public Guid? SorumluDoktorRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? ResponsiblePersonnelRef { get; set; }
        public Guid? RequestedByUserRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ManipulationRequest ManipulationRequest { get; set; }
        public virtual ResUser Technician { get; set; }
        public virtual ResUser SorumluDoktor { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser ResponsiblePersonnel { get; set; }
        public virtual ResUser RequestedByUser { get; set; }
        #endregion Parent Relations
    }
}