using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResHeaderShip
    {
        public Guid ObjectId { get; set; }
        public Guid? HospitalRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property
    }
}