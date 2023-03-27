using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReviewActionPatientDet
    {
        public Guid ObjectId { get; set; }
        public string Clinic { get; set; }
        public string Patient { get; set; }
        public long? UniqueRefNo { get; set; }
        public double? Amount { get; set; }
        public string MaterialName { get; set; }
        public Guid? PatientObjID { get; set; }
        public Guid? MaterialObjID { get; set; }
        public Guid? ReviewActionRef { get; set; }

        #region Parent Relations
        public virtual ReviewAction ReviewAction { get; set; }
        #endregion Parent Relations
    }
}