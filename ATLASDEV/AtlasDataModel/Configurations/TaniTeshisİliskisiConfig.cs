using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TaniTeshisİliskisiConfig : IEntityTypeConfiguration<AtlasModel.TaniTeshisİliskisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TaniTeshisİliskisi> builder)
        {
            builder.ToTable("TANITESHISILISKISI");
            builder.HasKey(nameof(AtlasModel.TaniTeshisİliskisi.ObjectId));
            builder.Property(nameof(AtlasModel.TaniTeshisİliskisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TaniTeshisİliskisi.DiagnosisGridRef)).HasColumnName("DIAGNOSISGRID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TaniTeshisİliskisi.TeshisRef)).HasColumnName("TESHIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TaniTeshisİliskisi.ReportDiagnosisRef)).HasColumnName("REPORTDIAGNOSIS").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DiagnosisGrid).WithOne().HasForeignKey<AtlasModel.TaniTeshisİliskisi>(x => x.DiagnosisGridRef).IsRequired(false);
            builder.HasOne(t => t.ReportDiagnosis).WithOne().HasForeignKey<AtlasModel.TaniTeshisİliskisi>(x => x.ReportDiagnosisRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}