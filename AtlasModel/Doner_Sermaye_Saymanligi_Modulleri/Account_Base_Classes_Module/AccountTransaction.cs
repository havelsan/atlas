using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountTransaction
    {
        public Guid ObjectId { get; set; }
        public double? TotalDiscountPrice { get; set; }
        public double? UnitPrice { get; set; }
        public string ExternalCode { get; set; }
        public double? Amount { get; set; }
        public PackageOutReasonEnum? PackageOutReason { get; set; }
        public string Description { get; set; }
        public DateTime? TransactionDate { get; set; }
        public bool? InvoiceInclusion { get; set; }
        public bool? MedulaInfoChangedByUser { get; set; }
        public bool? MedulaInfoUpdated { get; set; }
        public string UserNote { get; set; }
        public string MedulaProcessNo { get; set; }
        public long? Id { get; set; }
        public string MedulaResultCode { get; set; }
        public string MedulaResultMessage { get; set; }
        public decimal? MedulaPrice { get; set; }
        public double? UnitPriceOrg { get; set; }
        public string MedulaDescription { get; set; }
        public string MedulaBedNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Barcode { get; set; }
        public string ProducerCode { get; set; }
        public SendToENabizEnum? Nabiz700Status { get; set; }
        public string NabizResultCode { get; set; }
        public string NabizResultMessage { get; set; }
        public bool? UTSUsageCommitment { get; set; }
        public string MedulaAccessionNo { get; set; }
        public string MedulaDealerNo { get; set; }
        public SurgeryLeftRight? Position { get; set; }
        public Guid? ReceiptMaterialRef { get; set; }
        public Guid? SubEpisodeProtocolRef { get; set; }
        public Guid? SubActionMaterialRef { get; set; }
        public Guid? PatientInvoiceMaterialRef { get; set; }
        public Guid? CollectedPatientListRef { get; set; }
        public Guid? PayerInvoicePackageRef { get; set; }
        public Guid? PricingDetailRef { get; set; }
        public Guid? SubActionProcedureRef { get; set; }
        public Guid? ReceiptBackDetailRef { get; set; }
        public Guid? PayerInvoiceMaterialRef { get; set; }
        public Guid? PackageDefinitionRef { get; set; }
        public Guid? PatientInvoiceProcedureRef { get; set; }
        public Guid? ReceiptProcedureRef { get; set; }
        public Guid? AccountPayableReceivableRef { get; set; }
        public Guid? InpatientAdmissionRef { get; set; }
        public Guid? PayerInvoiceProcedureRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? DoctorRef { get; set; }
        public Guid? StockOutTransactionRef { get; set; }
        public Guid? UTSNotificationDetailRef { get; set; }

        #region Parent Relations
        public virtual SubEpisodeProtocol SubEpisodeProtocol { get; set; }
        public virtual SubActionMaterial SubActionMaterial { get; set; }
        public virtual PricingDetailDefinition PricingDetail { get; set; }
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        public virtual ReceiptProcedure ReceiptProcedure { get; set; }
        public virtual AccountPayableReceivable AccountPayableReceivable { get; set; }
        public virtual InpatientAdmission InpatientAdmission { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser Doctor { get; set; }
        public virtual StockTransaction StockOutTransaction { get; set; }
        public virtual UTSNotificationDetail UTSNotificationDetail { get; set; }
        #endregion Parent Relations
    }
}