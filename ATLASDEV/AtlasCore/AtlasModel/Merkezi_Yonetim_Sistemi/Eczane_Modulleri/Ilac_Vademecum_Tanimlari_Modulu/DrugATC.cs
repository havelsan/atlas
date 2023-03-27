using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugATC
    {
        public Guid ObjectId { get; set; }
        public Guid? OldDrugDefinition { get; set; }
        public Guid? ATCRef { get; set; }
        public Guid? DrugDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DrugDefinition DrugDefinition { get; set; }
        #endregion Parent Relations
    }
}