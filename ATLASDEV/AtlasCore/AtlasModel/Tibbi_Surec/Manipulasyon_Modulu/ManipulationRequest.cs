using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ManipulationRequest
    {
        public Guid ObjectId { get; set; }
        public long? ProtocolNo { get; set; }
        public bool? IsPatientApprovalFormGiven { get; set; }
        public Guid? PreInformation { get; set; }
        public string ReportNo { get; set; }
        public DateTime? ReportStartDate { get; set; }
        public DateTime? ReportEndDate { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property
    }
}