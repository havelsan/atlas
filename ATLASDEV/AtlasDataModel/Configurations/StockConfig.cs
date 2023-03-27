using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockConfig : IEntityTypeConfiguration<AtlasModel.Stock>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Stock> builder)
        {
            builder.ToTable("STOCK");
            builder.HasKey(nameof(AtlasModel.Stock.ObjectId));
            builder.Property(nameof(AtlasModel.Stock.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Stock.TotalOutPrice)).HasColumnName("TOTALOUTPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.Stock.MinimumLevel)).HasColumnName("MINIMUMLEVEL").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.TotalInPrice)).HasColumnName("TOTALINPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.Stock.TotalOut)).HasColumnName("TOTALOUT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.Consigned)).HasColumnName("CONSIGNED").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.Inheld)).HasColumnName("INHELD").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.TotalIn)).HasColumnName("TOTALIN").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.SafetyLevel)).HasColumnName("SAFETYLEVEL").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.Expendable)).HasColumnName("EXPENDABLE");
            builder.Property(nameof(AtlasModel.Stock.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.Stock.MaximumLevel)).HasColumnName("MAXIMUMLEVEL").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.CriticalLevel)).HasColumnName("CRITICALLEVEL").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Stock.Row)).HasColumnName("ROW");
            builder.Property(nameof(AtlasModel.Stock.Shelf)).HasColumnName("SHELF");
            builder.Property(nameof(AtlasModel.Stock.StoreRef)).HasColumnName("STORE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Stock.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.Stock>(x => x.StoreRef).IsRequired(true);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.Stock>(x => x.MaterialRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}