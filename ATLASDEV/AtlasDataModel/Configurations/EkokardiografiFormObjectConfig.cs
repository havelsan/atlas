using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EkokardiografiFormObjectConfig : IEntityTypeConfiguration<AtlasModel.EkokardiografiFormObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EkokardiografiFormObject> builder)
        {
            builder.ToTable("EKOKARDIOGRAFIFORMOBJECT");
            builder.HasKey(nameof(AtlasModel.EkokardiografiFormObject.ObjectId));
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.KalpHizi)).HasColumnName("KALPHIZI").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.Ritim)).HasColumnName("RITIM").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.LVSegmentHareket)).HasColumnName("LVSEGMENTHAREKET").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.PerikartOzellik)).HasColumnName("PERIKARTOZELLIK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.EkoSonuc)).HasColumnName("EKOSONUC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.Boy)).HasColumnName("BOY").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.EkokardiografiFormObject.Kilo)).HasColumnName("KILO").HasMaxLength(50);
            builder.HasOne(t => t.ManipulationFormBaseObject).WithOne().HasForeignKey<AtlasModel.ManipulationFormBaseObject>(p => p.ObjectId);
        }
    }
}