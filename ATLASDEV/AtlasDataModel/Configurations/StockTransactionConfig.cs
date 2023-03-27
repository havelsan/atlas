using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockTransactionConfig : IEntityTypeConfiguration<AtlasModel.StockTransaction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockTransaction> builder)
        {
            builder.ToTable("STOCKTRANSACTION");
            builder.HasKey(nameof(AtlasModel.StockTransaction.ObjectId));
            builder.Property(nameof(AtlasModel.StockTransaction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockTransaction.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.StockTransaction.InOut)).HasColumnName("INOUT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockTransaction.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.StockTransaction.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockTransaction.MaintainLevelCode)).HasColumnName("MAINTAINLEVELCODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockTransaction.VatRate)).HasColumnName("VATRATE");
            builder.Property(nameof(AtlasModel.StockTransaction.LotNo)).HasColumnName("LOTNO");
            builder.Property(nameof(AtlasModel.StockTransaction.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockTransaction.MKYS_StokHareketID)).HasColumnName("MKYS_STOKHAREKETID");
            builder.Property(nameof(AtlasModel.StockTransaction.SerialNo)).HasColumnName("SERIALNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.StockTransaction.ReceiveNotificationID)).HasColumnName("RECEIVENOTIFICATIONID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockTransaction.IncomingDeliveryNotifID)).HasColumnName("INCOMINGDELIVERYNOTIFID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockTransaction.DeliveryNotifictionID)).HasColumnName("DELIVERYNOTIFICTIONID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockTransaction.UsageNotificationID)).HasColumnName("USAGENOTIFICATIONID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockTransaction.StockRef)).HasColumnName("STOCK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTransaction.StockTransactionDefinitionRef)).HasColumnName("STOCKTRANSACTIONDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTransaction.StockLevelTypeRef)).HasColumnName("STOCKLEVELTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTransaction.StockActionDetailRef)).HasColumnName("STOCKACTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTransaction.BudgetTypeDefinitionRef)).HasColumnName("BUDGETTYPEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTransaction.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Stock).WithOne().HasForeignKey<AtlasModel.StockTransaction>(x => x.StockRef).IsRequired(true);
            builder.HasOne(t => t.StockTransactionDefinition).WithOne().HasForeignKey<AtlasModel.StockTransaction>(x => x.StockTransactionDefinitionRef).IsRequired(true);
            builder.HasOne(t => t.StockLevelType).WithOne().HasForeignKey<AtlasModel.StockTransaction>(x => x.StockLevelTypeRef).IsRequired(true);
            builder.HasOne(t => t.StockActionDetail).WithOne().HasForeignKey<AtlasModel.StockTransaction>(x => x.StockActionDetailRef).IsRequired(true);
            builder.HasOne(t => t.BudgetTypeDefinition).WithOne().HasForeignKey<AtlasModel.StockTransaction>(x => x.BudgetTypeDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.StockTransaction>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}