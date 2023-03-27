using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyActivityTestsFormConfig : IEntityTypeConfiguration<AtlasModel.DailyActivityTestsForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyActivityTestsForm> builder)
        {
            builder.ToTable("DAILYACTIVITYTESTSFORM");
            builder.HasKey(nameof(AtlasModel.DailyActivityTestsForm.ObjectId));
            builder.Property(nameof(AtlasModel.DailyActivityTestsForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DailyActivityTestsForm.BarthelTest)).HasColumnName("BARTHELTEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DailyActivityTestsForm.FonctionalIndependenceMeasure)).HasColumnName("FONCTIONALINDEPENDENCEMEASURE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DailyActivityTestsForm.HealthAssessmentQuostionnarie)).HasColumnName("HEALTHASSESSMENTQUOSTIONNARIE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DailyActivityTestsForm.BASFI)).HasColumnName("BASFI").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DailyActivityTestsForm.KatzIndex)).HasColumnName("KATZINDEX").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}