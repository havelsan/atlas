using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseHealthCommittee_HospitalsUnitsGridConfig : IEntityTypeConfiguration<AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid> builder)
        {
            builder.ToTable("BASEHC_HOSPITALSUNITSGRD");
            builder.HasKey(nameof(AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid.ObjectId));
            builder.Property(nameof(AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid.TemplateRef)).HasColumnName("TEMPLATE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid.BaseHealthCommitteeRef)).HasColumnName("BASEHEALTHCOMMITTEE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid.EpisodeActionTemplateRef)).HasColumnName("EPISODEACTIONTEMPLATE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.HospitalsUnitsGrid).WithOne().HasForeignKey<AtlasModel.HospitalsUnitsGrid>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.BaseHealthCommittee).WithOne().HasForeignKey<AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid>(x => x.BaseHealthCommitteeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}