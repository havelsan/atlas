using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratoryGridPanelTestDefinition
    {
        public Guid ObjectId { get; set; }
        public int? SequenceNo { get; set; }
        public Guid? LaboratoryTestRef { get; set; }
        public Guid? LaboratoryTestDefinitionRef { get; set; }

        #region Parent Relations
        public virtual LaboratoryTestDefinition LaboratoryTest { get; set; }
        public virtual LaboratoryTestDefinition LaboratoryTestDefinition { get; set; }
        #endregion Parent Relations
    }
}