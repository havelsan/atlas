using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockLocationConfig : IEntityTypeConfiguration<AtlasModel.StockLocation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockLocation> builder)
        {
            builder.ToTable("STOCKLOCATION");
            builder.HasKey(nameof(AtlasModel.StockLocation.ObjectId));
            builder.Property(nameof(AtlasModel.StockLocation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockLocation.IsGroup)).HasColumnName("ISGROUP");
            builder.Property(nameof(AtlasModel.StockLocation.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockLocation.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.StockLocation.ParentStockLocationRef)).HasColumnName("PARENTSTOCKLOCATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ParentStockLocation).WithOne().HasForeignKey<AtlasModel.StockLocation>(x => x.ParentStockLocationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}