using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockFirstInConfig : IEntityTypeConfiguration<AtlasModel.StockFirstIn>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockFirstIn> builder)
        {
            builder.ToTable("STOCKFIRSTIN");
            builder.HasKey(nameof(AtlasModel.StockFirstIn.ObjectId));
            builder.Property(nameof(AtlasModel.StockFirstIn.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}