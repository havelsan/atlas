using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StoreLocationConfig : IEntityTypeConfiguration<AtlasModel.StoreLocation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StoreLocation> builder)
        {
            builder.ToTable("STORELOCATION");
            builder.HasKey(nameof(AtlasModel.StoreLocation.ObjectId));
            builder.Property(nameof(AtlasModel.StoreLocation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StoreLocation.StockLocationRef)).HasColumnName("STOCKLOCATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StoreLocation.StockRef)).HasColumnName("STOCK").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockLocation).WithOne().HasForeignKey<AtlasModel.StoreLocation>(x => x.StockLocationRef).IsRequired(false);
            builder.HasOne(t => t.Stock).WithOne().HasForeignKey<AtlasModel.StoreLocation>(x => x.StockRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}