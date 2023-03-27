using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChangeStockLevelTypeDetailConfig : IEntityTypeConfiguration<AtlasModel.ChangeStockLevelTypeDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChangeStockLevelTypeDetail> builder)
        {
            builder.ToTable("CHANGESTOCKLEVELTYPEDETAIL");
            builder.HasKey(nameof(AtlasModel.ChangeStockLevelTypeDetail.ObjectId));
            builder.Property(nameof(AtlasModel.ChangeStockLevelTypeDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}