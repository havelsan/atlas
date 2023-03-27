using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InpatientDrugOrder
    {
        public Guid ObjectId { get; set; }
        public double? PackageAmount { get; set; }
        public Guid? DrugOrderID { get; set; }
        public Guid? InpatientPrescriptionRef { get; set; }

        #region Base Object Navigation Property
        public virtual DrugOrder DrugOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InpatientPrescription InpatientPrescription { get; set; }
        #endregion Parent Relations
    }
}