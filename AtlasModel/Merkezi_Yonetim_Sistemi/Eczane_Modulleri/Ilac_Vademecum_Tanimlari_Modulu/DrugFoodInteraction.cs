using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugFoodInteraction
    {
        public Guid ObjectId { get; set; }
        public InteractionLevelTypeEnum? InteractionLevelType { get; set; }
        public string Message { get; set; }
        public Guid? DietMaterialDefinitionRef { get; set; }
        public Guid? DrugDefinitionRef { get; set; }

        #region Parent Relations
        public virtual DietMaterialDefinition DietMaterialDefinition { get; set; }
        public virtual DrugDefinition DrugDefinition { get; set; }
        #endregion Parent Relations
    }
}