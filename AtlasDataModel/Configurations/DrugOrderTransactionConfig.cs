using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderTransactionConfig : IEntityTypeConfiguration<AtlasModel.DrugOrderTransaction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrderTransaction> builder)
        {
            builder.ToTable("DRUGORDERTRANSACTION");
            builder.HasKey(nameof(AtlasModel.DrugOrderTransaction.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrderTransaction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrderTransaction.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderTransaction.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.DrugOrderTransaction.DrugOrderRef)).HasColumnName("DRUGORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderTransaction.KScheduleMaterialRef)).HasColumnName("KSCHEDULEMATERIAL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrder).WithOne().HasForeignKey<AtlasModel.DrugOrderTransaction>(x => x.DrugOrderRef).IsRequired(false);
            builder.HasOne(t => t.KScheduleMaterial).WithOne().HasForeignKey<AtlasModel.DrugOrderTransaction>(x => x.KScheduleMaterialRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}