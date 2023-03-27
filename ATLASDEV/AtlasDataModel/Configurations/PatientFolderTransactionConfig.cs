using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientFolderTransactionConfig : IEntityTypeConfiguration<AtlasModel.PatientFolderTransaction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientFolderTransaction> builder)
        {
            builder.ToTable("PATIENTFOLDERTRANSACTION");
            builder.HasKey(nameof(AtlasModel.PatientFolderTransaction.ObjectId));
            builder.Property(nameof(AtlasModel.PatientFolderTransaction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientFolderTransaction.TransactionID)).HasColumnName("TRANSACTIONID");
            builder.Property(nameof(AtlasModel.PatientFolderTransaction.TransactionType)).HasColumnName("TRANSACTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientFolderTransaction.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.PatientFolderTransaction.TransactionUserRef)).HasColumnName("TRANSACTIONUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientFolderTransaction.FolderLocationRef)).HasColumnName("FOLDERLOCATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientFolderTransaction.PatientFolderRef)).HasColumnName("PATIENTFOLDER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.TransactionUser).WithOne().HasForeignKey<AtlasModel.PatientFolderTransaction>(x => x.TransactionUserRef).IsRequired(false);
            builder.HasOne(t => t.FolderLocation).WithOne().HasForeignKey<AtlasModel.PatientFolderTransaction>(x => x.FolderLocationRef).IsRequired(false);
            builder.HasOne(t => t.PatientFolder).WithOne().HasForeignKey<AtlasModel.PatientFolderTransaction>(x => x.PatientFolderRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}