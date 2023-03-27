using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendSMSForEmerGencyInterventionConfig : IEntityTypeConfiguration<AtlasModel.SendSMSForEmerGencyIntervention>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendSMSForEmerGencyIntervention> builder)
        {
            builder.ToTable("SENDSMSFOREMRINT");
            builder.HasKey(nameof(AtlasModel.SendSMSForEmerGencyIntervention.ObjectId));
            builder.Property(nameof(AtlasModel.SendSMSForEmerGencyIntervention.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.BaseScheduledTask>(p => p.ObjectId);
        }
    }
}