using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ExtendExpDateOutDetailConfig : IEntityTypeConfiguration<AtlasModel.ExtendExpDateOutDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ExtendExpDateOutDetail> builder)
        {
            builder.ToTable("EXTENDEXPDATEOUTDETAIL");
            builder.HasKey(nameof(AtlasModel.ExtendExpDateOutDetail.ObjectId));
            builder.Property(nameof(AtlasModel.ExtendExpDateOutDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ExtendExpDateOutDetail.OutExpirationDate)).HasColumnName("OUTEXPIRATIONDATE");
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}