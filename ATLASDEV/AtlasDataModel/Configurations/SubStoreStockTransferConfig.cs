using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubStoreStockTransferConfig : IEntityTypeConfiguration<AtlasModel.SubStoreStockTransfer>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubStoreStockTransfer> builder)
        {
            builder.ToTable("SUBSTORESTOCKTRANSFER");
            builder.HasKey(nameof(AtlasModel.SubStoreStockTransfer.ObjectId));
            builder.Property(nameof(AtlasModel.SubStoreStockTransfer.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}