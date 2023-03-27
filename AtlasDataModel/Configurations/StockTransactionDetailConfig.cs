using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockTransactionDetailConfig : IEntityTypeConfiguration<AtlasModel.StockTransactionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockTransactionDetail> builder)
        {
            builder.ToTable("STOCKTRANSACTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.StockTransactionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockTransactionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockTransactionDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockTransactionDetail.InStockTransactionRef)).HasColumnName("INSTOCKTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTransactionDetail.OutStockTransactionRef)).HasColumnName("OUTSTOCKTRANSACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InStockTransaction).WithOne().HasForeignKey<AtlasModel.StockTransactionDetail>(x => x.InStockTransactionRef).IsRequired(true);
            builder.HasOne(t => t.OutStockTransaction).WithOne().HasForeignKey<AtlasModel.StockTransactionDetail>(x => x.OutStockTransactionRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}