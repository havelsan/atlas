using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubActionPackageProcedureConfig : IEntityTypeConfiguration<AtlasModel.SubActionPackageProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubActionPackageProcedure> builder)
        {
            builder.ToTable("SUBACTIONPACKAGEPROCEDURE");
            builder.HasKey(nameof(AtlasModel.SubActionPackageProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.Aciklama)).HasColumnName("ACIKLAMA").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.RaporTakipNo)).HasColumnName("RAPORTAKIPNO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.Birim)).HasColumnName("BIRIM").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.Sonuc)).HasColumnName("SONUC").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.RefakatciGunSayisi)).HasColumnName("REFAKATCIGUNSAYISI");
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.MedulaEuroScore)).HasColumnName("MEDULAEUROSCORE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.BransRef)).HasColumnName("BRANS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.DoktorRef)).HasColumnName("DOKTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.AnesteziDoktorRef)).HasColumnName("ANESTEZIDOKTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionPackageProcedure.SagSolRef)).HasColumnName("SAGSOL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Doktor).WithOne().HasForeignKey<AtlasModel.SubActionPackageProcedure>(x => x.DoktorRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.SubActionPackageProcedure>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.AnesteziDoktor).WithOne().HasForeignKey<AtlasModel.SubActionPackageProcedure>(x => x.AnesteziDoktorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}