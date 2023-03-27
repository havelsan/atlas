using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderCollectedTrxConfig : IEntityTypeConfiguration<AtlasModel.DrugOrderCollectedTrx>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrderCollectedTrx> builder)
        {
            builder.ToTable("DRUGORDERCOLLECTEDTRX");
            builder.HasKey(nameof(AtlasModel.DrugOrderCollectedTrx.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrderCollectedTrx.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrderCollectedTrx.StockActionDetailRef)).HasColumnName("STOCKACTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderCollectedTrx.DrugOrderTransactionDetailRef)).HasColumnName("DRUGORDERTRANSACTIONDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockActionDetail).WithOne().HasForeignKey<AtlasModel.DrugOrderCollectedTrx>(x => x.StockActionDetailRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrderTransactionDetail).WithOne().HasForeignKey<AtlasModel.DrugOrderCollectedTrx>(x => x.DrugOrderTransactionDetailRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}