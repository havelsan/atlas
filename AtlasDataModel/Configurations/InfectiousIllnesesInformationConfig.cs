using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InfectiousIllnesesInformationConfig : IEntityTypeConfiguration<AtlasModel.InfectiousIllnesesInformation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InfectiousIllnesesInformation> builder)
        {
            builder.ToTable("INFECTILLNESSINFO");
            builder.HasKey(nameof(AtlasModel.InfectiousIllnesesInformation.ObjectId));
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.StartTimeOfInfectious)).HasColumnName("STARTTIMEOFINFECTIOUS");
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.Job)).HasColumnName("JOB").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.DeathTime)).HasColumnName("DEATHTIME");
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.IllnesesName)).HasColumnName("ILLNESESNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.NotAlive)).HasColumnName("NOTALIVE");
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.StarterEpisodeActionRef)).HasColumnName("STARTEREPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.PatientInfoRef)).HasColumnName("PATIENTINFO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.InfectiousIllnesesDiagnosisRef)).HasColumnName("INFECTIOUSILLNESESDIAGNOSIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InfectiousIllnesesInformation.StarterSubactionProcedureRef)).HasColumnName("STARTERSUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.StarterEpisodeAction).WithOne().HasForeignKey<AtlasModel.InfectiousIllnesesInformation>(x => x.StarterEpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.PatientInfo).WithOne().HasForeignKey<AtlasModel.InfectiousIllnesesInformation>(x => x.PatientInfoRef).IsRequired(false);
            builder.HasOne(t => t.InfectiousIllnesesDiagnosis).WithOne().HasForeignKey<AtlasModel.InfectiousIllnesesInformation>(x => x.InfectiousIllnesesDiagnosisRef).IsRequired(true);
            builder.HasOne(t => t.StarterSubactionProcedure).WithOne().HasForeignKey<AtlasModel.InfectiousIllnesesInformation>(x => x.StarterSubactionProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}