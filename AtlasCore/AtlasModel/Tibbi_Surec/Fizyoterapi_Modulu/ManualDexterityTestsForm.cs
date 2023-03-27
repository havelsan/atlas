using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ManualDexterityTestsForm
    {
        public Guid ObjectId { get; set; }
        public string PurduePegboardTest { get; set; }
        public string OConnorFingerDexterityTest { get; set; }
        public string NineHolePegTest { get; set; }
        public string MobergTest { get; set; }
        public string BimanuelFineMotorTest { get; set; }
        public string DellonTest { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}