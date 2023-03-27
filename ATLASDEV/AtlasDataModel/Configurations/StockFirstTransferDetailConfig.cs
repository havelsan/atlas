using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockFirstTransferDetailConfig : IEntityTypeConfiguration<AtlasModel.StockFirstTransferDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockFirstTransferDetail> builder)
        {
            builder.ToTable("STOCKFIRSTTRANSFERDETAIL");
            builder.HasKey(nameof(AtlasModel.StockFirstTransferDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockFirstTransferDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}