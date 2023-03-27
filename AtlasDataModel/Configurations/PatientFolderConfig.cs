using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientFolderConfig : IEntityTypeConfiguration<AtlasModel.PatientFolder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientFolder> builder)
        {
            builder.ToTable("PATIENTFOLDER");
            builder.HasKey(nameof(AtlasModel.PatientFolder.ObjectId));
            builder.Property(nameof(AtlasModel.PatientFolder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientFolder.PatientFolderID)).HasColumnName("PATIENTFOLDERID");
            builder.Property(nameof(AtlasModel.PatientFolder.Shelf)).HasColumnName("SHELF").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientFolder.FolderStatus)).HasColumnName("FOLDERSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientFolder.Row)).HasColumnName("ROW").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientFolder.LastPatientFolderTransactionRef)).HasColumnName("LASTPATIENTFOLDERTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientFolder.FolderLocationRef)).HasColumnName("FOLDERLOCATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientFolder.BuildingRef)).HasColumnName("BUILDING").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.LastPatientFolderTransaction).WithOne().HasForeignKey<AtlasModel.PatientFolder>(x => x.LastPatientFolderTransactionRef).IsRequired(false);
            builder.HasOne(t => t.FolderLocation).WithOne().HasForeignKey<AtlasModel.PatientFolder>(x => x.FolderLocationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}