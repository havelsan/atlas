using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockActionDetailInConfig : IEntityTypeConfiguration<AtlasModel.StockActionDetailIn>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockActionDetailIn> builder)
        {
            builder.ToTable("STOCKACTIONDETAILIN");
            builder.HasKey(nameof(AtlasModel.StockActionDetailIn.ObjectId));
            builder.Property(nameof(AtlasModel.StockActionDetailIn.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockActionDetailIn.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.NotDiscountedUnitPrice)).HasColumnName("NOTDISCOUNTEDUNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.TotalPriceNotDiscount)).HasColumnName("TOTALPRICENOTDISCOUNT").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.TotalDiscountAmount)).HasColumnName("TOTALDISCOUNTAMOUNT").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.LotNo)).HasColumnName("LOTNO");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.VatRate)).HasColumnName("VATRATE");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.DiscountRate)).HasColumnName("DISCOUNTRATE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.DiscountAmount)).HasColumnName("DISCOUNTAMOUNT").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.MKYS_DigerAciklama)).HasColumnName("MKYS_DIGERACIKLAMA");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.ProductionDate)).HasColumnName("PRODUCTIONDATE");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.RetrievalYear)).HasColumnName("RETRIEVALYEAR");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.VoucherDetailRecordNo)).HasColumnName("VOUCHERDETAILRECORDNO");
            builder.Property(nameof(AtlasModel.StockActionDetailIn.DeliveryNotifictionID)).HasColumnName("DELIVERYNOTIFICTIONID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockActionDetailIn.IncomingDeliveryNotifID)).HasColumnName("INCOMINGDELIVERYNOTIFID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockActionDetailIn.ReceiveNotificationID)).HasColumnName("RECEIVENOTIFICATIONID").HasMaxLength(50);
            builder.HasOne(t => t.StockActionDetail).WithOne().HasForeignKey<AtlasModel.StockActionDetail>(p => p.ObjectId);
        }
    }
}