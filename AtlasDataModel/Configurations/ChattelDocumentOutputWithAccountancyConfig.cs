using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChattelDocumentOutputWithAccountancyConfig : IEntityTypeConfiguration<AtlasModel.ChattelDocumentOutputWithAccountancy>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChattelDocumentOutputWithAccountancy> builder)
        {
            builder.ToTable("CHATTELDOCOWITHACCOUNTANCY");
            builder.HasKey(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.ObjectId));
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.MaterialStabilityActionID)).HasColumnName("MATERIALSTABILITYACTIONID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.TargetDocumentRecordLogNo)).HasColumnName("TARGETDOCUMENTRECORDLOGNO");
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.InputDocumentObjectID)).HasColumnName("INPUTDOCUMENTOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.outputStockMovementType)).HasColumnName("OUTPUTSTOCKMOVEMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.Waybill)).HasColumnName("WAYBILL").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.WaybillDate)).HasColumnName("WAYBILLDATE");
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.IsContainsContributions)).HasColumnName("ISCONTAINSCONTRIBUTIONS");
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.InvoiceNumberSec)).HasColumnName("INVOICENUMBERSEC");
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.AccountancyRef)).HasColumnName("ACCOUNTANCY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputWithAccountancy.SupplierRef)).HasColumnName("SUPPLIER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseChattelDocument).WithOne().HasForeignKey<AtlasModel.BaseChattelDocument>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Accountancy).WithOne().HasForeignKey<AtlasModel.ChattelDocumentOutputWithAccountancy>(x => x.AccountancyRef).IsRequired(true);
            builder.HasOne(t => t.Supplier).WithOne().HasForeignKey<AtlasModel.ChattelDocumentOutputWithAccountancy>(x => x.SupplierRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}