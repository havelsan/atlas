using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReviewActionConfig : IEntityTypeConfiguration<AtlasModel.ReviewAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReviewAction> builder)
        {
            builder.ToTable("REVIEWACTION");
            builder.HasKey(nameof(AtlasModel.ReviewAction.ObjectId));
            builder.Property(nameof(AtlasModel.ReviewAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReviewAction.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.ReviewAction.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.ReviewAction.ReviewActionType)).HasColumnName("REVIEWACTIONTYPE").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}