using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class WorkDayExceptionDef
    {
        public Guid ObjectId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Description_Shadow { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}