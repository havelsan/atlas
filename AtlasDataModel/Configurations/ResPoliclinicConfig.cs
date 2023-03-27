using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResPoliclinicConfig : IEntityTypeConfiguration<AtlasModel.ResPoliclinic>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResPoliclinic> builder)
        {
            builder.ToTable("RESPOLICLINIC");
            builder.HasKey(nameof(AtlasModel.ResPoliclinic.ObjectId));
            builder.Property(nameof(AtlasModel.ResPoliclinic.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResPoliclinic.ASALCode)).HasColumnName("ASALCODE");
            builder.Property(nameof(AtlasModel.ResPoliclinic.MHRSCode)).HasColumnName("MHRSCODE");
            builder.Property(nameof(AtlasModel.ResPoliclinic.MHRSAltKlinikKodu)).HasColumnName("MHRSALTKLINIKKODU");
            builder.Property(nameof(AtlasModel.ResPoliclinic.CopyHeightWeight)).HasColumnName("COPYHEIGHTWEIGHT");
            builder.Property(nameof(AtlasModel.ResPoliclinic.IsDentalPoliclinic)).HasColumnName("ISDENTALPOLICLINIC");
            builder.Property(nameof(AtlasModel.ResPoliclinic.PoliclinicType)).HasColumnName("POLICLINICTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResPoliclinic.PatientCallSystemInUse)).HasColumnName("PATIENTCALLSYSTEMINUSE");
            builder.Property(nameof(AtlasModel.ResPoliclinic.IsHealthCommittee)).HasColumnName("ISHEALTHCOMMITTEE");
            builder.Property(nameof(AtlasModel.ResPoliclinic.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.ResPoliclinic>(x => x.DepartmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}