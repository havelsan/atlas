using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EquivalentConsMaterial
    {
        public Guid ObjectId { get; set; }
        public Guid? ConsumableMaterialDefinitionRef { get; set; }
        public Guid? EquivalentMaterialRef { get; set; }

        #region Parent Relations
        public virtual ConsumableMaterialDefinition ConsumableMaterialDefinition { get; set; }
        public virtual ConsumableMaterialDefinition EquivalentMaterial { get; set; }
        #endregion Parent Relations
    }
}