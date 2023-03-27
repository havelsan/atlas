using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientPaymentDetail
    {
        public Guid ObjectId { get; set; }
        public bool? IsBack { get; set; }
        public bool? IsCancel { get; set; }
        public DateTime? Date { get; set; }
        public decimal? PaymentPrice { get; set; }
        public PaymentTypeEnum? PaymentType { get; set; }
        public bool? IsParticipationShare { get; set; }
        public Guid? AccountTransactionRef { get; set; }
        public Guid? AccountDocumentRef { get; set; }

        #region Parent Relations
        public virtual AccountTransaction AccountTransaction { get; set; }
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Parent Relations
    }
}