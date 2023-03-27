using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockControlConfig : IEntityTypeConfiguration<AtlasModel.StockControl>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockControl> builder)
        {
            builder.ToTable("STOCKCONTROL");
            builder.HasKey(nameof(AtlasModel.StockControl.ObjectId));
            builder.Property(nameof(AtlasModel.StockControl.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
        }
    }
}