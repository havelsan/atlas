using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiologyConfig : IEntityTypeConfiguration<AtlasModel.Radiology>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Radiology> builder)
        {
            builder.ToTable("RADIOLOGY");
            builder.HasKey(nameof(AtlasModel.Radiology.ObjectId));
            builder.Property(nameof(AtlasModel.Radiology.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Radiology.TechnicianNote)).HasColumnName("TECHNICIANNOTE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.Radiology.PreDiagnosis)).HasColumnName("PREDIAGNOSIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Radiology.ToothNumber)).HasColumnName("TOOTHNUMBER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Radiology.DentalPosition)).HasColumnName("DENTALPOSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Radiology.DisTaahhutNo)).HasColumnName("DISTAAHHUTNO");
            builder.Property(nameof(AtlasModel.Radiology.Anomali)).HasColumnName("ANOMALI");
            builder.Property(nameof(AtlasModel.Radiology.AllCheck)).HasColumnName("ALLCHECK");
            builder.Property(nameof(AtlasModel.Radiology.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Radiology.SourceObjectID)).HasColumnName("SOURCEOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Radiology.TargetObjectID)).HasColumnName("TARGETOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Radiology.RejectReasonRef)).HasColumnName("REJECTREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Radiology.RequestDoctorRef)).HasColumnName("REQUESTDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Radiology.RadiologyRequestTemplateRef)).HasColumnName("RADIOLOGYREQUESTTEMPLATE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RequestDoctor).WithOne().HasForeignKey<AtlasModel.Radiology>(x => x.RequestDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}