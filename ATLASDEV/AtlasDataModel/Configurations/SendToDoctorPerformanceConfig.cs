using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendToDoctorPerformanceConfig : IEntityTypeConfiguration<AtlasModel.SendToDoctorPerformance>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendToDoctorPerformance> builder)
        {
            builder.ToTable("SENDTODOCTORPERFORMANCE");
            builder.HasKey(nameof(AtlasModel.SendToDoctorPerformance.ObjectId));
            builder.Property(nameof(AtlasModel.SendToDoctorPerformance.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SendToDoctorPerformance.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SendToDoctorPerformance.RecordDate)).HasColumnName("RECORDDATE");
            builder.Property(nameof(AtlasModel.SendToDoctorPerformance.InternalObjectStatus)).HasColumnName("INTERNALOBJECTSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SendToDoctorPerformance.InternalObjectID)).HasColumnName("INTERNALOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SendToDoctorPerformance.InternalObjectDefName)).HasColumnName("INTERNALOBJECTDEFNAME").HasMaxLength(255);
        }
    }
}