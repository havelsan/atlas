//$1E7A5299
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace MkysServis {
    export enum EButceTurID {
        /// <remarks/>
        genelButce,
        /// <remarks/>
        donerSermaye
    }

    export enum EAlimYontemiID {
        /// <remarks/>
        acikIhale,
        /// <remarks/>
        madde21fPazarlik,
        /// <remarks/>
        madde22aDogrudanTemin,
        /// <remarks/>
        madde22bDogrudanTemin,
        /// <remarks/>
        madde22cDogrudanTemin,
        /// <remarks/>
        madde22dDogrudanTemin,
        /// <remarks/>
        madde22fDogrudanTemin,
        /// <remarks/>
        madde3eDMO,
        /// <remarks/>
        madde21bPazarlik,
        /// <remarks/>
        belliIstekliler,
        /// <remarks/>
        cerceveSozlesmeAcikIhale,
        /// <remarks/>
        test,
        /// <remarks/>
        madde3h,
        /// <remarks/>
        digerIsAvanslari,
        /// <remarks/>
        madde3cDunyaBankasindanAlinan,
        /// <remarks/>
        madde21aPazarlik,
        /// <remarks/>
        bos
    }

    export enum EMalzemeGrupID {
        /// <remarks/>
        ilac,
        /// <remarks/>
        tibbiSarf,
        /// <remarks/>
        tibbiCihaz,
        /// <remarks/>
        diger
    }

    export enum EOlcuBirimID {
        /// <remarks/>
        adet,
        /// <remarks/>
        ampul,
        /// <remarks/>
        bag,
        /// <remarks/>
        blister,
        /// <remarks/>
        boy,
        /// <remarks/>
        bolum,
        /// <remarks/>
        bidon,
        /// <remarks/>
        cilt,
        /// <remarks/>
        desimetreKare,
        /// <remarks/>
        desimetreKup,
        /// <remarks/>
        doz,
        /// <remarks/>
        duzine,
        /// <remarks/>
        flakon,
        /// <remarks/>
        galon,
        /// <remarks/>
        gram,
        /// <remarks/>
        kapsul,
        /// <remarks/>
        kartus,
        /// <remarks/>
        kasa,
        /// <remarks/>
        kavanoz,
        /// <remarks/>
        koli,
        /// <remarks/>
        kutu,
        /// <remarks/>
        kilogram,
        /// <remarks/>
        kisi,
        /// <remarks/>
        litre,
        /// <remarks/>
        metre,
        /// <remarks/>
        metreKare,
        /// <remarks/>
        metreKup,
        /// <remarks/>
        metreTul,
        /// <remarks/>
        miliGram,
        /// <remarks/>
        miliLitre,
        /// <remarks/>
        paket,
        /// <remarks/>
        plaka,
        /// <remarks/>
        poset,
        /// <remarks/>
        rulo,
        /// <remarks/>
        santiMetre,
        /// <remarks/>
        santiMetreKare,
        /// <remarks/>
        ster,
        /// <remarks/>
        tabaka,
        /// <remarks/>
        tablet,
        /// <remarks/>
        takim,
        /// <remarks/>
        teneke,
        /// <remarks/>
        ton,
        /// <remarks/>
        top,
        /// <remarks/>
        torba,
        /// <remarks/>
        tup,
        /// <remarks/>
        cift,
        /// <remarks/>
        unite,
        /// <remarks/>
        sise,
        /// <remarks/>
        test,
        /// <remarks/>
        mci,
        /// <remarks/>
        kwh,
        /// <remarks/>
        set,
        /// <remarks/>
        mikgrogram,
        /// <remarks/>
        puan,
        /// <remarks/>
        kart,
        /// <remarks/>
        kova,
        /// <remarks/>
        draje,
        /// <remarks/>
        enjektor,
        /// <remarks/>
        makara,
        /// <remarks/>
        disk
    }

    export enum EZimmetTuru {
        /// <remarks/>
        zimmet,
        /// <remarks/>
        ekZimmet
    }

    export enum ECikisIslemTuru {
        /// <remarks/>
        cikis,
        /// <remarks/>
        halksagcikis,
        /// <remarks/>
        emanet,
        /// <remarks/>
        ihtiyacFazlasi
    }

    export enum ECikisStokHareketTurID {
        /// <remarks/>
        ckAmbarlarArasiDevir,
        /// <remarks/>
        ckFireZayiat,
        /// <remarks/>
        ckDevirDigerBirimlereCikis,
        /// <remarks/>
        ckTuketim,
        /// <remarks/>
        ckDevirKurumDisiMalzemeCikis,
        /// <remarks/>
        ckTerkin,
        /// <remarks/>
        ckSatis,
        /// <remarks/>
        ckSayimNoksani,
        /// <remarks/>
        ckYabanciUlkelereBagis,
        /// <remarks/>
        ckKullanilmazHaleGelmeYokOlma,
        /// <remarks/>
        ckHurdayaAyirma,
        /// <remarks/>
        ckDonerSermayedenDevir,
        /// <remarks/>
        ckDuzeltme,
        /// <remarks/>
        ckTakas,
        /// <remarks/>
        ckDevirIhtiyacFazlasiDevir,
        /// <remarks/>
        ckDevirStokFazlasiDevir,
        /// <remarks/>
        ckSatinalmasiBaglananXXXXXXCikisi,
        /// <remarks/>
        ckXXXXXXBirlesmesindenDevir,
        /// <remarks/>
        ckBagliBirimlereCikis,
        /// <remarks/>
        ckTemelSagligaDevir,
        /// <remarks/>
        ckKullanimaVermeKisi,
        /// <remarks/>
        ckKullanimaVermeOrtakAlan,
        /// <remarks/>
        ckIhtiyacFazlasi,
        /// <remarks/>
        ckIhtiyacFazlasiIade,
        /// <remarks/>
        ckZimmettenIade,
        /// <remarks/>
        ckAfetDurumuCikisi,
        /// <remarks/>
        ckDevirUnvXXXXXXneIhtiyacFazlasiDevir,
        /// <remarks/>
        ckDevirUnvXXXXXXneStokFazlasiDevir,
        /// <remarks/>
        ck663KHKyaDevir,
        /// <remarks/>
        ckTuketimYatanHastaTedavisi,
        /// <remarks/>
        ckTuketimAyaktaTedaviAcilServis,
        /// <remarks/>
        ckTuketimGunuBirlikTedaviAcilServis,
        /// <remarks/>
        ckTuketimProtokolHizmeti,
        /// <remarks/>
        ckMiadUzatimiCikis,
        /// <remarks/>
        ckBagliSaglikTesislerineDevir,
        /// <remarks/>
        ckKamuOzelXXXXXXAantidotAntidoksinSatisi,
        /// <remarks/>
        skHalkSagligiBagliBirimlereCikis,
        /// <remarks/>
        ckTuketimEvdeSaglik,
        /// <remarks/>
        ckBirlikiciSaglikTesisineDevir,
        /// <remarks/>
        ckSaglikTesisindenGenelSekreterligeDevir,
        /// <remarks/>
        ckGarantiVeyaSigortaKapsamindaCikis,
        /// <remarks/>
        ckEmanetCikis,
        /// <remarks/>
        ckEmanetIade,
        /// <remarks/>
        ckPgdCikisi,
        /// <remarks/>
        ckDevirDigerKamuIdarelerineDevirCikisi,
        /// <remarks/>
        ckDevirKurumlarArasiDevirCikisi
    }

    export enum EGirisIslemTuru {
        /// <remarks/>
        giris
    }

    export enum ETedarikTurID {
        /// <remarks/>
        satinalma,
        /// <remarks/>
        takas,
        /// <remarks/>
        duzeltme,
        /// <remarks/>
        icImkanlarlaUretim,
        /// <remarks/>
        tasfiyeIdaresindenEdinilen,
        /// <remarks/>
        sayimFazlasi,
        /// <remarks/>
        iadeEdilen,
        /// <remarks/>
        devirAlinan,
        /// <remarks/>
        bagisVeYardim,
        /// <remarks/>
        temelSagliktanDevir,
        /// <remarks/>
        XXXXXXBirlesmesindenDevir,
        /// <remarks/>
        koordinatorXXXXXXdenDevir,
        /// <remarks/>
        stokFazlasiDevir,
        /// <remarks/>
        ihtiyacFazlasiDevir,
        /// <remarks/>
        ambarlarArasiDevir,
        /// <remarks/>
        acilisFiiliSayim,
        /// <remarks/>
        novartisHibe,
        /// <remarks/>
        ilOzelIdaresindenDevirAlinan,
        /// <remarks/>
        universiteXXXXXXndenIhtiyacFazlasiDevir,
        /// <remarks/>
        universiteXXXXXXndenStokFazlasiDevir,
        /// <remarks/>
        KHKdanDevirAlinan,
        /// <remarks/>
        MiadUzatimi,
        /// <remarks/>
        bagliBirliktenDevir,
        /// <remarks/>
        birlikSaglikTesisineDevir,
        /// <remarks/>
        bagliSaglikTsisisndenDevir,
        /// <remarks/>
        garantiSigortaKapsamindaGiris,
        /// <remarks/>
        XXXXXXAndidotAntidoksinGiris,
        /// <remarks/>
        devirKurumlarArasiDevir,
        /// <remarks/>
        devirDigerKamuIdarelerineDevirGiris,
        /// <remarks/>
        devir667KHKDevir,
        /// <remarks/>
        devir669KHKDevir
    }

    export enum EGirisStokHareketTurID {
        /// <remarks/>
        grSatinAlinanMalzemeninGirisi,
        /// <remarks/>
        grBirimlerdenGelenMalzemeGirisi,
        /// <remarks/>
        grBirimlerdenIade,
        /// <remarks/>
        grSayimFazlasi,
        /// <remarks/>
        grYilSonuDevri,
        /// <remarks/>
        grIadeEdilen,
        /// <remarks/>
        grIcImkanlarlaUretilen,
        /// <remarks/>
        grTasfiyeIdaresindenEdinilen,
        /// <remarks/>
        grBagisHibe,
        /// <remarks/>
        grAmbarlarArasiDevir,
        /// <remarks/>
        grDuzetme,
        /// <remarks/>
        grTakas,
        /// <remarks/>
        grIhtiyacFazlasiGirisi,
        /// <remarks/>
        grStokFazlasiGirisi,
        /// <remarks/>
        grKoordinatorXXXXXXdenDevirAlinan,
        /// <remarks/>
        grXXXXXXBirlesmesindenDevir,
        /// <remarks/>
        grTemelSagliktanDevir,
        /// <remarks/>
        grNovartisHibe,
        /// <remarks/>
        grilOzelIdaresindenDevir,
        /// <remarks/>
        grUnvXXXXXXndenStokFazlasiDevirGirisi,
        /// <remarks/>
        grUnvXXXXXXndenIhtiyacFazlasiDevirGirisi,
        /// <remarks/>
        gr663KHKdanDevirGirisi,
        /// <remarks/>
        grMiadUzatimiGiris,
        /// <remarks/>
        grBagliBirliktenDevirGirisi,
        /// <remarks/>
        grBirlikSaglikTesisineDevir,
        /// <remarks/>
        grSaglikTesisindenGenelSekreterligeDevir,
        /// <remarks/>
        grGarantiVeyaSigortaKApsamindaGiris,
        /// <remarks/>
        grSatinalinanKamuOZelXXXXXXAntidotAntidoksinCikis,
        /// <remarks/>
        grDevirKurumlarArasiDevirGirisi,
        /// <remarks/>
        grDevirDigerKamuIdarelerineDevirGiris,
        /// <remarks/>
        gr667KHKDevir,
        /// <remarks/>
        gr669KHKDevir,
        /// <remarks/>
        grTedarikPaylasim
    }

    export enum EEntegrasyonDurumu {
        /// <remarks/>
        entegre,
        /// <remarks/>
        kapsamDisi
    }

    export enum ECihazDurumu {
        /// <remarks/>
        Aktif,
        /// <remarks/>
        Pasif,
        /// <remarks/>
        Arizali
    }

    export enum EDepoTurId {
        /// <remarks/>
        medikalIlac,
        /// <remarks/>
        medikalSarf,
        /// <remarks/>
        medikalLaboratuvar,
        /// <remarks/>
        medikalCerrahiAletler,
        /// <remarks/>
        biyomedikalTuketim,
        /// <remarks/>
        biyomedikalDayanikliTasinir,
        /// <remarks/>
        ayniyatTuketim,
        /// <remarks/>
        ayniyatDayanikliTasinir
    }

    export class SoapKontrol {
        public mkysKullaniciAdi: string;
        public mkysSifre: string;
        public firmaKullaniciAdi: string;
        public firmaSifre: string;
        public birimKayitNo: number;
    }

    export class firmaBilgileriGetTumuSonuc {
        public unvan: string;
        public vergiDairesi: string;
        public vergiNumarasi: string;
    }

    export class mukerrerStokHareketItem {
        public stokHareketID: number;
        public belgeNo: string;
        public belgeTarihi: Date;
        public islemKayitNo: number;
    }

    export class zimmetListesiGetDataResultItem {
        public stokHareketID: number;
        public tasinirKodu: string;
        public malzemeAdi: string;
        public fiyat: number;
        public aciklama: string;
        public miktar: number;
        public sicilNo: string;
        public edinimYili: number;
        public demirbasNo: string;
        public hbysdetayID: string;
    }

    export class zimmetListesiGetItem {
        public butceYili: number;
        public depoKayitNo: number;
        public islemSiraNo: number;
        public belgeNo: string;
        public butceTurID: EButceTurID;
    }

    export class kayittanDusmeListItem {
        public girisStokHareketID: number;
        public miktar: number;
        public hbysKayitNo: string;
    }

    export class entitiesBaseClass {

    }

    export class yilSonuDevriSonucItem extends entitiesBaseClass {
        public malzeme_kayit_id: number;
        public miktar: number;
        public vergisiz_fiyat: number;
        public vergili_fiyat: number;
        public kdv_orani: number;
        public indirim_orani: number;
        public olcu_birimi_id: string;
        public malzeme_aciklamasi: string;
        public tasinir_kodu: string;
        public belge_tarihi: Date;
        public belge_no: string;
        public hataKodu: string;
        public stokHareketID: number;
        public sonKullanmaTarihi: Date;
        public butceTurID: string;
        public barkod: string;
    }

    export class yilSonuDevriItem extends entitiesBaseClass {
        public birimDepoID: number;
        public butceYili: number;
    }

    export class giriseAitCikislarResultItem extends entitiesBaseClass {
        public stokHareketID: number;
        public stokHareketTurID: string;
        public islemTuru: string;
        public butceTuruID: string;
        public miktar: number;
        public vergiliBirimFiyat: number;
        public olcuBirimID: string;
        public belgeNo: number;
        public belgeTarihi: Date;
        public dayanakBelgeNo: string;
        public dayanakBelgeTarihi: Date;
        public malzemeDigerAciklama: string;
        public depoKayitNo: number;
        public malzemeKayitID: number;
        public cikisTCKimlikNo: string;
        public uretimTarihi: Date;
        public sonKullanmaTarihi: Date;
        public demirbasNo: number;
        public girisStokHareketID: number;
        public cikisBirimDepoID: number;
        public cikisBirimKayitNo: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public malzemeTurID: string;
        public islemKayitNo: number;
        public ayniyatMakbuzID: number;
        public iadeTarihi: Date;
        public edinmeYili: number;
        public urunBarkodu: string;
        public digerBirimAdi: string;
        public hbysID: string;
        public hbysDetayID: string;
        public hataKodu: string;
    }

    export class malzemeZimmetBilgisiResult extends entitiesBaseClass {
        public islemTuru: string;
        public hareketTuru: string;
        public zimmeteVerilenKisiTCNo: number;
        public zimmeteVerilenKisiAdSoyad: string;
        public zimmeteVerildigiBirim: number;
        public iadeTarihi: Date;
        public belgeTarihi: Date;
        public belgeNo: string;
        public hataKodu: string;
    }

    export class demirbasGetDataResult extends entitiesBaseClass {
        public demirbasSicilNo: string;
        public tasinirKodu: string;
        public malzemeTuru: string;
        public islemTuru: string;
        public demirbasAdi: string;
        public hareketTuru: string;
        public hareketTurID: string;
        public edinimYili: number;
        public stokHareketID: number;
        public ayniyatMakbuzID: number;
        public belgeNo: number;
        public belgeTarihi: Date;
        public hataMesaji: string;
    }

    export class amortismanDetaySonucItem extends entitiesBaseClass {
        public amortismanDetayID: number;
        public amortismanID: number;
        public hbysKayitNo: string;
    }

    export class amortismanInsertSonuc extends entitiesBaseClass {
        public islemKayitNo: number;
        public basariDurumu: boolean;
        public detaySonucList: Array<amortismanDetaySonucItem>;
        public mesaj: string;
    }

    export class amortismanDetayListItem extends entitiesBaseClass {
        public amortismanID: number;
        public ydobaTutari: number;
        public ydsTutari: number;
        public ydsbaTutari: number;
        public baTutari: number;
        public ydombTutari: number;
        public netDeger: number;
        public amortismanOrani: number;
        public yenidenDegerlemeOrani: number;
        public cyaTutari: number;
        public degerArtirimi: number;
        public yil: number;
        public hbysKayitNo: string;
    }

    export class amortismanInsertItem extends entitiesBaseClass {
        public stokHareketID: number;
        public degerArtirimi: number;
        public edinmeYili: number;
        public detayList: Array<amortismanDetayListItem>;
    }

    export class sonKullanmaTarihiUpdateItemList extends entitiesBaseClass {
        public sonKullanmaTarihi: Date;
        public stokHareketID: number;
    }

    export class sonKullanmaUpdateInsertItem extends entitiesBaseClass {
        public list: Array<sonKullanmaTarihiUpdateItemList>;
        public depoKayitNo: number;
    }

    export class malzemeBilgileriUpdateItem extends entitiesBaseClass {
        public stokHareketID: number;
        public barkod: string;
        public malzemeAciklama: string;
        public malzemeKayitID: number;
    }

    export class girisiOlmayanCikislarItem extends entitiesBaseClass {
        public cikisStokHareketID: number;
        public girisStokHareketID: number;
        public cikisTasinirKodu: string;
        public cikisFiyati: number;
        public cikisMiktari: number;
        public cikisTutari: number;
        public demirbasNo: string;
        public malzemeKayitID: number;
        public tasinirKodu: string;
        public cikisTarihi: Date;
        public cikisBelgeNo: string;
    }

    export class ilacJenerikAdiItem extends entitiesBaseClass {
        public jenerikID: number;
        public jenerikAdi: string;
        public form: string;
    }

    export class ilacEtkenMaddeItem extends entitiesBaseClass {
        public barkod: string;
        public etkenMadde: string;
        public miktar: string;
        public birimi: string;
    }

    export class ilacAtcItem extends entitiesBaseClass {
        public barkod: string;
        public atcAdi: string;
        public atcKodu: string;
        public atcTanimi: string;
    }

    export class ilacItem extends entitiesBaseClass {
        public barkod: string;
        public ilacAdi: string;
    }

    export class ilacSorgulamaSonuc extends entitiesBaseClass {
        public ilacList: Array<ilacItem>;
        public atcList: Array<ilacAtcItem>;
        public etkenMaddeList: Array<ilacEtkenMaddeItem>;
        public jenerikList: Array<ilacJenerikAdiItem>;
        public mesaj: string;
    }

    export class yonetimHesabiCetveliItem extends entitiesBaseClass {
        public tasinirKoduDuzey1: string;
        public tasinirKoduDuzey2: string;
        public tasinirAdi: string;
        public tasinirAdiDuzey1Adi: string;
        public harcamaKodu: string;
        public gecenYildanDevirEdenMiktar: number;
        public gecenYildanDevredenTutar: number;
        public yilIcindeGirenMiktar: number;
        public yilIcindeGirenTutar: number;
        public yilIcindeCikanMiktar: number;
        public yilIcindeCikanTutar: number;
        public gelecekYilaDevredenMiktar: number;
        public gelecekYilaDevredenTutar: number;
        public ambarlarArasiDevirDurumu: string;
    }

    export class yonetimHesabiKriter extends entitiesBaseClass {
        public butceTuru: string;
        public butceYili: number;
        public tasinirKodu: string;
        public depoKayitNo: number;
    }

    export class ayniyatMakbuzuUpdateItem extends entitiesBaseClass {
        public ayniyatMakbuzID: number;
        public ihaleTarihi: Date;
        public ihaleKayitNo: string;
        public alimYontemi: EAlimYontemiID;
        public malzemeGrubu: EMalzemeGrupID;
    }

    export class stokHareketLogItem extends entitiesBaseClass {
        public stokHareketID: number;
        public stokHareketTurID: string;
        public islemTuru: string;
        public butceTuruID: string;
        public miktar: number;
        public vergiliBirimFiyat: number;
        public olcuBirimID: string;
        public belgeNo: number;
        public belgeTarihi: Date;
        public dayanakBelgeNo: string;
        public dayanakBelgeTarihi: Date;
        public malzemeDigerAciklama: string;
        public depoKayitNo: number;
        public malzemeKayitID: number;
        public cikisTCKimlikNo: string;
        public uretimTarihi: Date;
        public sonKullanmaTarihi: Date;
        public demirbasNo: number;
        public girisStokHareketID: number;
        public cikisBirimDepoID: number;
        public cikisBirimKayitNo: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public malzemeTurID: string;
        public islemKayitNo: number;
        public ayniyatMakbuzID: number;
        public iadeTarihi: Date;
        public edinmeYili: number;
        public urunBarkodu: string;
        public digerBirimAdi: string;
        public logTarih: string;
        public logKullanici: string;
        public logIslemTuru: string;
        public logIp: string;
        public logMakina: string;
    }

    export class stokHareketYilSonuItem extends entitiesBaseClass {
        public stokHareketID: number;
        public stokHareketTurID: string;
        public islemTuru: string;
        public butceTuruID: string;
        public miktar: number;
        public vergiliBirimFiyat: number;
        public olcuBirimID: string;
        public belgeNo: number;
        public belgeTarihi: Date;
        public dayanakBelgeNo: string;
        public dayanakBelgeTarihi: Date;
        public malzemeDigerAciklama: string;
        public depoKayitNo: number;
        public malzemeKayitID: number;
        public cikisTCKimlikNo: string;
        public uretimTarihi: Date;
        public sonKullanmaTarihi: Date;
        public demirbasNo: number;
        public girisStokHareketID: number;
        public cikisBirimDepoID: number;
        public cikisBirimKayitNo: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public malzemeTurID: string;
        public islemKayitNo: number;
        public ayniyatMakbuzID: number;
        public iadeTarihi: Date;
        public edinmeYili: number;
        public urunBarkodu: string;
        public digerBirimAdi: string;
        public cikisMiktari: number;
        public depodakiMiktar: number;
    }

    export class yilSonuKriter extends entitiesBaseClass {
        public butceYili: number;
        public depoKayitNo: number;
        public tasinirKodu: string;
        public butceTuru: string;
    }

    export class firmaBilgileriGetItem extends entitiesBaseClass {
        public unvan: string;
        public adres1: string;
        public adres2: string;
        public telefon: string;
        public fax: string;
        public email: string;
        public vergiDairesi: string;
        public vergiNo: string;
        public ilce: string;
        public il: string;
        public kod: number;
    }

    export class firmaBilgileriGetVergiNoSonuc extends entitiesBaseClass {
        public firmakod: number;
        public unvan: string;
        public isAdresi: string;
        public ikametAdresi: string;
        public vergiDairesiAdi: string;
        public vergiNo: string;
    }

    export class unvanTurItem extends entitiesBaseClass {
        public unvanTurID: string;
        public unvanAdi: string;
    }

    export class mkysSonuc extends entitiesBaseClass {
        public islemKayitNo: number;
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class stokHareketUpdateItem extends entitiesBaseClass {
        public stokHareketID: number;
        public uretimTarihi: Date;
        public sonKullanmaTarihi: Date;
        public edinmeYili: number;
    }

    export class depoYetkiKontrolSonuc extends entitiesBaseClass {
        public yetkiVar: boolean;
        public mesaj: string;
    }

    export class depoYetkiKontrolItem extends entitiesBaseClass {
        public depoKayitNo: number;
        public mkysKullaniciAdi: string;
    }

    export class aracModelItem extends entitiesBaseClass {
        public aracModelID: string;
        public modelAdi: string;
    }

    export class stokSeviyesiInsertSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public sonuc: number;
    }

    export class stokSeviyesiInsertItem extends entitiesBaseClass {
        public depoKayitNo: number;
        public malzemeKayitID: number;
        public barkod: string;
        public olcu: EOlcuBirimID;
        public yillikIhtiyac: string;
        public asgariMiktar: string;
    }

    export class cikisKontrolSonuc extends entitiesBaseClass {
        public cikisSayisi: number;
        public mesaj: string;
    }

    export class sifreDegistirSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class ihtiyacFazlasiItem extends entitiesBaseClass {
        public siraNo: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public malzemeDigerAciklama: string;
        public ilKodu: string;
        public adeti: number;
        public vergiliBirimFiyat: number;
        public birimAdi: string;
        public ilAdi: string;
        public tarih: Date;
    }

    export class ihtiyacFazlasiKriterItem extends entitiesBaseClass {
        public malzemeKodu: string;
        public malzemeAdi: string;
        public ilAdi: string;
        public birimAdi: string;
    }

    export class zimmetItem extends entitiesBaseClass {
        public belgeNo: number;
        public belgeTarihi: Date;
        public verilenKisiAdi: string;
        public verilenBirimAdi: string;
        public verilenYerAdi: string;
        public islemKayitNo: number;
        public personelSicilNo: number;
        public verilenKisiTCKimlikNo: string;
        public birimKayitNo: number;
        public hbysID: string;
        public dayanakBelgeNo: string;
        public dayanakBelgeTarihi: Date;
        public depoKayitNo: number;
    }

    export class zimmettenAlSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class zimmettenAlListItem extends entitiesBaseClass {
        public zimmetInsertHareketID: number;
        public hbysMakbuzDetayKayitNo: string;
    }

    export class zimmettenAlInsertItem extends entitiesBaseClass {
        public zimmettenAlmaTarihi: Date;
        public hbysID: string;
        public alinacakListe: Array<zimmettenAlListItem>;
    }

    export class sonucZimmetListItem extends entitiesBaseClass {
        public yeniStokHareketID: number;
        public hbysKayitNo: string;
    }

    export class zimmetInsertSonuc extends entitiesBaseClass {
        public islemKayitNo: number;
        public basariDurumu: boolean;
        public mesaj: string;
        public sonucZimmetList: Array<sonucZimmetListItem>;
    }

    export class zimmetListItem extends entitiesBaseClass {
        public girisStokHareketID: number;
        public hbysKayitNo: string;
    }

    export class zimmetInsertItem extends entitiesBaseClass {
        public zimmetTuru: EZimmetTuru;
        public ortakAlanaYapilanZimmet: boolean;
        public zimmeteVerilenKisiTCKimlikNo: string;
        public verilenYerID: number;
        public belgeNo: number;
        public belgeTarihi: Date;
        public butceTuru: EButceTurID;
        public depoKayitNo: number;
        public demirbasVerilenYerID: string;
        public zimmetListesi: Array<zimmetListItem>;
        public islemKayitNo: number;
    }

    export class kitapInsertUpdateSonuc extends entitiesBaseClass {
        public sonuc: boolean;
        public mesaj: string;
    }

    export class kitapInsertUpdateItem extends entitiesBaseClass {
        public makbuzDetayKayitNo: number;
        public adi: string;
        public ciltMadde: string;
        public dil: string;
        public konu: string;
        public yazar: string;
        public yayinYeri: string;
        public yayinTarihi: Date;
        public agirlik: string;
        public boyut: string;
        public satirSayisi: string;
        public yaprakSayisi: string;
        public sayfaSayisi: string;
        public ciltTuru: string;
        public digerTur: string;
        public bulunduguYer: string;
        public izBedeli: string;
    }

    export class sonucKayittanDusmeListItem extends entitiesBaseClass {
        public yeniStokHareketID: number;
        public hbysKayitNo: string;
    }

    export class kayittanDusmeSonuc extends entitiesBaseClass {
        public islemKayitNo: number;
        public basariDurumu: boolean;
        public mesaj: string;
        public sonucList: Array<sonucKayittanDusmeListItem>;
    }

    export class kayittanDusmeInsertItem extends entitiesBaseClass {
        public belgeNo: number;
        public belgeTarihi: Date;
        public butceTuru: EButceTurID;
        public depoKayitNo: number;
        public dusecekListe: Array<kayittanDusmeListItem>;
    }

    export class demirbasDevirSonuc extends entitiesBaseClass {
        public yeniStokHareketID: number;
        public mesaj: string;
        public basariDurumu: boolean;
    }

    export class demirbasDevirItem extends entitiesBaseClass {
        public devirEdecekStokHareketID: number;
        public devirTarihi: Date;
    }

    export class degerArtisiSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class degerArtisiInsertItem extends entitiesBaseClass {
        public stokHareketID: number;
        public artisMiktariToplam: number;
    }

    export class aracInsertSonuc extends entitiesBaseClass {
        public sonuc: boolean;
        public mesaj: string;
    }

    export class aracInsertItem extends entitiesBaseClass {
        public stokHareketID: number;
        public markaID: string;
        public modelID: string;
        public aracTurID: string;
        public modelYili: number;
        public plaka: string;
        public saseNo: string;
        public motorNo: string;
    }

    export class cikisFisDetayItem extends entitiesBaseClass {
        public cikisStokHareketID: number;
        public hareketTarihi: Date;
        public miktar: number;
        public vergiliBirimFiyat: number;
        public malzemeAdi: string;
        public malzemeKodu: string;
        public malzemeTurID: string;
        public olcuBirimID: string;
        public malzemeKayitID: number;
        public malzemeDigerAciklama: string;
        public demirbasNo: number;
        public girisStokHareketID: number;
        public sonKullanimTarihi: Date;
        public barkod: string;
    }

    export class girisMakbuzDetayItem extends entitiesBaseClass {
        public makbuzDetayID: number;
        public stokHareketID: number;
        public ayniyatMakbuzID: number;
        public malzemeKayitID: number;
        public miktar: number;
        public olcuBirimID: string;
        public vergisizBirimFiyat: number;
        public indirimOrani: number;
        public indirimTutari: number;
        public kdvOrani: number;
        public vergiliBirimFiyat: number;
        public malzemeDigerAciklama: string;
        public urunBarkodu: string;
        public sonKullanmaTarihi: Date;
        public vergili_birimFiyat: number;
        public devir_kdv: number;
    }

    export class cikisFisiItem extends entitiesBaseClass {
        public turu: string;
        public belgeNo: number;
        public belgeTarihi: Date;
        public dayanakNo: string;
        public dayanakTarih: Date;
        public hareketTarihi: Date;
        public butceTuruID: string;
        public depoAdi: string;
        public depoKayitNo: number;
        public cikisDepoKayitNo: number;
        public stokHareketTurID: string;
        public cikisTCKimlikNo: string;
        public verilenKisiAdi: string;
        public cikisBirimKayitNo: number;
        public islemKayitNo: number;
        public islemTuru: string;
        public cikisBirimAdi: string;
        public hbysID: string;
    }

    export class cikisFisleriKriter extends entitiesBaseClass {
        public depoKayitNo: number;
        public butceYili: number;
        public butceTuruID: string;
        public islemTuru: string;
        public belgeNo: string;
        public belgeTarihi: Date;
    }

    export class depoGirisMakbuzGetKriter extends entitiesBaseClass {
        public depoKayitNo: number;
        public butceYili: number;
        public butceTuruID: string;
        public belgeNo: string;
        public belgeTarihi: Date;
        public fisKayitEdildigiTarih: Date;
    }

    export class girisMakbuzItem extends entitiesBaseClass {
        public ayniyatMakbuzID: number;
        public birimKayitIDGiren: number;
        public makbuzNo: number;
        public makbuzTarihi: Date;
        public cilt: string;
        public sayfa: string;
        public tedarikTurID: string;
        public butceTurID: string;
        public teslimEden: string;
        public teslimAlan: string;
        public firmaVergiKayitNo: number;
        public dayanagiBelgeNo: string;
        public dayanagiBelgeTarihi: Date;
        public fisAciklama: string;
        public depoKayitNo: number;
        public muayeneNo: string;
        public muayaneTarihi: Date;
        public alimYontemiID: string;
        public firmaAdi: string;
        public malzemeGrupID: string;
        public gonderenBirimKayitNo: number;
        public stokHareketTurID: string;
        public ihaleNo: string;
        public ihaleTarihi: Date;
        public firmaVergiNumarasi: string;
    }

    export class kisiInsertSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class kisiInsertItem extends entitiesBaseClass {
        public kisiAdi: string;
        public kisiSoyadi: string;
        public tcKimlikNo: string;
        public cinsiyet: string;
        public dogumTarihi: Date;
        public unvanKodu: string;
    }

    export class kisiKontrolSonuc extends entitiesBaseClass {
        public varMi: boolean;
        public mesaj: string;
    }

    export class makbuzKontrolSonuc extends entitiesBaseClass {
        public varMi: boolean;
        public mesaj: string;
    }

    export class stokHareketItem extends entitiesBaseClass {
        public stokHareketID: number;
        public stokHareketTurID: string;
        public islemTuru: string;
        public butceTuruID: string;
        public miktar: number;
        public vergiliBirimFiyat: number;
        public vergisizBirimFiyat: number;
        public olcuBirimID: string;
        public belgeNo: number;
        public belgeTarihi: Date;
        public dayanakBelgeNo: string;
        public dayanakBelgeTarihi: Date;
        public malzemeDigerAciklama: string;
        public depoKayitNo: number;
        public malzemeKayitID: number;
        public cikisTCKimlikNo: string;
        public uretimTarihi: Date;
        public sonKullanmaTarihi: Date;
        public demirbasNo: number;
        public girisStokHareketID: number;
        public cikisBirimDepoID: number;
        public cikisBirimKayitNo: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public malzemeTurID: string;
        public islemKayitNo: number;
        public ayniyatMakbuzID: number;
        public iadeTarihi: Date;
        public edinmeYili: number;
        public urunBarkodu: string;
        public digerBirimAdi: string;
        public hbysID: string;
        public hbysDetayID: string;
        public makbuzDetayID: number;
        public sicilNo: string;
    }

    export class stokHareketKriter extends entitiesBaseClass {
        public butceTuruID: string;
        public stokHareketTurID: string;
        public islemTuru: string;
        public butceYili: number;
        public depoKayitNo: number;
        public belgeNo: string;
        public belgeTarihi: Date;
        public girisStokHareketID: number;
    }

    export class ihtiyacFazlasiIadeItem extends entitiesBaseClass {
        public ihtiyacFazlasiHareketID: number;
        public iadeTarihi: Date;
    }

    export class ihtiyacFazlasiSonuc extends entitiesBaseClass {
        public ihtiyacFazlasiHareketID: number;
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class ihtiyacFazlasiInsertItem extends entitiesBaseClass {
        public butceTuru: EButceTurID;
        public girisStokHareketID: number;
        public aciklama: string;
        public miktar: number;
        public belgeTarihi: Date;
        public depoKayitNo: number;
    }

    export class devirFisiItem extends entitiesBaseClass {
        public cikisStokHareketID: number;
        public hareketTarihi: Date;
        public miktar: number;
        public vergiliBirimFiyat: number;
        public malzemeKayitID: number;
        public malzemeAdi: string;
        public malzemeTurID: string;
        public olcuBirimID: string;
        public malzemeDigerAciklama: string;
        public urunBarkodu: string;
        public uretimTarihi: Date;
        public sonKullanmaTarihi: Date;
        public edinmeYili: number;
    }

    export class malzemeSiniflandirmaItem extends entitiesBaseClass {
        public malzemeKayitID: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public degisiklikTarihi: Date;
        public tibbiSarfKlinikBransi: string;
        public tibbiSarfKullanimYeri: string;
        public tibbiSarfKullanimAmaci: string;
        public tibbiSarfMalzemeCinsi: string;
        public tibbiSarfSutKodu: string;
        public laboratuvarBransi: string;
        public laboratuvarCinsi: string;
        public laboratuvarSutKodu: string;
        public cerrahiAletBransi: string;
        public cerrahiAletCinsi: string;
        public cerrahiAletSutKodu: string;
        public biyomedikalCihazTur: string;
        public biyomedikalCihazTanim: string;
        public biyomedikalSarfTur: string;
        public biyomedikalSarfTanim: string;
        public biyomedikalSarfCins: string;
        public biyomedikalSarfNitelik: string;
        public biyomedikalSarfSutKodu: string;
        public ilacBarkod: string;
        public ilacAdi: string;
        public ilacJenerikKodu: string;
        public ilacJenerikAdi: string;
        public pasif: string;
        public barkodDogrulamaDurumu: string;
    }

    export class malzemeTibbiSarfItem extends entitiesBaseClass {
        public malzemeKayitID: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public degisiklikTarihi: Date;
        public olcuBirimID: string;
        public malzemeTurID: string;
        public eskiMalzemeKodu: string;
        public klinikbransi: string;
        public kullanimyeri: string;
        public kullanimamaci: string;
        public malzemecinsi: string;
        public sutKodu: string;
        public aktif: boolean;
    }

    export class malzemeItem extends entitiesBaseClass {
        public malzemeKayitID: number;
        public malzemeKodu: string;
        public malzemeAdi: string;
        public degisiklikTarihi: Date;
        public olcuBirimID: string;
        public malzemeTurID: string;
        public eskiMalzemeKodu: string;
        public aktif: boolean;
    }

    export class kurumlardanGelenDevirItem extends entitiesBaseClass {
        public turu: string;
        public cikisBelgeNo: number;
        public cikisBelgeTarihi: Date;
        public gonderenBirimAdi: string;
        public gonderenButceTuruAdi: string;
        public gonderenDepoAdi: string;
        public hareketTuru: string;
        public gonderenBirimID: number;
        public birimDepoID: number;
        public islemKayitNo: number;
        public devirGerceklestiMi: number;
    }

    export class kurumlardanGelenDevirKriter extends entitiesBaseClass {
        public ilkTarih: Date;
        public sonTarih: Date;
        public ambarlarArasiDeviriDeGetir: boolean;
    }

    export class birimUpdateItem extends entitiesBaseClass {
        public birimKayitNo: number;
        public birimKisaAdi: string;
    }

    export class birimKayitIslemleriSonuc extends entitiesBaseClass {
        public birimKayitNo: number;
        public birimAdi: string;
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class birimInsertItem extends entitiesBaseClass {
        public birimKisaAdi: string;
    }

    export class stokHareketSilSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class makbuzIptalSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class makbuzSilmeSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class makbuzDetayInsertGirisSonuc extends entitiesBaseClass {
        public ayniyatMakbuzID: number;
        public mesaj: string;
        public sonucMakbuzDetayList: Array<sonucMakbuzDetayItem>;
        public sonucStokHareketList: Array<sonucStokHareketItem>;
        public basariDurumu: boolean;
    }

    export class sonucMakbuzDetayItem extends entitiesBaseClass {
        public makbuzDetayKayitNo: number;
        public hbysMakbuzDetayKayitNo: string;
        public hataliSatir: boolean;
    }

    export class sonucStokHareketItem extends entitiesBaseClass {
        public stokHareketID: number;
        public hbysStokHareketID: string;
        public hbysDemirbasNo: string;
        public hataliSatir: boolean;
        public demirbasKayitID: number;
    }

    export class makbuzDetayInsertGirisItem extends entitiesBaseClass {
        public ayniyatMakbuzID: number;
        public makbuzDetayList: Array<makbuzDetayGirisItem>;
        public demirbasItemList: Array<demirbasGirisItem>;
    }

    export class makbuzDetayGirisItem extends entitiesBaseClass {
        public malzemeKayitID: number;
        public miktar: number;
        public olcuBirimiID: EOlcuBirimID;
        public vergisizBirimFiyat: number;
        public vergiliBirimFiyat: number;
        public indirimOrani: number;
        public indirimTutari: number;
        public kdvOrani: number;
        public malzemeDigerAciklama: string;
        public urunBarkodu: string;
        public hbysMakbuzDetayKayitNo: string;
        public sonKullanmaTarihi: Date;
        public uretimTarihi: Date;
        public edinimYili: number;
        public devirEdecekStokHareketID: number;
        public devirOrani: number;
        public stokHareketDevirID: number;
        public demirbasKayitId: number;
    }

    export class demirbasGirisItem extends entitiesBaseClass {
        public hbysMakbuzDetayKayitNo: string;
        public hbysDemirbasKayitNo: string;
        public demirbasNo: number;
        public demirbasKayitId: number;
    }

    export class makbuzInsertCikisSonuc extends entitiesBaseClass {
        public islemKayitNo: number;
        public mesaj: string;
        public sonucStokHareketList: Array<sonucStokHareketItem>;
        public basariDurumu: boolean;
    }

    export class stokHareketCikisItem extends entitiesBaseClass {
        public girisStokHareketID: number;
        public cikisMiktar: number;
        public hbysStokHareketID: string;
        public cikisTibbiCihazKunyeNo: string;
        public cikisDemirbasNo: number;
        public cikisEdinmeYili: number;
    }

    export class makbuzInsertCikisItem extends entitiesBaseClass {
        public islemTuru: ECikisIslemTuru;
        public butceTurID: EButceTurID;
        public stokHareketTurID: ECikisStokHareketTurID;
        public makbuzNo: number;
        public makbuzTarihi: Date;
        public muayaneNo: string;
        public muayeneTarihi: Date;
        public dayanagiBelgeNo: string;
        public dayanagiBelgeTarihi: Date;
        public depoKayitNo: number;
        public teslimEden: string;
        public fisAciklama: string;
        public teslimAlan: string;
        public cikisYapilanDepoKayitNo: number;
        public cikisBirimKayitNo: number;
        public cikisYapilanKisiTCKimlikNo: string;
        public doktorTCKimlikNo: string;
        public digerBirimAdi: string;
        public hbysID: string;
        public cikisStokHareketList: Array<stokHareketCikisItem>;
    }

    export class makbuzInsertGirisSonuc extends entitiesBaseClass {
        public ayniyatMakbuzID: number;
        public mesaj: string;
        public sonucMakbuzDetayList: Array<sonucMakbuzDetayItem>;
        public sonucStokHareketList: Array<sonucStokHareketItem>;
        public basariDurumu: boolean;
    }

    export class makbuzInsertGirisItem extends entitiesBaseClass {
        public islemTuru: EGirisIslemTuru;
        public butceTurID: EButceTurID;
        public tedarikTurID: ETedarikTurID;
        public malzemeGrupID: EMalzemeGrupID;
        public stokHareketTurID: EGirisStokHareketTurID;
        public makbuzNo: number;
        public makbuzTarihi: Date;
        public muayeneNo: string;
        public muayeneTarihi: Date;
        public dayanagiBelgeNo: string;
        public dayanagiBelgeTarihi: Date;
        public depoKayitNo: number;
        public teslimEden: string;
        public fisAciklama: string;
        public teslimAlan: string;
        public geldigiYer: string;
        public alimYontemiID: EAlimYontemiID;
        public gonderenBirimKayitNo: number;
        public hbysID: string;
        public ihaleTarihi: Date;
        public ihaleKayitNo: string;
        public firmaVergiKayitNo: string;
        public makbuzDetayList: Array<makbuzDetayGirisItem>;
        public demirbasItemList: Array<demirbasGirisItem>;
    }

    export class depoUpdateItem extends entitiesBaseClass {
        public depoKayitNo: number;
        public depoTanimi: string;
        public entegrasyonDurumu: EEntegrasyonDurumu;
    }

    export class depoKayitIslemleriSonuc extends entitiesBaseClass {
        public depoKayitNo: number;
        public mesaj: string;
        public basariDurumu: boolean;
    }

    export class depoInsertItem extends entitiesBaseClass {
        public depoKodu: string;
        public depoTanimi: string;
        public sorumluKisiTCKimlikNo: string;
        public entegrasyonDurumu: EEntegrasyonDurumu;
    }

    export class birimDepoItem extends entitiesBaseClass {
        public depoKayitNo: number;
        public depoKodu: string;
        public depoTanimi: string;
        public entegrasyonKapsaminda: string;
        public birimKayitNo: number;
    }

    export class birimItem extends entitiesBaseClass {
        public birimKayitNo: number;
        public birimAdi: string;
        public birimKodu: string;
        public birimKisaAdi: string;
        public tur: string;
        public faaliyetDurumu: string;
        public bagliBirimID: number;
    }

    export class ntKodItem extends entitiesBaseClass {
        public kodAdi: string;
        public degeri: string;
        public aciklama: string;
        public enumNo: number;
        public aktif: boolean;
    }

    export class ihaleTarihiUpdateResult extends entitiesBaseClass {
        public basaridurumu: boolean;
        public mesaj: string;
        public ihaleNo: string;
        public ihaleTarihi: Date;
        public ayniyatMakbuzID: number;
    }

    export class ihaleTarihiUpdateInsertItem extends entitiesBaseClass {
        public ihaleNo: string;
        public ihaleTarihi: Date;
        public ayniyatMakbuzID: number;
    }

    export class yetkiKontrolSonuc extends entitiesBaseClass {
        public firmaLisansSonuc: boolean;
        public mkysLisansSonuc: boolean;
        public mesaj: string;
        public basarili: boolean;
        public kullaniciBirimID: number;
    }

    export class devirGerceklestiriciSonuc extends entitiesBaseClass {
        public basariDurumu: boolean;
        public mesaj: string;
    }

    export class devirGerceklestiYapItem extends entitiesBaseClass {
        public stokHareketID: number;
    }

    export class malzemeTeknikOzellikResult extends entitiesBaseClass {
        public basariDurumu: boolean;
        public hataMesaji: string;
    }

    export class teknikOzellikInsertItem extends entitiesBaseClass {
        public stokHareketID: number;
        public ubbBarkodu: string;
        public cihazinAdi: string;
        public markaIsmi: string;
        public modelNo: string;
        public uretimTarihi: Date;
        public seriNo: string;
        public garantiSuresi: number;
        public bakimHizmetiAliniyormu: boolean;
        public cihazinDurumu: ECihazDurumu;
    }

    export class universiteXXXXXXleriSonucItem extends entitiesBaseClass {
        public ad: string;
        public siraNo: number;
        public stdBRKodu: number;
        public tur: string;
        public faaliyetDurumu: string;
        public hataKodu: string;
    }

    export class WebMethods {
        public static async saglik_Calisani_MiSync(siteID: Guid, kisiTCKimlikNo: string): Promise<string> {
            let url: string = "/api/MkysServisController/saglik_Calisani_MiSync";
            let inputDto = { "siteID": siteID, "kisiTCKimlikNo": kisiTCKimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as string;
            return result;
        }
        public static async universiteXXXXXXleriGetDataSync(siteID: Guid): Promise<universiteXXXXXXleriSonucItem[]> {
            let url: string = "/api/MkysServisController/universiteXXXXXXleriGetDataSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as universiteXXXXXXleriSonucItem[];
            return result;
        }
        public static async tibbiCihazTeknikOzellikInsertSync(siteID: Guid, item: teknikOzellikInsertItem[], birimDepoID: number): Promise<malzemeTeknikOzellikResult> {
            let url: string = "/api/MkysServisController/tibbiCihazTeknikOzellikInsertSync";
            let inputDto = { "siteID": siteID, "item": item, "birimDepoID": birimDepoID };
            let result = await ServiceLocator.post(url, inputDto) as malzemeTeknikOzellikResult;
            return result;
        }
        public static async devirGerceklestiIptalSync(siteID: Guid, devirListesi: devirGerceklestiYapItem[]): Promise<devirGerceklestiriciSonuc> {
            let url: string = "/api/MkysServisController/devirGerceklestiIptalSync";
            let inputDto = { "siteID": siteID, "devirListesi": devirListesi };
            let result = await ServiceLocator.post(url, inputDto) as devirGerceklestiriciSonuc;
            return result;
        }
        public static async zimmetListesiDetayGetDataSync(siteID: Guid, item: zimmetListesiGetItem): Promise<zimmetListesiGetDataResultItem[]> {
            let url: string = "/api/MkysServisController/zimmetListesiDetayGetDataSync";
            let inputDto = { "siteID": siteID, "item": item };
            let result = await ServiceLocator.post(url, inputDto) as zimmetListesiGetDataResultItem[];
            return result;
        }
        public static async servisYetkiKontrolSync(siteID: Guid): Promise<yetkiKontrolSonuc> {
            let url: string = "/api/MkysServisController/servisYetkiKontrolSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as yetkiKontrolSonuc;
            return result;
        }
        public static async ihaleTarihiVeNumarasiUpdateSync(siteID: Guid, item: ihaleTarihiUpdateInsertItem): Promise<ihaleTarihiUpdateResult> {
            let url: string = "/api/MkysServisController/ihaleTarihiVeNumarasiUpdateSync";
            let inputDto = { "siteID": siteID, "item": item };
            let result = await ServiceLocator.post(url, inputDto) as ihaleTarihiUpdateResult;
            return result;
        }
        public static async ntKodGetDataSync(siteID: Guid): Promise<ntKodItem[]> {
            let url: string = "/api/MkysServisController/ntKodGetDataSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as ntKodItem[];
            return result;
        }
        public static async devirBirimleriGetDataSync(siteID: Guid, ilKodu: string, bagliOlduguBirimKodu: number): Promise<birimItem[]> {
            let url: string = "/api/MkysServisController/devirBirimleriGetDataSync";
            let inputDto = { "siteID": siteID, "ilKodu": ilKodu, "bagliOlduguBirimKodu": bagliOlduguBirimKodu };
            let result = await ServiceLocator.post(url, inputDto) as birimItem[];
            return result;
        }
        public static async disKurumlarListesiSync(siteID: Guid, ilKodu: string, bagliOlduguBirimKodu: number): Promise<birimItem[]> {
            let url: string = "/api/MkysServisController/disKurumlarListesiSync";
            let inputDto = { "siteID": siteID, "ilKodu": ilKodu, "bagliOlduguBirimKodu": bagliOlduguBirimKodu };
            let result = await ServiceLocator.post(url, inputDto) as birimItem[];
            return result;
        }
        public static async birimDepoGetDataSync(siteID: Guid): Promise<birimDepoItem[]> {
            let url: string = "/api/MkysServisController/birimDepoGetDataSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as birimDepoItem[];
            return result;
        }
        public static async depoInsertSync(siteID: Guid, insertItem: depoInsertItem): Promise<depoKayitIslemleriSonuc> {
            let url: string = "/api/MkysServisController/depoInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as depoKayitIslemleriSonuc;
            return result;
        }
        public static async depoUpdateSync(siteID: Guid, updateItem: depoUpdateItem): Promise<depoKayitIslemleriSonuc> {
            let url: string = "/api/MkysServisController/depoUpdateSync";
            let inputDto = { "siteID": siteID, "updateItem": updateItem };
            let result = await ServiceLocator.post(url, inputDto) as depoKayitIslemleriSonuc;
            return result;
        }
        public static async makbuzInsertGirisSync(siteID: Guid, insertItem: makbuzInsertGirisItem): Promise<makbuzInsertGirisSonuc> {
            let url: string = "/api/MkysServisController/makbuzInsertGirisSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as makbuzInsertGirisSonuc;
            return result;
        }
        public static async makbuzInsertCikisSync(siteID: Guid, insertItem: makbuzInsertCikisItem): Promise<makbuzInsertCikisSonuc> {
            let url: string = "/api/MkysServisController/makbuzInsertCikisSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as makbuzInsertCikisSonuc;
            return result;
        }
        public static async makbuzDetayInsertGirisSync(siteID: Guid, insertItem: makbuzDetayInsertGirisItem): Promise<makbuzDetayInsertGirisSonuc> {
            let url: string = "/api/MkysServisController/makbuzDetayInsertGirisSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as makbuzDetayInsertGirisSonuc;
            return result;
        }
        public static async girisMakbuzDeleteSync(siteID: Guid, ayniyatMakbuzID: number): Promise<makbuzSilmeSonuc> {
            let url: string = "/api/MkysServisController/girisMakbuzDeleteSync";
            let inputDto = { "siteID": siteID, "ayniyatMakbuzID": ayniyatMakbuzID };
            let result = await ServiceLocator.post(url, inputDto) as makbuzSilmeSonuc;
            return result;
        }
        public static async girisMakbuzIptalSync(siteID: Guid, ayniyatMakbuzID: number): Promise<makbuzIptalSonuc> {
            let url: string = "/api/MkysServisController/girisMakbuzIptalSync";
            let inputDto = { "siteID": siteID, "ayniyatMakbuzID": ayniyatMakbuzID };
            let result = await ServiceLocator.post(url, inputDto) as makbuzIptalSonuc;
            return result;
        }
        public static async cikisMakbuzDeleteSync(siteID: Guid, islemKayitNo: number): Promise<makbuzSilmeSonuc> {
            let url: string = "/api/MkysServisController/cikisMakbuzDeleteSync";
            let inputDto = { "siteID": siteID, "islemKayitNo": islemKayitNo };
            let result = await ServiceLocator.post(url, inputDto) as makbuzSilmeSonuc;
            return result;
        }
        public static async stokHareketDeleteSync(siteID: Guid, stokHareketID: number): Promise<stokHareketSilSonuc> {
            let url: string = "/api/MkysServisController/stokHareketDeleteSync";
            let inputDto = { "siteID": siteID, "stokHareketID": stokHareketID };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketSilSonuc;
            return result;
        }
        public static async birimGetDataSync(siteID: Guid): Promise<birimItem[]> {
            let url: string = "/api/MkysServisController/birimGetDataSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as birimItem[];
            return result;
        }
        public static async birimInsertSync(siteID: Guid, insertItem: birimInsertItem): Promise<birimKayitIslemleriSonuc> {
            let url: string = "/api/MkysServisController/birimInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as birimKayitIslemleriSonuc;
            return result;
        }
        public static async birimUpdateSync(siteID: Guid, updateItem: birimUpdateItem): Promise<birimKayitIslemleriSonuc> {
            let url: string = "/api/MkysServisController/birimUpdateSync";
            let inputDto = { "siteID": siteID, "updateItem": updateItem };
            let result = await ServiceLocator.post(url, inputDto) as birimKayitIslemleriSonuc;
            return result;
        }
        public static async tumBirimlerGetDataSync(siteID: Guid, birimAdi: string): Promise<birimItem[]> {
            let url: string = "/api/MkysServisController/tumBirimlerGetDataSync";
            let inputDto = { "siteID": siteID, "birimAdi": birimAdi };
            let result = await ServiceLocator.post(url, inputDto) as birimItem[];
            return result;
        }
        public static async kurumlardanGelenDevirlerGetDataSync(siteID: Guid, kriter: kurumlardanGelenDevirKriter): Promise<kurumlardanGelenDevirItem[]> {
            let url: string = "/api/MkysServisController/kurumlardanGelenDevirlerGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as kurumlardanGelenDevirItem[];
            return result;
        }
        public static async malzemeGetDataSync(siteID: Guid, gunlemeTarihi: Date): Promise<malzemeItem[]> {
            let url: string = "/api/MkysServisController/malzemeGetDataSync";
            let inputDto = { "siteID": siteID, "gunlemeTarihi": gunlemeTarihi };
            let result = await ServiceLocator.post(url, inputDto) as malzemeItem[];
            return result;
        }
        public static async malzemetibbiSarfGetDataSync(siteID: Guid, degisiklikTarihi: Date): Promise<malzemeTibbiSarfItem[]> {
            let url: string = "/api/MkysServisController/malzemetibbiSarfGetDataSync";
            let inputDto = { "siteID": siteID, "degisiklikTarihi": degisiklikTarihi };
            let result = await ServiceLocator.post(url, inputDto) as malzemeTibbiSarfItem[];
            return result;
        }
        public static async malzemeSiniflandirmaGetDataSync(siteID: Guid, degisiklikTarihi: Date, depoTuru: EDepoTurId): Promise<malzemeSiniflandirmaItem[]> {
            let url: string = "/api/MkysServisController/malzemeSiniflandirmaGetDataSync";
            let inputDto = { "siteID": siteID, "degisiklikTarihi": degisiklikTarihi, "depoTuru": depoTuru };
            let result = await ServiceLocator.post(url, inputDto) as malzemeSiniflandirmaItem[];
            return result;
        }
        public static async devirFisiGetSync(siteID: Guid, islemKayitNo: number): Promise<devirFisiItem[]> {
            let url: string = "/api/MkysServisController/devirFisiGetSync";
            let inputDto = { "siteID": siteID, "islemKayitNo": islemKayitNo };
            let result = await ServiceLocator.post(url, inputDto) as devirFisiItem[];
            return result;
        }
        public static async devirGerceklestiYapSync(siteID: Guid, devirListesi: devirGerceklestiYapItem[]): Promise<devirGerceklestiriciSonuc> {
            let url: string = "/api/MkysServisController/devirGerceklestiYapSync";
            let inputDto = { "siteID": siteID, "devirListesi": devirListesi };
            let result = await ServiceLocator.post(url, inputDto) as devirGerceklestiriciSonuc;
            return result;
        }
        public static async ihtiyacFazlasiInsertSync(siteID: Guid, insertItem: ihtiyacFazlasiInsertItem): Promise<ihtiyacFazlasiSonuc> {
            let url: string = "/api/MkysServisController/ihtiyacFazlasiInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as ihtiyacFazlasiSonuc;
            return result;
        }
        public static async ihtiyacFazlasiIadeSync(siteID: Guid, iadeItem: ihtiyacFazlasiIadeItem): Promise<ihtiyacFazlasiSonuc> {
            let url: string = "/api/MkysServisController/ihtiyacFazlasiIadeSync";
            let inputDto = { "siteID": siteID, "iadeItem": iadeItem };
            let result = await ServiceLocator.post(url, inputDto) as ihtiyacFazlasiSonuc;
            return result;
        }
        public static async stokHareketGetDataSync(siteID: Guid, kriter: stokHareketKriter): Promise<stokHareketItem[]> {
            let url: string = "/api/MkysServisController/stokHareketGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketItem[];
            return result;
        }
        public static async makbuzVarMiSync(siteID: Guid, ayniyatMakbuzID: number): Promise<makbuzKontrolSonuc> {
            let url: string = "/api/MkysServisController/makbuzVarMiSync";
            let inputDto = { "siteID": siteID, "ayniyatMakbuzID": ayniyatMakbuzID };
            let result = await ServiceLocator.post(url, inputDto) as makbuzKontrolSonuc;
            return result;
        }
        public static async kisiVarMiSync(siteID: Guid, kisiTCKimlikNo: string): Promise<kisiKontrolSonuc> {
            let url: string = "/api/MkysServisController/kisiVarMiSync";
            let inputDto = { "siteID": siteID, "kisiTCKimlikNo": kisiTCKimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as kisiKontrolSonuc;
            return result;
        }
        public static async kisiInsertSync(siteID: Guid, insertItem: kisiInsertItem): Promise<kisiInsertSonuc> {
            let url: string = "/api/MkysServisController/kisiInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as kisiInsertSonuc;
            return result;
        }
        public static async makbuzSelectSync(siteID: Guid, ayniyatMakbuzID: number): Promise<girisMakbuzItem> {
            let url: string = "/api/MkysServisController/makbuzSelectSync";
            let inputDto = { "siteID": siteID, "ayniyatMakbuzID": ayniyatMakbuzID };
            let result = await ServiceLocator.post(url, inputDto) as girisMakbuzItem;
            return result;
        }
        public static async depoGirisMakbuzGetDataSync(siteID: Guid, kriter: depoGirisMakbuzGetKriter): Promise<girisMakbuzItem[]> {
            let url: string = "/api/MkysServisController/depoGirisMakbuzGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as girisMakbuzItem[];
            return result;
        }
        public static async depoCikisMakbuzGetDataSync(siteID: Guid, kriter: cikisFisleriKriter): Promise<cikisFisiItem[]> {
            let url: string = "/api/MkysServisController/depoCikisMakbuzGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as cikisFisiItem[];
            return result;
        }
        public static async cikisFisGetDataSync(siteID: Guid, kriter: cikisFisleriKriter): Promise<cikisFisiItem[]> {
            let url: string = "/api/MkysServisController/cikisFisGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as cikisFisiItem[];
            return result;
        }
        public static async makbuzDetayGetDataSync(siteID: Guid, ayniyatMakbuzID: number, butceYili: number, butceTuru: EButceTurID): Promise<girisMakbuzDetayItem[]> {
            let url: string = "/api/MkysServisController/makbuzDetayGetDataSync";
            let inputDto = { "siteID": siteID, "ayniyatMakbuzID": ayniyatMakbuzID, "butceYili": butceYili, "butceTuru": butceTuru };
            let result = await ServiceLocator.post(url, inputDto) as girisMakbuzDetayItem[];
            return result;
        }
        public static async cikisFisDetayGetDataSync(siteID: Guid, islemKayitNo: number): Promise<cikisFisDetayItem[]> {
            let url: string = "/api/MkysServisController/cikisFisDetayGetDataSync";
            let inputDto = { "siteID": siteID, "islemKayitNo": islemKayitNo };
            let result = await ServiceLocator.post(url, inputDto) as cikisFisDetayItem[];
            return result;
        }
        public static async aracInsertSync(siteID: Guid, insertItem: aracInsertItem): Promise<aracInsertSonuc> {
            let url: string = "/api/MkysServisController/aracInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as aracInsertSonuc;
            return result;
        }
        public static async degerArtisiInsertSync(siteID: Guid, insertItem: degerArtisiInsertItem): Promise<degerArtisiSonuc> {
            let url: string = "/api/MkysServisController/degerArtisiInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as degerArtisiSonuc;
            return result;
        }
        public static async demirbaslariDevretSync(siteID: Guid, insertItem: demirbasDevirItem): Promise<demirbasDevirSonuc> {
            let url: string = "/api/MkysServisController/demirbaslariDevretSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as demirbasDevirSonuc;
            return result;
        }
        public static async kayittanDusmeInsertSync(siteID: Guid, insertItem: kayittanDusmeInsertItem): Promise<kayittanDusmeSonuc> {
            let url: string = "/api/MkysServisController/kayittanDusmeInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as kayittanDusmeSonuc;
            return result;
        }
        public static async kitapInsertUpdateSync(siteID: Guid, insertUpdateItem: kitapInsertUpdateItem): Promise<kitapInsertUpdateSonuc> {
            let url: string = "/api/MkysServisController/kitapInsertUpdateSync";
            let inputDto = { "siteID": siteID, "insertUpdateItem": insertUpdateItem };
            let result = await ServiceLocator.post(url, inputDto) as kitapInsertUpdateSonuc;
            return result;
        }
        public static async girisStokHareketGetSync(siteID: Guid, makbuzDetayID: number, butceYili: number, butceTuru: EButceTurID): Promise<stokHareketItem[]> {
            let url: string = "/api/MkysServisController/girisStokHareketGetSync";
            let inputDto = { "siteID": siteID, "makbuzDetayID": makbuzDetayID, "butceYili": butceYili, "butceTuru": butceTuru };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketItem[];
            return result;
        }
        public static async zimmetInsertSync(siteID: Guid, insertItem: zimmetInsertItem): Promise<zimmetInsertSonuc> {
            let url: string = "/api/MkysServisController/zimmetInsertSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as zimmetInsertSonuc;
            return result;
        }
        public static async zimmettenAlSync(siteID: Guid, insertItem: zimmettenAlInsertItem): Promise<zimmettenAlSonuc> {
            let url: string = "/api/MkysServisController/zimmettenAlSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as zimmettenAlSonuc;
            return result;
        }
        public static async zimmetListesiGetDataSync(siteID: Guid): Promise<zimmetItem[]> {
            let url: string = "/api/MkysServisController/zimmetListesiGetDataSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as zimmetItem[];
            return result;
        }
        public static async ihtiyacFazlasiGetDataSync(siteID: Guid, kriter: ihtiyacFazlasiKriterItem): Promise<ihtiyacFazlasiItem[]> {
            let url: string = "/api/MkysServisController/ihtiyacFazlasiGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as ihtiyacFazlasiItem[];
            return result;
        }
        public static async firmaSifreDegistirSync(siteID: Guid, kullaniciAdi: string, eskiSifre: string, yeniSifre: string): Promise<sifreDegistirSonuc> {
            let url: string = "/api/MkysServisController/firmaSifreDegistirSync";
            let inputDto = { "siteID": siteID, "kullaniciAdi": kullaniciAdi, "eskiSifre": eskiSifre, "yeniSifre": yeniSifre };
            let result = await ServiceLocator.post(url, inputDto) as sifreDegistirSonuc;
            return result;
        }
        public static async girisMakbuzundanCikisYapilmisMi2Sync(siteID: Guid, stokHareketID: number): Promise<cikisKontrolSonuc> {
            let url: string = "/api/MkysServisController/girisMakbuzundanCikisYapilmisMi2Sync";
            let inputDto = { "siteID": siteID, "stokHareketID": stokHareketID };
            let result = await ServiceLocator.post(url, inputDto) as cikisKontrolSonuc;
            return result;
        }
        public static async girisMakbuzundanCikisYapilmisMiSync(siteID: Guid, ayniyatMakbuzID: number): Promise<cikisKontrolSonuc> {
            let url: string = "/api/MkysServisController/girisMakbuzundanCikisYapilmisMiSync";
            let inputDto = { "siteID": siteID, "ayniyatMakbuzID": ayniyatMakbuzID };
            let result = await ServiceLocator.post(url, inputDto) as cikisKontrolSonuc;
            return result;
        }
        public static async stokSeviyesiInsertSync(siteID: Guid, item: stokSeviyesiInsertItem): Promise<stokSeviyesiInsertSonuc> {
            let url: string = "/api/MkysServisController/stokSeviyesiInsertSync";
            let inputDto = { "siteID": siteID, "item": item };
            let result = await ServiceLocator.post(url, inputDto) as stokSeviyesiInsertSonuc;
            return result;
        }
        public static async aracModelGetDataSync(siteID: Guid, markaID: string): Promise<aracModelItem[]> {
            let url: string = "/api/MkysServisController/aracModelGetDataSync";
            let inputDto = { "siteID": siteID, "markaID": markaID };
            let result = await ServiceLocator.post(url, inputDto) as aracModelItem[];
            return result;
        }
        public static async depoYetkiKontrolSync(siteID: Guid, kontrol: depoYetkiKontrolItem): Promise<depoYetkiKontrolSonuc> {
            let url: string = "/api/MkysServisController/depoYetkiKontrolSync";
            let inputDto = { "siteID": siteID, "kontrol": kontrol };
            let result = await ServiceLocator.post(url, inputDto) as depoYetkiKontrolSonuc;
            return result;
        }
        public static async cikisFisiVarMiSync(siteID: Guid, islemKayitNo: number, hbysID: string): Promise<boolean> {
            let url: string = "/api/MkysServisController/cikisFisiVarMiSync";
            let inputDto = { "siteID": siteID, "islemKayitNo": islemKayitNo, "hbysID": hbysID };
            let result = await ServiceLocator.post(url, inputDto) as boolean;
            return result;
        }
        public static async stokHareketUpdateSync(siteID: Guid, stok: stokHareketUpdateItem[]): Promise<mkysSonuc> {
            let url: string = "/api/MkysServisController/stokHareketUpdateSync";
            let inputDto = { "siteID": siteID, "stok": stok };
            let result = await ServiceLocator.post(url, inputDto) as mkysSonuc;
            return result;
        }
        public static async unvanTurGetDataSync(siteID: Guid, unvanAdi: string): Promise<unvanTurItem[]> {
            let url: string = "/api/MkysServisController/unvanTurGetDataSync";
            let inputDto = { "siteID": siteID, "unvanAdi": unvanAdi };
            let result = await ServiceLocator.post(url, inputDto) as unvanTurItem[];
            return result;
        }
        public static async firmaBilgileriGetVergiNoSync(siteID: Guid, firmaVergiNo: string): Promise<firmaBilgileriGetVergiNoSonuc[]> {
            let url: string = "/api/MkysServisController/firmaBilgileriGetVergiNoSync";
            let inputDto = { "siteID": siteID, "firmaVergiNo": firmaVergiNo };
            let result = await ServiceLocator.post(url, inputDto) as firmaBilgileriGetVergiNoSonuc[];
            return result;
        }
        public static async firmaBilgileriGetSync(siteID: Guid, firmaKodu: number): Promise<firmaBilgileriGetItem[]> {
            let url: string = "/api/MkysServisController/firmaBilgileriGetSync";
            let inputDto = { "siteID": siteID, "firmaKodu": firmaKodu };
            let result = await ServiceLocator.post(url, inputDto) as firmaBilgileriGetItem[];
            return result;
        }
        public static async eksiBakiyeStoklarGetDataSync(siteID: Guid, kriter: yilSonuKriter): Promise<stokHareketYilSonuItem[]> {
            let url: string = "/api/MkysServisController/eksiBakiyeStoklarGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketYilSonuItem[];
            return result;
        }
        public static async fiyatiFarkliOlanStoklarGetDataSync(siteID: Guid, kriter: yilSonuKriter): Promise<stokHareketYilSonuItem[]> {
            let url: string = "/api/MkysServisController/fiyatiFarkliOlanStoklarGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketYilSonuItem[];
            return result;
        }
        public static async butceTuruFarkliOlanStoklarGetDataSync(siteID: Guid, kriter: yilSonuKriter): Promise<stokHareketYilSonuItem[]> {
            let url: string = "/api/MkysServisController/butceTuruFarkliOlanStoklarGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketYilSonuItem[];
            return result;
        }
        public static async deposuFarkliOlanStoklarGetDataSync(siteID: Guid, kriter: yilSonuKriter): Promise<stokHareketYilSonuItem[]> {
            let url: string = "/api/MkysServisController/deposuFarkliOlanStoklarGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketYilSonuItem[];
            return result;
        }
        public static async malzemeIDFarkliStoklarGetDataSync(siteID: Guid, kriter: yilSonuKriter): Promise<stokHareketYilSonuItem[]> {
            let url: string = "/api/MkysServisController/malzemeIDFarkliStoklarGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketYilSonuItem[];
            return result;
        }
        public static async stokDurumGetDataSync(siteID: Guid, kriter: yilSonuKriter): Promise<stokHareketYilSonuItem[]> {
            let url: string = "/api/MkysServisController/stokDurumGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketYilSonuItem[];
            return result;
        }
        public static async stokHareketLogGetDataSync(siteID: Guid, stokHareketID: number): Promise<stokHareketLogItem[]> {
            let url: string = "/api/MkysServisController/stokHareketLogGetDataSync";
            let inputDto = { "siteID": siteID, "stokHareketID": stokHareketID };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketLogItem[];
            return result;
        }
        public static async barkodUpdateSync(siteID: Guid, stokHareketID: number, barkod: string): Promise<mkysSonuc> {
            let url: string = "/api/MkysServisController/barkodUpdateSync";
            let inputDto = { "siteID": siteID, "stokHareketID": stokHareketID, "barkod": barkod };
            let result = await ServiceLocator.post(url, inputDto) as mkysSonuc;
            return result;
        }
        public static async makbuzUpdateSync(siteID: Guid, makbuz: ayniyatMakbuzuUpdateItem[]): Promise<mkysSonuc> {
            let url: string = "/api/MkysServisController/makbuzUpdateSync";
            let inputDto = { "siteID": siteID, "makbuz": makbuz };
            let result = await ServiceLocator.post(url, inputDto) as mkysSonuc;
            return result;
        }
        public static async yonetimHesabiCetveliGetDataSync(siteID: Guid, kriter: yonetimHesabiKriter): Promise<yonetimHesabiCetveliItem[]> {
            let url: string = "/api/MkysServisController/yonetimHesabiCetveliGetDataSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as yonetimHesabiCetveliItem[];
            return result;
        }
        public static async ilacSorgulaSync(siteID: Guid, barkod: string, ilacAdi: string): Promise<ilacSorgulamaSonuc> {
            let url: string = "/api/MkysServisController/ilacSorgulaSync";
            let inputDto = { "siteID": siteID, "barkod": barkod, "ilacAdi": ilacAdi };
            let result = await ServiceLocator.post(url, inputDto) as ilacSorgulamaSonuc;
            return result;
        }
        public static async mukerrerCikisGetDataSync(siteID: Guid, butceYili: number, depoKayitNo: number, butceTurID: string): Promise<mukerrerStokHareketItem[]> {
            let url: string = "/api/MkysServisController/mukerrerCikisGetDataSync";
            let inputDto = { "siteID": siteID, "butceYili": butceYili, "depoKayitNo": depoKayitNo, "butceTurID": butceTurID };
            let result = await ServiceLocator.post(url, inputDto) as mukerrerStokHareketItem[];
            return result;
        }
        public static async stokTedarikTuruUpdateSync(siteID: Guid, ayniyatMakbuzID: number, tedarikTuru: ETedarikTurID, stokHareketTuru: EGirisStokHareketTurID): Promise<mkysSonuc> {
            let url: string = "/api/MkysServisController/stokTedarikTuruUpdateSync";
            let inputDto = { "siteID": siteID, "ayniyatMakbuzID": ayniyatMakbuzID, "tedarikTuru": tedarikTuru, "stokHareketTuru": stokHareketTuru };
            let result = await ServiceLocator.post(url, inputDto) as mkysSonuc;
            return result;
        }
        public static async girisiOlmayanCikislarSync(siteID: Guid, birimKayitID: number, butceYili: number, depoKayitNo: number, butceTurID: string, tasinirKodu: string): Promise<girisiOlmayanCikislarItem[]> {
            let url: string = "/api/MkysServisController/girisiOlmayanCikislarSync";
            let inputDto = { "siteID": siteID, "birimKayitID": birimKayitID, "butceYili": butceYili, "depoKayitNo": depoKayitNo, "butceTurID": butceTurID, "tasinirKodu": tasinirKodu };
            let result = await ServiceLocator.post(url, inputDto) as girisiOlmayanCikislarItem[];
            return result;
        }
        public static async firmaBilgileriGetTumuSync(siteID: Guid): Promise<firmaBilgileriGetTumuSonuc[]> {
            let url: string = "/api/MkysServisController/firmaBilgileriGetTumuSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as firmaBilgileriGetTumuSonuc[];
            return result;
        }
        public static async malzemeBilgileriUpdateSync(siteID: Guid, item: malzemeBilgileriUpdateItem[]): Promise<mkysSonuc> {
            let url: string = "/api/MkysServisController/malzemeBilgileriUpdateSync";
            let inputDto = { "siteID": siteID, "item": item };
            let result = await ServiceLocator.post(url, inputDto) as mkysSonuc;
            return result;
        }
        public static async sonKullanmaTarihiUpdateSync(siteID: Guid, insertItem: sonKullanmaUpdateInsertItem): Promise<mkysSonuc> {
            let url: string = "/api/MkysServisController/sonKullanmaTarihiUpdateSync";
            let inputDto = { "siteID": siteID, "insertItem": insertItem };
            let result = await ServiceLocator.post(url, inputDto) as mkysSonuc;
            return result;
        }
        public static async birimBilgileriGetiriciSync(siteID: Guid, birimKayitID: number): Promise<birimItem[]> {
            let url: string = "/api/MkysServisController/birimBilgileriGetiriciSync";
            let inputDto = { "siteID": siteID, "birimKayitID": birimKayitID };
            let result = await ServiceLocator.post(url, inputDto) as birimItem[];
            return result;
        }
        public static async stokHareketGirisLogGetDataSync(siteID: Guid, ayniatMakbuzID: number): Promise<stokHareketLogItem[]> {
            let url: string = "/api/MkysServisController/stokHareketGirisLogGetDataSync";
            let inputDto = { "siteID": siteID, "ayniatMakbuzID": ayniatMakbuzID };
            let result = await ServiceLocator.post(url, inputDto) as stokHareketLogItem[];
            return result;
        }
        public static async amortismanInsertSync(siteID: Guid, item: amortismanInsertItem): Promise<amortismanInsertSonuc> {
            let url: string = "/api/MkysServisController/amortismanInsertSync";
            let inputDto = { "siteID": siteID, "item": item };
            let result = await ServiceLocator.post(url, inputDto) as amortismanInsertSonuc;
            return result;
        }
        public static async guncelMalzemeGetDataSync(siteID: Guid, guncellemeTarihi: Date): Promise<malzemeItem[]> {
            let url: string = "/api/MkysServisController/guncelMalzemeGetDataSync";
            let inputDto = { "siteID": siteID, "guncellemeTarihi": guncellemeTarihi };
            let result = await ServiceLocator.post(url, inputDto) as malzemeItem[];
            return result;
        }
        public static async demirbasGetDataSync(siteID: Guid, depoKayitNo: number, butceyili: number): Promise<demirbasGetDataResult[]> {
            let url: string = "/api/MkysServisController/demirbasGetDataSync";
            let inputDto = { "siteID": siteID, "depoKayitNo": depoKayitNo, "butceyili": butceyili };
            let result = await ServiceLocator.post(url, inputDto) as demirbasGetDataResult[];
            return result;
        }
        public static async malzemeZimmetBilgisiSync(siteID: Guid, depoKayitNo: number, stokHareketID: number, butceYili: number): Promise<malzemeZimmetBilgisiResult[]> {
            let url: string = "/api/MkysServisController/malzemeZimmetBilgisiSync";
            let inputDto = { "siteID": siteID, "depoKayitNo": depoKayitNo, "stokHareketID": stokHareketID, "butceYili": butceYili };
            let result = await ServiceLocator.post(url, inputDto) as malzemeZimmetBilgisiResult[];
            return result;
        }
        public static async giriseAitCikislarSync(siteID: Guid, stokHareketID: number): Promise<giriseAitCikislarResultItem[]> {
            let url: string = "/api/MkysServisController/giriseAitCikislarSync";
            let inputDto = { "siteID": siteID, "stokHareketID": stokHareketID };
            let result = await ServiceLocator.post(url, inputDto) as giriseAitCikislarResultItem[];
            return result;
        }
        public static async yilSonuDevirDetayBilgileriSync(siteID: Guid, item: yilSonuDevriItem): Promise<yilSonuDevriSonucItem[]> {
            let url: string = "/api/MkysServisController/yilSonuDevirDetayBilgileriSync";
            let inputDto = { "siteID": siteID, "item": item };
            let result = await ServiceLocator.post(url, inputDto) as yilSonuDevriSonucItem[];
            return result;
        }
    }
}
