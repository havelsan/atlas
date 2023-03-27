using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class GlaskowScoreConfig : IEntityTypeConfiguration<AtlasModel.GlaskowScore>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.GlaskowScore> builder)
        {
            builder.ToTable("GLASKOWSCORE");
            builder.HasKey(nameof(AtlasModel.GlaskowScore.ObjectId));
            builder.Property(nameof(AtlasModel.GlaskowScore.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.GlaskowScore.Total)).HasColumnName("TOTAL");
            builder.Property(nameof(AtlasModel.GlaskowScore.TotalScore)).HasColumnName("TOTALSCORE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.GlaskowScore.EyesRef)).HasColumnName("EYES").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.GlaskowScore.MotorAnswerRef)).HasColumnName("MOTORANSWER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.GlaskowScore.OralAnswerRef)).HasColumnName("ORALANSWER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseMultipleDataEntry).WithOne().HasForeignKey<AtlasModel.BaseMultipleDataEntry>(p => p.ObjectId);
        }
    }
}