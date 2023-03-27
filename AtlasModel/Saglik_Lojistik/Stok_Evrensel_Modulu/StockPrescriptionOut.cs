using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockPrescriptionOut
    {
        public Guid ObjectId { get; set; }
        public Guid? PrescriptionPaperRef { get; set; }
        public Guid? PrescriptionRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Prescription Prescription { get; set; }
        #endregion Parent Relations
    }
}