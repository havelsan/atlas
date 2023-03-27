using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MKYSTrxConfig : IEntityTypeConfiguration<AtlasModel.MKYSTrx>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MKYSTrx> builder)
        {
            builder.ToTable("MKYSTRX");
            builder.HasKey(nameof(AtlasModel.MKYSTrx.ObjectId));
            builder.Property(nameof(AtlasModel.MKYSTrx.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MKYSTrx.MkysID)).HasColumnName("MKYSID");
            builder.Property(nameof(AtlasModel.MKYSTrx.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.MKYSTrx.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.MKYSTrx.VatRate)).HasColumnName("VATRATE");
            builder.Property(nameof(AtlasModel.MKYSTrx.MkysDescription)).HasColumnName("MKYSDESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MKYSTrx.NATOStockNO)).HasColumnName("NATOSTOCKNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSTrx.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.MKYSTrx.TransactionID)).HasColumnName("TRANSACTIONID");
            builder.Property(nameof(AtlasModel.MKYSTrx.MKYS_StokHareketID)).HasColumnName("MKYS_STOKHAREKETID");
            builder.Property(nameof(AtlasModel.MKYSTrx.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.MKYSTrx.MKYS_Butce)).HasColumnName("MKYS_BUTCE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MKYSTrx.Barcode)).HasColumnName("BARCODE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.MKYSTrx.InOut)).HasColumnName("INOUT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MKYSTrx.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MKYSTrx.MainStoreDefinitionRef)).HasColumnName("MAINSTOREDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.MKYSTrx>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.MainStoreDefinition).WithOne().HasForeignKey<AtlasModel.MKYSTrx>(x => x.MainStoreDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}