using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockTrxUpdateActionConfig : IEntityTypeConfiguration<AtlasModel.StockTrxUpdateAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockTrxUpdateAction> builder)
        {
            builder.ToTable("STOCKTRXUPDATEACTION");
            builder.HasKey(nameof(AtlasModel.StockTrxUpdateAction.ObjectId));
            builder.Property(nameof(AtlasModel.StockTrxUpdateAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockTrxUpdateAction.NewUnitPrice)).HasColumnName("NEWUNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockTrxUpdateAction.MainStoreDefinitionRef)).HasColumnName("MAINSTOREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockTrxUpdateAction.StockCardRef)).HasColumnName("STOCKCARD").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainStoreDefinition).WithOne().HasForeignKey<AtlasModel.StockTrxUpdateAction>(x => x.MainStoreDefinitionRef).IsRequired(true);
            builder.HasOne(t => t.StockCard).WithOne().HasForeignKey<AtlasModel.StockTrxUpdateAction>(x => x.StockCardRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}