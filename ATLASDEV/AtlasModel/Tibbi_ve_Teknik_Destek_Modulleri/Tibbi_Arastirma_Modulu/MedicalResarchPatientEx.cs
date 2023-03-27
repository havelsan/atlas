using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalResarchPatientEx
    {
        public Guid ObjectId { get; set; }
        public Guid? MedicalResarchRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MedicalResarch MedicalResarch { get; set; }
        #endregion Parent Relations
    }
}