using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OzelDurumConfig : IEntityTypeConfiguration<AtlasModel.OzelDurum>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OzelDurum> builder)
        {
            builder.ToTable("OZELDURUM");
            builder.HasKey(nameof(AtlasModel.OzelDurum.ObjectId));
            builder.Property(nameof(AtlasModel.OzelDurum.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OzelDurum.ozelDurumAdi)).HasColumnName("OZELDURUMADI");
            builder.Property(nameof(AtlasModel.OzelDurum.ozelDurumAdi_Shadow)).HasColumnName("OZELDURUMADI_SHADOW");
            builder.Property(nameof(AtlasModel.OzelDurum.ozelDurumKodu)).HasColumnName("OZELDURUMKODU");
            builder.HasOne(t => t.BaseMedulaDefinition).WithOne().HasForeignKey<AtlasModel.BaseMedulaDefinition>(p => p.ObjectId);
        }
    }
}