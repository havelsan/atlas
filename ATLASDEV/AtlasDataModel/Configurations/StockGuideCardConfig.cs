using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockGuideCardConfig : IEntityTypeConfiguration<AtlasModel.StockGuideCard>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockGuideCard> builder)
        {
            builder.ToTable("STOCKGUIDECARD");
            builder.HasKey(nameof(AtlasModel.StockGuideCard.ObjectId));
            builder.Property(nameof(AtlasModel.StockGuideCard.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockGuideCard.ShortDescription)).HasColumnName("SHORTDESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockGuideCard.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockGuideCard.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockGuideCard.Description_Shadow)).HasColumnName("DESCRIPTION_SHADOW");
            builder.Property(nameof(AtlasModel.StockGuideCard.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.StockGuideCard.StockCardRef)).HasColumnName("STOCKCARD").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockCard).WithOne().HasForeignKey<AtlasModel.StockGuideCard>(x => x.StockCardRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}