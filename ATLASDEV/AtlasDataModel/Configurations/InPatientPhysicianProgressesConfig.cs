using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InPatientPhysicianProgressesConfig : IEntityTypeConfiguration<AtlasModel.InPatientPhysicianProgresses>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InPatientPhysicianProgresses> builder)
        {
            builder.ToTable("INPATIENTPHYSICIANPROGR");
            builder.HasKey(nameof(AtlasModel.InPatientPhysicianProgresses.ObjectId));
            builder.Property(nameof(AtlasModel.InPatientPhysicianProgresses.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InPatientPhysicianProgresses.ProgressDate)).HasColumnName("PROGRESSDATE");
            builder.Property(nameof(AtlasModel.InPatientPhysicianProgresses.Description)).HasColumnName("DESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientPhysicianProgresses.EntryEpisodeActionRef)).HasColumnName("ENTRYEPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientPhysicianProgresses.ProcedureDoctorRef)).HasColumnName("PROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientPhysicianProgresses.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EntryEpisodeAction).WithOne().HasForeignKey<AtlasModel.InPatientPhysicianProgresses>(x => x.EntryEpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor).WithOne().HasForeignKey<AtlasModel.InPatientPhysicianProgresses>(x => x.ProcedureDoctorRef).IsRequired(true);
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.InPatientPhysicianProgresses>(x => x.SubEpisodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}