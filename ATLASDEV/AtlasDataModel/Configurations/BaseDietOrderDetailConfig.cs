using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseDietOrderDetailConfig : IEntityTypeConfiguration<AtlasModel.BaseDietOrderDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseDietOrderDetail> builder)
        {
            builder.ToTable("BASEDIETORDERDETAIL");
            builder.HasKey(nameof(AtlasModel.BaseDietOrderDetail.ObjectId));
            builder.Property(nameof(AtlasModel.BaseDietOrderDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseDietOrderDetail.MealTypeRef)).HasColumnName("MEALTYPE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PeriodicOrderDetail).WithOne().HasForeignKey<AtlasModel.PeriodicOrderDetail>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MealType).WithOne().HasForeignKey<AtlasModel.BaseDietOrderDetail>(x => x.MealTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}