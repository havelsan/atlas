using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class WoundStageDef
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public bool? IsDepthNeeded { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}