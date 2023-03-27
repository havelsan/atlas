using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResDepartmentConfig : IEntityTypeConfiguration<AtlasModel.ResDepartment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResDepartment> builder)
        {
            builder.ToTable("RESDEPARTMENT");
            builder.HasKey(nameof(AtlasModel.ResDepartment.ObjectId));
            builder.Property(nameof(AtlasModel.ResDepartment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResDepartment.ActionEnabled)).HasColumnName("ACTIONENABLED");
            builder.Property(nameof(AtlasModel.ResDepartment.ResourceType)).HasColumnName("RESOURCETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResDepartment.IsEmergencyDepartment)).HasColumnName("ISEMERGENCYDEPARTMENT");
            builder.Property(nameof(AtlasModel.ResDepartment.MainDepartmentRef)).HasColumnName("MAINDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResDepartment.BuildingRef)).HasColumnName("BUILDING").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainDepartment).WithOne().HasForeignKey<AtlasModel.ResDepartment>(x => x.MainDepartmentRef).IsRequired(false);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.Clinics).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentRef);
            #endregion Child Relations
        }
    }
}