using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BasePhysiotherapyOrderConfig : IEntityTypeConfiguration<AtlasModel.BasePhysiotherapyOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BasePhysiotherapyOrder> builder)
        {
            builder.ToTable("BASEPHYSIOTHERAPYORDER");
            builder.HasKey(nameof(AtlasModel.BasePhysiotherapyOrder.ObjectId));
            builder.Property(nameof(AtlasModel.BasePhysiotherapyOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.PlannedAction).WithOne().HasForeignKey<AtlasModel.PlannedAction>(p => p.ObjectId);
        }
    }
}