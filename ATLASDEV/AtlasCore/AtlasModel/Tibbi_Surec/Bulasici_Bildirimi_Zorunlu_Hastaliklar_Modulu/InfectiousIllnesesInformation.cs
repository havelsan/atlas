using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InfectiousIllnesesInformation
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public DateTime? StartTimeOfInfectious { get; set; }
        public string Job { get; set; }
        public DateTime? DeathTime { get; set; }
        public string IllnesesName { get; set; }
        public bool? NotAlive { get; set; }
        public Guid? StarterEpisodeActionRef { get; set; }
        public Guid? PatientInfoRef { get; set; }
        public Guid? InfectiousIllnesesDiagnosisRef { get; set; }
        public Guid? StarterSubactionProcedureRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual EpisodeAction StarterEpisodeAction { get; set; }
        public virtual Patient PatientInfo { get; set; }
        public virtual DiagnosisDefinition InfectiousIllnesesDiagnosis { get; set; }
        public virtual SubactionProcedureWithDiagnosis StarterSubactionProcedure { get; set; }
        #endregion Parent Relations
    }
}