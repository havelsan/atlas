using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MKYSKodConfig : IEntityTypeConfiguration<AtlasModel.MKYSKod>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MKYSKod> builder)
        {
            builder.ToTable("MKYSKOD");
            builder.HasKey(nameof(AtlasModel.MKYSKod.ObjectId));
            builder.Property(nameof(AtlasModel.MKYSKod.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MKYSKod.KodAdi)).HasColumnName("KODADI").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MKYSKod.Degeri)).HasColumnName("DEGERI").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.MKYSKod.Aciklama)).HasColumnName("ACIKLAMA").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MKYSKod.EnumNo)).HasColumnName("ENUMNO");
            builder.Property(nameof(AtlasModel.MKYSKod.Aktif)).HasColumnName("AKTIF");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}