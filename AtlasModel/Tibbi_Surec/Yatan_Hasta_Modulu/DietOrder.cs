using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DietOrder
    {
        public Guid ObjectId { get; set; }
        public Guid? InpatientPhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseDietOrder BaseDietOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InPatientPhysicianApplication InpatientPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}