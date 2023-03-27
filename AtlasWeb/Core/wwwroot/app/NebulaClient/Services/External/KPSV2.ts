//$7F276D63
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export namespace KPSV2 {
    export enum ECinsiyet {
        BILINMEYEN = 0,
        ERKEK = 1,
        KADIN = 2
    }

    export enum EAileSorguTipi {
        Aile = 0,
        TumAile = 1
    }

    export class KpsServisSonucuOfBilesikKisiBilgisiZmZ26SC9 {
        HataBilgisi: KPSV2.Parametre;
        Sonuc: KPSV2.BilesikKisiBilgisi;
    }

    export class Parametre {
        Aciklama: string;
        Kod: number;
    }

    export class BilesikKisiBilgisi {
        HataBilgisi: KPSV2.Parametre;
        KimlikNo: number;
        MaviKartliKisiKutukleri: KPSV2.MaviKartliKisiKutukleri;
        TCVatandasiKisiKutukleri: KPSV2.TCVatandasiKisiKutukleri;
        YabanciKisiKutukleri: KPSV2.YabanciKisiKutukleri;
    }

    export class KpsServisSonucuBilesikKisiBilgisi extends KPSV2.KpsServisSonucuOfBilesikKisiBilgisiZmZ26SC9 {

    }

    export class MaviKartliKisiKutukleri {
        AdresBilgisi: KPSV2.KisiAdresBilgisi;
        HataBilgisi: KPSV2.Parametre;
        KisiBilgisi: KPSV2.MaviKartKisiBilgisi;
        MaviKartBilgisi: KPSV2.MaviKartBilgisi;
    }

    export class TCVatandasiKisiKutukleri {
        AdresBilgisi: KPSV2.KisiAdresBilgisi;
        GeciciKimlikBilgisi: KPSV2.TCGeciciKimlikBilgisi;
        HataBilgisi: KPSV2.Parametre;
        KisiBilgisi: KPSV2.TCKisiBilgisi;
        NufusCuzdaniBilgisi: KPSV2.TCCuzdanBilgisi;
        TCKKBilgisi: KPSV2.TCKK;
    }

    export class YabanciKisiKutukleri {
        AdresBilgisi: KPSV2.KisiAdresBilgisi;
        HataBilgisi: KPSV2.Parametre;
        KisiBilgisi: KPSV2.YabanciKisiBilgisi;
    }

    export class KisiAdresBilgisi {
        AcikAdres: string;
        AdresNo: number;
        AdresTip: KPSV2.Parametre;
        BeldeAdresi: KPSV2.BeldeAdresi;
        BeyanTarihi: KPSV2.TarihBilgisi;
        BeyandaBulunanKimlikNo: number;
        HataBilgisi: KPSV2.Parametre;
        IlIlceMerkezAdresi: KPSV2.IlIlceMerkezAdresi;
        KoyAdresi: KPSV2.KoyAdresi;
        TasinmaTarihi: KPSV2.TarihBilgisi;
        TescilTarihi: KPSV2.TarihBilgisi;
        YurtDisiAdresi: KPSV2.YurtDisiAdresi;
    }

    export class MaviKartKisiBilgisi {
        AnneTCKimlikNo: number;
        BabaTCKimlikNo: number;
        DogumYerKod: number;
        DurumBilgisi: KPSV2.DurumBilgisi;
        EsTCKimlikNo: number;
        GercekKisiKimlikNo: number;
        HataBilgisi: KPSV2.Parametre;
        KazanilanTCKimlikNo: number;
        KimlikNo: number;
        TemelBilgisi: KPSV2.TemelBilgisi;
        Ulke: KPSV2.Parametre;
    }

    export class MaviKartBilgisi {
        Ad: string;
        AnneAd: string;
        BabaAd: string;
        Birim: number;
        Cinsiyet: KPSV2.Parametre;
        DogumTarih: KPSV2.TarihBilgisi;
        DogumYer: string;
        DogumYerKod: number;
        HataBilgisi: KPSV2.Parametre;
        KartKayitNo: number;
        KimlikNo: number;
        MedeniHal: KPSV2.Parametre;
        No: number;
        OncekiSoyad: string;
        Seri: string;
        Soyad: string;
        Uyruk: KPSV2.Parametre;
        VerilisNeden: KPSV2.Parametre;
        VerilmeTarih: KPSV2.TarihBilgisi;
    }

    export class BeldeAdresi {
        BagimsizBolumDurum: KPSV2.Parametre;
        BagimsizBolumTipi: KPSV2.Parametre;
        BinaAda: string;
        BinaBlokAdi: string;
        BinaDurum: KPSV2.Parametre;
        BinaKodu: number;
        BinaNo: number;
        BinaNumaratajTipi: KPSV2.Parametre;
        BinaPafta: string;
        BinaParsel: string;
        BinaSiteAdi: string;
        BinaYapiTipi: KPSV2.Parametre;
        Csbm: string;
        CsbmKodu: number;
        DisKapiNo: string;
        HataBilgisi: KPSV2.Parametre;
        IcKapiNo: string;
        Il: string;
        IlKodu: number;
        Ilce: string;
        IlceKodu: number;
        KatNo: string;
        Koy: string;
        KoyKayitNo: number;
        KoyKodu: number;
        Mahalle: string;
        MahalleKodu: number;
        TapuBagimsizBolumNo: string;
        YapiKullanimAmac: KPSV2.Parametre;
        YolAltiKatSayisi: number;
        YolUstuKatSayisi: number;
    }

    export class TarihBilgisi {
        Ay: number;
        Gun: number;
        Yil: number;
    }

    export class IlIlceMerkezAdresi {
        BagimsizBolumDurum: KPSV2.Parametre;
        BagimsizBolumTipi: KPSV2.Parametre;
        BinaAda: string;
        BinaBlokAdi: string;
        BinaDurum: KPSV2.Parametre;
        BinaKodu: number;
        BinaNo: number;
        BinaNumaratajTipi: KPSV2.Parametre;
        BinaPafta: string;
        BinaParsel: string;
        BinaSiteAdi: string;
        BinaYapiTipi: KPSV2.Parametre;
        Csbm: string;
        CsbmKodu: number;
        DisKapiNo: string;
        HataBilgisi: KPSV2.Parametre;
        IcKapiNo: string;
        Il: string;
        IlKodu: number;
        Ilce: string;
        IlceKodu: number;
        KatNo: string;
        Mahalle: string;
        MahalleKodu: number;
        TapuBagimsizBolumNo: string;
        YapiKullanimAmac: KPSV2.Parametre;
        YolAltiKatSayisi: number;
        YolUstuKatSayisi: number;
    }

    export class KoyAdresi {
        BagimsizBolumDurum: KPSV2.Parametre;
        BagimsizBolumTipi: KPSV2.Parametre;
        BinaAda: string;
        BinaBlokAdi: string;
        BinaDurum: KPSV2.Parametre;
        BinaKodu: number;
        BinaNo: number;
        BinaNumaratajTipi: KPSV2.Parametre;
        BinaPafta: string;
        BinaParsel: string;
        BinaSiteAdi: string;
        BinaYapiTipi: KPSV2.Parametre;
        Csbm: string;
        CsbmKodu: number;
        DisKapiNo: string;
        HataBilgisi: KPSV2.Parametre;
        IcKapiNo: string;
        Il: string;
        IlKodu: number;
        Ilce: string;
        IlceKodu: number;
        KatNo: string;
        Koy: string;
        KoyKayitNo: number;
        KoyKodu: number;
        Mahalle: string;
        MahalleKodu: number;
        TapuBagimsizBolumNo: string;
        YapiKullanimAmac: KPSV2.Parametre;
        YolAltiKatSayisi: number;
        YolUstuKatSayisi: number;
    }

    export class YurtDisiAdresi {
        DisTemsDuzeltmeBeyanTarih: Date;
        DisTemsDuzeltmeKararTarih: Date;
        DisTemsDuzeltmeNeden: KPSV2.Parametre;
        DisTemsilcilik: KPSV2.Parametre;
        HataBilgisi: KPSV2.Parametre;
        YabanciAdres: string;
        YabanciSehir: string;
        YabanciUlke: KPSV2.Parametre;
    }

    export class DurumBilgisi {
        Din: KPSV2.Parametre;
        Durum: KPSV2.Parametre;
        MedeniHal: KPSV2.Parametre;
        OlumTarih: KPSV2.TarihBilgisi;
    }

    export class TemelBilgisi {
        Ad: string;
        AnneAd: string;
        BabaAd: string;
        Cinsiyet: KPSV2.Parametre;
        DogumTarih: KPSV2.TarihBilgisi;
        DogumYer: string;
        Soyad: string;
    }

    export class TCGeciciKimlikBilgisi {
        Ad: string;
        AnneAd: string;
        BabaAd: string;
        BelgeNo: string;
        Cinsiyet: KPSV2.Parametre;
        DogumTarih: KPSV2.TarihBilgisi;
        DuzenlenmeTarih: KPSV2.TarihBilgisi;
        DuzenleyenIlce: KPSV2.Parametre;
        HataBilgisi: KPSV2.Parametre;
        OncekiSoyad: string;
        SonGecerlilikTarih: KPSV2.TarihBilgisi;
        Soyad: string;
        TCKimlikNo: number;
    }

    export class TCKisiBilgisi {
        AnneTCKimlikNo: number;
        BabaTCKimlikNo: number;
        DogumYerKod: number;
        DurumBilgisi: KPSV2.DurumBilgisi;
        EsTCKimlikNo: number;
        HataBilgisi: KPSV2.Parametre;
        KayitYeriBilgisi: KPSV2.KayitYeriBilgisi;
        TCKimlikNo: number;
        TemelBilgisi: KPSV2.TemelBilgisi;
    }

    export class TCCuzdanBilgisi {
        Ad: string;
        AnaAd: string;
        BabaAd: string;
        CuzdanKayitNo: number;
        CuzdanVerilmeNeden: KPSV2.Parametre;
        DogumTarih: KPSV2.TarihBilgisi;
        DogumYer: string;
        HataBilgisi: KPSV2.Parametre;
        No: number;
        Seri: string;
        Soyad: string;
        TCKimlikNo: number;
        VerildigiIlce: KPSV2.Parametre;
        VerilmeTarih: KPSV2.TarihBilgisi;
    }

    export class TCKK {
        Ad: string;
        AnneAd: string;
        BabaAd: string;
        BasvuruNeden: KPSV2.Parametre;
        Cinsiyet: KPSV2.Parametre;
        DogumTarih: KPSV2.TarihBilgisi;
        DogumYer: string;
        HataBilgisi: KPSV2.Parametre;
        KayitNo: number;
        SeriNo: string;
        SonGecerlilikTarih: KPSV2.TarihBilgisi;
        Soyad: string;
        TCKimlikNo: number;
        TeslimEdenBirim: KPSV2.Parametre;
        TeslimTarih: KPSV2.TarihBilgisi;
        VerenMakam: string;
    }

    export class KayitYeriBilgisi {
        AileSiraNo: number;
        BireySiraNo: number;
        Cilt: KPSV2.Parametre;
        Il: KPSV2.Parametre;
        Ilce: KPSV2.Parametre;
    }

    export class YabanciKisiBilgisi {
        AnneKimlikNo: number;
        BabaKimlikNo: number;
        BitisTarihiBelirsizOlmaNeden: KPSV2.Parametre;
        DogumTarih: KPSV2.TarihBilgisi;
        DogumYerKod: number;
        EsKimlikNo: number;
        GercekKisiKimlikNo: number;
        HataBilgisi: KPSV2.Parametre;
        IzinBaslangicTarih: Date;
        IzinBitisTarih: Date;
        IzinDuzenlenenIl: KPSV2.Parametre;
        IzinNo: string;
        KaynakBirim: KPSV2.Parametre;
        KazanilanTCKimlikNo: number;
        KimlikNo: number;
        OlumTarih: KPSV2.TarihBilgisi;
        TemelBilgisi: KPSV2.TemelBilgisi;
        Uyruk: KPSV2.Parametre;
    }

    export class KisiSorgulaKisiBilgileriCO {
        Adi: string;
        AnneAdi: string;
        BabaAdi: string;
        Cinsiyet: KPSV2.ECinsiyet;
        DogumTarihi: Date;
        DogumYeri: string;
        Soyadi: string;
    }

    export class KpsServisSonucuOfTCKisiBilgisiZmZ26SC9 {
        HataBilgisi: KPSV2.Parametre;
        Sonuc: KPSV2.TCKisiBilgisi;
    }

    export class KpsServisSonucuKisiTemelBilgisi extends KPSV2.KpsServisSonucuOfTCKisiBilgisiZmZ26SC9 {

    }

    export class KpsServisSonucuOfKisiAdresBilgisiZmZ26SC9 {
        HataBilgisi: KPSV2.Parametre;
        Sonuc: KPSV2.KisiAdresBilgisi;
    }

    export class KpsServisSonucuKisiAdresBilgisi extends KPSV2.KpsServisSonucuOfKisiAdresBilgisiZmZ26SC9 {

    }

    export class AileBireyleriSorgulaKriter {
        TCKimlikNo: number;
        Tip: KPSV2.EAileSorguTipi;
    }

    export class KpsServisSonucuOfAileBilgisiZmZ26SC9 {
        HataBilgisi: KPSV2.Parametre;
        Sonuc: KPSV2.AileBilgisi;
    }

    export class AileBilgisi {
        AileKisiListesi: Array<KPSV2.KisiBilgisi>;
        HataBilgisi: KPSV2.Parametre;
        KisiBilgisi: KPSV2.TCKisiBilgisi;
        TCKimlikNo: number;
    }

    export class KpsServisSonucuAileBilgisi extends KPSV2.KpsServisSonucuOfAileBilgisiZmZ26SC9 {

    }

    export class KisiBilgisi {
        DurumBilgisi: KPSV2.DurumBilgisi;
        HataBilgisi: KPSV2.Parametre;
        KayitYeriBilgisi: KPSV2.KayitYeriBilgisi;
        TCKimlikNo: number;
        TemelBilgisi: KPSV2.TemelBilgisi;
        Yakinlik: KPSV2.Parametre;
    }

    export class KpsServisSonucuOfGenelNufusKayitOrnegiZmZ26SC9 {
        HataBilgisi: KPSV2.Parametre;
        Sonuc: KPSV2.GenelNufusKayitOrnegi;
    }

    export class GenelNufusKayitOrnegi {
        NkoMaviKart: KPSV2.NkoMaviKart;
        NkoVatandas: KPSV2.Nko;
    }

    export class KpsServisSonucuGenelNufusKayitOrnegi extends KPSV2.KpsServisSonucuOfGenelNufusKayitOrnegiZmZ26SC9 {

    }

    export class NkoMaviKart {
        HataBilgisi: KPSV2.Parametre;
        Kisiler: Array<KPSV2.NkoMaviKartKisi>;
        NkoTuru: KPSV2.Parametre;
        Olaylar: Array<KPSV2.NkoMaviKartOlay>;
    }

    export class Nko {
        HataBilgisi: KPSV2.Parametre;
        Kisiler: Array<KPSV2.KisiBilgisi>;
        NkoTuru: KPSV2.Parametre;
        Olaylar: Array<KPSV2.NkoOlay>;
    }

    export class NkoMaviKartKisi {
        AnneKimlikNo: number;
        BabaKimlikNo: number;
        BosanmaTarih: KPSV2.TarihBilgisi;
        DurumBilgisi: KPSV2.NkoMaviKartKisiDurumBilgisi;
        EsKimlikNo: number;
        EvlenmeTarih: KPSV2.TarihBilgisi;
        HataBilgisi: KPSV2.Parametre;
        KimlikNo: number;
        TemelBilgisi: KPSV2.TemelBilgisi;
        TescilTarih: KPSV2.TarihBilgisi;
        Ulke: KPSV2.Parametre;
        YakinlikKod: KPSV2.Parametre;
    }

    export class NkoMaviKartOlay {
        Ad: string;
        Dusunce: string;
        HataBilgisi: KPSV2.Parametre;
        KisiKimlikNo: number;
        OlayTarih: KPSV2.TarihBilgisi;
        OlayTipi: KPSV2.Parametre;
        Soyad: string;
    }

    export class NkoMaviKartKisiDurumBilgisi {
        Durum: KPSV2.Parametre;
        MedeniHal: KPSV2.Parametre;
        OlumTarih: KPSV2.TarihBilgisi;
    }

    export class NkoOlay {
        Ad: string;
        Dusunce: string;
        HataBilgisi: KPSV2.Parametre;
        KayitYeri: KPSV2.KisiKayitYeriKodBilgisi;
        OlayKayitNo: number;
        OlayTarih: KPSV2.TarihBilgisi;
        OlayTipi: KPSV2.Parametre;
        Soyad: string;
    }

    export class KisiKayitYeriKodBilgisi {
        AileSiraNo: number;
        BireySiraNo: number;
        CiltKod: number;
        IlceKod: number;
    }

    export class KpsServisSonucuOfArrayOfServiceZmZ26SC9 {
        HataBilgisi: KPSV2.Parametre;
        Sonuc: Array<KPSV2.Service>;
    }

    export class KpsServisSonucuYetkiListesi extends KPSV2.KpsServisSonucuOfArrayOfServiceZmZ26SC9 {

    }

    export class BaseEntity {
        CreatedBy: number;
        CreatedOn: Date;
        Id: string;
        ModifiedBy: number;
        ModifiedOn: Date;
    }

    export class Service extends KPSV2.BaseEntity {
        Description: string;
        IsActive: boolean;
        IsAuthorized: boolean;
        IsEditable: boolean;
        Methods: Array<KPSV2.Method>;
        Name: string;
        Namespace: string;
        ServiceNo: number;
        ServiceTestUrl: string;
        ServiceUrl: string;
    }

    export class Method {
        Argumans: Array<KPSV2.Property>;
        Description: string;
        IsAuthorized: boolean;
        IsEditable: boolean;
        Name: string;
        ReturnProperties: Array<KPSV2.Property>;
    }

    export class Property {
        IsAuthorized: boolean;
        IsEditable: boolean;
        Name: string;
        SubProperties: Array<KPSV2.Property>;
        Type: string;
    }

    export class WebMethods {
        public static async BilesikKisiSorgulaSync(siteID: Guid, kimlikNo: number): Promise<KpsServisSonucuBilesikKisiBilgisi> {
            let url = '/api/KPSV2/BilesikKisiSorgulaSync';
            let inputDto = { 'siteID': siteID, 'kimlikNo': kimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as KpsServisSonucuBilesikKisiBilgisi;
            return result;
        }
        public static async BilesikKisiveAdresSorgulaSync(siteID: Guid, kimlikNo: number): Promise<KpsServisSonucuBilesikKisiBilgisi> {
            let url = '/api/KPSV2/BilesikKisiveAdresSorgulaSync';
            let inputDto = { 'siteID': siteID, 'kimlikNo': kimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as KpsServisSonucuBilesikKisiBilgisi;
            return result;
        }
        public static async TcKimlikNoSorgulaSync(siteID: Guid, kriter: KisiSorgulaKisiBilgileriCO): Promise<KpsServisSonucuKisiTemelBilgisi> {
            let url = '/api/KPSV2/TcKimlikNoSorgulaSync';
            let inputDto = { 'siteID': siteID, 'kriter': kriter };
            let result = await ServiceLocator.post(url, inputDto) as KpsServisSonucuKisiTemelBilgisi;
            return result;
        }
        public static async KimlikNoIleAdresBilgisiSorgulaSync(siteID: Guid, kimlikNo: number): Promise<KpsServisSonucuKisiAdresBilgisi> {
            let url = '/api/KPSV2/KimlikNoIleAdresBilgisiSorgulaSync';
            let inputDto = { 'siteID': siteID, 'kimlikNo': kimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as KpsServisSonucuKisiAdresBilgisi;
            return result;
        }
        public static async AileBireyleriSorgulaSync(siteID: Guid, kriter: AileBireyleriSorgulaKriter): Promise<KpsServisSonucuAileBilgisi> {
            let url = '/api/KPSV2/AileBireyleriSorgulaSync';
            let inputDto = { 'siteID': siteID, 'kriter': kriter };
            let result = await ServiceLocator.post(url, inputDto) as KpsServisSonucuAileBilgisi;
            return result;
        }
        public static async KimlikNoIleNufusKayitOrnegiSorgulaSync(siteID: Guid, kimlikNo: number): Promise<KpsServisSonucuGenelNufusKayitOrnegi> {
            let url = '/api/KPSV2/KimlikNoIleNufusKayitOrnegiSorgulaSync';
            let inputDto = { 'siteID': siteID, 'kimlikNo': kimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as KpsServisSonucuGenelNufusKayitOrnegi;
            return result;
        }
        public static async YetkiListesiSync(siteID: Guid): Promise<KpsServisSonucuYetkiListesi> {
            let url = '/api/KPSV2/YetkiListesiSync';
            let inputDto = { 'siteID': siteID };
            let result = await ServiceLocator.post(url, inputDto) as KpsServisSonucuYetkiListesi;
            return result;
        }
    }
}
