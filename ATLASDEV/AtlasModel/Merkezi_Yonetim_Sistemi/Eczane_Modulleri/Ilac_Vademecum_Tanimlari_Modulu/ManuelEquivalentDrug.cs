using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ManuelEquivalentDrug
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugDefinitionRef { get; set; }
        public Guid? EquivalentDrugRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DrugDefinition DrugDefinition { get; set; }
        public virtual DrugDefinition EquivalentDrug { get; set; }
        #endregion Parent Relations
    }
}