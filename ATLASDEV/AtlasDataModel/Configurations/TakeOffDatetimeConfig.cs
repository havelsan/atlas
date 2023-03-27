using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TakeOffDatetimeConfig : IEntityTypeConfiguration<AtlasModel.TakeOffDatetime>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TakeOffDatetime> builder)
        {
            builder.ToTable("TAKEOFFDATETIME");
            builder.HasKey(nameof(AtlasModel.TakeOffDatetime.ObjectId));
            builder.Property(nameof(AtlasModel.TakeOffDatetime.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TakeOffDatetime.TakeOffDate)).HasColumnName("TAKEOFFDATE");
            builder.Property(nameof(AtlasModel.TakeOffDatetime.StartTime)).HasColumnName("STARTTIME");
            builder.Property(nameof(AtlasModel.TakeOffDatetime.EndTime)).HasColumnName("ENDTIME");
            builder.Property(nameof(AtlasModel.TakeOffDatetime.IsAllDayOff)).HasColumnName("ISALLDAYOFF");
            builder.Property(nameof(AtlasModel.TakeOffDatetime.IsStart)).HasColumnName("ISSTART");
        }
    }
}