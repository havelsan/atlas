using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockLotDetailConfig : IEntityTypeConfiguration<AtlasModel.StockLotDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockLotDetail> builder)
        {
            builder.ToTable("STOCKLOTDETAIL");
            builder.HasKey(nameof(AtlasModel.StockLotDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockLotDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockLotDetail.LotNo)).HasColumnName("LOTNO");
            builder.Property(nameof(AtlasModel.StockLotDetail.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.StockLotDetail.RestAmount)).HasColumnName("RESTAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockLotDetail.StockRef)).HasColumnName("STOCK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockLotDetail.StockLevelTypeRef)).HasColumnName("STOCKLEVELTYPE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Stock).WithOne().HasForeignKey<AtlasModel.StockLotDetail>(x => x.StockRef).IsRequired(false);
            builder.HasOne(t => t.StockLevelType).WithOne().HasForeignKey<AtlasModel.StockLotDetail>(x => x.StockLevelTypeRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}