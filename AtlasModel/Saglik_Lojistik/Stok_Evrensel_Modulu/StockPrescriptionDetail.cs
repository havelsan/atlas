using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockPrescriptionDetail
    {
        public Guid ObjectId { get; set; }
        public string VolumeNo { get; set; }
        public string SerialNo { get; set; }
        public Guid? StockRef { get; set; }
        public Guid? PrescriptionRef { get; set; }
        public Guid? PrescriptionPaperRef { get; set; }

        #region Parent Relations
        public virtual Stock Stock { get; set; }
        public virtual Prescription Prescription { get; set; }
        #endregion Parent Relations
    }
}