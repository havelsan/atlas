using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class KronikHastaliklarVeriSetiConfig : IEntityTypeConfiguration<AtlasModel.KronikHastaliklarVeriSeti>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.KronikHastaliklarVeriSeti> builder)
        {
            builder.ToTable("KRONIKHASTALIKLARVERISETI");
            builder.HasKey(nameof(AtlasModel.KronikHastaliklarVeriSeti.ObjectId));
            builder.Property(nameof(AtlasModel.KronikHastaliklarVeriSeti.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.KronikHastaliklarVeriSeti.IlkTaniTarihi)).HasColumnName("ILKTANITARIHI");
            builder.Property(nameof(AtlasModel.KronikHastaliklarVeriSeti.PaketeAitIslemZamani)).HasColumnName("PAKETEAITISLEMZAMANI");
            builder.Property(nameof(AtlasModel.KronikHastaliklarVeriSeti.SKRSSpirometriRef)).HasColumnName("SKRSSPIROMETRI").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ENabiz).WithOne().HasForeignKey<AtlasModel.ENabiz>(p => p.ObjectId);
        }
    }
}