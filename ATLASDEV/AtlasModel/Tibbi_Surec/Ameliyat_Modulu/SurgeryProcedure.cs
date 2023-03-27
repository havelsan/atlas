using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryProcedure
    {
        public Guid ObjectId { get; set; }
        public bool? HasChangedAtChildObjects { get; set; }
        public RabsonEnum? RabsonGroup { get; set; }
        public string ComplicationDescription { get; set; }
        public bool? IsComplicationSurgery { get; set; }
        public bool? IsScoliosisSurgery { get; set; }
        public Guid? DepartmentRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSurgeryProcedure BaseSurgeryProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection Department { get; set; }
        #endregion Parent Relations
    }
}