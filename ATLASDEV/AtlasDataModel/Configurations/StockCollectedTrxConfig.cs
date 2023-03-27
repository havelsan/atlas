using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockCollectedTrxConfig : IEntityTypeConfiguration<AtlasModel.StockCollectedTrx>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockCollectedTrx> builder)
        {
            builder.ToTable("STOCKCOLLECTEDTRX");
            builder.HasKey(nameof(AtlasModel.StockCollectedTrx.ObjectId));
            builder.Property(nameof(AtlasModel.StockCollectedTrx.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockCollectedTrx.StockActionDetailRef)).HasColumnName("STOCKACTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCollectedTrx.StockTransactionRef)).HasColumnName("STOCKTRANSACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockActionDetail).WithOne().HasForeignKey<AtlasModel.StockCollectedTrx>(x => x.StockActionDetailRef).IsRequired(true);
            builder.HasOne(t => t.StockTransaction).WithOne().HasForeignKey<AtlasModel.StockCollectedTrx>(x => x.StockTransactionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}