using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockActionConfig : IEntityTypeConfiguration<AtlasModel.StockAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockAction> builder)
        {
            builder.ToTable("STOCKACTION");
            builder.HasKey(nameof(AtlasModel.StockAction.ObjectId));
            builder.Property(nameof(AtlasModel.StockAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockAction.Description)).HasColumnName("DESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.StockAction.RegistrationNumber)).HasColumnName("REGISTRATIONNUMBER").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockAction.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.StockAction.RegistrationNumberSeq)).HasColumnName("REGISTRATIONNUMBERSEQ");
            builder.Property(nameof(AtlasModel.StockAction.StockActionID)).HasColumnName("STOCKACTIONID");
            builder.Property(nameof(AtlasModel.StockAction.SequenceNumber)).HasColumnName("SEQUENCENUMBER").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockAction.SequenceNumberSeq)).HasColumnName("SEQUENCENUMBERSEQ");
            builder.Property(nameof(AtlasModel.StockAction.AdditionalDocumentCount)).HasColumnName("ADDITIONALDOCUMENTCOUNT");
            builder.Property(nameof(AtlasModel.StockAction.IsEntryOldMaterial)).HasColumnName("ISENTRYOLDMATERIAL");
            builder.Property(nameof(AtlasModel.StockAction.GrandTotal)).HasColumnName("GRANDTOTAL").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.StockAction.InvoicePicture)).HasColumnName("INVOICEPICTURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockAction.TotalPrice)).HasColumnName("TOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_Yil)).HasColumnName("MKYS_YIL");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_GelenVeri)).HasColumnName("MKYS_GELENVERI").HasColumnType("CLOB");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_AyniyatMakbuzID)).HasColumnName("MKYS_AYNIYATMAKBUZID");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_EAlimYontemi)).HasColumnName("MKYS_EALIMYONTEMI").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_EButceTur)).HasColumnName("MKYS_EBUTCETUR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_ETedarikTuru)).HasColumnName("MKYS_ETEDARIKTURU").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_TeslimEden)).HasColumnName("MKYS_TESLIMEDEN");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_EMalzemeGrup)).HasColumnName("MKYS_EMALZEMEGRUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_TeslimAlan)).HasColumnName("MKYS_TESLIMALAN");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_MakbuzTarihi)).HasColumnName("MKYS_MAKBUZTARIHI");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_DepoKayitNo)).HasColumnName("MKYS_DEPOKAYITNO");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_CikisIslemTuru)).HasColumnName("MKYS_CIKISISLEMTURU").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_CikisStokHareketTuru)).HasColumnName("MKYS_CIKISSTOKHAREKETTURU").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_CikisYapilanDepoKayitNo)).HasColumnName("MKYS_CIKISYAPILANDEPOKAYITNO");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_CikisYapilanKisiTCNo)).HasColumnName("MKYS_CIKISYAPILANKISITCNO");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_GonderimTarihi)).HasColumnName("MKYS_GONDERIMTARIHI");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_GidenVeri)).HasColumnName("MKYS_GIDENVERI").HasColumnType("CLOB");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_GeldigiYer)).HasColumnName("MKYS_GELDIGIYER");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_KarsiBirimKayitNo)).HasColumnName("MKYS_KARSIBIRIMKAYITNO");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_MakbuzNo)).HasColumnName("MKYS_MAKBUZNO");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_MuayeneNo)).HasColumnName("MKYS_MUAYENENO");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_MuayeneTarihi)).HasColumnName("MKYS_MUAYENETARIHI");
            builder.Property(nameof(AtlasModel.StockAction.MKYSControl)).HasColumnName("MKYSCONTROL");
            builder.Property(nameof(AtlasModel.StockAction.MKYS_TeslimAlanObjID)).HasColumnName("MKYS_TESLIMALANOBJID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockAction.MKYS_TeslimEdenObjID)).HasColumnName("MKYS_TESLIMEDENOBJID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockAction.IsPTSAction)).HasColumnName("ISPTSACTION");
            builder.Property(nameof(AtlasModel.StockAction.PTSNumber)).HasColumnName("PTSNUMBER").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.StockAction.AccountingTermRef)).HasColumnName("ACCOUNTINGTERM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockAction.DestinationStoreRef)).HasColumnName("DESTINATIONSTORE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockAction.StoreRef)).HasColumnName("STORE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockAction.StockActionInspectionRef)).HasColumnName("STOCKACTIONINSPECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockAction.BudgetTypeDefinitionRef)).HasColumnName("BUDGETTYPEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.AccountingTerm).WithOne().HasForeignKey<AtlasModel.StockAction>(x => x.AccountingTermRef).IsRequired(false);
            builder.HasOne(t => t.DestinationStore).WithOne().HasForeignKey<AtlasModel.StockAction>(x => x.DestinationStoreRef).IsRequired(false);
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.StockAction>(x => x.StoreRef).IsRequired(true);
            builder.HasOne(t => t.StockActionInspection).WithOne().HasForeignKey<AtlasModel.StockAction>(x => x.StockActionInspectionRef).IsRequired(false);
            builder.HasOne(t => t.BudgetTypeDefinition).WithOne().HasForeignKey<AtlasModel.StockAction>(x => x.BudgetTypeDefinitionRef).IsRequired(false);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.StockActionDetails).WithOne(x => x.StockAction).HasForeignKey(x => x.StockActionRef);
            #endregion Child Relations
        }
    }
}