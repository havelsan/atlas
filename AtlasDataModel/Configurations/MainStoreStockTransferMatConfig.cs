using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainStoreStockTransferMatConfig : IEntityTypeConfiguration<AtlasModel.MainStoreStockTransferMat>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainStoreStockTransferMat> builder)
        {
            builder.ToTable("MAINSTORESTOCKTRANSFERMAT");
            builder.HasKey(nameof(AtlasModel.MainStoreStockTransferMat.ObjectId));
            builder.Property(nameof(AtlasModel.MainStoreStockTransferMat.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainStoreStockTransferMat.RequestAmount)).HasColumnName("REQUESTAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}