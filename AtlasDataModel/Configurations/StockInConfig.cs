using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockInConfig : IEntityTypeConfiguration<AtlasModel.StockIn>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockIn> builder)
        {
            builder.ToTable("STOCKIN");
            builder.HasKey(nameof(AtlasModel.StockIn.ObjectId));
            builder.Property(nameof(AtlasModel.StockIn.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockIn.DrugReturnActionRef)).HasColumnName("DRUGRETURNACTION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DrugReturnAction).WithOne().HasForeignKey<AtlasModel.StockIn>(x => x.DrugReturnActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}