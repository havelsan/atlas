using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChemotherapyRadiotherapyConfig : IEntityTypeConfiguration<AtlasModel.ChemotherapyRadiotherapy>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChemotherapyRadiotherapy> builder)
        {
            builder.ToTable("CHEMOTHERAPYRADIOTHERAPY");
            builder.HasKey(nameof(AtlasModel.ChemotherapyRadiotherapy.ObjectId));
            builder.Property(nameof(AtlasModel.ChemotherapyRadiotherapy.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChemotherapyRadiotherapy.CureStartDate)).HasColumnName("CURESTARTDATE");
            builder.Property(nameof(AtlasModel.ChemotherapyRadiotherapy.Description)).HasColumnName("DESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}