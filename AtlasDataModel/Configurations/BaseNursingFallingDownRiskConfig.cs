using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseNursingFallingDownRiskConfig : IEntityTypeConfiguration<AtlasModel.BaseNursingFallingDownRisk>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseNursingFallingDownRisk> builder)
        {
            builder.ToTable("BASENURSINGFALLINGDOWNRISK");
            builder.HasKey(nameof(AtlasModel.BaseNursingFallingDownRisk.ObjectId));
            builder.Property(nameof(AtlasModel.BaseNursingFallingDownRisk.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseNursingFallingDownRisk.NursingAppDoneDate)).HasColumnName("NURSINGAPPDONEDATE");
            builder.Property(nameof(AtlasModel.BaseNursingFallingDownRisk.FallingDownRiskReason)).HasColumnName("FALLINGDOWNRISKREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseNursingFallingDownRisk.Note)).HasColumnName("NOTE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.BaseNursingFallingDownRisk.TotalScore)).HasColumnName("TOTALSCORE");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}