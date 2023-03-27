using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockReservationConfig : IEntityTypeConfiguration<AtlasModel.StockReservation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockReservation> builder)
        {
            builder.ToTable("STOCKRESERVATION");
            builder.HasKey(nameof(AtlasModel.StockReservation.ObjectId));
            builder.Property(nameof(AtlasModel.StockReservation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockReservation.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockReservation.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockReservation.StockRef)).HasColumnName("STOCK").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Stock).WithOne().HasForeignKey<AtlasModel.StockReservation>(x => x.StockRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}