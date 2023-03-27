using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WoundLocalizationDefConfig : IEntityTypeConfiguration<AtlasModel.WoundLocalizationDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.WoundLocalizationDef> builder)
        {
            builder.ToTable("WOUNDLOCALIZATIONDEF");
            builder.HasKey(nameof(AtlasModel.WoundLocalizationDef.ObjectId));
            builder.Property(nameof(AtlasModel.WoundLocalizationDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.WoundLocalizationDef.Localization)).HasColumnName("LOCALIZATION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.WoundLocalizationDef.Localization_Shadow)).HasColumnName("LOCALIZATION_SHADOW").HasColumnType("VARCHAR2(4000)");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}