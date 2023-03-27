using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryPersonnel
    {
        public Guid ObjectId { get; set; }
        public SurgeryRoleEnum? Role { get; set; }
        public Guid? SurgeryRef { get; set; }

        #region Parent Relations
        public virtual Surgery Surgery { get; set; }
        #endregion Parent Relations
    }
}