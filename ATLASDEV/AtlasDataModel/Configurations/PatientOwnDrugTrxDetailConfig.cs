using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientOwnDrugTrxDetailConfig : IEntityTypeConfiguration<AtlasModel.PatientOwnDrugTrxDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientOwnDrugTrxDetail> builder)
        {
            builder.ToTable("PATIENTOWNDRUGTRXDETAIL");
            builder.HasKey(nameof(AtlasModel.PatientOwnDrugTrxDetail.ObjectId));
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrxDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrxDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrxDetail.DrugOrderDetailRef)).HasColumnName("DRUGORDERDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientOwnDrugTrxDetail.PatientOwnDrugTrxRef)).HasColumnName("PATIENTOWNDRUGTRX").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrderDetail).WithOne().HasForeignKey<AtlasModel.PatientOwnDrugTrxDetail>(x => x.DrugOrderDetailRef).IsRequired(false);
            builder.HasOne(t => t.PatientOwnDrugTrx).WithOne().HasForeignKey<AtlasModel.PatientOwnDrugTrxDetail>(x => x.PatientOwnDrugTrxRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}