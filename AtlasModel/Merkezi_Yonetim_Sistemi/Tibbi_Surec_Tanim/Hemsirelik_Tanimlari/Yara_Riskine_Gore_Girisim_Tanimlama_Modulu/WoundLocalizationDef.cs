using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class WoundLocalizationDef
    {
        public Guid ObjectId { get; set; }
        public string Localization { get; set; }
        public string Localization_Shadow { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}