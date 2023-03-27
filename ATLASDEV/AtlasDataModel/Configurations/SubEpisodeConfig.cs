using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubEpisodeConfig : IEntityTypeConfiguration<AtlasModel.SubEpisode>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubEpisode> builder)
        {
            builder.ToTable("SUBEPISODE");
            builder.HasKey(nameof(AtlasModel.SubEpisode.ObjectId));
            builder.Property(nameof(AtlasModel.SubEpisode.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubEpisode.ClosingDate)).HasColumnName("CLOSINGDATE");
            builder.Property(nameof(AtlasModel.SubEpisode.PatientStatus)).HasColumnName("PATIENTSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubEpisode.ProtocolNo)).HasColumnName("PROTOCOLNO").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.SubEpisode.OpeningDate)).HasColumnName("OPENINGDATE");
            builder.Property(nameof(AtlasModel.SubEpisode.SYSTakipNo)).HasColumnName("SYSTAKIPNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.SubEpisode.OnlineProtokolNo)).HasColumnName("ONLINEPROTOKOLNO");
            builder.Property(nameof(AtlasModel.SubEpisode.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.SubEpisode.InpatientStatus)).HasColumnName("INPATIENTSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubEpisode.Sent101Package)).HasColumnName("SENT101PACKAGE");
            builder.Property(nameof(AtlasModel.SubEpisode.InpatientAdmissionRef)).HasColumnName("INPATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisode.OldSubEpisodeRef)).HasColumnName("OLDSUBEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisode.ResSectionRef)).HasColumnName("RESSECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisode.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisode.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisode.StarterEpisodeActionRef)).HasColumnName("STARTEREPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisode.StarterSubActionProcedureRef)).HasColumnName("STARTERSUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisode.PatientAdmissionRef)).HasColumnName("PATIENTADMISSION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InpatientAdmission).WithOne().HasForeignKey<AtlasModel.SubEpisode>(x => x.InpatientAdmissionRef).IsRequired(false);
            builder.HasOne(t => t.OldSubEpisode).WithOne().HasForeignKey<AtlasModel.SubEpisode>(x => x.OldSubEpisodeRef).IsRequired(false);
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.SubEpisode>(x => x.ResSectionRef).IsRequired(true);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.SubEpisode>(x => x.EpisodeRef).IsRequired(true);
            builder.HasOne(t => t.StarterEpisodeAction).WithOne().HasForeignKey<AtlasModel.SubEpisode>(x => x.StarterEpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.StarterSubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubEpisode>(x => x.StarterSubActionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.PatientAdmission).WithOne().HasForeignKey<AtlasModel.SubEpisode>(x => x.PatientAdmissionRef).IsRequired(true);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.EpisodeActions).WithOne(x => x.SubEpisode).HasForeignKey(x => x.SubEpisodeRef);
            #endregion Child Relations
        }
    }
}