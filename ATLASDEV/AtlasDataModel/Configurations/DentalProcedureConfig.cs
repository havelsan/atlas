using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalProcedureConfig : IEntityTypeConfiguration<AtlasModel.DentalProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalProcedure> builder)
        {
            builder.ToTable("DENTALPROCEDURE");
            builder.HasKey(nameof(AtlasModel.DentalProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.DentalProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DentalProcedure.ExternalID)).HasColumnName("EXTERNALID").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DentalProcedure.ToothNumber)).HasColumnName("TOOTHNUMBER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DentalProcedure.AccountRecordable)).HasColumnName("ACCOUNTRECORDABLE");
            builder.Property(nameof(AtlasModel.DentalProcedure.PatientPrice)).HasColumnName("PATIENTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.DentalProcedure.Anomali)).HasColumnName("ANOMALI");
            builder.Property(nameof(AtlasModel.DentalProcedure.DisTaahhutNo)).HasColumnName("DISTAAHHUTNO");
            builder.Property(nameof(AtlasModel.DentalProcedure.DentalPosition)).HasColumnName("DENTALPOSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DentalProcedure.AnesteziDoktorRef)).HasColumnName("ANESTEZIDOKTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalProcedure.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubactionProcedureWithDiagnosis).WithOne().HasForeignKey<AtlasModel.SubactionProcedureWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.AnesteziDoktor).WithOne().HasForeignKey<AtlasModel.DentalProcedure>(x => x.AnesteziDoktorRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.DentalProcedure>(x => x.OzelDurumRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}