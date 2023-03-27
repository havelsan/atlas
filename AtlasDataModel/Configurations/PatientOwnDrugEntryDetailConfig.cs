using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientOwnDrugEntryDetailConfig : IEntityTypeConfiguration<AtlasModel.PatientOwnDrugEntryDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientOwnDrugEntryDetail> builder)
        {
            builder.ToTable("PATIENTOWNDRUGENTRYDETAIL");
            builder.HasKey(nameof(AtlasModel.PatientOwnDrugEntryDetail.ObjectId));
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.SendAmount)).HasColumnName("SENDAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.BarcodeAmount)).HasColumnName("BARCODEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntryDetail.PatientOwnDrugEntryRef)).HasColumnName("PATIENTOWNDRUGENTRY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.PatientOwnDrugEntryDetail>(x => x.MaterialRef).IsRequired(true);
            builder.HasOne(t => t.PatientOwnDrugEntry).WithOne().HasForeignKey<AtlasModel.PatientOwnDrugEntryDetail>(x => x.PatientOwnDrugEntryRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}