using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DiyabetVeriSetiConfig : IEntityTypeConfiguration<AtlasModel.DiyabetVeriSeti>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DiyabetVeriSeti> builder)
        {
            builder.ToTable("DIYABETVERISETI");
            builder.HasKey(nameof(AtlasModel.DiyabetVeriSeti.ObjectId));
            builder.Property(nameof(AtlasModel.DiyabetVeriSeti.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DiyabetVeriSeti.IlkTaniTarihi)).HasColumnName("ILKTANITARIHI");
            builder.Property(nameof(AtlasModel.DiyabetVeriSeti.Boy)).HasColumnName("BOY");
            builder.Property(nameof(AtlasModel.DiyabetVeriSeti.Kilo)).HasColumnName("KILO").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DiyabetVeriSeti.SKRSDiyabetEgitimiRef)).HasColumnName("SKRSDIYABETEGITIMI").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ENabiz).WithOne().HasForeignKey<AtlasModel.ENabiz>(p => p.ObjectId);
        }
    }
}