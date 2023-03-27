using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResourcesToBeReferredGridConfig : IEntityTypeConfiguration<AtlasModel.ResourcesToBeReferredGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResourcesToBeReferredGrid> builder)
        {
            builder.ToTable("RESOURCESTOBEREFERREDGRID");
            builder.HasKey(nameof(AtlasModel.ResourcesToBeReferredGrid.ObjectId));
            builder.Property(nameof(AtlasModel.ResourcesToBeReferredGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResourcesToBeReferredGrid.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.ResourcesToBeReferredGrid>(x => x.ResourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}