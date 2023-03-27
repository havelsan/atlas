using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientOwnDrugTrx
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public double? Amount { get; set; }
        public Guid? PatientOwnDrugEntryDetailRef { get; set; }

        #region Parent Relations
        public virtual PatientOwnDrugEntryDetail PatientOwnDrugEntryDetail { get; set; }
        #endregion Parent Relations
    }
}