using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResObservationUnitConfig : IEntityTypeConfiguration<AtlasModel.ResObservationUnit>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResObservationUnit> builder)
        {
            builder.ToTable("RESOBSERVATIONUNIT");
            builder.HasKey(nameof(AtlasModel.ResObservationUnit.ObjectId));
            builder.Property(nameof(AtlasModel.ResObservationUnit.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResObservationUnit.IsExternalObservationUnit)).HasColumnName("ISEXTERNALOBSERVATIONUNIT");
            builder.Property(nameof(AtlasModel.ResObservationUnit.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResObservationUnit.ObservationDepartmentRef)).HasColumnName("OBSERVATIONDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.ResObservationUnit>(x => x.DepartmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}