using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReceiptConfig : IEntityTypeConfiguration<AtlasModel.Receipt>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Receipt> builder)
        {
            builder.ToTable("RECEIPT");
            builder.HasKey(nameof(AtlasModel.Receipt.ObjectId));
            builder.Property(nameof(AtlasModel.Receipt.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Receipt.TotalDiscountEntry)).HasColumnName("TOTALDISCOUNTENTRY").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.Receipt.TotalPayment)).HasColumnName("TOTALPAYMENT").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.Receipt.DebentureTaken)).HasColumnName("DEBENTURETAKEN").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.Receipt.AdvanceTaken)).HasColumnName("ADVANCETAKEN").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.Receipt.UnDetailedReport)).HasColumnName("UNDETAILEDREPORT");
            builder.Property(nameof(AtlasModel.Receipt.DiscountTypeDefinitionRef)).HasColumnName("DISCOUNTTYPEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Receipt.ReceiptDocumentRef)).HasColumnName("RECEIPTDOCUMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAccountAction).WithOne().HasForeignKey<AtlasModel.EpisodeAccountAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ReceiptDocument).WithOne().HasForeignKey<AtlasModel.Receipt>(x => x.ReceiptDocumentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}