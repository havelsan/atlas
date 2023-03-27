using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AnesthesiaAndReanimationConfig : IEntityTypeConfiguration<AtlasModel.AnesthesiaAndReanimation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AnesthesiaAndReanimation> builder)
        {
            builder.ToTable("ANESTHESIAANDREANIMATION");
            builder.HasKey(nameof(AtlasModel.AnesthesiaAndReanimation.ObjectId));
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.PlannedAnesthesiaDate)).HasColumnName("PLANNEDANESTHESIADATE");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.AnesthesiaStartDateTime)).HasColumnName("ANESTHESIASTARTDATETIME");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.AnesthesiaReport)).HasColumnName("ANESTHESIAREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.AnesthesiaEndDateTime)).HasColumnName("ANESTHESIAENDDATETIME");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ASAType)).HasColumnName("ASATYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.AnesthesiaReportDate)).HasColumnName("ANESTHESIAREPORTDATE");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.AnesthesiaReportNo)).HasColumnName("ANESTHESIAREPORTNO");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.RequestNote)).HasColumnName("REQUESTNOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.AnesthesiaTechnique)).HasColumnName("ANESTHESIATECHNIQUE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.IsTreatmentMaterialEmpty)).HasColumnName("ISTREATMENTMATERIALEMPTY");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.CancelledBySurgery)).HasColumnName("CANCELLEDBYSURGERY");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.AnesthesiaNote)).HasColumnName("ANESTHESIANOTE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.IsPatientApprovalFormGiven)).HasColumnName("ISPATIENTAPPROVALFORMGIVEN");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.drAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.HasComplication)).HasColumnName("HASCOMPLICATION");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ComplicationDescription)).HasColumnName("COMPLICATIONDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ASAScore)).HasColumnName("ASASCORE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ScarType)).HasColumnName("SCARTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.Laparoscopy)).HasColumnName("LAPAROSCOPY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.MainSurgeryRef)).HasColumnName("MAINSURGERY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AnesthesiaAndReanimation.ProcedureDoctor2Ref)).HasColumnName("PROCEDUREDOCTOR2").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainSurgery).WithOne().HasForeignKey<AtlasModel.AnesthesiaAndReanimation>(x => x.MainSurgeryRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.AnesthesiaAndReanimation>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.AnesthesiaAndReanimation>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor2).WithOne().HasForeignKey<AtlasModel.AnesthesiaAndReanimation>(x => x.ProcedureDoctor2Ref).IsRequired(false);
            #endregion Parent Relations
        }
    }
}