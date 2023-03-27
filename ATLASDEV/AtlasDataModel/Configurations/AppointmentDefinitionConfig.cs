using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AppointmentDefinitionConfig : IEntityTypeConfiguration<AtlasModel.AppointmentDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AppointmentDefinition> builder)
        {
            builder.ToTable("APPOINTMENTDEFINITION");
            builder.HasKey(nameof(AtlasModel.AppointmentDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.AppointmentDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AppointmentDefinition.StateOnly)).HasColumnName("STATEONLY");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.AppointmentDefinitionID)).HasColumnName("APPOINTMENTDEFINITIONID");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.AppDefNameDisplayText)).HasColumnName("APPDEFNAMEDISPLAYTEXT").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AppointmentDefinition.GiveFromResource)).HasColumnName("GIVEFROMRESOURCE");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.GiveToMaster)).HasColumnName("GIVETOMASTER");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.FormDefID)).HasColumnName("FORMDEFID");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.OverlapAllowed)).HasColumnName("OVERLAPALLOWED");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.AppointmentDefinitionName)).HasColumnName("APPOINTMENTDEFINITIONNAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.AppDefNameDisplayText_Shad)).HasColumnName("APPDEFNAMEDISPLAYTEXT_SHAD");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.IsDescReqForNonScheduledApps)).HasColumnName("ISDESCREQFORNONSCHEDULEDAPPS");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.ScheduleOverlapAllowed)).HasColumnName("SCHEDULEOVERLAPALLOWED");
            builder.Property(nameof(AtlasModel.AppointmentDefinition.SentToMHRS)).HasColumnName("SENTTOMHRS");
        }
    }
}