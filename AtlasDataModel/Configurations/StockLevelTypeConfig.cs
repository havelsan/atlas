using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockLevelTypeConfig : IEntityTypeConfiguration<AtlasModel.StockLevelType>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockLevelType> builder)
        {
            builder.ToTable("STOCKLEVELTYPE");
            builder.HasKey(nameof(AtlasModel.StockLevelType.ObjectId));
            builder.Property(nameof(AtlasModel.StockLevelType.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockLevelType.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockLevelType.StockLevelTypeStatus)).HasColumnName("STOCKLEVELTYPESTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockLevelType.Description_Shadow)).HasColumnName("DESCRIPTION_SHADOW");
            builder.Property(nameof(AtlasModel.StockLevelType.ParentLevelRef)).HasColumnName("PARENTLEVEL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentLevel).WithOne().HasForeignKey<AtlasModel.StockLevelType>(x => x.ParentLevelRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}