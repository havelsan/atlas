using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PrescriptionConfig : IEntityTypeConfiguration<AtlasModel.Prescription>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Prescription> builder)
        {
            builder.ToTable("PRESCRIPTION");
            builder.HasKey(nameof(AtlasModel.Prescription.ObjectId));
            builder.Property(nameof(AtlasModel.Prescription.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Prescription.PrescriptionNO)).HasColumnName("PRESCRIPTIONNO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.Prescription.IsSigned)).HasColumnName("ISSIGNED");
            builder.Property(nameof(AtlasModel.Prescription.EHUUniqueNo)).HasColumnName("EHUUNIQUENO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Prescription.EHURecetePassword)).HasColumnName("EHURECETEPASSWORD").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Prescription.DistributionNo)).HasColumnName("DISTRIBUTIONNO").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Prescription.PrescriptionPrice)).HasColumnName("PRESCRIPTIONPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Prescription.EReceteDescription)).HasColumnName("ERECETEDESCRIPTION");
            builder.Property(nameof(AtlasModel.Prescription.PrescriptionType)).HasColumnName("PRESCRIPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Prescription.SignedData)).HasColumnName("SIGNEDDATA").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Prescription.ProvisionType)).HasColumnName("PROVISIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Prescription.PrescriptionSubType)).HasColumnName("PRESCRIPTIONSUBTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Prescription.EReceteNo)).HasColumnName("ERECETENO").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Prescription.FillingDate)).HasColumnName("FILLINGDATE");
            builder.Property(nameof(AtlasModel.Prescription.ERecetePassword)).HasColumnName("ERECETEPASSWORD").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Prescription.IsRepeated)).HasColumnName("ISREPEATED");
            builder.Property(nameof(AtlasModel.Prescription.PrescriptionPaperRef)).HasColumnName("PRESCRIPTIONPAPER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}