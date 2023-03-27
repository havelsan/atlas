using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseDietOrder
    {
        public Guid ObjectId { get; set; }
        public Guid? MealTypeRef { get; set; }

        #region Base Object Navigation Property
        public virtual PeriodicOrder PeriodicOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MealTypes MealType { get; set; }
        #endregion Parent Relations
    }
}