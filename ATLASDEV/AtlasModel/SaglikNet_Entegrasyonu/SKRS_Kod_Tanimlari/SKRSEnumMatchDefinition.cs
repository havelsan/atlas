using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSEnumMatchDefinition
    {
        public Guid ObjectId { get; set; }
        public int? EnumValue { get; set; }
        public Guid? SKRSDefinitionObjectId { get; set; }
        public Guid? SKRSDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual BaseSKRSDefinition SKRSDefinition { get; set; }
        #endregion Parent Relations
    }
}