using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseNursingOrderConfig : IEntityTypeConfiguration<AtlasModel.BaseNursingOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseNursingOrder> builder)
        {
            builder.ToTable("BASENURSINGORDER");
            builder.HasKey(nameof(AtlasModel.BaseNursingOrder.ObjectId));
            builder.Property(nameof(AtlasModel.BaseNursingOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.PeriodicOrder).WithOne().HasForeignKey<AtlasModel.PeriodicOrder>(p => p.ObjectId);
        }
    }
}