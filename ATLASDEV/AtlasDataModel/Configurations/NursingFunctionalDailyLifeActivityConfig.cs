using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingFunctionalDailyLifeActivityConfig : IEntityTypeConfiguration<AtlasModel.NursingFunctionalDailyLifeActivity>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingFunctionalDailyLifeActivity> builder)
        {
            builder.ToTable("NURFUNCDAILYLIFEACTIVITY");
            builder.HasKey(nameof(AtlasModel.NursingFunctionalDailyLifeActivity.ObjectId));
            builder.Property(nameof(AtlasModel.NursingFunctionalDailyLifeActivity.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingFunctionalDailyLifeActivity.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingFunctionalDailyLifeActivity.DetailNote)).HasColumnName("DETAILNOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NursingFunctionalDailyLifeActivity.IsCheck)).HasColumnName("ISCHECK");
            builder.Property(nameof(AtlasModel.NursingFunctionalDailyLifeActivity.NursingDailyLifeActivityRef)).HasColumnName("NURSINGDAILYLIFEACTIVITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingFunctionalDailyLifeActivity.DailyLifeActivityRef)).HasColumnName("DAILYLIFEACTIVITY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingDailyLifeActivity).WithOne().HasForeignKey<AtlasModel.NursingFunctionalDailyLifeActivity>(x => x.NursingDailyLifeActivityRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}