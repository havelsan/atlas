using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EtkinMaddeConfig : IEntityTypeConfiguration<AtlasModel.EtkinMadde>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EtkinMadde> builder)
        {
            builder.ToTable("ETKINMADDE");
            builder.HasKey(nameof(AtlasModel.EtkinMadde.ObjectId));
            builder.Property(nameof(AtlasModel.EtkinMadde.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EtkinMadde.etkinMaddeLatinceAdi)).HasColumnName("ETKINMADDELATINCEADI");
            builder.Property(nameof(AtlasModel.EtkinMadde.adetMiktar)).HasColumnName("ADETMIKTAR");
            builder.Property(nameof(AtlasModel.EtkinMadde.etkinMaddeAdi)).HasColumnName("ETKINMADDEADI");
            builder.Property(nameof(AtlasModel.EtkinMadde.etkinMaddeAdi_Shadow)).HasColumnName("ETKINMADDEADI_SHADOW");
            builder.Property(nameof(AtlasModel.EtkinMadde.etkinMaddeKodu)).HasColumnName("ETKINMADDEKODU");
            builder.Property(nameof(AtlasModel.EtkinMadde.form)).HasColumnName("FORM");
            builder.Property(nameof(AtlasModel.EtkinMadde.icerikMiktari)).HasColumnName("ICERIKMIKTARI");
            builder.Property(nameof(AtlasModel.EtkinMadde.hastaGvnlikveIzlemFrmGerek)).HasColumnName("HASTAGVNLIKVEIZLEMFRMGEREK");
            builder.Property(nameof(AtlasModel.EtkinMadde.baslangicTarihi)).HasColumnName("BASLANGICTARIHI");
            builder.Property(nameof(AtlasModel.EtkinMadde.bitisTarihi)).HasColumnName("BITISTARIHI");
            builder.Property(nameof(AtlasModel.EtkinMadde.SUTList)).HasColumnName("SUTLIST").HasColumnType("VARCHAR2(4000)");
            builder.HasOne(t => t.BaseMedulaDefinition).WithOne().HasForeignKey<AtlasModel.BaseMedulaDefinition>(p => p.ObjectId);
        }
    }
}