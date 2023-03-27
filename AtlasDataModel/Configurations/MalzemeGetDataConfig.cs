using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MalzemeGetDataConfig : IEntityTypeConfiguration<AtlasModel.MalzemeGetData>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MalzemeGetData> builder)
        {
            builder.ToTable("MALZEMEGETDATA");
            builder.HasKey(nameof(AtlasModel.MalzemeGetData.ObjectId));
            builder.Property(nameof(AtlasModel.MalzemeGetData.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MalzemeGetData.malzemeKayitID)).HasColumnName("MALZEMEKAYITID");
            builder.Property(nameof(AtlasModel.MalzemeGetData.malzemeKodu)).HasColumnName("MALZEMEKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.MalzemeGetData.malzemeAdi)).HasColumnName("MALZEMEADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.MalzemeGetData.degisiklikTarihi)).HasColumnName("DEGISIKLIKTARIHI");
            builder.Property(nameof(AtlasModel.MalzemeGetData.olcuBirimiID)).HasColumnName("OLCUBIRIMIID").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.MalzemeGetData.malzemeTurID)).HasColumnName("MALZEMETURID").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.MalzemeGetData.eskiMalzemeKodu)).HasColumnName("ESKIMALZEMEKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.MalzemeGetData.aktif)).HasColumnName("AKTIF");
            builder.Property(nameof(AtlasModel.MalzemeGetData.gunlemeTarihi)).HasColumnName("GUNLEMETARIHI");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}