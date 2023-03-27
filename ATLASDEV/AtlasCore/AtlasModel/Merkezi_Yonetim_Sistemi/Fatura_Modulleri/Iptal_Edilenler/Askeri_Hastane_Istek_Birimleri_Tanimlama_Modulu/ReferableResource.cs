using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReferableResource
    {
        public Guid ObjectId { get; set; }
        public string ResourceObjectID { get; set; }
        public string ResourceName { get; set; }
        public string ResourceName_Shadow { get; set; }
        public Guid? LastUpdateRealSiteGuid { get; set; }
        public Guid? LastUpdateSiteGuid { get; set; }
        public Guid? ReferableHospitalRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}