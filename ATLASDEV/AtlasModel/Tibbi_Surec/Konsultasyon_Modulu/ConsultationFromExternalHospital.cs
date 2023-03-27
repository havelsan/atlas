using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ConsultationFromExternalHospital
    {
        public Guid ObjectId { get; set; }
        public Guid? RequestDescription { get; set; }
        public Guid? RequestedExternalHospitalRef { get; set; }
        public Guid? RequestedExternalSpecialityRef { get; set; }
        public Guid? PhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual PhysicianApplication PhysicianApplication { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ExternalHospitalDefinition RequestedExternalHospital { get; set; }
        public virtual PhysicianApplication PhysicianApplicationExternalConsultations { get; set; }
        #endregion Parent Relations
    }
}