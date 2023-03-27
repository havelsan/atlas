using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InfectionCommitteeDetail
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? InfectionCommitteeRef { get; set; }
        public Guid? DrugOrderRef { get; set; }

        #region Parent Relations
        public virtual InfectionCommittee InfectionCommittee { get; set; }
        public virtual DrugOrder DrugOrder { get; set; }
        #endregion Parent Relations
    }
}