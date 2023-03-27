using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MKYSMalzemeSiniflandirmaConfig : IEntityTypeConfiguration<AtlasModel.MKYSMalzemeSiniflandirma>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MKYSMalzemeSiniflandirma> builder)
        {
            builder.ToTable("MKYSMALZEMESINIFLANDIRMA");
            builder.HasKey(nameof(AtlasModel.MKYSMalzemeSiniflandirma.ObjectId));
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.MalzemeKayitID)).HasColumnName("MALZEMEKAYITID");
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.MalzemeKodu)).HasColumnName("MALZEMEKODU");
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.MalzemeAdi)).HasColumnName("MALZEMEADI").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.DegisiklikTarihi)).HasColumnName("DEGISIKLIKTARIHI");
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.TibbiSarfKlinikBransi)).HasColumnName("TIBBISARFKLINIKBRANSI");
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.TibbiSarfKullanimYeri)).HasColumnName("TIBBISARFKULLANIMYERI");
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.TibbiSarfKullanimAmaci)).HasColumnName("TIBBISARFKULLANIMAMACI").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.TibbiSarfMalzemeCinsi)).HasColumnName("TIBBISARFMALZEMECINSI").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.TibbiSarfSutKodu)).HasColumnName("TIBBISARFSUTKODU").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.LaboratuvarBransi)).HasColumnName("LABORATUVARBRANSI").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.LaboratuvarCinsi)).HasColumnName("LABORATUVARCINSI").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.LaboratuvarSutKodu)).HasColumnName("LABORATUVARSUTKODU").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.CerrahiAletBransi)).HasColumnName("CERRAHIALETBRANSI").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.CerrahiAletCinsi)).HasColumnName("CERRAHIALETCINSI").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.CerrahiAletSutKodu)).HasColumnName("CERRAHIALETSUTKODU").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BiyomedikalCihazTur)).HasColumnName("BIYOMEDIKALCIHAZTUR").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BiyomedikalCihazTanim)).HasColumnName("BIYOMEDIKALCIHAZTANIM").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BiyomedikalSarfTur)).HasColumnName("BIYOMEDIKALSARFTUR").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BiyomedikalSarfTanim)).HasColumnName("BIYOMEDIKALSARFTANIM").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BiyomedikalSarfCins)).HasColumnName("BIYOMEDIKALSARFCINS").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BiyomedikalSarfNitelik)).HasColumnName("BIYOMEDIKALSARFNITELIK").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BiyomedikalSarfSutKodu)).HasColumnName("BIYOMEDIKALSARFSUTKODU").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.IlacBarkod)).HasColumnName("ILACBARKOD").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.IlacAdi)).HasColumnName("ILACADI").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.IlacJenerikKodu)).HasColumnName("ILACJENERIKKODU").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.IlacJenerikAdi)).HasColumnName("ILACJENERIKADI").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.Pasif)).HasColumnName("PASIF");
            builder.Property(nameof(AtlasModel.MKYSMalzemeSiniflandirma.BarkodDogrulamaDurumu)).HasColumnName("BARKODDOGRULAMADURUMU");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}