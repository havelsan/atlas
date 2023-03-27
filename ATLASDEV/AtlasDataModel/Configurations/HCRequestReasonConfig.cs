using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HCRequestReasonConfig : IEntityTypeConfiguration<AtlasModel.HCRequestReason>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HCRequestReason> builder)
        {
            builder.ToTable("HCREQUESTREASON");
            builder.HasKey(nameof(AtlasModel.HCRequestReason.ObjectId));
            builder.Property(nameof(AtlasModel.HCRequestReason.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HCRequestReason.ReasonName)).HasColumnName("REASONNAME").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HCRequestReason.HCEReportType)).HasColumnName("HCEREPORTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HCRequestReason.ReasonName_Shadow)).HasColumnName("REASONNAME_SHADOW").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.HCRequestReason.ReasonForExaminationRef)).HasColumnName("REASONFOREXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ReasonForExamination).WithOne().HasForeignKey<AtlasModel.HCRequestReason>(x => x.ReasonForExaminationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}