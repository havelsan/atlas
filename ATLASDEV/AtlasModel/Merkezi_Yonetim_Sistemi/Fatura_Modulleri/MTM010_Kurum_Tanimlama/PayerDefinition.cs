using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PayerDefinition
    {
        public Guid ObjectId { get; set; }
        public string TaxNumber { get; set; }
        public string ZipCode { get; set; }
        public string TaxOffice { get; set; }
        public string Name { get; set; }
        public bool? GetPatientParticipation { get; set; }
        public string Address { get; set; }
        public string FaxNumber { get; set; }
        public long? ID { get; set; }
        public string PhoneNumber { get; set; }
        public long? Code { get; set; }
        public int? DayOfSent { get; set; }
        public int? LimitOfInvoiceSummaryList { get; set; }
        public string Name_Shadow { get; set; }
        public bool? IsInternal { get; set; }
        public bool? OnlineInvoice { get; set; }
        public bool? CancelPatientShareAccTrx { get; set; }
        public int? PaymentDayLimit { get; set; }
        public bool? HealthTourism { get; set; }
        public Guid? CityRef { get; set; }
        public Guid? TypeRef { get; set; }
        public Guid? ParentPayerRef { get; set; }
        public Guid? MedulaDevredilenKurumRef { get; set; }
        public Guid? RevenueSubAccountCodeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PayerDefinition ParentPayer { get; set; }
        public virtual DevredilenKurum MedulaDevredilenKurum { get; set; }
        public virtual RevenueSubAccountCodeDefinition RevenueSubAccountCode { get; set; }
        #endregion Parent Relations
    }
}