using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockFirstTransferConfig : IEntityTypeConfiguration<AtlasModel.StockFirstTransfer>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockFirstTransfer> builder)
        {
            builder.ToTable("STOCKFIRSTTRANSFER");
            builder.HasKey(nameof(AtlasModel.StockFirstTransfer.ObjectId));
            builder.Property(nameof(AtlasModel.StockFirstTransfer.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}