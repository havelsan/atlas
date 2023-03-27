using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InfectionCommitteeConfig : IEntityTypeConfiguration<AtlasModel.InfectionCommittee>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InfectionCommittee> builder)
        {
            builder.ToTable("INFECTIONCOMMITTEE");
            builder.HasKey(nameof(AtlasModel.InfectionCommittee.ObjectId));
            builder.Property(nameof(AtlasModel.InfectionCommittee.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InfectionCommittee.CancelReason)).HasColumnName("CANCELREASON").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.InfectionCommittee.InPatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.InPatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.InfectionCommittee>(x => x.InPatientPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}