using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendSMSResponsiblePATDelayConfig : IEntityTypeConfiguration<AtlasModel.SendSMSResponsiblePATDelay>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendSMSResponsiblePATDelay> builder)
        {
            builder.ToTable("SENDSMSRESPONSIBLEPATDELAY");
            builder.HasKey(nameof(AtlasModel.SendSMSResponsiblePATDelay.ObjectId));
            builder.Property(nameof(AtlasModel.SendSMSResponsiblePATDelay.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.BaseScheduledTask>(p => p.ObjectId);
        }
    }
}