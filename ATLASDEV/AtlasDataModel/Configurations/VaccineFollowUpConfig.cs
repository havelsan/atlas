using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class VaccineFollowUpConfig : IEntityTypeConfiguration<AtlasModel.VaccineFollowUp>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.VaccineFollowUp> builder)
        {
            builder.ToTable("VACCINEFOLLOWUP");
            builder.HasKey(nameof(AtlasModel.VaccineFollowUp.ObjectId));
            builder.Property(nameof(AtlasModel.VaccineFollowUp.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}