using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WoundSideInfoConfig : IEntityTypeConfiguration<AtlasModel.WoundSideInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.WoundSideInfo> builder)
        {
            builder.ToTable("WOUNDSIDEINFO");
            builder.HasKey(nameof(AtlasModel.WoundSideInfo.ObjectId));
            builder.Property(nameof(AtlasModel.WoundSideInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.WoundSideInfo.SideInfo)).HasColumnName("SIDEINFO");
            builder.Property(nameof(AtlasModel.WoundSideInfo.SideInfo_Shadow)).HasColumnName("SIDEINFO_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}