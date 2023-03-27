using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalInfoDrugAllergies
    {
        public Guid ObjectId { get; set; }
        public Guid? MedicalInfoAllergiesRef { get; set; }
        public Guid? ActiveIngredientRef { get; set; }

        #region Parent Relations
        public virtual MedicalInfoAllergies MedicalInfoAllergies { get; set; }
        public virtual ActiveIngredientDefinition ActiveIngredient { get; set; }
        #endregion Parent Relations
    }
}