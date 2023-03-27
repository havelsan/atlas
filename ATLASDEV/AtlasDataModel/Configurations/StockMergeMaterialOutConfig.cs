using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockMergeMaterialOutConfig : IEntityTypeConfiguration<AtlasModel.StockMergeMaterialOut>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockMergeMaterialOut> builder)
        {
            builder.ToTable("STOCKMERGEMATERIALOUT");
            builder.HasKey(nameof(AtlasModel.StockMergeMaterialOut.ObjectId));
            builder.Property(nameof(AtlasModel.StockMergeMaterialOut.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockMergeMaterialOut.StockMergeMaterialInRef)).HasColumnName("STOCKMERGEMATERIALIN").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockMergeMaterialOut.OutableStockTransactionRef)).HasColumnName("OUTABLESTOCKTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.StockMergeMaterialIn).WithOne().HasForeignKey<AtlasModel.StockMergeMaterialOut>(x => x.StockMergeMaterialInRef).IsRequired(true);
            builder.HasOne(t => t.OutableStockTransaction).WithOne().HasForeignKey<AtlasModel.StockMergeMaterialOut>(x => x.OutableStockTransactionRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}