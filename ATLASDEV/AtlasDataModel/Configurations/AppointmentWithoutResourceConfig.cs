using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AppointmentWithoutResourceConfig : IEntityTypeConfiguration<AtlasModel.AppointmentWithoutResource>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AppointmentWithoutResource> builder)
        {
            builder.ToTable("APPOINTMENTWITHOUTRESOURCE");
            builder.HasKey(nameof(AtlasModel.AppointmentWithoutResource.ObjectId));
            builder.Property(nameof(AtlasModel.AppointmentWithoutResource.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AppointmentWithoutResource.AppDateTime)).HasColumnName("APPDATETIME");
            builder.Property(nameof(AtlasModel.AppointmentWithoutResource.ActionRef)).HasColumnName("ACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AppointmentWithoutResource.SubActionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Action).WithOne().HasForeignKey<AtlasModel.AppointmentWithoutResource>(x => x.ActionRef).IsRequired(false);
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.AppointmentWithoutResource>(x => x.SubActionProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}