using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResSurgeryRoom
    {
        public Guid ObjectId { get; set; }
        public Guid? SurgeryDepartmentRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property
    }
}