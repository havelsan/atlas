//$55476210
using Infrastructure.Filters;
using System;
using System.Collections.Generic;

using System.Linq;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class MenuDefinitionServiceController : Controller
    {
        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MenuServiceDefinitionModel GetHorizontalMenuRoles()
        {
            MenuServiceDefinitionModel model = new MenuServiceDefinitionModel();
            #region Fatura Menüler
            model.donemIslemleri = TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Donem_Islemleri) || TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Saymanlik_Islemleri);
            model.icmalIslemleri = TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Icmal_Islemleri);
            model.tahsilatIslemleri = TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Tahsilat_Islemleri);
            model.venzeIslemleri = TTUser.CurrentUser.HasRole(TTRoleNames.Vezne_Islemleri) || TTUser.CurrentUser.HasRole(TTRoleNames.Senet_Islemleri);
            model.faturaIslemleri = TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Islemleri);
            model.faturaAllinOne = Convert.ToBoolean(SystemParameter.GetParameterValue("SHOWINVOICEALLINONE", "FALSE"));
            model.tigModule = TTUser.CurrentUser.HasRole(TTRoleNames.Tig_Islemleri); //?
            model.faturaAnaMenu = model.donemIslemleri || model.icmalIslemleri || model.tahsilatIslemleri || model.venzeIslemleri || model.faturaIslemleri || model.tigModule;
            #endregion Fatura Menüler
            #region Döküman Yönetimi Menüler

            model.dokumanYonetimi = TTUser.CurrentUser.HasRole(TTRoleNames.Dokuman_Indirme);

            #endregion Döküman Yönetimi Menüler
            #region Mazleme Yönetimi Menüler

            model.malzemeYonetimi = TTUser.CurrentUser.HasRole(TTRoleNames.Stok_Is_Listesi);

            #endregion Mazleme Yönetimi Menüler
            #region ORTEZ PROTEZ
            model.ortezIstek = TTUser.CurrentUser.HasRole(TTRoleNames.Ortez_Protez_Istek_RUW);
            #endregion

            #region DİYET
            model.diyetListe = TTUser.CurrentUser.HasRole(TTRoleNames.Diyet_Uzmani);
            #endregion

            #region TELETIP
            model.teletipListe = TTUser.CurrentUser.HasRole(TTRoleNames.Radyoloji_Sekreteri);
            #endregion

            #region Hemşirelik hizmetleri
            model.nursing = TTUser.CurrentUser.HasRole(TTRoleNames.Hemsire);
            model.drugCorrection = TTUser.CurrentUser.HasRole(TTRoleNames.Hemsire);
            #endregion

            #region LaboratuvarIsListesi
            model.laboratuvarNumuneAlmaIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Laboratuvar_Numune_Alma) || TTUser.CurrentUser.HasRole(TTRoleNames.Laboratuvar_Istek_Kabul) || TTUser.CurrentUser.HasRole(TTRoleNames.Laboratuvar_Isleme_Al);
            model.laboratuvarProsedurIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Laboratuvar_Is_Listesi_Genel_Listeleme);
            model.laboratuvarIsListesi = model.laboratuvarNumuneAlmaIsListesi || model.laboratuvarProsedurIsListesi;
            #endregion LaboratuvarIsListesi

            #region Hasta Dosyası 
            model.showPatientFolderShow = TTUser.CurrentUser.IsSuperUser ? true : false;
            #endregion

            #region ORTEZ PROTEZ İŞ LİSTESİ
            model.ortezListele = TTUser.CurrentUser.HasRole(TTRoleNames.Ortez_Protez_Is_Listesi);
            #endregion

            #region Poliklinik Ayaktan İş listesi
            model.ayaktanHastaIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Ayaktan_Hasta_Listesi);
            #endregion

            #region Sağlık Kurulu İş listesi
            model.saglikKuruluIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Saglik_Kurulu_Veri_Hazirlama_Memuru) || TTUser.CurrentUser.HasRole(TTRoleNames.Saglik_Kurulu_Memuru) ||
                 TTUser.CurrentUser.HasRole(TTRoleNames.Saglik_Kurulu_Kisim_Amiri) || TTUser.CurrentUser.HasRole(TTRoleNames.Saglik_Kurulu_Tamamlanan_Islem_Geri_Alma) || TTUser.CurrentUser.HasRole(TTRoleNames.Saglik_Kurulu_Islem_Geri_Alma) ||
                 TTUser.CurrentUser.HasRole(TTRoleNames.Bastabip) || TTUser.CurrentUser.HasRole(TTRoleNames.Bastabip_Yardimcisi);
            #endregion
            #region Yeni Hasta Kayıt
            model.yeniHastaKayitListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Hasta_Modul);
            #endregion

            #region İş listesi
            model.isListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Is_Listesi_Modulu);
            #endregion

            #region Yatan Hasta Modülü
            model.yatanIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Yatan_Hasta_Modulu);
            #endregion

            #region FTR İş Listesi
            model.ftrIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.FTR_Is_Listesi_Modulu);
            #endregion

            #region Sosyal Hizmetler İş Listesi
            model.sosyalHizmetlerIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Sosyal_Hizmetler_Is_Listesi);
            #endregion

            #region Radyoloji Modülü
            model.radyolojiListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Radyoloji_Modulu);
            #endregion

            #region Nükleer Tıp Modülü
            model.nukleertipListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Nukleer_Tip_Modulu);
            #endregion

            #region Hemşirelik Modülü
            model.hemsirelikHizmetleri = TTUser.CurrentUser.HasRole(TTRoleNames.Hemsirelik_Modulu);
            #endregion

            #region Hemşire Bilgilendirme / Hasta İlaç Doğrulama
            model.hastaIlacDogrulama = TTUser.CurrentUser.HasRole(TTRoleNames.Hasta_Ilac_Dogrulama_Modulu);
            #endregion

            #region MHRS Yönetim
            model.mhrsYonetim = TTUser.CurrentUser.HasRole(TTRoleNames.MHRS_Yonetim_Modulu);
            #endregion

            #region Randevu Verme
            model.randevuVerme = TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Verme_Modulu);
            #endregion

            #region Randevu Planlama
            model.randevuPlanlama = TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Planlama_Modulu);
            #endregion

            #region Hasta Geçmişi
            model.hastaGecmisiListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Hasta_Gecmisi_Arama_Modulu);
            #endregion

            #region Personel
            model.personelIntegration = TTUser.CurrentUser.HasRole(TTRoleNames.Personel_Modulu);
            #endregion

            #region Cihaz Arıza Bildirim
            model.cihazArizaBildirimi = TTUser.CurrentUser.HasRole(TTRoleNames.Cihaz_Ariza_Bildirimi_Modulu);
            #endregion

            #region Vademecum Online
            model.vademecumOnline = TTUser.CurrentUser.HasRole(TTRoleNames.Vademecum_Online_Modulu);
            #endregion
            #region Order Saat Tanımı
            model.hospitalTimeSchedule = TTUser.CurrentUser.IsSuperUser;
            #endregion
            #region İstatistik
            model.istatistik = TTUser.CurrentUser.HasRole(TTRoleNames.Istatistik_Modulu);
            #endregion



            model.coloredPrescriptionApprove = TTUser.CurrentUser.HasRole(TTRoleNames.ReceteOnay_Bashekim) ? true : false;

            #region Yeni Doktor Performans
            model.yeniDoktorPerformans = TTUser.CurrentUser.HasRole(TTRoleNames.DP_Yeni_Modul);
            #endregion



            //  #region DİĞER
            #region Kullanıcı Tanımları Menüler
            model.kullaniciTanimlari = TTObjectClasses.SystemParameter.GetParameterValue("ShowKullaniciTanimlari", "TRUE") == "TRUE" ? true : false;
            #endregion Kullanıcı Tanımları Menüler

            #region Hizmet Tanımları Menüler
            //model.hizmetTanimlari = TTObjectClasses.SystemParameter.GetParameterValue("ShowHizmetTanimlari", "TRUE") == "TRUE" ? true : false;
            model.hizmetTanimlari = TTUser.CurrentUser.HasRole(TTRoleNames.ATLAS_Hizmet_Tanimlama) ? true : false;
            #endregion Hizmet Tanımları Menüler

            #region Danışma
            model.danismaListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Danisma_Modulu);
            #endregion
            #region Arşiv iş Listesi
            model.arsivIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Arsiv_Is_Listesi_Modulu);
            #endregion
            #region Tıbbi / Tehlikeli Atık
            model.tibbiatik = TTUser.CurrentUser.HasRole(TTRoleNames.Tibbi_Atik_Modulu);
            #endregion
            #region Mesajlaşma
            model.mesajlasmaListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Mesajlasma_Modulu);
            #endregion
            #region Log Sorgulama
            model.logSorgulamaListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Log_Sorgulama_Modulu);
            #endregion
            #region Genel Lcd Ekranı
            model.genelLCDEkrani = TTUser.CurrentUser.HasRole(TTRoleNames.Genel_LCD_Ekrani_Modulu);
            #endregion
            #region Raporlar
            model.raporlarListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Raporlar_Modulu);
            #endregion
            #region Sterilizasyon İstek
            model.sterilizasyonIstek = TTUser.CurrentUser.HasRole(TTRoleNames.Sterilizasyon_Istek_Modulu);
            #endregion
            #region Sterilizasyon Modülü
            model.sterilizasyonModulu = TTUser.CurrentUser.HasRole(TTRoleNames.Sterilizasyon_Modulu);
            #endregion
            #region Nabız
            model.nabizGoruntule = TTUser.CurrentUser.HasRole(TTRoleNames.Nabiz_Goruntuleme) ? true : false;
            #endregion
            #region Reçete Istatistik
            model.receteIstatistikGoruntule = TTUser.CurrentUser.HasRole(TTRoleNames.Recete_Istatistik_Ekrani) ? true : false;
            #endregion

            #region Tıbbi Araştırma
            model.medicalResach = TTUser.CurrentUser.IsSuperUser ? true : false;
            #endregion
            model.surgeryAppointment = (TTUser.CurrentUser.HasRole(TTRoleNames.Ameliyat_Randevu_Modulu) ? true : false);
            model.kiosk = TTUser.CurrentUser.IsSuperUser ? true : (TTUser.CurrentUser.HasRole(TTRoleNames.AnketTanimlama) ? true : false);

            #region Kemoterapi Radyoterapi İş Listesi
            model.chemoRadioIsListesi = TTUser.CurrentUser.HasRole(TTRoleNames.Kemoterapi_ve_Radyoterapi_Modulu) ? true : false;
            model.tescilliYatakEslestirme = TTUser.CurrentUser.HasRole(TTRoleNames.Medula_Yatak_Eslestirme) ? true : false;
            #endregion
            model.SMSModule = TTUser.CurrentUser.IsSuperUser ? true : false;
            #region Çamaşırhane ve temizlik
            model.laundryModule = TTUser.CurrentUser.HasRole(TTRoleNames.LaundryAndCleaningModule);
            #endregion

            #region Arşiv Tanımları
            model.archiveDefinition = TTUser.CurrentUser.HasRole(TTRoleNames.Arsiv_Is_Listesi_Modulu);
            #endregion
            return model;
        }
    }

    public class MenuServiceDefinitionModel
    {

        #region FİNANSAL MODÜLLER
        public bool donemIslemleri;
        public bool icmalIslemleri;
        public bool tahsilatIslemleri;
        public bool venzeIslemleri;
        public bool faturaIslemleri;
        public bool faturaAllinOne;
        public bool faturaAnaMenu;
        public bool tigModule;
        #endregion FİNANSAL MODÜLLER
        #region Döküman Yönetimi Menüler
        public bool dokumanYonetimi;
        #endregion Döküman Yönetimi Menüler
        #region Malzeme Yönetimi Menüler
        public bool malzemeYonetimi;
        #endregion Malzeme Yönetimi Menüler

        #region ORTEZ PROTEZ
        public bool ortezIstek;
        #endregion

        #region DİYET
        public bool diyetListe;
        #endregion

        #region TELETIP
        public bool teletipListe;
        #endregion


        #region HEMŞİRELİK
        public bool nursing;
        public bool drugCorrection;
        #endregion

        #region TIBBİ MODÜLLER

        #region LaboratuvarIsListesi
        public bool laboratuvarNumuneAlmaIsListesi { get; set; }
        public bool laboratuvarProsedurIsListesi { get; set; }
        public bool laboratuvarIsListesi { get; set; }
        #endregion LaboratuvarIsListesi


        #region Hasta dosyası 
        public bool showPatientFolderShow { get; set; }
        #endregion


        #region ORTEZ PROTEZ İŞ LİSTESİ
        public bool ortezListele;
        #endregion

        #region Poliklinik Ayaktan İş listesi
        public bool ayaktanHastaIsListesi;
        #endregion

        #region Sağlık Kurulu İş listesi
        public bool saglikKuruluIsListesi;
        #endregion

        #region Order Saat Tanımı
        public bool hospitalTimeSchedule { get; set; }
        #endregion

        #region Yeni Hasta Kayıt
        public bool yeniHastaKayitListesi;
        #endregion

        #region İş Listesi
        public bool isListesi;
        #endregion

        #region Yatan Hasta Modülü
        public bool yatanIsListesi;
        #endregion

        #region FTR İş Listesi
        public bool ftrIsListesi;
        #endregion

        #region Sosyal Hizmetler İş Listesi
        public bool sosyalHizmetlerIsListesi;
        #endregion

        #region Radyoloji Modülü
        public bool radyolojiListesi;
        #endregion

        #region Nükleer Tıp Modülü
        public bool nukleertipListesi;
        #endregion

        #region Hemşirelik Modülü
        public bool hemsirelikHizmetleri;
        #endregion

        #region Hemşire Bilgilendirme / Hasta İlaç Doğrulama
        public bool hastaIlacDogrulama;
        #endregion

        #region MHRS Yönetim
        public bool mhrsYonetim;
        #endregion

        #region Randevu Verme
        public bool randevuVerme;
        #endregion

        #region Randevu Planlama
        public bool randevuPlanlama;
        #endregion

        #region Hasta Geçmişi
        public bool hastaGecmisiListesi;
        #endregion


        #endregion

        #region İDARİ MODÜLLER
        #region Personel
        public bool personelIntegration;
        #endregion

        #region Cihaz Arıza Bildirimi
        public bool cihazArizaBildirimi;
        #endregion




        #region Vademecum Online
        public bool vademecumOnline;
        #endregion

        #region İstatistik
        public bool istatistik;
        #endregion



        public bool coloredPrescriptionApprove;
        #endregion

        #region DİĞER

        #region Danışma
        public bool danismaListesi;
        #endregion

        #region Arşiv İş Listesi
        public bool arsivIsListesi;
        #endregion

        #region Tıbbi / Tehlikeli Atık
        public bool tibbiatik;
        #endregion

        #region Mesajlaşma
        public bool mesajlasmaListesi;
        #endregion

        #region Log Sorgulama
        public bool logSorgulamaListesi;
        #endregion

        #region Genel LCD Ekranı
        public bool genelLCDEkrani;
        #endregion

        #region Raporlar
        public bool raporlarListesi;
        #endregion

        #region Sterilizasyon İstek
        public bool sterilizasyonIstek;
        #endregion

        #region Poliklinik Ayaktan İş listesi
        public bool yeniDoktorPerformans;
        #endregion
        #region Sterilizasyon Modülü
        public bool sterilizasyonModulu;
        #endregion
        #region Çamaşırhane ve temizlik
        public bool laundryModule;
        #endregion

        #region Arşiv Tanımları
        public bool archiveDefinition;
        #endregion

        #endregion
        #region Kullanıcı Tanımları Menüler
        public bool kullaniciTanimlari;
        #endregion  Kullanıcı Tanımları Menüler

        #region Hizmet Tanımları Menüler
        public bool hizmetTanimlari;
        #endregion  Hizmet Tanımları Menüler

        public bool SMSModule { get; set; }
        public bool nabizGoruntule;
        public bool receteIstatistikGoruntule;
        public bool chemoRadioIsListesi;
        public bool medicalResach;
        public bool tescilliYatakEslestirme;
        public bool surgeryAppointment;
        public bool kiosk;
    }
}
