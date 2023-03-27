using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainStoreDistDocDetailConfig : IEntityTypeConfiguration<AtlasModel.MainStoreDistDocDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainStoreDistDocDetail> builder)
        {
            builder.ToTable("MAINSTOREDISTDOCDETAIL");
            builder.HasKey(nameof(AtlasModel.MainStoreDistDocDetail.ObjectId));
            builder.Property(nameof(AtlasModel.MainStoreDistDocDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainStoreDistDocDetail.SendedAmount)).HasColumnName("SENDEDAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}