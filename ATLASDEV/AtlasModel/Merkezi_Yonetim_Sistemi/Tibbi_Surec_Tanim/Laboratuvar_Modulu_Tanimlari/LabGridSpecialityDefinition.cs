using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LabGridSpecialityDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? SpecialityDefinitonRef { get; set; }
        public Guid? LaboratoryTestRef { get; set; }

        #region Parent Relations
        public virtual LaboratoryTestDefinition LaboratoryTest { get; set; }
        #endregion Parent Relations
    }
}