using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSICDOMORFOLOJIKODUConfig : IEntityTypeConfiguration<AtlasModel.SKRSICDOMORFOLOJIKODU>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSICDOMORFOLOJIKODU> builder)
        {
            builder.ToTable("SKRSICDOMORFOLOJIKODU");
            builder.HasKey(nameof(AtlasModel.SKRSICDOMORFOLOJIKODU.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSICDOMORFOLOJIKODU.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSICDOMORFOLOJIKODU.MORFOLOJIKOD)).HasColumnName("MORFOLOJIKOD").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDOMORFOLOJIKODU.MORFOLOJIKODTANIM)).HasColumnName("MORFOLOJIKODTANIM").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDOMORFOLOJIKODU.MORFOLOJIKODACIKLAMA)).HasColumnName("MORFOLOJIKODACIKLAMA").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDOMORFOLOJIKODU.Morfoloji_Shadow)).HasColumnName("MORFOLOJI_SHADOW");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}