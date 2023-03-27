using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ManipulationFormBaseObjectConfig : IEntityTypeConfiguration<AtlasModel.ManipulationFormBaseObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ManipulationFormBaseObject> builder)
        {
            builder.ToTable("MANIPULATIONFORMBASEOBJECT");
            builder.HasKey(nameof(AtlasModel.ManipulationFormBaseObject.ObjectId));
            builder.Property(nameof(AtlasModel.ManipulationFormBaseObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ManipulationFormBaseObject.ManipulationRef)).HasColumnName("MANIPULATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Manipulation).WithOne().HasForeignKey<AtlasModel.ManipulationFormBaseObject>(x => x.ManipulationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}