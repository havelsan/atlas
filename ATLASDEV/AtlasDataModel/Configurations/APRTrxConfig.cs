using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class APRTrxConfig : IEntityTypeConfiguration<AtlasModel.APRTrx>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.APRTrx> builder)
        {
            builder.ToTable("APRTRX");
            builder.HasKey(nameof(AtlasModel.APRTrx.ObjectId));
            builder.Property(nameof(AtlasModel.APRTrx.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.APRTrx.Price)).HasColumnName("PRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.APRTrx.AccountPayableReceivableRef)).HasColumnName("ACCOUNTPAYABLERECEIVABLE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.APRTrx.AccountDocumentRef)).HasColumnName("ACCOUNTDOCUMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.APRTrx.APRTrxTypeRef)).HasColumnName("APRTRXTYPE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountPayableReceivable).WithOne().HasForeignKey<AtlasModel.APRTrx>(x => x.AccountPayableReceivableRef).IsRequired(false);
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.APRTrx>(x => x.AccountDocumentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}