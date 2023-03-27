using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PsychologicExamination
    {
        public Guid ObjectId { get; set; }
        public string ConsultationRequestStatement { get; set; }
        public string ConsultationResult { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property
    }
}