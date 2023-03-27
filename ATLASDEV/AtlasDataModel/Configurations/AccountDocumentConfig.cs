using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountDocumentConfig : IEntityTypeConfiguration<AtlasModel.AccountDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountDocument> builder)
        {
            builder.ToTable("ACCOUNTDOCUMENT");
            builder.HasKey(nameof(AtlasModel.AccountDocument.ObjectId));
            builder.Property(nameof(AtlasModel.AccountDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountDocument.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AccountDocument.PatientStatus)).HasColumnName("PATIENTSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountDocument.DocumentDate)).HasColumnName("DOCUMENTDATE");
            builder.Property(nameof(AtlasModel.AccountDocument.DocumentNo)).HasColumnName("DOCUMENTNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AccountDocument.SendToAccounting)).HasColumnName("SENDTOACCOUNTING");
            builder.Property(nameof(AtlasModel.AccountDocument.DocumentID)).HasColumnName("DOCUMENTID");
            builder.Property(nameof(AtlasModel.AccountDocument.TotalPrice)).HasColumnName("TOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDocument.PaymentType)).HasColumnName("PAYMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountDocument.CreateDate)).HasColumnName("CREATEDATE");
            builder.Property(nameof(AtlasModel.AccountDocument.CancelDate)).HasColumnName("CANCELDATE");
            builder.Property(nameof(AtlasModel.AccountDocument.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountDocument.CashOfficeRef)).HasColumnName("CASHOFFICE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountDocument.CashierLogRef)).HasColumnName("CASHIERLOG").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountDocument.EpisodeAccountActionRef)).HasColumnName("EPISODEACCOUNTACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountDocument.AccountActionRef)).HasColumnName("ACCOUNTACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.AccountDocument>(x => x.ResUserRef).IsRequired(true);
            builder.HasOne(t => t.EpisodeAccountAction).WithOne().HasForeignKey<AtlasModel.AccountDocument>(x => x.EpisodeAccountActionRef).IsRequired(false);
            builder.HasOne(t => t.AccountAction).WithOne().HasForeignKey<AtlasModel.AccountDocument>(x => x.AccountActionRef).IsRequired(false);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.Payments).WithOne(x => x.AccountDocument).HasForeignKey(x => x.AccountDocumentRef);
            builder.HasMany(t => t.AccountDocumentGroups).WithOne(x => x.AccountDocument).HasForeignKey(x => x.AccountDocumentRef);
            #endregion Child Relations
        }
    }
}