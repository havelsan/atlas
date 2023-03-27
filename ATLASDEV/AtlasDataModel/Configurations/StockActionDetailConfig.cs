using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockActionDetailConfig : IEntityTypeConfiguration<AtlasModel.StockActionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockActionDetail> builder)
        {
            builder.ToTable("STOCKACTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.StockActionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockActionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockActionDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockActionDetail.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockActionDetail.ChattelDocDetailOrderNo)).HasColumnName("CHATTELDOCDETAILORDERNO");
            builder.Property(nameof(AtlasModel.StockActionDetail.AuctionDate)).HasColumnName("AUCTIONDATE");
            builder.Property(nameof(AtlasModel.StockActionDetail.RegistrationAuctionNo)).HasColumnName("REGISTRATIONAUCTIONNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.StockActionDetail.ResetOuttableStockTransaction)).HasColumnName("RESETOUTTABLESTOCKTRANSACTION");
            builder.Property(nameof(AtlasModel.StockActionDetail.InvoiceDate)).HasColumnName("INVOICEDATE");
            builder.Property(nameof(AtlasModel.StockActionDetail.MKYS_StokHareketID)).HasColumnName("MKYS_STOKHAREKETID");
            builder.Property(nameof(AtlasModel.StockActionDetail.SerialNo)).HasColumnName("SERIALNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.StockActionDetail.StockLevelTypeRef)).HasColumnName("STOCKLEVELTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionDetail.StockActionRef)).HasColumnName("STOCKACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionDetail.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionDetail.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionDetail.PTSStockActionDetailRef)).HasColumnName("PTSSTOCKACTIONDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockLevelType).WithOne().HasForeignKey<AtlasModel.StockActionDetail>(x => x.StockLevelTypeRef).IsRequired(true);
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockActionDetail>(x => x.StockActionRef).IsRequired(false);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.StockActionDetail>(x => x.MaterialRef).IsRequired(true);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.StockActionDetail>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}