using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class GaitAnalysisFormConfig : IEntityTypeConfiguration<AtlasModel.GaitAnalysisForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.GaitAnalysisForm> builder)
        {
            builder.ToTable("GAITANALYSISFORM");
            builder.HasKey(nameof(AtlasModel.GaitAnalysisForm.ObjectId));
            builder.Property(nameof(AtlasModel.GaitAnalysisForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.GaitAnalysisForm.FIM)).HasColumnName("FIM").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.GaitAnalysisForm.FAC)).HasColumnName("FAC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.GaitAnalysisForm.RivermeadAssessment)).HasColumnName("RIVERMEADASSESSMENT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.GaitAnalysisForm.BarthelIndex)).HasColumnName("BARTHELINDEX").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.GaitAnalysisForm.PULSESProfile)).HasColumnName("PULSESPROFILE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.GaitAnalysisForm.GMFCS)).HasColumnName("GMFCS").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}