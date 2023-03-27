using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendSMSWorkHealthSecWarnConfig : IEntityTypeConfiguration<AtlasModel.SendSMSWorkHealthSecWarn>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendSMSWorkHealthSecWarn> builder)
        {
            builder.ToTable("SENDSMSWORKHEALTHSECWARN");
            builder.HasKey(nameof(AtlasModel.SendSMSWorkHealthSecWarn.ObjectId));
            builder.Property(nameof(AtlasModel.SendSMSWorkHealthSecWarn.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.BaseScheduledTask>(p => p.ObjectId);
        }
    }
}