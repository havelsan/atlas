using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseAnesthesiaProcedure
    {
        public Guid ObjectId { get; set; }
        public string Note { get; set; }
        public Guid? ProcedureDoctor2Ref { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser ProcedureDoctor2 { get; set; }
        #endregion Parent Relations
    }
}