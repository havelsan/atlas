using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingInitiativeConfig : IEntityTypeConfiguration<AtlasModel.NursingInitiative>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingInitiative> builder)
        {
            builder.ToTable("NURSINGINITIATIVES");
            builder.HasKey(nameof(AtlasModel.NursingInitiative.ObjectId));
            builder.Property(nameof(AtlasModel.NursingInitiative.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingInitiative.NursingPainScaleRef)).HasColumnName("NURSINGPAINSCALE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingPainScale).WithOne().HasForeignKey<AtlasModel.NursingInitiative>(x => x.NursingPainScaleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}