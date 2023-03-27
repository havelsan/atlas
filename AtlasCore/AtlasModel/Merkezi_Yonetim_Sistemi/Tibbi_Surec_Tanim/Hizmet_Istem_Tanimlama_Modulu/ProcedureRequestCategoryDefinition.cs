using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedureRequestCategoryDefinition
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public string CategoryName { get; set; }
        public int? OrderNo { get; set; }
        public Guid? ProcedureRequestFormRef { get; set; }

        #region Parent Relations
        public virtual ProcedureRequestFormDefinition ProcedureRequestForm { get; set; }
        #endregion Parent Relations
    }
}