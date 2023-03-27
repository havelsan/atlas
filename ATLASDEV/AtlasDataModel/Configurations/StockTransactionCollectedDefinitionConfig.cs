using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockTransactionCollectedDefinitionConfig : IEntityTypeConfiguration<AtlasModel.StockTransactionCollectedDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockTransactionCollectedDefinition> builder)
        {
            builder.ToTable("STOCKTRANSACTIONCOLLECTDEF");
            builder.HasKey(nameof(AtlasModel.StockTransactionCollectedDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.StockTransactionCollectedDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockTransactionCollectedDefinition.CheckedStockTransactionDefRef)).HasColumnName("CHECKEDSTOCKTRANSACTIONDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTransactionCollectedDefinition.StockTransactionDefinitionRef)).HasColumnName("STOCKTRANSACTIONDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.CheckedStockTransactionDef).WithOne().HasForeignKey<AtlasModel.StockTransactionCollectedDefinition>(x => x.CheckedStockTransactionDefRef).IsRequired(false);
            builder.HasOne(t => t.StockTransactionDefinition).WithOne().HasForeignKey<AtlasModel.StockTransactionCollectedDefinition>(x => x.StockTransactionDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}