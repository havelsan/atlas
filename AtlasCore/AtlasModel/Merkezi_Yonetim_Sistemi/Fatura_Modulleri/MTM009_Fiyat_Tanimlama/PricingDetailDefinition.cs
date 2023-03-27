using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PricingDetailDefinition
    {
        public Guid ObjectId { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateStart { get; set; }
        public string Description { get; set; }
        public string ExternalCode { get; set; }
        public long? SPTSPricingDetailID { get; set; }
        public double? OutPatientDiscountPercent { get; set; }
        public string Description_Shadow { get; set; }
        public decimal? Price { get; set; }
        public double? Point { get; set; }
        public decimal? PriceWithOutDiscount { get; set; }
        public double? DiscountPercent { get; set; }
        public MedulaSUTGroupEnum? MedulaSUTGroup { get; set; }
        public double? InPatientDiscountPercent { get; set; }
        public Guid? PricingListRef { get; set; }
        public Guid? PricingListGroupRef { get; set; }
        public Guid? CurrencyTypeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}