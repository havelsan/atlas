using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockMergeMaterialInConfig : IEntityTypeConfiguration<AtlasModel.StockMergeMaterialIn>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockMergeMaterialIn> builder)
        {
            builder.ToTable("STOCKMERGEMATERIALIN");
            builder.HasKey(nameof(AtlasModel.StockMergeMaterialIn.ObjectId));
            builder.Property(nameof(AtlasModel.StockMergeMaterialIn.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockMergeMaterialIn.StockMergeMaterialOutRef)).HasColumnName("STOCKMERGEMATERIALOUT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockActionDetailIn).WithOne().HasForeignKey<AtlasModel.StockActionDetailIn>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.StockMergeMaterialOut).WithOne().HasForeignKey<AtlasModel.StockMergeMaterialIn>(x => x.StockMergeMaterialOutRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}