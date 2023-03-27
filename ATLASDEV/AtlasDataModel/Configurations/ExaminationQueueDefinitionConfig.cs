using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ExaminationQueueDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ExaminationQueueDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ExaminationQueueDefinition> builder)
        {
            builder.ToTable("EXAMINATIONQUEUEDEFINITION");
            builder.HasKey(nameof(AtlasModel.ExaminationQueueDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.RecallCount)).HasColumnName("RECALLCOUNT");
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.IsEmergencyQueue)).HasColumnName("ISEMERGENCYQUEUE");
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.NotAllowToSelectDoctor)).HasColumnName("NOTALLOWTOSELECTDOCTOR");
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.IsActiveQueue)).HasColumnName("ISACTIVEQUEUE");
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.IgnorePriority)).HasColumnName("IGNOREPRIORITY");
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.DisplayPeriod)).HasColumnName("DISPLAYPERIOD");
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.Name)).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.DivertTime)).HasColumnName("DIVERTTIME");
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.QueuePriorityTemplateDefRef)).HasColumnName("QUEUEPRIORITYTEMPLATEDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueDefinition.ResSectionRef)).HasColumnName("RESSECTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ExaminationQueueDefinition>(x => x.ResSectionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}