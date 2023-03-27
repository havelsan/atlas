using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MealTypesConfig : IEntityTypeConfiguration<AtlasModel.MealTypes>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MealTypes> builder)
        {
            builder.ToTable("MEALTYPES");
            builder.HasKey(nameof(AtlasModel.MealTypes.ObjectId));
            builder.Property(nameof(AtlasModel.MealTypes.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MealTypes.Breakfast)).HasColumnName("BREAKFAST");
            builder.Property(nameof(AtlasModel.MealTypes.Dinner)).HasColumnName("DINNER");
            builder.Property(nameof(AtlasModel.MealTypes.Lunch)).HasColumnName("LUNCH");
            builder.Property(nameof(AtlasModel.MealTypes.NightBreakfast)).HasColumnName("NIGHTBREAKFAST");
            builder.Property(nameof(AtlasModel.MealTypes.Snack1)).HasColumnName("SNACK1");
            builder.Property(nameof(AtlasModel.MealTypes.Snack2)).HasColumnName("SNACK2");
            builder.Property(nameof(AtlasModel.MealTypes.Snack3)).HasColumnName("SNACK3");
        }
    }
}