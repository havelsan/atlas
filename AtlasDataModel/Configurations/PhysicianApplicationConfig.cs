using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PhysicianApplicationConfig : IEntityTypeConfiguration<AtlasModel.PhysicianApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PhysicianApplication> builder)
        {
            builder.ToTable("PHYSICIANAPPLICATION");
            builder.HasKey(nameof(AtlasModel.PhysicianApplication.ObjectId));
            builder.Property(nameof(AtlasModel.PhysicianApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PhysicianApplication.ProcessEndDate)).HasColumnName("PROCESSENDDATE");
            builder.Property(nameof(AtlasModel.PhysicianApplication.Complaint)).HasColumnName("COMPLAINT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.ContinuousDrugs)).HasColumnName("CONTINUOUSDRUGS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.DecisionAndAction)).HasColumnName("DECISIONANDACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.ExaminationSummary)).HasColumnName("EXAMINATIONSUMMARY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.Habits)).HasColumnName("HABITS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.Image)).HasColumnName("IMAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.IsTreatmentMaterialEmpty)).HasColumnName("ISTREATMENTMATERIALEMPTY");
            builder.Property(nameof(AtlasModel.PhysicianApplication.PatientFamilyHistory)).HasColumnName("PATIENTFAMILYHISTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.PatientFolder)).HasColumnName("PATIENTFOLDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.PatientHistory)).HasColumnName("PATIENTHISTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.PatientStory)).HasColumnName("PATIENTSTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.PhysicalExamination)).HasColumnName("PHYSICALEXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.ProcessDate)).HasColumnName("PROCESSDATE");
            builder.Property(nameof(AtlasModel.PhysicianApplication.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.PhysicianApplication.SystemQuery)).HasColumnName("SYSTEMQUERY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.MTSConclusion)).HasColumnName("MTSCONCLUSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysicianApplication.MasterPhysicianApplicationRef)).HasColumnName("MASTERPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.PhysicianApplication>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.MasterPhysicianApplication).WithOne().HasForeignKey<AtlasModel.PhysicianApplication>(x => x.MasterPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}