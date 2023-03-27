using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PostureAnalysisFormConfig : IEntityTypeConfiguration<AtlasModel.PostureAnalysisForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PostureAnalysisForm> builder)
        {
            builder.ToTable("POSTUREANALYSISFORM");
            builder.HasKey(nameof(AtlasModel.PostureAnalysisForm.ObjectId));
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.HeadPosture)).HasColumnName("HEADPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.ChestPosture)).HasColumnName("CHESTPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.ShoulderPosture)).HasColumnName("SHOULDERPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.ScapulaPosture)).HasColumnName("SCAPULAPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.SpinePosture)).HasColumnName("SPINEPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.LegPosture)).HasColumnName("LEGPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.FeetPosture)).HasColumnName("FEETPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PostureAnalysisForm.LegsLength)).HasColumnName("LEGSLENGTH").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}