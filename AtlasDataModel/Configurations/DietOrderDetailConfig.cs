using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DietOrderDetailConfig : IEntityTypeConfiguration<AtlasModel.DietOrderDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DietOrderDetail> builder)
        {
            builder.ToTable("DIETORDERDETAIL");
            builder.HasKey(nameof(AtlasModel.DietOrderDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DietOrderDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DietOrderDetail.IsReported)).HasColumnName("ISREPORTED");
            builder.Property(nameof(AtlasModel.DietOrderDetail.AdditionalRation)).HasColumnName("ADDITIONALRATION");
            builder.Property(nameof(AtlasModel.DietOrderDetail.ReportDate)).HasColumnName("REPORTDATE");
            builder.HasOne(t => t.BaseDietOrderDetail).WithOne().HasForeignKey<AtlasModel.BaseDietOrderDetail>(p => p.ObjectId);
        }
    }
}