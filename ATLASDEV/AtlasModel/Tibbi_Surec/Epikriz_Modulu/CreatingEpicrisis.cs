using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CreatingEpicrisis
    {
        public Guid ObjectId { get; set; }
        public Guid? PROCEDURE { get; set; }
        public Guid? Suggestion { get; set; }
        public Guid? AUTOBIOGRAPHY { get; set; }
        public Guid? Report { get; set; }
        public Guid? PHYSICALEXAMINATION { get; set; }
        public Guid? COMPLAINTANDSTORY { get; set; }
        public long? ReportNo { get; set; }
        public Guid? STORY { get; set; }
        public Guid? SYMPTOM { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property
    }
}