using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChattelDocumentInputWithAccountancy
    {
        public Guid ObjectId { get; set; }
        public Guid? ChattelOutDocumentGuid { get; set; }
        public int? ActionRecordNo { get; set; }
        public string Waybill { get; set; }
        public DateTime? WaybillDate { get; set; }
        public TasinirMalGirisTurEnum? inputWithAccountancyType { get; set; }
        public Guid? AccountancyRef { get; set; }
        public Guid? SupplierRef { get; set; }
        public Guid? InPatientPhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseChattelDocument BaseChattelDocument { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Accountancy Accountancy { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}