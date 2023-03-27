using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseChattelDocumentConfig : IEntityTypeConfiguration<AtlasModel.BaseChattelDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseChattelDocument> builder)
        {
            builder.ToTable("BASECHATTELDOCUMENT");
            builder.HasKey(nameof(AtlasModel.BaseChattelDocument.ObjectId));
            builder.Property(nameof(AtlasModel.BaseChattelDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseChattelDocument.SpendingUnit)).HasColumnName("SPENDINGUNIT").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.BaseChattelDocument.SpendingUnitCode)).HasColumnName("SPENDINGUNITCODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.BaseChattelDocument.BaseNumber)).HasColumnName("BASENUMBER").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.BaseChattelDocument.BaseDateTime)).HasColumnName("BASEDATETIME");
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}