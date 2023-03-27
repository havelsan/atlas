using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseSurgeryProcedureConfig : IEntityTypeConfiguration<AtlasModel.BaseSurgeryProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseSurgeryProcedure> builder)
        {
            builder.ToTable("BASESURGERYPROCEDURE");
            builder.HasKey(nameof(AtlasModel.BaseSurgeryProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.Position)).HasColumnName("POSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.IncisionType)).HasColumnName("INCISIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.DescriptionOfProcedureObject)).HasColumnName("DESCRIPTIONOFPROCEDUREOBJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.ToothNumber)).HasColumnName("TOOTHNUMBER");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.ToothAnomaly)).HasColumnName("TOOTHANOMALY");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.ToothCommitmentNumber)).HasColumnName("TOOTHCOMMITMENTNUMBER");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.PackageStartDate)).HasColumnName("PACKAGESTARTDATE");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.PackageEndDate)).HasColumnName("PACKAGEENDDATE");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.Aciklama)).HasColumnName("ACIKLAMA");
            builder.Property(nameof(AtlasModel.BaseSurgeryProcedure.PackageProcedureObjectRef)).HasColumnName("PACKAGEPROCEDUREOBJECT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseSurgeryAndManipulationProcedure).WithOne().HasForeignKey<AtlasModel.BaseSurgeryAndManipulationProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PackageProcedureObject).WithOne().HasForeignKey<AtlasModel.BaseSurgeryProcedure>(x => x.PackageProcedureObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}