using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DpRuleDetailConfig : IEntityTypeConfiguration<AtlasModel.DpRuleDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DpRuleDetail> builder)
        {
            builder.ToTable("DPRULEDETAIL");
            builder.HasKey(nameof(AtlasModel.DpRuleDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DpRuleDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DpRuleDetail.Sex)).HasColumnName("SEX");
            builder.Property(nameof(AtlasModel.DpRuleDetail.TedaviTuru)).HasColumnName("TEDAVITURU");
            builder.Property(nameof(AtlasModel.DpRuleDetail.Kesi)).HasColumnName("KESI");
            builder.Property(nameof(AtlasModel.DpRuleDetail.Report)).HasColumnName("REPORT");
            builder.Property(nameof(AtlasModel.DpRuleDetail.Age)).HasColumnName("AGE");
            builder.Property(nameof(AtlasModel.DpRuleDetail.AgeType)).HasColumnName("AGETYPE");
            builder.Property(nameof(AtlasModel.DpRuleDetail.HospitalType)).HasColumnName("HOSPITALTYPE");
            builder.Property(nameof(AtlasModel.DpRuleDetail.PeriodScope)).HasColumnName("PERIODSCOPE");
            builder.Property(nameof(AtlasModel.DpRuleDetail.PeriodAmount)).HasColumnName("PERIODAMOUNT");
            builder.Property(nameof(AtlasModel.DpRuleDetail.Period)).HasColumnName("PERIOD");
            builder.Property(nameof(AtlasModel.DpRuleDetail.PeriodTimeType)).HasColumnName("PERIODTIMETYPE");
            builder.Property(nameof(AtlasModel.DpRuleDetail.Master)).HasColumnName("MASTER");
            builder.Property(nameof(AtlasModel.DpRuleDetail.DPRuleMasterRef)).HasColumnName("DPRULEMASTER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DPRuleMaster).WithOne().HasForeignKey<AtlasModel.DpRuleDetail>(x => x.DPRuleMasterRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}