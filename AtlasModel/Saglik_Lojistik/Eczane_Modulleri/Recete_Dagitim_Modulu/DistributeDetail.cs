using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DistributeDetail
    {
        public Guid ObjectId { get; set; }
        public long? PatientQuarantineNo { get; set; }
        public decimal? Price { get; set; }
        public long? PatientProtocolNo { get; set; }
        public string PatientName { get; set; }
        public Guid? ExternalPharmacyRef { get; set; }
        public Guid? PrescriptionRef { get; set; }
        public Guid? PrescriptionDistributeRef { get; set; }

        #region Parent Relations
        public virtual Prescription Prescription { get; set; }
        #endregion Parent Relations
    }
}