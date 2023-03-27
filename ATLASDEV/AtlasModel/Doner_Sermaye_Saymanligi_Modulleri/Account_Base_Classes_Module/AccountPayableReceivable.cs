using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountPayableReceivable
    {
        public Guid ObjectId { get; set; }
        public APRTypeEnum? Type { get; set; }
        public string Name { get; set; }
        public decimal? Balance { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? PayerDefinitionRef { get; set; }

        #region Parent Relations
        public virtual Patient Patient { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual PayerDefinition PayerDefinition { get; set; }
        #endregion Parent Relations
    }
}