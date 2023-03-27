using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SohaRuleRepoUpdate
    {
        public Guid ObjectId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public SohaRuleRepoTypeEnum? RepositoryType { get; set; }
    }
}