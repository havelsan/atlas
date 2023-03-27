using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MaterialPrice
    {
        public Guid ObjectId { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? PricingDetailRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Material Material { get; set; }
        public virtual PricingDetailDefinition PricingDetail { get; set; }
        #endregion Parent Relations
    }
}