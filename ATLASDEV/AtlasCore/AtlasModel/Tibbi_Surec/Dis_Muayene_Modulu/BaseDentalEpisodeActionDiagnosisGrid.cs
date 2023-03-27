using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseDentalEpisodeActionDiagnosisGrid
    {
        public Guid ObjectId { get; set; }
        public DentalPositionEnum? DentalPosition { get; set; }
        public ToothNumberEnum? ToothNumber { get; set; }
        public string ExternalID { get; set; }

        #region Base Object Navigation Property
        public virtual DiagnosisGrid DiagnosisGrid { get; set; }
        #endregion Base Object Navigation Property
    }
}