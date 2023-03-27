using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class GaitAnalysisComputerBasedFormConfig : IEntityTypeConfiguration<AtlasModel.GaitAnalysisComputerBasedForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.GaitAnalysisComputerBasedForm> builder)
        {
            builder.ToTable("GAITANALYSISCOMPUTERBASED");
            builder.HasKey(nameof(AtlasModel.GaitAnalysisComputerBasedForm.ObjectId));
            builder.Property(nameof(AtlasModel.GaitAnalysisComputerBasedForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.GaitAnalysisComputerBasedForm.GaitAnalysis)).HasColumnName("GAITANALYSIS").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}