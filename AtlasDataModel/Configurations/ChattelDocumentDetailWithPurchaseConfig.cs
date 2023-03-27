using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChattelDocumentDetailWithPurchaseConfig : IEntityTypeConfiguration<AtlasModel.ChattelDocumentDetailWithPurchase>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChattelDocumentDetailWithPurchase> builder)
        {
            builder.ToTable("CHATTELDOCDETWITHPURCHASE");
            builder.HasKey(nameof(AtlasModel.ChattelDocumentDetailWithPurchase.ObjectId));
            builder.Property(nameof(AtlasModel.ChattelDocumentDetailWithPurchase.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChattelDocumentDetailWithPurchase.UnitPriceWithOutVat)).HasColumnName("UNITPRICEWITHOUTVAT").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.ChattelDocumentDetailWithPurchase.UnitPriceWithInVat)).HasColumnName("UNITPRICEWITHINVAT").HasColumnType("NUMBER(15,4)");
            builder.HasOne(t => t.StockActionDetailIn).WithOne().HasForeignKey<AtlasModel.StockActionDetailIn>(p => p.ObjectId);
        }
    }
}