using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseDietOrderConfig : IEntityTypeConfiguration<AtlasModel.BaseDietOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseDietOrder> builder)
        {
            builder.ToTable("BASEDIETORDER");
            builder.HasKey(nameof(AtlasModel.BaseDietOrder.ObjectId));
            builder.Property(nameof(AtlasModel.BaseDietOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseDietOrder.MealTypeRef)).HasColumnName("MEALTYPE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PeriodicOrder).WithOne().HasForeignKey<AtlasModel.PeriodicOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MealType).WithOne().HasForeignKey<AtlasModel.BaseDietOrder>(x => x.MealTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}