using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockTransactionDefinitionConfig : IEntityTypeConfiguration<AtlasModel.StockTransactionDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockTransactionDefinition> builder)
        {
            builder.ToTable("STOCKTRANSACTIONDEFINITION");
            builder.HasKey(nameof(AtlasModel.StockTransactionDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.ShortDescription)).HasColumnName("SHORTDESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.ReferenceLetter)).HasColumnName("REFERENCELETTER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.DestinationMaintainLevelCode)).HasColumnName("DESTINATIONMAINTAINLEVELCODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.IsStockDown)).HasColumnName("ISSTOCKDOWN");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.RegistrationPrefix)).HasColumnName("REGISTRATIONPREFIX").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.StartDateTimeFormat)).HasColumnName("STARTDATETIMEFORMAT").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.IsFixedAsset)).HasColumnName("ISFIXEDASSET");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.TransactionType)).HasColumnName("TRANSACTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.AskForDateTime)).HasColumnName("ASKFORDATETIME");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.Description_Shadow)).HasColumnName("DESCRIPTION_SHADOW");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.MaintainLevelCode)).HasColumnName("MAINTAINLEVELCODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.IsTotalReport)).HasColumnName("ISTOTALREPORT");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.EndDateTimeFormat)).HasColumnName("ENDDATETIMEFORMAT").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.IsMinMaxLevelCalc)).HasColumnName("ISMINMAXLEVELCALC");
            builder.Property(nameof(AtlasModel.StockTransactionDefinition.ChangedStockLevelTypeRef)).HasColumnName("CHANGEDSTOCKLEVELTYPE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ChangedStockLevelType).WithOne().HasForeignKey<AtlasModel.StockTransactionDefinition>(x => x.ChangedStockLevelTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}