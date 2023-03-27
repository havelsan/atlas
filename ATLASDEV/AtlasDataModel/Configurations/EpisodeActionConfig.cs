using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EpisodeActionConfig : IEntityTypeConfiguration<AtlasModel.EpisodeAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EpisodeAction> builder)
        {
            builder.ToTable("EPISODEACTION");
            builder.HasKey(nameof(AtlasModel.EpisodeAction.ObjectId));
            builder.Property(nameof(AtlasModel.EpisodeAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EpisodeAction.RequestDate)).HasColumnName("REQUESTDATE");
            builder.Property(nameof(AtlasModel.EpisodeAction.Emergency)).HasColumnName("EMERGENCY");
            builder.Property(nameof(AtlasModel.EpisodeAction.PatientPay)).HasColumnName("PATIENTPAY");
            builder.Property(nameof(AtlasModel.EpisodeAction.OrderObject)).HasColumnName("ORDEROBJECT").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.EpisodeAction.DescriptionForWorkList)).HasColumnName("DESCRIPTIONFORWORKLIST").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.EpisodeAction.AdmissionQueueNumber)).HasColumnName("ADMISSIONQUEUENUMBER");
            builder.Property(nameof(AtlasModel.EpisodeAction.SecondaryMasterResourceRef)).HasColumnName("SECONDARYMASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.MasterResourceRef)).HasColumnName("MASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.FromResourceRef)).HasColumnName("FROMRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.ProcedureSpecialityRef)).HasColumnName("PROCEDURESPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.MedulaHastaKabulRef)).HasColumnName("MEDULAHASTAKABUL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.PatientAdmissionRef)).HasColumnName("PATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.ProcedureDoctorRef)).HasColumnName("PROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeAction.ProcedureByUserRef)).HasColumnName("PROCEDUREBYUSER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SecondaryMasterResource).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(x => x.SecondaryMasterResourceRef).IsRequired(false);
            builder.HasOne(t => t.MasterResource).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(x => x.MasterResourceRef).IsRequired(true);
            builder.HasOne(t => t.FromResource).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(x => x.FromResourceRef).IsRequired(true);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(x => x.EpisodeRef).IsRequired(true);
            builder.HasOne(t => t.PatientAdmission).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(x => x.PatientAdmissionRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(x => x.ProcedureDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureByUser).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(x => x.ProcedureByUserRef).IsRequired(false);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.SubactionProcedures).WithOne(x => x.EpisodeAction).HasForeignKey(x => x.EpisodeActionRef);
            builder.HasMany(t => t.VitalSigns).WithOne(x => x.EpisodeAction).HasForeignKey(x => x.EpisodeActionRef);
            #endregion Child Relations
        }
    }
}