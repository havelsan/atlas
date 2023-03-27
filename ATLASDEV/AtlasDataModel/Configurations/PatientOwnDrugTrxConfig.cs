using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientOwnDrugTrxConfig : IEntityTypeConfiguration<AtlasModel.PatientOwnDrugTrx>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientOwnDrugTrx> builder)
        {
            builder.ToTable("PATIENTOWNDRUGTRX");
            builder.HasKey(nameof(AtlasModel.PatientOwnDrugTrx.ObjectId));
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrx.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrx.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrx.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrx.PatientOwnDrugEntryDetailRef)).HasColumnName("PATIENTOWNDRUGENTRYDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PatientOwnDrugEntryDetail).WithOne().HasForeignKey<AtlasModel.PatientOwnDrugTrx>(x => x.PatientOwnDrugEntryDetailRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}