using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UploadedDocumentConfig : IEntityTypeConfiguration<AtlasModel.UploadedDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UploadedDocument> builder)
        {
            builder.ToTable("UPLOADEDDOCUMENT");
            builder.HasKey(nameof(AtlasModel.UploadedDocument.ObjectId));
            builder.Property(nameof(AtlasModel.UploadedDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UploadedDocument.UploadDate)).HasColumnName("UPLOADDATE");
            builder.Property(nameof(AtlasModel.UploadedDocument.Explanation)).HasColumnName("EXPLANATION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.UploadedDocument.DocumentType)).HasColumnName("DOCUMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.UploadedDocument.File)).HasColumnName("FILE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UploadedDocument.FileName)).HasColumnName("FILENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.UploadedDocument.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.UploadedDocument>(x => x.EpisodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}