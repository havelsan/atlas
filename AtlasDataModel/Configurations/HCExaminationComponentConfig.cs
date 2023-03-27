using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HCExaminationComponentConfig : IEntityTypeConfiguration<AtlasModel.HCExaminationComponent>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HCExaminationComponent> builder)
        {
            builder.ToTable("HCEXAMINATIONCOMPONENT");
            builder.HasKey(nameof(AtlasModel.HCExaminationComponent.ObjectId));
            builder.Property(nameof(AtlasModel.HCExaminationComponent.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HCExaminationComponent.ReportDate)).HasColumnName("REPORTDATE");
            builder.Property(nameof(AtlasModel.HCExaminationComponent.TreatmentInfo)).HasColumnName("TREATMENTINFO").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HCExaminationComponent.ClinicalInfo)).HasColumnName("CLINICALINFO").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HCExaminationComponent.LaboratoryInfo)).HasColumnName("LABORATORYINFO").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HCExaminationComponent.RadiologicalInfo)).HasColumnName("RADIOLOGICALINFO").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HCExaminationComponent.NumberOfProcess)).HasColumnName("NUMBEROFPROCESS");
            builder.Property(nameof(AtlasModel.HCExaminationComponent.OfferOfDecision)).HasColumnName("OFFEROFDECISION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HCExaminationComponent.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HCExaminationComponent.DisabledRatio)).HasColumnName("DISABLEDRATIO").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.HCExaminationComponent.IsHealthy)).HasColumnName("ISHEALTHY");
            builder.Property(nameof(AtlasModel.HCExaminationComponent.EngelliRaporuMuayeneId)).HasColumnName("ENGELLIRAPORUMUAYENEID").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.HCExaminationComponent.EDurumBildirirMuayeneId)).HasColumnName("EDURUMBILDIRIRMUAYENEID").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.HCExaminationComponent.ReasonForExaminationRef)).HasColumnName("REASONFOREXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HCExaminationComponent.EDisabledReportRef)).HasColumnName("EDISABLEDREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HCExaminationComponent.EStatusNotRepCommitteeObjRef)).HasColumnName("ESTATUSNOTREPCOMMITTEEOBJ").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HCExaminationComponent.CozgerSpecReqAreaRef)).HasColumnName("COZGERSPECREQAREA").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HCExaminationComponent.CozgerSpecReqLevelRef)).HasColumnName("COZGERSPECREQLEVEL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ReasonForExamination).WithOne().HasForeignKey<AtlasModel.HCExaminationComponent>(x => x.ReasonForExaminationRef).IsRequired(false);
            builder.HasOne(t => t.EDisabledReport).WithOne().HasForeignKey<AtlasModel.HCExaminationComponent>(x => x.EDisabledReportRef).IsRequired(false);
            builder.HasOne(t => t.EStatusNotRepCommitteeObj).WithOne().HasForeignKey<AtlasModel.HCExaminationComponent>(x => x.EStatusNotRepCommitteeObjRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}