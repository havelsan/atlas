using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubEpisode
    {
        public Guid ObjectId { get; set; }
        public DateTime? ClosingDate { get; set; }
        public SubEpisodeStatusEnum? PatientStatus { get; set; }
        public string ProtocolNo { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string SYSTakipNo { get; set; }
        public string OnlineProtokolNo { get; set; }
        public DateTime? EndDate { get; set; }
        public InpatientStatusEnum? InpatientStatus { get; set; }
        public bool? Sent101Package { get; set; }
        public Guid? InpatientAdmissionRef { get; set; }
        public Guid? OldSubEpisodeRef { get; set; }
        public Guid? ResSectionRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? SpecialityRef { get; set; }
        public Guid? StarterEpisodeActionRef { get; set; }
        public Guid? StarterSubActionProcedureRef { get; set; }
        public Guid? PatientAdmissionRef { get; set; }

        #region Parent Relations
        public virtual InpatientAdmission InpatientAdmission { get; set; }
        public virtual SubEpisode OldSubEpisode { get; set; }
        public virtual ResSection ResSection { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual EpisodeAction StarterEpisodeAction { get; set; }
        public virtual SubActionProcedure StarterSubActionProcedure { get; set; }
        public virtual PatientAdmission PatientAdmission { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<EpisodeAction> EpisodeActions { get; set; }
        #endregion Child Relations
    }
}