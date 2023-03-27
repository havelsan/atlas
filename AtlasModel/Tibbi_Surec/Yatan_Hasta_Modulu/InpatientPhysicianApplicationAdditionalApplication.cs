using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InpatientPhysicianApplicationAdditionalApplication
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalApplication BaseAdditionalApplication { get; set; }
        #endregion Base Object Navigation Property
    }
}