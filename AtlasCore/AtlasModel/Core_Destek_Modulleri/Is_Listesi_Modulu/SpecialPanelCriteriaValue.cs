using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SpecialPanelCriteriaValue
    {
        public Guid ObjectId { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public Guid? SpecialPanelRef { get; set; }

        #region Parent Relations
        public virtual SpecialPanelDefinition SpecialPanel { get; set; }
        #endregion Parent Relations
    }
}