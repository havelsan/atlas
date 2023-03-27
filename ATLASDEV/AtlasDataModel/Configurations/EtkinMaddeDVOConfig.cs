using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EtkinMaddeDVOConfig : IEntityTypeConfiguration<AtlasModel.EtkinMaddeDVO>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EtkinMaddeDVO> builder)
        {
            builder.ToTable("ETKINMADDEDVO");
            builder.HasKey(nameof(AtlasModel.EtkinMaddeDVO.ObjectId));
            builder.Property(nameof(AtlasModel.EtkinMaddeDVO.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EtkinMaddeDVO.adetMiktar)).HasColumnName("ADETMIKTAR");
            builder.Property(nameof(AtlasModel.EtkinMaddeDVO.etkinMaddeAdi)).HasColumnName("ETKINMADDEADI");
            builder.Property(nameof(AtlasModel.EtkinMaddeDVO.etkinMaddeKodu)).HasColumnName("ETKINMADDEKODU");
            builder.Property(nameof(AtlasModel.EtkinMaddeDVO.form)).HasColumnName("FORM").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.EtkinMaddeDVO.icerikMiktari)).HasColumnName("ICERIKMIKTARI");
            builder.Property(nameof(AtlasModel.EtkinMaddeDVO.EtkinMaddeOkuCevapDVORef)).HasColumnName("ETKINMADDEOKUCEVAPDVO").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseMedulaObject).WithOne().HasForeignKey<AtlasModel.BaseMedulaObject>(p => p.ObjectId);
        }
    }
}