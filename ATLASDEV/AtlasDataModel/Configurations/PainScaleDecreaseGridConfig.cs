using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PainScaleDecreaseGridConfig : IEntityTypeConfiguration<AtlasModel.PainScaleDecreaseGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PainScaleDecreaseGrid> builder)
        {
            builder.ToTable("PAINSCALEDECREASEGRID");
            builder.HasKey(nameof(AtlasModel.PainScaleDecreaseGrid.ObjectId));
            builder.Property(nameof(AtlasModel.PainScaleDecreaseGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PainScaleDecreaseGrid.NursingPainScaleRef)).HasColumnName("NURSINGPAINSCALE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PainScaleDecreaseGrid.PainChangingSituationRef)).HasColumnName("PAINCHANGINGSITUATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingPainScale).WithOne().HasForeignKey<AtlasModel.PainScaleDecreaseGrid>(x => x.NursingPainScaleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}