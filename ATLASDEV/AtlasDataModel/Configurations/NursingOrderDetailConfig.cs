using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingOrderDetailConfig : IEntityTypeConfiguration<AtlasModel.NursingOrderDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingOrderDetail> builder)
        {
            builder.ToTable("NURSINGORDERDETAIL");
            builder.HasKey(nameof(AtlasModel.NursingOrderDetail.ObjectId));
            builder.Property(nameof(AtlasModel.NursingOrderDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseNursingOrderDetails).WithOne().HasForeignKey<AtlasModel.BaseNursingOrderDetails>(p => p.ObjectId);
        }
    }
}