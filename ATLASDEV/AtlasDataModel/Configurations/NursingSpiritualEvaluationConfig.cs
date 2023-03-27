using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingSpiritualEvaluationConfig : IEntityTypeConfiguration<AtlasModel.NursingSpiritualEvaluation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingSpiritualEvaluation> builder)
        {
            builder.ToTable("NURSINGSPIRITUALEVALUATION");
            builder.HasKey(nameof(AtlasModel.NursingSpiritualEvaluation.ObjectId));
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.Normal)).HasColumnName("NORMAL");
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.Furious)).HasColumnName("FURIOUS");
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.Sad)).HasColumnName("SAD");
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.Nervous)).HasColumnName("NERVOUS");
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.Indifferent)).HasColumnName("INDIFFERENT");
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.Other)).HasColumnName("OTHER");
            builder.Property(nameof(AtlasModel.NursingSpiritualEvaluation.Explanation)).HasColumnName("EXPLANATION").HasMaxLength(100);
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}