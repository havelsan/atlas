using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DistributeDetailConfig : IEntityTypeConfiguration<AtlasModel.DistributeDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DistributeDetail> builder)
        {
            builder.ToTable("DISTRIBUTEDETAIL");
            builder.HasKey(nameof(AtlasModel.DistributeDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DistributeDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DistributeDetail.PatientQuarantineNo)).HasColumnName("PATIENTQUARANTINENO");
            builder.Property(nameof(AtlasModel.DistributeDetail.Price)).HasColumnName("PRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.DistributeDetail.PatientProtocolNo)).HasColumnName("PATIENTPROTOCOLNO");
            builder.Property(nameof(AtlasModel.DistributeDetail.PatientName)).HasColumnName("PATIENTNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DistributeDetail.ExternalPharmacyRef)).HasColumnName("EXTERNALPHARMACY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DistributeDetail.PrescriptionRef)).HasColumnName("PRESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DistributeDetail.PrescriptionDistributeRef)).HasColumnName("PRESCRIPTIONDISTRIBUTE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Prescription).WithOne().HasForeignKey<AtlasModel.DistributeDetail>(x => x.PrescriptionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}