using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WoundStageDefConfig : IEntityTypeConfiguration<AtlasModel.WoundStageDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.WoundStageDef> builder)
        {
            builder.ToTable("WOUNDSTAGEDEF");
            builder.HasKey(nameof(AtlasModel.WoundStageDef.ObjectId));
            builder.Property(nameof(AtlasModel.WoundStageDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.WoundStageDef.Name)).HasColumnName("NAME").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.WoundStageDef.IsDepthNeeded)).HasColumnName("ISDEPTHNEEDED");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}