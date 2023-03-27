using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LinenType
    {
        public Guid ObjectId { get; set; }
        public string Type { get; set; }
        public int? MaxWashingCount { get; set; }
        public string IntegrationCode { get; set; }
        public Guid? LinenGroupRef { get; set; }

        #region Parent Relations
        public virtual LinenGroup LinenGroup { get; set; }
        #endregion Parent Relations
    }
}