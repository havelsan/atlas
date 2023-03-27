using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendSMSDoctorPATDelayConfig : IEntityTypeConfiguration<AtlasModel.SendSMSDoctorPATDelay>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendSMSDoctorPATDelay> builder)
        {
            builder.ToTable("SENDSMSDOCTORPATDELAY");
            builder.HasKey(nameof(AtlasModel.SendSMSDoctorPATDelay.ObjectId));
            builder.Property(nameof(AtlasModel.SendSMSDoctorPATDelay.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.BaseScheduledTask>(p => p.ObjectId);
        }
    }
}