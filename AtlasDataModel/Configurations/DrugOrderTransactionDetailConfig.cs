using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderTransactionDetailConfig : IEntityTypeConfiguration<AtlasModel.DrugOrderTransactionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrderTransactionDetail> builder)
        {
            builder.ToTable("DRUGORDERTRANSACTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.DrugOrderTransactionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrderTransactionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrderTransactionDetail.IsStockOperation)).HasColumnName("ISSTOCKOPERATION");
            builder.Property(nameof(AtlasModel.DrugOrderTransactionDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderTransactionDetail.DrugOrderTransactionRef)).HasColumnName("DRUGORDERTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderTransactionDetail.StockTransactionRef)).HasColumnName("STOCKTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderTransactionDetail.DrugOrderDetailRef)).HasColumnName("DRUGORDERDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrderTransaction).WithOne().HasForeignKey<AtlasModel.DrugOrderTransactionDetail>(x => x.DrugOrderTransactionRef).IsRequired(false);
            builder.HasOne(t => t.StockTransaction).WithOne().HasForeignKey<AtlasModel.DrugOrderTransactionDetail>(x => x.StockTransactionRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrderDetail).WithOne().HasForeignKey<AtlasModel.DrugOrderTransactionDetail>(x => x.DrugOrderDetailRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}