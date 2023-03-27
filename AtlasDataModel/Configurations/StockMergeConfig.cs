using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockMergeConfig : IEntityTypeConfiguration<AtlasModel.StockMerge>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockMerge> builder)
        {
            builder.ToTable("STOCKMERGE");
            builder.HasKey(nameof(AtlasModel.StockMerge.ObjectId));
            builder.Property(nameof(AtlasModel.StockMerge.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}