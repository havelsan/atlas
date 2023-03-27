using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryRejectReasonConfig : IEntityTypeConfiguration<AtlasModel.SurgeryRejectReason>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryRejectReason> builder)
        {
            builder.ToTable("SURGERYREJECTREASON");
            builder.HasKey(nameof(AtlasModel.SurgeryRejectReason.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryRejectReason.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryRejectReason.LackOfMaterial)).HasColumnName("LACKOFMATERIAL");
            builder.Property(nameof(AtlasModel.SurgeryRejectReason.PreopPreparation)).HasColumnName("PREOPPREPARATION");
            builder.Property(nameof(AtlasModel.SurgeryRejectReason.PatientNotCome)).HasColumnName("PATIENTNOTCOME");
            builder.Property(nameof(AtlasModel.SurgeryRejectReason.ProlongSurgery)).HasColumnName("PROLONGSURGERY");
            builder.Property(nameof(AtlasModel.SurgeryRejectReason.OtherReason)).HasColumnName("OTHERREASON");
            builder.Property(nameof(AtlasModel.SurgeryRejectReason.OtherReasonExplanation)).HasColumnName("OTHERREASONEXPLANATION").HasColumnType("VARCHAR2(4000)");
        }
    }
}