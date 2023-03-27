using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RadiologyGridEquipmentDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? EquipmentRef { get; set; }
        public Guid? RadiologyTestRef { get; set; }

        #region Parent Relations
        public virtual RadiologyTestDefinition RadiologyTest { get; set; }
        #endregion Parent Relations
    }
}