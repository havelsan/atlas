using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HospitalsUnitsGridConfig : IEntityTypeConfiguration<AtlasModel.HospitalsUnitsGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HospitalsUnitsGrid> builder)
        {
            builder.ToTable("HOSPITALSUNITSGRID");
            builder.HasKey(nameof(AtlasModel.HospitalsUnitsGrid.ObjectId));
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.Explanation)).HasColumnName("EXPLANATION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.Approve)).HasColumnName("APPROVE");
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.Reject)).HasColumnName("REJECT");
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.ExaminationState)).HasColumnName("EXAMINATIONSTATE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.DisableRatio)).HasColumnName("DISABLERATIO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.UnitRef)).HasColumnName("UNIT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HospitalsUnitsGrid.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.HospitalsUnitsGrid>(x => x.DoctorRef).IsRequired(false);
            builder.HasOne(t => t.Unit).WithOne().HasForeignKey<AtlasModel.HospitalsUnitsGrid>(x => x.UnitRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}