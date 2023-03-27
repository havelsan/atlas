using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugActiveIngredient
    {
        public Guid ObjectId { get; set; }
        public double? MaxDose { get; set; }
        public Guid? OldDrugDefinition { get; set; }
        public double? Value { get; set; }
        public bool? IsParentIngredient { get; set; }
        public Guid? UnitRef { get; set; }
        public Guid? DrugDefinitionRef { get; set; }
        public Guid? ActiveIngredientRef { get; set; }
        public Guid? MaxDoseUnitRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DrugDefinition DrugDefinition { get; set; }
        public virtual ActiveIngredientDefinition ActiveIngredient { get; set; }
        #endregion Parent Relations
    }
}