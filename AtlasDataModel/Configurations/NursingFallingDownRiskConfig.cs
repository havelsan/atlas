using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingFallingDownRiskConfig : IEntityTypeConfiguration<AtlasModel.NursingFallingDownRisk>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingFallingDownRisk> builder)
        {
            builder.ToTable("NURSINGFALLINGDOWNRISK");
            builder.HasKey(nameof(AtlasModel.NursingFallingDownRisk.ObjectId));
            builder.Property(nameof(AtlasModel.NursingFallingDownRisk.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingFallingDownRisk.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.NursingFallingDownRisk.RiskFactorRef)).HasColumnName("RISKFACTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingFallingDownRisk.BaseNursingFallingDownRiskRef)).HasColumnName("BASENURSINGFALLINGDOWNRISK").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.RiskFactor).WithOne().HasForeignKey<AtlasModel.NursingFallingDownRisk>(x => x.RiskFactorRef).IsRequired(false);
            builder.HasOne(t => t.BaseNursingFallingDownRisk).WithOne().HasForeignKey<AtlasModel.NursingFallingDownRisk>(x => x.BaseNursingFallingDownRiskRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}