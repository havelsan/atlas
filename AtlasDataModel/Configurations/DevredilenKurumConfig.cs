using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DevredilenKurumConfig : IEntityTypeConfiguration<AtlasModel.DevredilenKurum>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DevredilenKurum> builder)
        {
            builder.ToTable("DEVREDILENKURUM");
            builder.HasKey(nameof(AtlasModel.DevredilenKurum.ObjectId));
            builder.Property(nameof(AtlasModel.DevredilenKurum.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DevredilenKurum.devredilenKurumAdi_Shadow)).HasColumnName("DEVREDILENKURUMADI_SHADOW");
            builder.Property(nameof(AtlasModel.DevredilenKurum.devredilenKurumAdi)).HasColumnName("DEVREDILENKURUMADI");
            builder.Property(nameof(AtlasModel.DevredilenKurum.devredilenKurumKodu)).HasColumnName("DEVREDILENKURUMKODU");
            builder.HasOne(t => t.BaseMedulaDefinition).WithOne().HasForeignKey<AtlasModel.BaseMedulaDefinition>(p => p.ObjectId);
        }
    }
}