using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SpecialPanelDefinition
    {
        public Guid ObjectId { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
        public Guid? WorkListDefinitionRef { get; set; }
        public Guid? UserRef { get; set; }

        #region Parent Relations
        public virtual WorkListDefinition WorkListDefinition { get; set; }
        public virtual ResUser User { get; set; }
        #endregion Parent Relations
    }
}