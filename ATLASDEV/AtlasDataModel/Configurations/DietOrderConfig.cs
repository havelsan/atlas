using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DietOrderConfig : IEntityTypeConfiguration<AtlasModel.DietOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DietOrder> builder)
        {
            builder.ToTable("DIETORDER");
            builder.HasKey(nameof(AtlasModel.DietOrder.ObjectId));
            builder.Property(nameof(AtlasModel.DietOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DietOrder.InpatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseDietOrder).WithOne().HasForeignKey<AtlasModel.BaseDietOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.InpatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.DietOrder>(x => x.InpatientPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}