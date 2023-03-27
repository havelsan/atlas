using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockFirstInDetailConfig : IEntityTypeConfiguration<AtlasModel.StockFirstInDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockFirstInDetail> builder)
        {
            builder.ToTable("STOCKFIRSTINDETAIL");
            builder.HasKey(nameof(AtlasModel.StockFirstInDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockFirstInDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockFirstInDetail.MkysStokHareketID)).HasColumnName("MKYSSTOKHAREKETID");
            builder.HasOne(t => t.StockActionDetailIn).WithOne().HasForeignKey<AtlasModel.StockActionDetailIn>(p => p.ObjectId);
        }
    }
}