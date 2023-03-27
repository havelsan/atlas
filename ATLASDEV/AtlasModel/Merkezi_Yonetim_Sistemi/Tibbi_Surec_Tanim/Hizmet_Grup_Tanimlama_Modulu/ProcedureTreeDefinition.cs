using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedureTreeDefinition
    {
        public Guid ObjectId { get; set; }
        public string ExternalCode { get; set; }
        public long? ID { get; set; }
        public string Description_Shadow { get; set; }
        public string Description { get; set; }
        public Guid? ParentIDRef { get; set; }
        public Guid? RevenueSubAccountCodeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ProcedureTreeDefinition ParentID { get; set; }
        public virtual RevenueSubAccountCodeDefinition RevenueSubAccountCode { get; set; }
        #endregion Parent Relations
    }
}