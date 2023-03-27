using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TradititionalMedAppCases
    {
        public Guid ObjectId { get; set; }
        public Guid? TraditionalMedicineRef { get; set; }

        #region Parent Relations
        public virtual TraditionalMedicine TraditionalMedicine { get; set; }
        #endregion Parent Relations
    }
}