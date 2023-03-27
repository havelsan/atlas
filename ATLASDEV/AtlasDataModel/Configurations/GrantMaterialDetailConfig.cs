using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class GrantMaterialDetailConfig : IEntityTypeConfiguration<AtlasModel.GrantMaterialDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.GrantMaterialDetail> builder)
        {
            builder.ToTable("GRANTMATERIALDETAIL");
            builder.HasKey(nameof(AtlasModel.GrantMaterialDetail.ObjectId));
            builder.Property(nameof(AtlasModel.GrantMaterialDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailIn).WithOne().HasForeignKey<AtlasModel.StockActionDetailIn>(p => p.ObjectId);
        }
    }
}