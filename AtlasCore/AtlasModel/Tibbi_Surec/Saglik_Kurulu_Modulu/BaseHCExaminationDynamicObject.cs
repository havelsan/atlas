using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseHCExaminationDynamicObject
    {
        public Guid ObjectId { get; set; }
        public Guid? PatientExaminationRef { get; set; }

        #region Parent Relations
        public virtual PatientExamination PatientExamination { get; set; }
        #endregion Parent Relations
    }
}