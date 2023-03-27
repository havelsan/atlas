using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResClinic
    {
        public Guid ObjectId { get; set; }
        public bool? IsEmergencyClinic { get; set; }
        public int? PreDischargeLimit { get; set; }
        public bool? HasCertificate { get; set; }
        public Guid? DepartmentRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResWard ResWard { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResDepartment Department { get; set; }
        #endregion Parent Relations
    }
}