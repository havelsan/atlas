using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubSurgery
    {
        public Guid ObjectId { get; set; }
        public Guid? SurgeryReport { get; set; }
        public DateTime? SurgeryReportDate { get; set; }
        public long? SurgeryReportNo { get; set; }
        public SurgeryShiftEnum? SurgeryShift { get; set; }
        public SurgeryStatusEnum? SurgeryStatus { get; set; }
        public SurgeryPointGroupEnum? SurgeryPointGroup { get; set; }
        public Guid? SurgeryRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Surgery Surgery { get; set; }
        #endregion Parent Relations
    }
}