using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubSurgeryConfig : IEntityTypeConfiguration<AtlasModel.SubSurgery>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubSurgery> builder)
        {
            builder.ToTable("SUBSURGERY");
            builder.HasKey(nameof(AtlasModel.SubSurgery.ObjectId));
            builder.Property(nameof(AtlasModel.SubSurgery.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubSurgery.SurgeryReport)).HasColumnName("SURGERYREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubSurgery.SurgeryReportDate)).HasColumnName("SURGERYREPORTDATE");
            builder.Property(nameof(AtlasModel.SubSurgery.SurgeryReportNo)).HasColumnName("SURGERYREPORTNO");
            builder.Property(nameof(AtlasModel.SubSurgery.SurgeryShift)).HasColumnName("SURGERYSHIFT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubSurgery.SurgeryStatus)).HasColumnName("SURGERYSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubSurgery.SurgeryPointGroup)).HasColumnName("SURGERYPOINTGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubSurgery.SurgeryRef)).HasColumnName("SURGERY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Surgery).WithOne().HasForeignKey<AtlasModel.SubSurgery>(x => x.SurgeryRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}