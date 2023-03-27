using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class WoundSideInfo
    {
        public Guid ObjectId { get; set; }
        public string SideInfo { get; set; }
        public string SideInfo_Shadow { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}