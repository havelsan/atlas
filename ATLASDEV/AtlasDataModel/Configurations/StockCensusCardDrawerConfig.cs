using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockCensusCardDrawerConfig : IEntityTypeConfiguration<AtlasModel.StockCensusCardDrawer>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockCensusCardDrawer> builder)
        {
            builder.ToTable("STOCKCENSUSCARDDRAWER");
            builder.HasKey(nameof(AtlasModel.StockCensusCardDrawer.ObjectId));
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.IsDoubleZeroCompleted)).HasColumnName("ISDOUBLEZEROCOMPLETED");
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.IsStockCensusCompleted)).HasColumnName("ISSTOCKCENSUSCOMPLETED");
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.DoubleZeroObjectID)).HasColumnName("DOUBLEZEROOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.StockCensusObjectID)).HasColumnName("STOCKCENSUSOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.CardDrawerRef)).HasColumnName("CARDDRAWER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.CheckStockCensusActionRef)).HasColumnName("CHECKSTOCKCENSUSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusCardDrawer.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.CheckStockCensusAction).WithOne().HasForeignKey<AtlasModel.StockCensusCardDrawer>(x => x.CheckStockCensusActionRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.StockCensusCardDrawer>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}