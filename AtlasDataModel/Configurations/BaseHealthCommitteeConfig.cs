using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseHealthCommitteeConfig : IEntityTypeConfiguration<AtlasModel.BaseHealthCommittee>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseHealthCommittee> builder)
        {
            builder.ToTable("BASEHEALTHCOMMITTEE");
            builder.HasKey(nameof(AtlasModel.BaseHealthCommittee.ObjectId));
            builder.Property(nameof(AtlasModel.BaseHealthCommittee.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);
        }
    }
}