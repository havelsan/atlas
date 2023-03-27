using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockCardClassConfig : IEntityTypeConfiguration<AtlasModel.StockCardClass>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockCardClass> builder)
        {
            builder.ToTable("STOCKCARDCLASS");
            builder.HasKey(nameof(AtlasModel.StockCardClass.ObjectId));
            builder.Property(nameof(AtlasModel.StockCardClass.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockCardClass.IsGroup)).HasColumnName("ISGROUP");
            builder.Property(nameof(AtlasModel.StockCardClass.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockCardClass.Code)).HasColumnName("CODE").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.StockCardClass.QREF)).HasColumnName("QREF").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockCardClass.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.StockCardClass.ParentStockCardClassRef)).HasColumnName("PARENTSTOCKCARDCLASS").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentStockCardClass).WithOne().HasForeignKey<AtlasModel.StockCardClass>(x => x.ParentStockCardClassRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}