using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResourceSpecialityGridConfig : IEntityTypeConfiguration<AtlasModel.ResourceSpecialityGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResourceSpecialityGrid> builder)
        {
            builder.ToTable("RESOURCESPECIALITYGRID");
            builder.HasKey(nameof(AtlasModel.ResourceSpecialityGrid.ObjectId));
            builder.Property(nameof(AtlasModel.ResourceSpecialityGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResourceSpecialityGrid.MainSpeciality)).HasColumnName("MAINSPECIALITY");
            builder.Property(nameof(AtlasModel.ResourceSpecialityGrid.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResourceSpecialityGrid.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.ResourceSpecialityGrid>(x => x.ResourceRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}