using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChattelDocumentOutputWithAccountancy
    {
        public Guid ObjectId { get; set; }
        public Guid? MaterialStabilityActionID { get; set; }
        public string TargetDocumentRecordLogNo { get; set; }
        public Guid? InputDocumentObjectID { get; set; }
        public TasinirCikisHareketTurEnum? outputStockMovementType { get; set; }
        public string Waybill { get; set; }
        public DateTime? WaybillDate { get; set; }
        public bool? IsContainsContributions { get; set; }
        public string InvoiceNumberSec { get; set; }
        public Guid? AccountancyRef { get; set; }
        public Guid? SupplierRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseChattelDocument BaseChattelDocument { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Accountancy Accountancy { get; set; }
        public virtual Supplier Supplier { get; set; }
        #endregion Parent Relations
    }
}