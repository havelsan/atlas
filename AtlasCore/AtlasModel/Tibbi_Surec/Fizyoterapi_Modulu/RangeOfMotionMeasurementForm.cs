using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RangeOfMotionMeasurementForm
    {
        public Guid ObjectId { get; set; }
        public string ExtensionEHA { get; set; }
        public string ExtensionHABK { get; set; }
        public string ExtensionHASK { get; set; }
        public string ExtensionHAOK { get; set; }
        public string FlexionEHA { get; set; }
        public string FlexionHABK { get; set; }
        public string FlexionHAOK { get; set; }
        public string FlexionHASK { get; set; }
        public string AbductionEHA { get; set; }
        public string AbductionHABK { get; set; }
        public string AbductionHAOK { get; set; }
        public string AbductionHASK { get; set; }
        public string RotationEHA { get; set; }
        public string RotationHABK { get; set; }
        public string RotationHAOK { get; set; }
        public string RotationHASK { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}