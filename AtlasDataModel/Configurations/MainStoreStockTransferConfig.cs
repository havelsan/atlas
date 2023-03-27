using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainStoreStockTransferConfig : IEntityTypeConfiguration<AtlasModel.MainStoreStockTransfer>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainStoreStockTransfer> builder)
        {
            builder.ToTable("MAINSTORESTOCKTRANSFER");
            builder.HasKey(nameof(AtlasModel.MainStoreStockTransfer.ObjectId));
            builder.Property(nameof(AtlasModel.MainStoreStockTransfer.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainStoreStockTransfer.InMkysControl)).HasColumnName("INMKYSCONTROL");
            builder.Property(nameof(AtlasModel.MainStoreStockTransfer.OutMkysControl)).HasColumnName("OUTMKYSCONTROL");
            builder.Property(nameof(AtlasModel.MainStoreStockTransfer.MKYS_AyniyatMakbuzIDGiris)).HasColumnName("MKYS_AYNIYATMAKBUZIDGIRIS");
            builder.HasOne(t => t.BaseChattelDocument).WithOne().HasForeignKey<AtlasModel.BaseChattelDocument>(p => p.ObjectId);
        }
    }
}