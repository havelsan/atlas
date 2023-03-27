using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratoryGridDepartmentDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? LaboratoryTestRef { get; set; }
        public Guid? DepartmentRef { get; set; }

        #region Parent Relations
        public virtual LaboratoryTestDefinition LaboratoryTest { get; set; }
        #endregion Parent Relations
    }
}