using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientOwnDrugTrxDetail
    {
        public Guid ObjectId { get; set; }
        public double? Amount { get; set; }
        public Guid? DrugOrderDetailRef { get; set; }
        public Guid? PatientOwnDrugTrxRef { get; set; }

        #region Parent Relations
        public virtual DrugOrderDetail DrugOrderDetail { get; set; }
        public virtual PatientOwnDrugTrx PatientOwnDrugTrx { get; set; }
        #endregion Parent Relations
    }
}