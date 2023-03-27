using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubStoreStockTransferMatConfig : IEntityTypeConfiguration<AtlasModel.SubStoreStockTransferMat>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubStoreStockTransferMat> builder)
        {
            builder.ToTable("SUBSTORESTOCKTRANSFERMAT");
            builder.HasKey(nameof(AtlasModel.SubStoreStockTransferMat.ObjectId));
            builder.Property(nameof(AtlasModel.SubStoreStockTransferMat.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubStoreStockTransferMat.RequestAmount)).HasColumnName("REQUESTAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}