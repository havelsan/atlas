using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientOldDebtConfig : IEntityTypeConfiguration<AtlasModel.PatientOldDebt>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientOldDebt> builder)
        {
            builder.ToTable("PATIENTOLDDEBT");
            builder.HasKey(nameof(AtlasModel.PatientOldDebt.ObjectId));
            builder.Property(nameof(AtlasModel.PatientOldDebt.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientOldDebt.OldID)).HasColumnName("OLDID");
            builder.Property(nameof(AtlasModel.PatientOldDebt.TotalDebt)).HasColumnName("TOTALDEBT").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PatientOldDebt.ProcedureType)).HasColumnName("PROCEDURETYPE");
            builder.Property(nameof(AtlasModel.PatientOldDebt.ProcedureCode)).HasColumnName("PROCEDURECODE");
            builder.Property(nameof(AtlasModel.PatientOldDebt.ProcedureName)).HasColumnName("PROCEDURENAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.PatientOldDebt.PaymentType)).HasColumnName("PAYMENTTYPE");
            builder.Property(nameof(AtlasModel.PatientOldDebt.TransactionDebt)).HasColumnName("TRANSACTIONDEBT").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PatientOldDebt.OldPatientID)).HasColumnName("OLDPATIENTID");
            builder.Property(nameof(AtlasModel.PatientOldDebt.OldPADate)).HasColumnName("OLDPADATE");
            builder.Property(nameof(AtlasModel.PatientOldDebt.OldPANo)).HasColumnName("OLDPANO");
            builder.Property(nameof(AtlasModel.PatientOldDebt.OldPatientNameSurname)).HasColumnName("OLDPATIENTNAMESURNAME");
            builder.Property(nameof(AtlasModel.PatientOldDebt.OldUniqueRefNo)).HasColumnName("OLDUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.PatientOldDebt.IsRemoved)).HasColumnName("ISREMOVED");
            builder.Property(nameof(AtlasModel.PatientOldDebt.OldDebtReceiptDocumentRef)).HasColumnName("OLDDEBTRECEIPTDOCUMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientOldDebt.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientOldDebt.ProcedureDefinitionRef)).HasColumnName("PROCEDUREDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.OldDebtReceiptDocument).WithOne().HasForeignKey<AtlasModel.PatientOldDebt>(x => x.OldDebtReceiptDocumentRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.PatientOldDebt>(x => x.PatientRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.PatientOldDebt>(x => x.ProcedureDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}