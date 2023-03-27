using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountDocumentDetailConfig : IEntityTypeConfiguration<AtlasModel.AccountDocumentDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountDocumentDetail> builder)
        {
            builder.ToTable("ACCOUNTDOCUMENTDETAIL");
            builder.HasKey(nameof(AtlasModel.AccountDocumentDetail.ObjectId));
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.ExternalCode)).HasColumnName("EXTERNALCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.TotalDiscountPrice)).HasColumnName("TOTALDISCOUNTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.VATPrice)).HasColumnName("VATPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.TotalDiscountedPrice)).HasColumnName("TOTALDISCOUNTEDPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.AccountDocumentGroupRef)).HasColumnName("ACCOUNTDOCUMENTGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountDocumentDetail.CurrencyTypeRef)).HasColumnName("CURRENCYTYPE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountDocumentGroup).WithOne().HasForeignKey<AtlasModel.AccountDocumentDetail>(x => x.AccountDocumentGroupRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}