import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AtlasAuthGuardService } from 'Fw/Services/AtlasAuthGuardService';
import { AtlasCanDeactivateGuard } from 'Fw/Services/AtlasCanDeactivateGuard';

const appRoutes: Routes = [
    { path: '', redirectTo: '/acilis', pathMatch: 'full' },
    { path: 'giris', loadChildren: 'AppModules/System/LoginModule#LoginModule' },
    { path: 'sifredegistir', loadChildren: 'AppModules/System/LoginModule#LoginModule' },
    { path: 'acilis', loadChildren: 'AppModules/System/SystemModule#SystemModule' },
    { path: 'hasta', loadChildren: 'Modules/Tibbi_Surec/Kayit_Kabul_Modulu/KayitKabulModule#KayitKabulModule', canActivate: [AtlasAuthGuardService] },
    { path: 'danisma', loadChildren: 'Modules/Tibbi_Surec/Danisma_Modulu/DanismaModule#DanismaModule', canActivate: [AtlasAuthGuardService] },
    { path: 'fizyoterapi', loadChildren: 'Modules/Tibbi_Surec/Fizyoterapi_Is_Listesi/PhysiotherapyWorkListModule#PhysiotherapyWorkListModule', canActivate: [AtlasAuthGuardService] },
    {
        path: 'personnelintegration',
        loadChildren: 'Modules/Tibbi_Surec/Personel_Entegrasyon_Modulu/PersonelEntegrasyonModule#PersonelEntegrasyonModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'XXXXXXehipintegration',
        loadChildren: 'Modules/ExternalWebServices/XXXXXX_EHIP_Module/XXXXXXEHIPModuleModule#XXXXXXEHIPModuleModule',
        canActivate: [AtlasAuthGuardService]
    },
    { path: 'aciltriaj', loadChildren: 'Modules/Tibbi_Surec/Acil_Modulu/AcilModule#AcilModule', canActivate: [AtlasAuthGuardService] },
    { path: 'ameliyat', loadChildren: 'Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule#AmeliyatModule', canActivate: [AtlasAuthGuardService] },
    {
        path: 'islistesi',
        loadChildren: 'Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListModule#EpisodeActionWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },

    {
        path: 'yatanislistesi',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Yatan_Hasta_Is_Listesi/InPatientWorkListModule#InPatientWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'ameliyatveanestezi',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Ameliyat_Hasta_Is_Listesi/SurgeryWorkListModule#SurgeryWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'patolojiislistesi',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Patoloji_Is_Listesi/PathologyWorkListModule#PathologyWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'ayaktanislistesi',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Ayaktan_Hasta_Is_Listesi/ExaminationWorkListModule#ExaminationWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'kullaniciTanimlari',
        loadChildren: 'Modules/Core_Destek_Modulleri/Resource_User_Modulleri/ResourceUserModule#ResourceUserModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'hizmetTanimlari',
        loadChildren: 'Modules/Merkezi_Yonetim_Sistemi/Tibbi_Surec_Tanim/Hizmet_Tanimlama_Modulu/HizmetTanimlamaModule#HizmetTanimlamaModule',
        canActivate: [AtlasAuthGuardService]
    },

    { path: 'diyet', loadChildren: 'Modules/Tibbi_Surec/Diyet_Modulu/DiyetModule#DiyetModule', canActivate: [AtlasAuthGuardService] },
    {
        path: 'ortezProtez',
        loadChildren: 'Modules/Tibbi_Surec/Ortez_Protez_Modulu/Ortez_Protez_Is_Listesi/OrtezProtezIsModule#OrtezProtezIsModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'sosyalHizmetIsListesi',
        loadChildren: 'Modules/Tibbi_Surec/Sosyal_Hizmetler_Modulu/Sosyal_Hizmetler_Is_Listesi/SosyalHizmetlerWorkListModule#SosyalHizmetlerWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'fiziktedavi',
        loadChildren: 'Modules/Tibbi_Surec/Fizyoterapi_Is_Listesi/PhysiotherapyWorkListModule#PhysiotherapyWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'kemoterapiradyoterapi',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Kemoterapi_Radyoterapi_Is_Listesi/ChemoRadiotherapyWorkListModule#ChemoRadiotherapyWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'hemodiyaliz',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Hemodiyaliz_Is_Listesi/HemodialysisWorkListModule#HemodialysisWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'hemodiyalizRandevu',
        loadChildren: 'Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodiyalizModule#HemodiyalizModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'radyoloji',
        loadChildren: 'Modules/Tibbi_Surec/Radyoloji_Is_Listesi/RadiologyWorkListModule#RadiologyWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'nukleertip',
        loadChildren: 'Modules/Tibbi_Surec/Nukleer_Tip_Is_Listesi/NuclearMedicineWorkListModule#NuclearMedicineWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'hastacagri',
        loadChildren: 'Modules/Tibbi_Surec/Hasta_Cagri_Modulu/HastaCagriModule#HastaCagriModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'laboratuvar',
        loadChildren: 'Modules/Tibbi_Surec/Laboratuar_Is_Listesi/LaboratoryWorkListModule#LaboratoryWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'malzemeyonetimi', loadChildren: 'AppModules/Logistic/LogisticFormsModule#LogisticFormsModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'document', loadChildren: 'AppModules/DocumentDefinition/DocumentDefinitionFormsModule#DocumentDefinitionFormsModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'hemsirelikhizmetleri',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Hemsirelik_Modulu_Is_Listesi/NursingModuleWorkListModule#NursingModuleWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'saglikkurulukabul',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Saglik_Kurulu_Is_Listesi/HealthCommitteeWorkListModule#HealthCommitteeWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'ehuislistesi',
        loadChildren: 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Enfeksiyon_Komitesi_Onay_Is_Listesi/InfectionCommitteeWorkListModule#InfectionCommitteeWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'tibbiArastirma',
        loadChildren: 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Tibbi_Arastirma_Modulu/Tibbi_Arastirma_Is_Listesi/MedicalResarchWorkListModule#MedicalResarchWorkListModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'tescilliyatakeslestirme',
        loadChildren: 'Modules/Tibbi_Surec/Medula_Yatak_Islemleri_Modulu/MedulaYatakIslemleriModule#MedulaYatakIslemleriModule',
        canActivate: [AtlasAuthGuardService]
    },

    {
        path: 'kiosk',
        loadChildren: 'Modules/Kiosk_Modulleri/KioskDefinitionModule#KioskDefinitionModule',
        canActivate: [AtlasAuthGuardService]
    },

    {
        path: 'arsivTanimlari',
        loadChildren: 'Modules/Kaynak_Tanimlari/Arsiv_Tanimlari/ArchiveDefinitionModule#ArchiveDefinitionModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'atikTanimlari',
        loadChildren: 'Modules/Kaynak_Tanimlari/Tibbi_Atik_Tanimlari/MedicalWasteDefinitionModule#MedicalWasteDefinitionModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'hastaDosyasiTanimlari',
        loadChildren: 'Modules/Kaynak_Tanimlari/Hasta_Dosyasi_Tanimlari/PatientFolderContentDefModule#PatientFolderContentDefModule',
        canActivate: [AtlasAuthGuardService]
    },
    //{
    //    path: 'hemsirelikhizmetleri',
    //    loadChildren: 'Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/Hemsirelik_Is_Listesi/NursingWorkList#NursingWorkList'
    //    , canActivate: [AtlasAuthGuardService]
    //},
    {
        path: 'hastailacdogrulama',
        loadChildren: 'Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/Hasta_Ilac_Dogrulama/DrugCorrection#DrugCorrection'
        , canActivate: [AtlasAuthGuardService]
    },

    { path: 'newdoctorperformance', loadChildren: 'AppModules/DoctorPerformance/DoctorPerformanceModule#DoctorPerformanceModule', canActivate: [AtlasAuthGuardService] },
    { path: 'laundry', loadChildren: 'AppModules/Laundry/LaundryModule#LaundryModule', canActivate: [AtlasAuthGuardService] },
    { path: 'fatura', loadChildren: 'AppModules/Invoice/InvoiceModule#InvoiceModule', canActivate: [AtlasAuthGuardService] },
    // { path: 'faturaAllinOne', loadChildren: 'AppModules/Invoice/InvoiceModule#InvoiceModule', canActivate: [AtlasAuthGuardService] },
    { path: 'vezne', loadChildren: 'AppModules/CashOfficeForms/CashOfficeFormModule#CashOfficeFormModule', canActivate: [AtlasAuthGuardService] },
    {
        path: 'kullanicimesaj',
        loadChildren: 'Modules/Core_Destek_Modulleri/Kullanici_Mesajlari_Modulu/KullaniciMesajlariModule#KullaniciMesajlariModule',
        canActivate: [AtlasAuthGuardService]
    },
    {
        path: 'errorwatcher',
        loadChildren: 'Modules/Core_Destek_Modulleri/ErrorWatcherModule/ErrorWatcherModule#ErrorWatcherModule',
        canActivate: [AtlasAuthGuardService]
    },
    { path: 'arsiv', loadChildren: 'Modules/Tibbi_Surec/Arsiv_Modulu/ArsivModule#ArsivModule', canActivate: [AtlasAuthGuardService] },

    { path: 'tibbiatik', loadChildren: 'Modules/Tibbi_Surec/Tibbi_Tehlikeli_Atik_Modulu/TibbiTehlikeliAtikModule#TibbiTehlikeliAtikModule', canActivate: [AtlasAuthGuardService] },

    { path: 'gelirgider', loadChildren: 'Modules/Doner_Sermaye_Saymanligi_Modulleri/MDS058_Gelir_Gider_Takip_Islemleri/MDS058GelirGiderTakipIslemleriModule#MDS058GelirGiderTakipIslemleriModule', canActivate: [AtlasAuthGuardService] },

    { path: 'doctorquota', loadChildren: 'Modules/Core_Destek_Modulleri/Doktor_Kota_Tanimlama_Modulu/DoktorKotaTanimlamaModule#DoktorKotaTanimlamaModule', canActivate: [AtlasAuthGuardService] },

    { path: 'log', loadChildren: 'Modules/Core_Destek_Modulleri/Log_Modulu/LogModule#LogModule', canActivate: [AtlasAuthGuardService] },
    { path: 'testpad', loadChildren: 'AppModules/TestPad/TestPadModule#TestPadModule', canActivate: [AtlasAuthGuardService] },
    { path: 'ConvTest', loadChildren: 'Modules/Core_Destek_Modulleri/Test_Modulu/TestModule#TestModule', canActivate: [AtlasAuthGuardService] },
    { path: 'ConvTestView', loadChildren: 'AppModules/ConvTestPad/ConvTestPadModule#ConvTestPadModule', canActivate: [AtlasAuthGuardService] },
    {
        path: 'hastaraporlari',
        loadChildren: 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule#HastaRaporlariModule',
        canActivate: [AtlasAuthGuardService]
    },
    { path: 'randevuveplanlama', loadChildren: 'Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule#RandevuModule', canActivate: [AtlasAuthGuardService] },
    { path: 'yatanRandevu', loadChildren: 'Modules/Tibbi_Surec/Randevu_Modulu/Yatan_Randevu_Is_Listesi/InpatientAppWorkListModule#InpatientAppWorkListModule', canActivate: [AtlasAuthGuardService] },
    { path: 'objecttest', loadChildren: 'AppModules/TestPad/ObjectTestModule#ObjectTestModule', canActivate: [AtlasAuthGuardService] },  
    { path: 'patoloji', loadChildren: 'Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule#PatolojiModule', canActivate: [AtlasAuthGuardService] },
    { path: 'taburcu', loadChildren: 'Modules/Tibbi_Surec/Taburcu_Islemleri_Modulu/TaburcuIslemleriModule#TaburcuIslemleriModule', canActivate: [AtlasAuthGuardService] },

    { path: 'sosyalhizmet', loadChildren: 'Modules/Tibbi_Surec/Sosyal_Hizmetler_Modulu/SosyalHizmetlerModule#SosyalHizmetlerModule', canActivate: [AtlasAuthGuardService] },
    { path: 'psikolog', loadChildren: 'Modules/Tibbi_Surec/Psikolog_Modulu/PsikologModule#PsikologModule', canActivate: [AtlasAuthGuardService] },
    {
        path: 'mhrs',
        loadChildren: 'Modules/Sorgulama_ve_Cikartma_Formlari/MHRS_Randevu_Plani_Sorgulama_Formlari/MHRSRandevuPlaniSorgulamaFormlariModule#MHRSRandevuPlaniSorgulamaFormlariModule',
        canActivate: [AtlasAuthGuardService]
    },
    { path: 'nabiz', loadChildren: 'Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule#ENabizModule', canActivate: [AtlasAuthGuardService] },
    { path: 'nabiztakip', loadChildren: 'Modules/Tibbi_Surec/E_Nabiz_Paket_Yonetim_Modulu/ENabizPackageManagementModule#ENabizPackageManagementModule', canActivate: [AtlasAuthGuardService] },
    { path: 'receteistatistik', loadChildren: 'Modules/Tibbi_Surec/Recete_Istatistik_Modulu/ReceteIstatistikModule#ReceteIstatistikModule', canActivate: [AtlasAuthGuardService] },
    { path: 'tigmodulu', loadChildren: 'Modules/Tibbi_Surec/TIG_Modulu/TIGModule#TIGModule', canActivate: [AtlasAuthGuardService] },
    { path: 'morg', loadChildren: 'Modules/Tibbi_Surec/Morg_Modulu/MorgModule#MorgModule', canActivate: [AtlasAuthGuardService] },
    { path: 'hastagecmisiarama', loadChildren: 'Modules/Tibbi_Surec/Hasta_Gecmisi_Arama_Modulu/PatientHistorySearchModule#PatientHistorySearchModule', canActivate: [AtlasAuthGuardService] },
    { path: 'hastadosyasi', loadChildren: 'Modules/Tibbi_Surec/Hasta_Dosyasi/HastaDosyasiModule#HastaDosyasiModule', canActivate: [AtlasAuthGuardService] },
    { path: 'raporlar', loadChildren: 'Modules/Sorgulama_ve_Cikartma_Formlari/Rapor_Yazdirma_Formu/PrintReportFormModule#PrintReportFormModule', canActivate: [AtlasAuthGuardService] },
    //{ path: 'tablet', loadChildren: 'Modules/Mobile/MobileMainScreen/MobileMainScreenModule#MobileMainScreenModule', canActivate: [AtlasAuthGuardService] },
    //{ path: 'webapi', loadChildren: 'Modules/Mobile/APITest/APITestModule#APITestModule', canActivate: [AtlasAuthGuardService] },
    { path: 'orderzamancizelgesi', loadChildren: 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/HospitalTimeScheduleModule#HospitalTimeScheduleModule', canActivate: [AtlasAuthGuardService] },

    {
        path: 'sterilizasyonistek',
        loadChildren: 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Sterilizasyon_Modulu/SterilizasyonModule#SterilizasyonModule',
        canActivate: [AtlasAuthGuardService]
    },
    { path: 'sterilizasyon', loadChildren: 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Sterilizasyon_Modulu/Sterilizasyon_Is_Listesi/SterilizationIsModule#SterilizationIsModule', canActivate: [AtlasAuthGuardService] },
    { path: 'teletip', loadChildren: 'Modules/Tibbi_Surec/Radyoloji_Modulu/Teletip_Is_Listesi/TeletipIsModule#TeletipIsModule', canActivate: [AtlasAuthGuardService] },
    
    { path: 'dynamicreporting', loadChildren: 'AppModules/DevexpressReporting/DevexpressReportingModule#DevexpressReportingModule' },
    { path: 'dynamicformdesigner', loadChildren: 'AppModules/DynamicFormDesigner/DynamicFormModule#DynamicFormModule' },


   



    { path: 'lcd', loadChildren: 'Modules/Tibbi_Surec/Hasta_Cagri_Modulu/HastaCagriModule#HastaCagriModule' },

    { path: 'smsmodulu', loadChildren: 'Modules/Core_Destek_Modulleri/SMS_Module/SMSModule#SMSModule', canActivate: [AtlasAuthGuardService] },


    { path: '**', redirectTo: '/acilis', pathMatch: 'full' },



];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule],
    providers: [AtlasCanDeactivateGuard]
})
export class AppRoutingModule {

	static dynamicComponentsMap = {
		RouterModule
	};

}
