using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratoryGridBoundedTestDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? LaboratoryTestDefinitionRef { get; set; }
        public Guid? LaboratoryTestRef { get; set; }

        #region Parent Relations
        public virtual LaboratoryTestDefinition LaboratoryTestDefinition { get; set; }
        public virtual LaboratoryTestDefinition LaboratoryTest { get; set; }
        #endregion Parent Relations
    }
}