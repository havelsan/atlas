using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DistributionTypeDefinition
    {
        public Guid ObjectId { get; set; }
        public string DistributionType { get; set; }
        public string QRef { get; set; }
        public string DistributionType_Shadow { get; set; }
        public string QRef_Shadow { get; set; }
        public MKYS_EOlcuBirimEnum? MKYS_DistType { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}