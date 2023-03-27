using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class IntensiveCareSpecialityObj
    {
        public Guid ObjectId { get; set; }
        public IntensiveCareStepEnum? IntensiveCareStep { get; set; }
        public IntensiveCareTypeEnum? IntensiveCareType { get; set; }
        public Guid? SepsisStatusRef { get; set; }
        public Guid? SepticShockRef { get; set; }

        #region Base Object Navigation Property
        public virtual SpecialityBasedObject SpecialityBasedObject { get; set; }
        #endregion Base Object Navigation Property
    }
}