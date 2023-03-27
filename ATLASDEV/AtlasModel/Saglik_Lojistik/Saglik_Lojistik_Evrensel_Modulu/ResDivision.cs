using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResDivision
    {
        public Guid ObjectId { get; set; }
        public Guid? HeaderShipRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResHeaderShip HeaderShip { get; set; }
        #endregion Parent Relations
    }
}