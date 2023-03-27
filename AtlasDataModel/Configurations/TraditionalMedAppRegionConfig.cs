using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TraditionalMedAppRegionConfig : IEntityTypeConfiguration<AtlasModel.TraditionalMedAppRegion>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TraditionalMedAppRegion> builder)
        {
            builder.ToTable("TRADITIONALMEDAPPREGION");
            builder.HasKey(nameof(AtlasModel.TraditionalMedAppRegion.ObjectId));
            builder.Property(nameof(AtlasModel.TraditionalMedAppRegion.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TraditionalMedAppRegion.SKRSGetatApplicationRegionRef)).HasColumnName("SKRSGETATAPPLICATIONREGION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TraditionalMedAppRegion.TraditionalMedicineRef)).HasColumnName("TRADITIONALMEDICINE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.TraditionalMedicine).WithOne().HasForeignKey<AtlasModel.TraditionalMedAppRegion>(x => x.TraditionalMedicineRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}