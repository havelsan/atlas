using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugDrugInteraction
    {
        public Guid ObjectId { get; set; }
        public string Message { get; set; }
        public InteractionLevelTypeEnum? InteractionLevelType { get; set; }
        public Guid? InteractionDrugRef { get; set; }
        public Guid? DrugDefinitionRef { get; set; }

        #region Parent Relations
        public virtual DrugDefinition InteractionDrug { get; set; }
        public virtual DrugDefinition DrugDefinition { get; set; }
        #endregion Parent Relations
    }
}