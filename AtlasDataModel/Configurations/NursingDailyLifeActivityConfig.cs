using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingDailyLifeActivityConfig : IEntityTypeConfiguration<AtlasModel.NursingDailyLifeActivity>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingDailyLifeActivity> builder)
        {
            builder.ToTable("NURDAILYLIFEACTIVITY");
            builder.HasKey(nameof(AtlasModel.NursingDailyLifeActivity.ObjectId));
            builder.Property(nameof(AtlasModel.NursingDailyLifeActivity.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingDailyLifeActivity.Note)).HasColumnName("NOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NursingDailyLifeActivity.ActionDate)).HasColumnName("ACTIONDATE");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}