using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendSMSChiefPATDelayConfig : IEntityTypeConfiguration<AtlasModel.SendSMSChiefPATDelay>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendSMSChiefPATDelay> builder)
        {
            builder.ToTable("SENDSMSCHIEFPATDELAY");
            builder.HasKey(nameof(AtlasModel.SendSMSChiefPATDelay.ObjectId));
            builder.Property(nameof(AtlasModel.SendSMSChiefPATDelay.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.BaseScheduledTask>(p => p.ObjectId);
        }
    }
}