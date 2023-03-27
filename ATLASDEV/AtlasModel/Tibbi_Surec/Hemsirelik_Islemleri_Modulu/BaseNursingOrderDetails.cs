using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseNursingOrderDetails
    {
        public Guid ObjectId { get; set; }
        public string Result { get; set; }
        public string Notes { get; set; }
        public string Result_Pulse { get; set; }
        public string ResultBloodPressure { get; set; }
        public string Result_SPO2 { get; set; }
        public Guid? VitalSignRef { get; set; }

        #region Base Object Navigation Property
        public virtual PeriodicOrderDetail PeriodicOrderDetail { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual VitalSign VitalSign { get; set; }
        #endregion Parent Relations
    }
}