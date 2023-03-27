using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MKYSTrx
    {
        public Guid ObjectId { get; set; }
        public int? MkysID { get; set; }
        public decimal? Amount { get; set; }
        public decimal? UnitPrice { get; set; }
        public long? VatRate { get; set; }
        public string MkysDescription { get; set; }
        public string NATOStockNO { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? TransactionID { get; set; }
        public int? MKYS_StokHareketID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public MKYS_EButceTurEnum? MKYS_Butce { get; set; }
        public string Barcode { get; set; }
        public TransactionTypeEnum? InOut { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? MainStoreDefinitionRef { get; set; }

        #region Parent Relations
        public virtual Material Material { get; set; }
        public virtual MainStoreDefinition MainStoreDefinition { get; set; }
        #endregion Parent Relations
    }
}