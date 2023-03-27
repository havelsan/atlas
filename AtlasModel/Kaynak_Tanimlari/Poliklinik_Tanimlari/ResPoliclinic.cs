using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResPoliclinic
    {
        public Guid ObjectId { get; set; }
        public int? ASALCode { get; set; }
        public int? MHRSCode { get; set; }
        public int? MHRSAltKlinikKodu { get; set; }
        public bool? CopyHeightWeight { get; set; }
        public bool? IsDentalPoliclinic { get; set; }
        public PoliclinicTypeEnum? PoliclinicType { get; set; }
        public bool? PatientCallSystemInUse { get; set; }
        public bool? IsHealthCommittee { get; set; }
        public Guid? DepartmentRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResDepartment Department { get; set; }
        #endregion Parent Relations
    }
}