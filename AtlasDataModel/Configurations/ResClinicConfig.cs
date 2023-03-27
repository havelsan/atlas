using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResClinicConfig : IEntityTypeConfiguration<AtlasModel.ResClinic>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResClinic> builder)
        {
            builder.ToTable("RESCLINIC");
            builder.HasKey(nameof(AtlasModel.ResClinic.ObjectId));
            builder.Property(nameof(AtlasModel.ResClinic.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResClinic.IsEmergencyClinic)).HasColumnName("ISEMERGENCYCLINIC");
            builder.Property(nameof(AtlasModel.ResClinic.PreDischargeLimit)).HasColumnName("PREDISCHARGELIMIT");
            builder.Property(nameof(AtlasModel.ResClinic.HasCertificate)).HasColumnName("HASCERTIFICATE");
            builder.Property(nameof(AtlasModel.ResClinic.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResWard).WithOne().HasForeignKey<AtlasModel.ResWard>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.ResClinic>(x => x.DepartmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}