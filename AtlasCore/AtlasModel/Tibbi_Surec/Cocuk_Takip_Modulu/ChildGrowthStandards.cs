using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChildGrowthStandards
    {
        public Guid ObjectId { get; set; }
        public Guid? PatientExaminationRef { get; set; }

        #region Base Object Navigation Property
        public virtual SpecialityBasedObject SpecialityBasedObject { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PatientExamination PatientExamination { get; set; }
        #endregion Parent Relations
    }
}