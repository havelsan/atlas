using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockActionDetailOutConfig : IEntityTypeConfiguration<AtlasModel.StockActionDetailOut>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockActionDetailOut> builder)
        {
            builder.ToTable("STOCKACTIONDETAILOUT");
            builder.HasKey(nameof(AtlasModel.StockActionDetailOut.ObjectId));
            builder.Property(nameof(AtlasModel.StockActionDetailOut.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockActionDetailOut.IsZeroUnitPrice)).HasColumnName("ISZEROUNITPRICE");
            builder.Property(nameof(AtlasModel.StockActionDetailOut.ReadQRCode)).HasColumnName("READQRCODE");
            builder.Property(nameof(AtlasModel.StockActionDetailOut.VatRate)).HasColumnName("VATRATE");
            builder.Property(nameof(AtlasModel.StockActionDetailOut.TagNo)).HasColumnName("TAGNO").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.StockActionDetailOut.UserSelectedOutableTrx)).HasColumnName("USERSELECTEDOUTABLETRX");
            builder.Property(nameof(AtlasModel.StockActionDetailOut.StockReservationRef)).HasColumnName("STOCKRESERVATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockActionDetail).WithOne().HasForeignKey<AtlasModel.StockActionDetail>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.StockReservation).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(x => x.StockReservationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}