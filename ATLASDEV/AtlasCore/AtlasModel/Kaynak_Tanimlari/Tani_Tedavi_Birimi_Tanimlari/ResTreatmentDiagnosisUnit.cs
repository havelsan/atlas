using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResTreatmentDiagnosisUnit
    {
        public Guid ObjectId { get; set; }
        public bool? OpenOnSaturday { get; set; }
        public bool? OpenOnSunday { get; set; }
        public bool? OpenOnTuesday { get; set; }
        public bool? OpenOnWednesday { get; set; }
        public bool? OpenOnFriday { get; set; }
        public bool? OpenOnMonday { get; set; }
        public bool? OpenOnThursday { get; set; }
        public Guid? DepartmentRef { get; set; }
        public Guid? HospitalRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResDepartment Department { get; set; }
        #endregion Parent Relations
    }
}