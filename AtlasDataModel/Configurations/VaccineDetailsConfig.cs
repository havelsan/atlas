using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class VaccineDetailsConfig : IEntityTypeConfiguration<AtlasModel.VaccineDetails>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.VaccineDetails> builder)
        {
            builder.ToTable("VACCINEDETAILS");
            builder.HasKey(nameof(AtlasModel.VaccineDetails.ObjectId));
            builder.Property(nameof(AtlasModel.VaccineDetails.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.VaccineDetails.Date)).HasColumnName("DATE");
            builder.Property(nameof(AtlasModel.VaccineDetails.AppointmentDate)).HasColumnName("APPOINTMENTDATE");
            builder.Property(nameof(AtlasModel.VaccineDetails.ApplicationDate)).HasColumnName("APPLICATIONDATE");
            builder.Property(nameof(AtlasModel.VaccineDetails.DisMerkezMi)).HasColumnName("DISMERKEZMI");
            builder.Property(nameof(AtlasModel.VaccineDetails.Notes)).HasColumnName("NOTES").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.VaccineDetails.DisMerkez)).HasColumnName("DISMERKEZ").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.VaccineDetails.VaccineState)).HasColumnName("VACCINESTATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.VaccineDetails.AsiAntiSerumuKarekodu)).HasColumnName("ASIANTISERUMUKAREKODU");
            builder.Property(nameof(AtlasModel.VaccineDetails.AsiKarekodu)).HasColumnName("ASIKAREKODU");
            builder.Property(nameof(AtlasModel.VaccineDetails.AsiSulandiriciKarekodu)).HasColumnName("ASISULANDIRICIKAREKODU");
            builder.Property(nameof(AtlasModel.VaccineDetails.AsininSonKullanmaTarihi)).HasColumnName("ASININSONKULLANMATARIHI");
            builder.Property(nameof(AtlasModel.VaccineDetails.SorguNumarasi)).HasColumnName("SORGUNUMARASI");
            builder.Property(nameof(AtlasModel.VaccineDetails.Barkod)).HasColumnName("BARKOD");
            builder.Property(nameof(AtlasModel.VaccineDetails.SeriNumarasi)).HasColumnName("SERINUMARASI");
            builder.Property(nameof(AtlasModel.VaccineDetails.PartiNumarasi)).HasColumnName("PARTINUMARASI");
            builder.Property(nameof(AtlasModel.VaccineDetails.KirilimBilgisi)).HasColumnName("KIRILIMBILGISI");
            builder.Property(nameof(AtlasModel.VaccineDetails.GeziciHizmetMi)).HasColumnName("GEZICIHIZMETMI");
            builder.Property(nameof(AtlasModel.VaccineDetails.BildirimDurumu)).HasColumnName("BILDIRIMDURUMU");
            builder.Property(nameof(AtlasModel.VaccineDetails.SorguSonucu)).HasColumnName("SORGUSONUCU");
            builder.Property(nameof(AtlasModel.VaccineDetails.VaccinePostponeTime)).HasColumnName("VACCINEPOSTPONETIME");
            builder.Property(nameof(AtlasModel.VaccineDetails.VaccineName)).HasColumnName("VACCINENAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.VaccineDetails.PeriodName)).HasColumnName("PERIODNAME");
            builder.Property(nameof(AtlasModel.VaccineDetails.PeriodRange)).HasColumnName("PERIODRANGE");
            builder.Property(nameof(AtlasModel.VaccineDetails.PeriodUnit)).HasColumnName("PERIODUNIT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.VaccineDetails.IslemYapan)).HasColumnName("ISLEMYAPAN");
            builder.Property(nameof(AtlasModel.VaccineDetails.BilgiAlinanKisiAdiSoyadi)).HasColumnName("BILGIALINANKISIADISOYADI");
            builder.Property(nameof(AtlasModel.VaccineDetails.BilgiAlinanKisiTel)).HasColumnName("BILGIALINANKISITEL");
            builder.Property(nameof(AtlasModel.VaccineDetails.ASIEOrtayaCikisTarihi)).HasColumnName("ASIEORTAYACIKISTARIHI");
            builder.Property(nameof(AtlasModel.VaccineDetails.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsiYapilmamaDurumuRef)).HasColumnName("SKRSASIYAPILMAMADURUMU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsiYapilmamaNedeniRef)).HasColumnName("SKRSASIYAPILMAMANEDENI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSASIISLEMTURURef)).HasColumnName("SKRSASIISLEMTURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSKurumlarRef)).HasColumnName("SKRSKURUMLAR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsiKoduRef)).HasColumnName("SKRSASIKODU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.VaccineFollowUpRef)).HasColumnName("VACCINEFOLLOWUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsininDozuRef)).HasColumnName("SKRSASININDOZU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsininUygulamaSekliRef)).HasColumnName("SKRSASININUYGULAMASEKLI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsininSaglandigiKaynakRef)).HasColumnName("SKRSASININSAGLANDIGIKAYNAK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsiUygulamaYeriRef)).HasColumnName("SKRSASIUYGULAMAYERI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.ResponsibleNurseRef)).HasColumnName("RESPONSIBLENURSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VaccineDetails.SKRSAsiOzelDurumNedeniRef)).HasColumnName("SKRSASIOZELDURUMNEDENI").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.VaccineDetails>(x => x.PatientRef).IsRequired(false);
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.VaccineDetails>(x => x.ResponsibleDoctorRef).IsRequired(false);
            builder.HasOne(t => t.SKRSKurumlar).WithOne().HasForeignKey<AtlasModel.VaccineDetails>(x => x.SKRSKurumlarRef).IsRequired(false);
            builder.HasOne(t => t.SKRSAsiKodu).WithOne().HasForeignKey<AtlasModel.VaccineDetails>(x => x.SKRSAsiKoduRef).IsRequired(false);
            builder.HasOne(t => t.VaccineFollowUp).WithOne().HasForeignKey<AtlasModel.VaccineDetails>(x => x.VaccineFollowUpRef).IsRequired(false);
            builder.HasOne(t => t.ResponsibleNurse).WithOne().HasForeignKey<AtlasModel.VaccineDetails>(x => x.ResponsibleNurseRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}