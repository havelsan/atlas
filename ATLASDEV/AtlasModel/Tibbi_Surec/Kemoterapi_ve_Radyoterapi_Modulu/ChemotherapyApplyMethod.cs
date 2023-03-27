using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChemotherapyApplyMethod
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}