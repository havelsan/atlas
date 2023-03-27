using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class KScheduleCollectedOrderConfig : IEntityTypeConfiguration<AtlasModel.KScheduleCollectedOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.KScheduleCollectedOrder> builder)
        {
            builder.ToTable("KSCHEDULECOLLECTEDORDER");
            builder.HasKey(nameof(AtlasModel.KScheduleCollectedOrder.ObjectId));
            builder.Property(nameof(AtlasModel.KScheduleCollectedOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
        }
    }
}