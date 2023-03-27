using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AppointmentCarrierConfig : IEntityTypeConfiguration<AtlasModel.AppointmentCarrier>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AppointmentCarrier> builder)
        {
            builder.ToTable("APPOINTMENTCARRIER");
            builder.HasKey(nameof(AtlasModel.AppointmentCarrier.ObjectId));
            builder.Property(nameof(AtlasModel.AppointmentCarrier.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AppointmentCarrier.SubResourceCaption)).HasColumnName("SUBRESOURCECAPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AppointmentCarrier.SubResource)).HasColumnName("SUBRESOURCE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AppointmentCarrier.AppointmentType)).HasColumnName("APPOINTMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AppointmentCarrier.RelationParentName)).HasColumnName("RELATIONPARENTNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AppointmentCarrier.IsDefault)).HasColumnName("ISDEFAULT");
            builder.Property(nameof(AtlasModel.AppointmentCarrier.AppointmentCount)).HasColumnName("APPOINTMENTCOUNT");
            builder.Property(nameof(AtlasModel.AppointmentCarrier.MasterResourceCaption)).HasColumnName("MASTERRESOURCECAPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AppointmentCarrier.CarrierName)).HasColumnName("CARRIERNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AppointmentCarrier.AppointmentDuration)).HasColumnName("APPOINTMENTDURATION");
            builder.Property(nameof(AtlasModel.AppointmentCarrier.MasterResource)).HasColumnName("MASTERRESOURCE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AppointmentCarrier.MasterResourceFilter)).HasColumnName("MASTERRESOURCEFILTER").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AppointmentCarrier.AppointmentDefinitionRef)).HasColumnName("APPOINTMENTDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AppointmentDefinition).WithOne().HasForeignKey<AtlasModel.AppointmentCarrier>(x => x.AppointmentDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}