using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingWoundedAssesmentConfig : IEntityTypeConfiguration<AtlasModel.NursingWoundedAssesment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingWoundedAssesment> builder)
        {
            builder.ToTable("NURSINGWOUNDEDASSESMENT");
            builder.HasKey(nameof(AtlasModel.NursingWoundedAssesment.ObjectId));
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.Width)).HasColumnName("WIDTH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.WoundedType)).HasColumnName("WOUNDEDTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.OperationDate)).HasColumnName("OPERATIONDATE");
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.Height)).HasColumnName("HEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.Depth)).HasColumnName("DEPTH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.NursingWoundTime)).HasColumnName("NURSINGWOUNDTIME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.Amount)).HasColumnName("AMOUNT");
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.WoundStageRef)).HasColumnName("WOUNDSTAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.WoundLocalizationRef)).HasColumnName("WOUNDLOCALIZATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingWoundedAssesment.WoundSideRef)).HasColumnName("WOUNDSIDE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.WoundStage).WithOne().HasForeignKey<AtlasModel.NursingWoundedAssesment>(x => x.WoundStageRef).IsRequired(false);
            builder.HasOne(t => t.WoundLocalization).WithOne().HasForeignKey<AtlasModel.NursingWoundedAssesment>(x => x.WoundLocalizationRef).IsRequired(false);
            builder.HasOne(t => t.WoundSide).WithOne().HasForeignKey<AtlasModel.NursingWoundedAssesment>(x => x.WoundSideRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}