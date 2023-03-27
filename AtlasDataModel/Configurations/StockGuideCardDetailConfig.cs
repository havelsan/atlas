using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockGuideCardDetailConfig : IEntityTypeConfiguration<AtlasModel.StockGuideCardDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockGuideCardDetail> builder)
        {
            builder.ToTable("STOCKGUIDECARDDETAIL");
            builder.HasKey(nameof(AtlasModel.StockGuideCardDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockGuideCardDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockGuideCardDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.StockGuideCardDetail.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockGuideCardDetail.StockGuideCardRef)).HasColumnName("STOCKGUIDECARD").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.StockGuideCardDetail>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.StockGuideCard).WithOne().HasForeignKey<AtlasModel.StockGuideCardDetail>(x => x.StockGuideCardRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}