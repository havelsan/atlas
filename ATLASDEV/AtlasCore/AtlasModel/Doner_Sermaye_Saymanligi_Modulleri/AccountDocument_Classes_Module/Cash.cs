using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Cash
    {
        public Guid ObjectId { get; set; }
        public Guid? CurrencyTypeRef { get; set; }

        #region Base Object Navigation Property
        public virtual Payment Payment { get; set; }
        #endregion Base Object Navigation Property
    }
}