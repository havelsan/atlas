using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ExternalHospitalDefinition
    {
        public Guid ObjectId { get; set; }
        public long? HospitalID { get; set; }
        public int? MedulaSiteCode { get; set; }
        public Guid? LinkedCityRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property
    }
}