using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InpatientResponsibleNurseConfig : IEntityTypeConfiguration<AtlasModel.InpatientResponsibleNurse>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InpatientResponsibleNurse> builder)
        {
            builder.ToTable("INPATIENTRESPONSIBLENURSE");
            builder.HasKey(nameof(AtlasModel.InpatientResponsibleNurse.ObjectId));
            builder.Property(nameof(AtlasModel.InpatientResponsibleNurse.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InpatientResponsibleNurse.SDateTime)).HasColumnName("SDATETIME");
            builder.Property(nameof(AtlasModel.InpatientResponsibleNurse.NurseRef)).HasColumnName("NURSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InpatientResponsibleNurse.InPatientTreatmentClinicAppRef)).HasColumnName("INPATIENTTREATMENTCLINICAPP").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Nurse).WithOne().HasForeignKey<AtlasModel.InpatientResponsibleNurse>(x => x.NurseRef).IsRequired(false);
            builder.HasOne(t => t.InPatientTreatmentClinicApp).WithOne().HasForeignKey<AtlasModel.InpatientResponsibleNurse>(x => x.InPatientTreatmentClinicAppRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}