using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SohaRuleLog
    {
        public Guid ObjectId { get; set; }
        public DateTime? LogDate { get; set; }
        public OperationTypeEnum? LogType { get; set; }
        public Guid? SohaRuleRef { get; set; }
        public Guid? UserRef { get; set; }

        #region Parent Relations
        public virtual ResUser User { get; set; }
        #endregion Parent Relations
    }
}