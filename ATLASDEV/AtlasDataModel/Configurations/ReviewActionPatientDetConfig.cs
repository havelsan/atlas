using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReviewActionPatientDetConfig : IEntityTypeConfiguration<AtlasModel.ReviewActionPatientDet>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReviewActionPatientDet> builder)
        {
            builder.ToTable("REVIEWACTIONPATIENTDET");
            builder.HasKey(nameof(AtlasModel.ReviewActionPatientDet.ObjectId));
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.Clinic)).HasColumnName("CLINIC");
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.Patient)).HasColumnName("PATIENT");
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.UniqueRefNo)).HasColumnName("UNIQUEREFNO");
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.MaterialName)).HasColumnName("MATERIALNAME").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.PatientObjID)).HasColumnName("PATIENTOBJID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.MaterialObjID)).HasColumnName("MATERIALOBJID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReviewActionPatientDet.ReviewActionRef)).HasColumnName("REVIEWACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ReviewAction).WithOne().HasForeignKey<AtlasModel.ReviewActionPatientDet>(x => x.ReviewActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}