using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSICDO
    {
        public Guid ObjectId { get; set; }
        public int? KOD { get; set; }
        public string TOPOGRAFI { get; set; }
        public string YERLESIMBILGISI { get; set; }
        public int? HISTOLOJIKOD { get; set; }
        public string HISTOLOJIACIKLAMA { get; set; }
        public string DAVRANISKOD { get; set; }
        public string DAVRANISKODTANIM { get; set; }
        public string DAVRANISKODACIKLAMA { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}