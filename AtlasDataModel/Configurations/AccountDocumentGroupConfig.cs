using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountDocumentGroupConfig : IEntityTypeConfiguration<AtlasModel.AccountDocumentGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountDocumentGroup> builder)
        {
            builder.ToTable("ACCOUNTDOCUMENTGROUP");
            builder.HasKey(nameof(AtlasModel.AccountDocumentGroup.ObjectId));
            builder.Property(nameof(AtlasModel.AccountDocumentGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountDocumentGroup.GroupDescription)).HasColumnName("GROUPDESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AccountDocumentGroup.GroupCode)).HasColumnName("GROUPCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AccountDocumentGroup.AccountDocumentRef)).HasColumnName("ACCOUNTDOCUMENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.AccountDocumentGroup>(x => x.AccountDocumentRef).IsRequired(false);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.AccountDocumentDetails).WithOne(x => x.AccountDocumentGroup).HasForeignKey(x => x.AccountDocumentGroupRef);
            #endregion Child Relations
        }
    }
}