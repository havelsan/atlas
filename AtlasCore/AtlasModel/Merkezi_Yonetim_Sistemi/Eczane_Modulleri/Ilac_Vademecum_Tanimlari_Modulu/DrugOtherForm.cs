using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOtherForm
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugDefinitionRef { get; set; }
        public Guid? OtherFormRef { get; set; }

        #region Parent Relations
        public virtual DrugDefinition DrugDefinition { get; set; }
        public virtual DrugDefinition OtherForm { get; set; }
        #endregion Parent Relations
    }
}