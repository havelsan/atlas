using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InpatientPrescription
    {
        public Guid ObjectId { get; set; }
        public bool? ChangePres { get; set; }
        public Guid? ExternalPharmacyRef { get; set; }

        #region Base Object Navigation Property
        public virtual Prescription Prescription { get; set; }
        #endregion Base Object Navigation Property
    }
}