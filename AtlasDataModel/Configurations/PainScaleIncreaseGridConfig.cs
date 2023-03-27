using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PainScaleIncreaseGridConfig : IEntityTypeConfiguration<AtlasModel.PainScaleIncreaseGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PainScaleIncreaseGrid> builder)
        {
            builder.ToTable("PAINSCALEINCREASEGRID");
            builder.HasKey(nameof(AtlasModel.PainScaleIncreaseGrid.ObjectId));
            builder.Property(nameof(AtlasModel.PainScaleIncreaseGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PainScaleIncreaseGrid.NursingPainScaleRef)).HasColumnName("NURSINGPAINSCALE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PainScaleIncreaseGrid.PainChangingSituationRef)).HasColumnName("PAINCHANGINGSITUATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingPainScale).WithOne().HasForeignKey<AtlasModel.PainScaleIncreaseGrid>(x => x.NursingPainScaleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}