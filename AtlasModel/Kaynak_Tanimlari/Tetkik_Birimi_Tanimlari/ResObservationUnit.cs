using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResObservationUnit
    {
        public Guid ObjectId { get; set; }
        public bool? IsExternalObservationUnit { get; set; }
        public Guid? DepartmentRef { get; set; }
        public Guid? ObservationDepartmentRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResDepartment Department { get; set; }
        #endregion Parent Relations
    }
}