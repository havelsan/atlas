using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResDepartment
    {
        public Guid ObjectId { get; set; }
        public bool? ActionEnabled { get; set; }
        public ResourceTypeEnum? ResourceType { get; set; }
        public bool? IsEmergencyDepartment { get; set; }
        public Guid? MainDepartmentRef { get; set; }
        public Guid? BuildingRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResDepartment MainDepartment { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<ResClinic> Clinics { get; set; }
        #endregion Child Relations
    }
}