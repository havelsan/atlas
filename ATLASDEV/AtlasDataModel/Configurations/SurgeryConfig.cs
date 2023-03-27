using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryConfig : IEntityTypeConfiguration<AtlasModel.Surgery>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Surgery> builder)
        {
            builder.ToTable("SURGERY");
            builder.HasKey(nameof(AtlasModel.Surgery.ObjectId));
            builder.Property(nameof(AtlasModel.Surgery.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryAnesthesiaPoint)).HasColumnName("SURGERYANESTHESIAPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryEndTime)).HasColumnName("SURGERYENDTIME");
            builder.Property(nameof(AtlasModel.Surgery.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.Surgery.ReturnToDoctorReason)).HasColumnName("RETURNTODOCTORREASON").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Surgery.DescriptionToPreOp)).HasColumnName("DESCRIPTIONTOPREOP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.PreOpDescriptions)).HasColumnName("PREOPDESCRIPTIONS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Surgery.SurgeryReport)).HasColumnName("SURGERYREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryReportNo)).HasColumnName("SURGERYREPORTNO");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryStartTime)).HasColumnName("SURGERYSTARTTIME");
            builder.Property(nameof(AtlasModel.Surgery.NotesToAnesthesia)).HasColumnName("NOTESTOANESTHESIA").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Surgery.PlannedSurgeryDate)).HasColumnName("PLANNEDSURGERYDATE");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryTotalPoint)).HasColumnName("SURGERYTOTALPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryReportDate)).HasColumnName("SURGERYREPORTDATE");
            builder.Property(nameof(AtlasModel.Surgery.IsPatientApprovalFormGiven)).HasColumnName("ISPATIENTAPPROVALFORMGIVEN");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryTemplate)).HasColumnName("SURGERYTEMPLATE");
            builder.Property(nameof(AtlasModel.Surgery.MedulaAciklamasi)).HasColumnName("MEDULAACIKLAMASI");
            builder.Property(nameof(AtlasModel.Surgery.IsNeedAnesthesia)).HasColumnName("ISNEEDANESTHESIA");
            builder.Property(nameof(AtlasModel.Surgery.IsComplicationSurgery)).HasColumnName("ISCOMPLICATIONSURGERY");
            builder.Property(nameof(AtlasModel.Surgery.ComplicationDescription)).HasColumnName("COMPLICATIONDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Surgery.PlannedSurgeryDescription)).HasColumnName("PLANNEDSURGERYDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Surgery.SurgeryShift)).HasColumnName("SURGERYSHIFT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryStatus)).HasColumnName("SURGERYSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Surgery.IsDelayedSurgery)).HasColumnName("ISDELAYEDSURGERY");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryStatusDefinitionTime)).HasColumnName("SURGERYSTATUSDEFINITIONTIME");
            builder.Property(nameof(AtlasModel.Surgery.SurgeryPointGroup)).HasColumnName("SURGERYPOINTGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Surgery.AnesthesiaAndReanimationRef)).HasColumnName("ANESTHESIAANDREANIMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryRoomRef)).HasColumnName("SURGERYROOM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryDeskRef)).HasColumnName("SURGERYDESK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryExtensionRef)).HasColumnName("SURGERYEXTENSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryRobsonRef)).HasColumnName("SURGERYROBSON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryResultRef)).HasColumnName("SURGERYRESULT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Surgery.SurgeryStatusDefinitionRef)).HasColumnName("SURGERYSTATUSDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.AnesthesiaAndReanimation).WithOne().HasForeignKey<AtlasModel.Surgery>(x => x.AnesthesiaAndReanimationRef).IsRequired(false);
            builder.HasOne(t => t.SurgeryRoom).WithOne().HasForeignKey<AtlasModel.Surgery>(x => x.SurgeryRoomRef).IsRequired(false);
            builder.HasOne(t => t.SurgeryDesk).WithOne().HasForeignKey<AtlasModel.Surgery>(x => x.SurgeryDeskRef).IsRequired(false);
            builder.HasOne(t => t.SurgeryExtension).WithOne().HasForeignKey<AtlasModel.Surgery>(x => x.SurgeryExtensionRef).IsRequired(false);
            builder.HasOne(t => t.SurgeryRobson).WithOne().HasForeignKey<AtlasModel.Surgery>(x => x.SurgeryRobsonRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}