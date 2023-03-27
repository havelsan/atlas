using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChattelDocumentWithPurchase
    {
        public Guid ObjectId { get; set; }
        public decimal? XXXXXXGeneralTotal { get; set; }
        public decimal? XXXXXXVatTotal { get; set; }
        public decimal? XXXXXXSaleTotal { get; set; }
        public decimal? XXXXXXInvoice { get; set; }
        public DateTime? WaybillDate { get; set; }
        public string XXXXXXTalepNo { get; set; }
        public DateTime? AuctionDate { get; set; }
        public string RegistrationAuctionNo { get; set; }
        public DateTime? ConclusionDateTime { get; set; }
        public string ConclusionNumber { get; set; }
        public DateTime? ContractDateTime { get; set; }
        public string ContractNumber { get; set; }
        public bool? FreeEntry { get; set; }
        public DateTime? ExaminationReportDate { get; set; }
        public string ExaminationReportNo { get; set; }
        public int? XXXXXXEtkilenenAdet { get; set; }
        public bool? XXXXXXIslemBasarili { get; set; }
        public int? XXXXXXKayitId { get; set; }
        public string XXXXXXMesaj { get; set; }
        public string Waybill { get; set; }
        public string PatientUniqueNo { get; set; }
        public string PatientFullName { get; set; }
        public int? XXXXXXSatMKabulId { get; set; }
        public int? FastSoftUygulamaId { get; set; }
        public int? FastSoftFaturaId { get; set; }
        public bool? IsFastSoft { get; set; }
        public Guid? SupplierRef { get; set; }
        public Guid? ProjectCodeDefinitionRef { get; set; }
        public Guid? InPatientPhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseChattelDocument BaseChattelDocument { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Supplier Supplier { get; set; }
        public virtual InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}