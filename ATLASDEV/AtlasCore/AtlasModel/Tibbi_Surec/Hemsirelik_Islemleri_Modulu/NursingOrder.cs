using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingOrder
    {
        public Guid ObjectId { get; set; }
        public Guid? NursingApplicationRef { get; set; }
        public Guid? InPatientPhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingOrder BaseNursingOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual NursingApplication NursingApplication { get; set; }
        public virtual InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}