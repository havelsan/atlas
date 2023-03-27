using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HospitalTimeScheduleDetailConfig : IEntityTypeConfiguration<AtlasModel.HospitalTimeScheduleDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HospitalTimeScheduleDetail> builder)
        {
            builder.ToTable("HOSPITALTIMESCHEDULEDETAIL");
            builder.HasKey(nameof(AtlasModel.HospitalTimeScheduleDetail.ObjectId));
            builder.Property(nameof(AtlasModel.HospitalTimeScheduleDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HospitalTimeScheduleDetail.Time)).HasColumnName("TIME");
            builder.Property(nameof(AtlasModel.HospitalTimeScheduleDetail.TimeNumber)).HasColumnName("TIMENUMBER");
            builder.Property(nameof(AtlasModel.HospitalTimeScheduleDetail.HospitalTimeScheduleRef)).HasColumnName("HOSPITALTIMESCHEDULE").HasMaxLength(36).IsFixedLength();
        }
    }
}