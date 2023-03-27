using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockAction
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? TransactionDate { get; set; }
        public long? RegistrationNumberSeq { get; set; }
        public long? StockActionID { get; set; }
        public string SequenceNumber { get; set; }
        public long? SequenceNumberSeq { get; set; }
        public int? AdditionalDocumentCount { get; set; }
        public bool? IsEntryOldMaterial { get; set; }
        public decimal? GrandTotal { get; set; }
        public Guid? InvoicePicture { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? MKYS_Yil { get; set; }
        public string MKYS_GelenVeri { get; set; }
        public int? MKYS_AyniyatMakbuzID { get; set; }
        public MKYS_EAlimYontemiEnum? MKYS_EAlimYontemi { get; set; }
        public MKYS_EButceTurEnum? MKYS_EButceTur { get; set; }
        public MKYS_ETedarikTurEnum? MKYS_ETedarikTuru { get; set; }
        public string MKYS_TeslimEden { get; set; }
        public MKYS_EMalzemeGrupEnum? MKYS_EMalzemeGrup { get; set; }
        public string MKYS_TeslimAlan { get; set; }
        public DateTime? MKYS_MakbuzTarihi { get; set; }
        public int? MKYS_DepoKayitNo { get; set; }
        public MKYS_ECikisIslemTuruEnum? MKYS_CikisIslemTuru { get; set; }
        public MKYS_ECikisStokHareketTurEnum? MKYS_CikisStokHareketTuru { get; set; }
        public int? MKYS_CikisYapilanDepoKayitNo { get; set; }
        public string MKYS_CikisYapilanKisiTCNo { get; set; }
        public DateTime? MKYS_GonderimTarihi { get; set; }
        public string MKYS_GidenVeri { get; set; }
        public string MKYS_GeldigiYer { get; set; }
        public int? MKYS_KarsiBirimKayitNo { get; set; }
        public int? MKYS_MakbuzNo { get; set; }
        public string MKYS_MuayeneNo { get; set; }
        public DateTime? MKYS_MuayeneTarihi { get; set; }
        public bool? MKYSControl { get; set; }
        public Guid? MKYS_TeslimAlanObjID { get; set; }
        public Guid? MKYS_TeslimEdenObjID { get; set; }
        public bool? IsPTSAction { get; set; }
        public string PTSNumber { get; set; }
        public Guid? AccountingTermRef { get; set; }
        public Guid? DestinationStoreRef { get; set; }
        public Guid? StoreRef { get; set; }
        public Guid? StockActionInspectionRef { get; set; }
        public Guid? BudgetTypeDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual AccountingTerm AccountingTerm { get; set; }
        public virtual Store DestinationStore { get; set; }
        public virtual Store Store { get; set; }
        public virtual StockActionInspection StockActionInspection { get; set; }
        public virtual BudgetTypeDefinition BudgetTypeDefinition { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<StockActionDetail> StockActionDetails { get; set; }
        #endregion Child Relations
    }
}