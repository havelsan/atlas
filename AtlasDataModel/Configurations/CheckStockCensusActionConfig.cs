using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CheckStockCensusActionConfig : IEntityTypeConfiguration<AtlasModel.CheckStockCensusAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CheckStockCensusAction> builder)
        {
            builder.ToTable("CHECKSTOCKCENSUSACTION");
            builder.HasKey(nameof(AtlasModel.CheckStockCensusAction.ObjectId));
            builder.Property(nameof(AtlasModel.CheckStockCensusAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CheckStockCensusAction.IsChecked)).HasColumnName("ISCHECKED");
            builder.Property(nameof(AtlasModel.CheckStockCensusAction.IsUpdateCreationDate)).HasColumnName("ISUPDATECREATIONDATE");
            builder.Property(nameof(AtlasModel.CheckStockCensusAction.MainStoreDefinitionRef)).HasColumnName("MAINSTOREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CheckStockCensusAction.AccountingTermRef)).HasColumnName("ACCOUNTINGTERM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainStoreDefinition).WithOne().HasForeignKey<AtlasModel.CheckStockCensusAction>(x => x.MainStoreDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.AccountingTerm).WithOne().HasForeignKey<AtlasModel.CheckStockCensusAction>(x => x.AccountingTermRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}