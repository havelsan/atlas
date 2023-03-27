using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ExaminationQueueItemConfig : IEntityTypeConfiguration<AtlasModel.ExaminationQueueItem>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ExaminationQueueItem> builder)
        {
            builder.ToTable("EXAMINATIONQUEUEITEM");
            builder.HasKey(nameof(AtlasModel.ExaminationQueueItem.ObjectId));
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.PriorityReason)).HasColumnName("PRIORITYREASON").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.IsEmergency)).HasColumnName("ISEMERGENCY");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.CallCount)).HasColumnName("CALLCOUNT");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.QueueDate)).HasColumnName("QUEUEDATE");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.NextItemsCount)).HasColumnName("NEXTITEMSCOUNT");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.CallTime)).HasColumnName("CALLTIME");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.DivertedTime)).HasColumnName("DIVERTEDTIME");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.Priority)).HasColumnName("PRIORITY");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.IsResultExamination)).HasColumnName("ISRESULTEXAMINATION");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.DestinationResourceRef)).HasColumnName("DESTINATIONRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.ExaminationQueueDefinitionRef)).HasColumnName("EXAMINATIONQUEUEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.AppointmentRef)).HasColumnName("APPOINTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.SubactionProcedureFlowableRef)).HasColumnName("SUBACTIONPROCEDUREFLOWABLE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ExaminationQueueItem.CompletedByRef)).HasColumnName("COMPLETEDBY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DestinationResource).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.DestinationResourceRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.EpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.ExaminationQueueDefinition).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.ExaminationQueueDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.DoctorRef).IsRequired(false);
            builder.HasOne(t => t.Appointment).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.AppointmentRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.PatientRef).IsRequired(true);
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.SubactionProcedureFlowableRef).IsRequired(false);
            builder.HasOne(t => t.CompletedBy).WithOne().HasForeignKey<AtlasModel.ExaminationQueueItem>(x => x.CompletedByRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}