using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedurePriceDefinition
    {
        public Guid ObjectId { get; set; }
        public int? AMOUNT { get; set; }
        public Guid? ProcedureObjectRef { get; set; }
        public Guid? PricingDetailRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ProcedureDefinition ProcedureObject { get; set; }
        public virtual PricingDetailDefinition PricingDetail { get; set; }
        #endregion Parent Relations
    }
}