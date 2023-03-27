using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountDocument
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public OutPatientInPatientBothEnum? PatientStatus { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentNo { get; set; }
        public bool? SendToAccounting { get; set; }
        public long? DocumentID { get; set; }
        public decimal? TotalPrice { get; set; }
        public PaymentTypeEnum? PaymentType { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? CashOfficeRef { get; set; }
        public Guid? CashierLogRef { get; set; }
        public Guid? EpisodeAccountActionRef { get; set; }
        public Guid? AccountActionRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        public virtual EpisodeAccountAction EpisodeAccountAction { get; set; }
        public virtual AccountAction AccountAction { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<AccountDocumentGroup> AccountDocumentGroups { get; set; }
        #endregion Child Relations
    }
}