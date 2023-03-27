using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MHRSAdmissionAppointmentConfig : IEntityTypeConfiguration<AtlasModel.MHRSAdmissionAppointment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MHRSAdmissionAppointment> builder)
        {
            builder.ToTable("MHRSADMISSIONAPPOINTMENT");
            builder.HasKey(nameof(AtlasModel.MHRSAdmissionAppointment.ObjectId));
            builder.Property(nameof(AtlasModel.MHRSAdmissionAppointment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MHRSAdmissionAppointment.RandevuHrn)).HasColumnName("RANDEVUHRN").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MHRSAdmissionAppointment.IsDisabled)).HasColumnName("ISDISABLED");
            builder.Property(nameof(AtlasModel.MHRSAdmissionAppointment.IsForlorn)).HasColumnName("ISFORLORN");
            builder.Property(nameof(AtlasModel.MHRSAdmissionAppointment.IsHighRiskPregnancy)).HasColumnName("ISHIGHRISKPREGNANCY");
            builder.Property(nameof(AtlasModel.MHRSAdmissionAppointment.IsVirtuleUniqueRefNo)).HasColumnName("ISVIRTULEUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.MHRSAdmissionAppointment.IsWantedCompanion)).HasColumnName("ISWANTEDCOMPANION");
            builder.HasOne(t => t.AdmissionAppointment).WithOne().HasForeignKey<AtlasModel.AdmissionAppointment>(p => p.ObjectId);
        }
    }
}