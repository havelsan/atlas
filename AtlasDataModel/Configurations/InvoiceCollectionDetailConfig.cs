using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceCollectionDetailConfig : IEntityTypeConfiguration<AtlasModel.InvoiceCollectionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceCollectionDetail> builder)
        {
            builder.ToTable("INVOICECOLLECTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.InvoiceCollectionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.CreateDate)).HasColumnName("CREATEDATE");
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.Payment)).HasColumnName("PAYMENT").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.Deduction)).HasColumnName("DEDUCTION").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.CreateUserRef)).HasColumnName("CREATEUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.InvoiceCollectionRef)).HasColumnName("INVOICECOLLECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.NewInvoiceCollectionDetailRef)).HasColumnName("NEWINVOICECOLLECTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InvoiceCollectionDetail.PayerInvoiceDocumentRef)).HasColumnName("PAYERINVOICEDOCUMENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.CreateUser).WithOne().HasForeignKey<AtlasModel.InvoiceCollectionDetail>(x => x.CreateUserRef).IsRequired(true);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.InvoiceCollectionDetail>(x => x.EpisodeRef).IsRequired(true);
            builder.HasOne(t => t.NewInvoiceCollectionDetail).WithOne().HasForeignKey<AtlasModel.InvoiceCollectionDetail>(x => x.NewInvoiceCollectionDetailRef).IsRequired(false);
            builder.HasOne(t => t.PayerInvoiceDocument).WithOne().HasForeignKey<AtlasModel.InvoiceCollectionDetail>(x => x.PayerInvoiceDocumentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}