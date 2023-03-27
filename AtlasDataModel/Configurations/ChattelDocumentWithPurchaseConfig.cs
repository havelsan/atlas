using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChattelDocumentWithPurchaseConfig : IEntityTypeConfiguration<AtlasModel.ChattelDocumentWithPurchase>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChattelDocumentWithPurchase> builder)
        {
            builder.ToTable("CHATTELDOCWITHPURCHASE");
            builder.HasKey(nameof(AtlasModel.ChattelDocumentWithPurchase.ObjectId));
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXGeneralTotal)).HasColumnName("XXXXXXGENERALTOTAL").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXVatTotal)).HasColumnName("XXXXXXVATTOTAL").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXSaleTotal)).HasColumnName("XXXXXXSALETOTAL").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXInvoice)).HasColumnName("XXXXXXINVOICE").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.WaybillDate)).HasColumnName("WAYBILLDATE");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXTalepNo)).HasColumnName("XXXXXXTALEPNO");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.AuctionDate)).HasColumnName("AUCTIONDATE");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.RegistrationAuctionNo)).HasColumnName("REGISTRATIONAUCTIONNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ConclusionDateTime)).HasColumnName("CONCLUSIONDATETIME");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ConclusionNumber)).HasColumnName("CONCLUSIONNUMBER").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ContractDateTime)).HasColumnName("CONTRACTDATETIME");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ContractNumber)).HasColumnName("CONTRACTNUMBER").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.FreeEntry)).HasColumnName("FREEENTRY");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ExaminationReportDate)).HasColumnName("EXAMINATIONREPORTDATE");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ExaminationReportNo)).HasColumnName("EXAMINATIONREPORTNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXEtkilenenAdet)).HasColumnName("XXXXXXETKILENENADET");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXIslemBasarili)).HasColumnName("XXXXXXISLEMBASARILI");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXKayitId)).HasColumnName("XXXXXXKAYITID");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXMesaj)).HasColumnName("XXXXXXMESAJ");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.Waybill)).HasColumnName("WAYBILL").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.PatientUniqueNo)).HasColumnName("PATIENTUNIQUENO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.PatientFullName)).HasColumnName("PATIENTFULLNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.XXXXXXSatMKabulId)).HasColumnName("XXXXXXSATMKABULID");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.FastSoftUygulamaId)).HasColumnName("FASTSOFTUYGULAMAID");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.FastSoftFaturaId)).HasColumnName("FASTSOFTFATURAID");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.IsFastSoft)).HasColumnName("ISFASTSOFT");
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.SupplierRef)).HasColumnName("SUPPLIER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.ProjectCodeDefinitionRef)).HasColumnName("PROJECTCODEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentWithPurchase.InPatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseChattelDocument).WithOne().HasForeignKey<AtlasModel.BaseChattelDocument>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Supplier).WithOne().HasForeignKey<AtlasModel.ChattelDocumentWithPurchase>(x => x.SupplierRef).IsRequired(true);
            builder.HasOne(t => t.InPatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.ChattelDocumentWithPurchase>(x => x.InPatientPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}