using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingLegMeasurement
    {
        public Guid ObjectId { get; set; }
        public string LowerRightLeg { get; set; }
        public string UpperRightLeg { get; set; }
        public string LowerLeftLeg { get; set; }
        public string UpperLeftLeg { get; set; }
        public DateTime? ActionDate { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}