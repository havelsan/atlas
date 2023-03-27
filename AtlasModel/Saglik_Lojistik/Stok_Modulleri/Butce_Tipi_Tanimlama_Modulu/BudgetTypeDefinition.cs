using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BudgetTypeDefinition
    {
        public Guid ObjectId { get; set; }
        public MKYS_EButceTurEnum? MKYS_Butce { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}