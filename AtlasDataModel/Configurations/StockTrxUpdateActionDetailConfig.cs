using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockTrxUpdateActionDetailConfig : IEntityTypeConfiguration<AtlasModel.StockTrxUpdateActionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockTrxUpdateActionDetail> builder)
        {
            builder.ToTable("STOCKTRXUPDATEACTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.StockTrxUpdateActionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockTrxUpdateActionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockTrxUpdateActionDetail.StockActionName)).HasColumnName("STOCKACTIONNAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.StockTrxUpdateActionDetail.OldUnitPrice)).HasColumnName("OLDUNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockTrxUpdateActionDetail.NewUnitPrice)).HasColumnName("NEWUNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockTrxUpdateActionDetail.StockTrxUpdateActionRef)).HasColumnName("STOCKTRXUPDATEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTrxUpdateActionDetail.StockTransactionRef)).HasColumnName("STOCKTRANSACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockTrxUpdateAction).WithOne().HasForeignKey<AtlasModel.StockTrxUpdateActionDetail>(x => x.StockTrxUpdateActionRef).IsRequired(true);
            builder.HasOne(t => t.StockTransaction).WithOne().HasForeignKey<AtlasModel.StockTrxUpdateActionDetail>(x => x.StockTransactionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}