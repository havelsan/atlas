using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MKYS_ServisDepoConfig : IEntityTypeConfiguration<AtlasModel.MKYS_ServisDepo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MKYS_ServisDepo> builder)
        {
            builder.ToTable("MKYS_SERVISDEPO");
            builder.HasKey(nameof(AtlasModel.MKYS_ServisDepo.ObjectId));
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.bagliBirimID)).HasColumnName("BAGLIBIRIMID");
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.birimAdi)).HasColumnName("BIRIMADI");
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.birimKayitNo)).HasColumnName("BIRIMKAYITNO");
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.birimKisaAdi)).HasColumnName("BIRIMKISAADI");
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.birimKodu)).HasColumnName("BIRIMKODU");
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.faaliyetDurumu)).HasColumnName("FAALIYETDURUMU");
            builder.Property(nameof(AtlasModel.MKYS_ServisDepo.tur)).HasColumnName("TUR");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}