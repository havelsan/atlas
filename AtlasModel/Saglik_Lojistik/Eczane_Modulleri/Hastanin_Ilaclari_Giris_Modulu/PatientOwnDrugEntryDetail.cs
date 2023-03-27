using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientOwnDrugEntryDetail
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public double? SendAmount { get; set; }
        public double? Amount { get; set; }
        public double? BarcodeAmount { get; set; }
        public OwnDrugStatus? Status { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? PatientOwnDrugEntryRef { get; set; }

        #region Parent Relations
        public virtual Material Material { get; set; }
        public virtual PatientOwnDrugEntry PatientOwnDrugEntry { get; set; }
        #endregion Parent Relations
    }
}