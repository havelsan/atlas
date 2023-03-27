//$69263266
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export namespace RaporIslemleri {
    export class raporGirisDVO {
        public saglikTesisKodu: number;
        public ilacRapor: ilacRaporDVO;
        public tedaviRapor: tedaviRaporDVO;
        public isgoremezlikRapor: isgoremezlikRaporDVO;
        public maluliyetRapor: maluliyetRaporDVO;
    }

    export class ilacRaporDVO {
        public raporDVO: raporDVO;
        public takipFormuNo: string;
        public raporEtkinMaddeler: Array<raporEtkinMaddeDVO>;
    }

    export class raporDVO {
        public raporBilgisi: raporBilgisiDVO;
        public turu: string;
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public duzenlemeTuru: string;
        public hakSahibi: hakSahibiBilgisiDVO;
        public protokolNo: string;
        public protokolTarihi: string;
        public durum: string;
        public aciklama: string;
        public doktorlar: Array<doktorBilgisiDVO>;
        public tanilar: Array<taniBilgisiDVO>;
        public teshisler: Array<teshisBilgisiDVO>;
        public ilacTeshisler: Array<ilacTeshisBilgiDVO>;
        public takipNo: string;
        public klinikTani: string;
        public ozelDurum: number;
    }

    export class raporBilgisiDVO {
        public raporTesisKodu: number;
        public tarih: string;
        public no: string;
        public raporTakipNo: string;
        public raporSiraNo: number;
        public aVakaTKaza: number;
    }

    export class ilacRaporDuzeltDVO {
        public raporNo: string;
        public raporTarihi: string;
        public saglikTesisKodu: number;
        public raporTuru: string;
        public duzeltmeTarihi: string;
        public duzeltmeBilgisi: string;
        public drTescilNo: string;
        public raporEtkinMaddeler: Array<raporEtkinMaddeDVO>;
        public tanilar: Array<taniBilgisiDVO>;
        public ilacTeshisler: Array<ilacTeshisBilgiDVO>;
    }

    export class raporEtkinMaddeDVO {
        public etkinMaddeKodu: string;
        public kullanimDoz1: number;
        public kullanimDoz2: number;
        public kullanimDozBirim: string;
        public kullanimPeriyot: number;
        public kullanimPeriyotBirim: string;
    }

    export class taniBilgisiDVO {
        public taniKodu: string;
    }

    export class ilacTeshisBilgiDVO {
        public teshisKodu: number;
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public ICD10Kodu: Array<taniBilgisiDVO>;
    }

    export class raporCevapTCKimlikNodanDVO {
        public raporlar: Array<raporCevapDVO>;
        public sonucKodu: number;
        public sonucAciklamasi: string;
    }

    export class raporCevapDVO {
        public raporTakipNo: number;
        public sonucKodu: number;
        public sonucAciklamasi: string;
        public isgoremezlikRapor: isgoremezlikRaporDVO;
        public isgoremezlikRaporEkleri: Array<isgoremezlikRaporEkDVO>;
        public dogumOncesiCalisabilirRapor: dogumOncesiCalisabilirRaporDVO;
        public dogumRapor: dogumRaporDVO;
        public analikRapor: analikIsgoremezlikRaporDVO;
        public protezRapor: protezRaporDVO;
        public ilacRapor: ilacRaporDVO;
        public tedaviRapor: tedaviRaporDVO;
        public maluliyetRapor: maluliyetRaporDVO;
        public raporTuru: string;
    }

    export class isgoremezlikRaporDVO {
        public raporDVO: raporDVO;
        public isGoremezlikRaporTuru: number;
        public bransKodu: number;
        public teshis: string;
        public olum: string;
        public klinikBulgu: string;
        public ronLabBilgi: string;
        public karar: string;
        public isKazasiRaporu: isKazasiRaporDVO;
        public meslekHastaligiRaporu: meslekHastaligiRaporDVO;
        public analikRaporu: analikRaporDVO;
        public emzirmeRaporu: emzirmeRaporDVO;
        public hastalikRaporu: hastalikRaporDVO;
        public devammi: number;
        public yatisDevam: string;
    }

    export class isKazasiRaporDVO {
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public raporDurumu: string;
        public isKontTarihi: string;
        public XXXXXXYatisTarihi: string;
        public XXXXXXCikisTarihi: string;
        public nuks: string;
        public yaraninTuru: string;
        public yaraninYeri: string;
        public taburcuTarihi: string;
        public taburcuKodu: number;
        public isKazasiTarihi: string;
    }

    export class meslekHastaligiRaporDVO {
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public raporDurumu: string;
        public isKontTarihi: string;
        public XXXXXXYatisTarihi: string;
        public XXXXXXCikisTarihi: string;
        public nuks: string;
        public yaraninTuru: string;
        public yaraninYeri: string;
        public taburcuTarihi: string;
        public taburcuKodu: number;
    }

    export class analikRaporDVO {
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public raporDurumu: string;
        public isKontTarihi: string;
        public XXXXXXYatisTarihi: string;
        public XXXXXXCikisTarihi: string;
        public bebekDogumTarihi: string;
        public canliCocukSayisi: number;
        public doganCocukSayisi: number;
        public norSezFor: string;
        public taburcuTarihi: string;
        public taburcuKodu: number;
        public gebelikTipi: number;
        public gebelikHaftasi1: number;
        public gebelikHaftasi2: number;
        public bebekDogumHaftasi: number;
        public aktarmaHaftasi: number;
        public analikRaporTipi: number;
    }

    export class emzirmeRaporDVO {
        public bebekDogumTarihi: string;
        public canliCocukSayisi: number;
        public doganCocukSayisi: number;
        public anneTcKimlikNo: string;
    }

    export class hastalikRaporDVO {
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public raporDurumu: string;
        public isKontTarihi: string;
        public XXXXXXYatisTarihi: string;
        public XXXXXXCikisTarihi: string;
        public taburcuTarihi: string;
        public taburcuKodu: number;
        public nuks: string;
    }

    export class isgoremezlikRaporEkDVO {
        public kullaniciTesisKodu: number;
        public raporBilgisiDVO: raporBilgisiDVO;
        public kontrolMu: string;
        public kontrolTarihi: string;
        public hastaYatisVarMi: string;
        public yatislar: Array<hastaYatisBilgisiDVO>;
        public bitisTarihi: string;
        public duzenlemeTuru: string;
        public protokolNo: string;
        public protokolTarihi: string;
        public durum: string;
        public aciklama: string;
        public doktorlar: Array<doktorBilgisiDVO>;
        public tanilar: Array<taniBilgisiDVO>;
    }

    export class hastaYatisBilgisiDVO {
        public yatisTarihi: string;
        public cikisTarihi: string;
    }

    export class doktorBilgisiDVO {
        public drTescilNo: string;
        public drAdi: string;
        public drSoyadi: string;
        public drBransKodu: string;
        public tipi: string;
    }

    export class dogumOncesiCalisabilirRaporDVO {
        public raporDVO: raporDVO;
        public bebekDogumTarihi: string;
        public dogumIzniBaslangicTarihi: string;
    }

    export class dogumRaporDVO {
        public raporDVO: raporDVO;
        public bebekDogumTarihi: string;
        public cocukSayisi: number;
        public canliCocukSayisi: number;
        public dogumTipi: string;
        public epizyotemi: string;
        public anesteziTipi: string;
        public cocuklar: Array<cocukBilgisiDVO>;
    }

    export class cocukBilgisiDVO {
        public cinsiyet: string;
        public kilo: string;
        public dogumSaati: string;
    }

    export class analikIsgoremezlikRaporDVO {
        public raporDVO: raporDVO;
        public bebekDogumTarihi: string;
        public cocukSayisi: number;
    }

    export class protezRaporDVO {
        public raporDVO: raporDVO;
        public malzemeler: Array<malzemeBilgisiDVO>;
    }

    export class malzemeBilgisiDVO {
        public malzemeKodu: string;
        public malzemeAdi: string;
        public malzemeTuru: string;
        public adet: number;
    }

    export class tedaviRaporDVO {
        public raporDVO: raporDVO;
        public islemler: Array<tedaviIslemBilgisiDVO>;
        public tedaviRaporTuru: number;
    }

    export class tedaviIslemBilgisiDVO {
        public diyalizRaporBilgisi: diyalizRaporBilgisiDVO;
        public hotRaporBilgisi: hotRaporBilgisiDVO;
        public eswtRaporBilgisi: eswtRaporBilgisiDVO;
        public tupBebekRaporBilgisi: tupBebekRaporBilgisiDVO;
        public ftrRaporBilgisi: ftrRaporBilgisiDVO;
        public eswlRaporBilgisi: eswlRaporBilgisiDVO;
        public evHemodiyaliziRaporBilgisi: evHemodiyaliziRaporBilgisiDVO;
    }

    export class diyalizRaporBilgisiDVO {
        public butKodu: string;
        public seansSayi: number;
        public seansGun: number;
        public refakatVarMi: string;
    }

    export class hotRaporBilgisiDVO {
        public tedaviSuresi: number;
        public seansSayi: number;
        public seansGun: number;
    }

    export class eswtRaporBilgisiDVO {
        public butKodu: string;
        public eswtVucutBolgesiKodu: number;
        public seansSayi: number;
        public seansGun: number;
    }

    export class tupBebekRaporBilgisiDVO {
        public butKodu: string;
        public tupBebekRaporTuru: number;
    }

    export class ftrRaporBilgisiDVO {
        public butKodu: string;
        public seansSayi: number;
        public seansGun: number;
        public ftrVucutBolgesiKodu: number;
        public tedaviTuru: string;
        public robotikRehabilitasyon: string;
    }

    export class eswlRaporBilgisiDVO {
        public butKodu: string;
        public eswlRaporuTasSayisi: number;
        public eswlRaporuSeansSayisi: number;
        public bobrekBilgisi: number;
        public eswlRaporuTasBilgileri: Array<eswlTasBilgisiDVO>;
    }

    export class eswlTasBilgisiDVO {
        public tasBoyutu: string;
        public tasLokalizasyonKodu: number;
    }

    export class evHemodiyaliziRaporBilgisiDVO {
        public butKodu: string;
        public seansSayi: number;
        public seansGun: number;
    }

    export class maluliyetRaporDVO {
        public raporDVO: raporDVO;
        public aciklama: string;
        public laboratuvarBulgulari: string;
        public goruntulemeYontemleri: string;
        public teshis: string;
        public karar: string;
        public bransGorusleri: Array<bransGorusBilgisiDVO>;
    }

    export class bransGorusBilgisiDVO {
        public bransKodu: string;
        public aciklama: string;
    }

    export class raporOkuTCKimlikNodanDVO {
        public tckimlikNo: string;
        public raporTuru: string;
        public saglikTesisKodu: number;
    }

    export class raporOkuRaporTakipNodanDVO {
        public raporTakipNo: string;
        public raporSiraNo: string;
        public saglikTesisKodu: number;
    }

    export class raporOkuDVO {
        public raporTesisKodu: number;
        public tarih: string;
        public no: string;
        public turu: string;
        public raporSiraNo: string;
    }

    export class raporSorguDVO {
        public saglikTesisKodu: number;
        public raporBilgisi: raporOkuDVO;
    }

    export class teshisBilgisiDVO {
        public teshisKodu: number;
        public baslangicTarihi: string;
        public bitisTarihi: string;
    }

    export class hakSahibiBilgisiDVO {
        public tckimlikNo: string;
        public karneNo: string;
        public sosyalGuvenlikNo: string;
        public yakinlikKodu: string;
        public sigortaliTuru: string;
        public devredilenKurum: string;
        public provizyonTipi: string;
        public provizyonTarihi: string;
        public adi: string;
        public soyadi: string;
        public adres: string;
        public telefon: string;
        public bagliBulunanBirim: string;
    }

    export class WebMethods {
        public static async ilacRaporDuzeltSync(siteID: Guid, raporDuzelt: ilacRaporDuzeltDVO): Promise<raporCevapDVO> {
            let url = '/api/RaporIslemleri/ilacRaporDuzeltSync';
            let inputDto = { 'siteID': siteID, 'raporDuzelt': raporDuzelt };
            let result = await ServiceLocator.post(url, inputDto) as raporCevapDVO;
            return result;
        }
        public static async raporBilgisiBulRaporTakipNodanSync(siteID: Guid, raporOku: raporOkuRaporTakipNodanDVO): Promise<raporCevapDVO> {
            let url = '/api/RaporIslemleri/raporBilgisiBulRaporTakipNodanSync';
            let inputDto = { 'siteID': siteID, 'raporOku': raporOku };
            let result = await ServiceLocator.post(url, inputDto) as raporCevapDVO;
            return result;
        }
        public static async raporBilgisiBulSync(siteID: Guid, raporBilgisi: raporSorguDVO): Promise<raporCevapDVO> {
            let url = '/api/RaporIslemleri/raporBilgisiBulSync';
            let inputDto = { 'siteID': siteID, 'raporBilgisi': raporBilgisi };
            let result = await ServiceLocator.post(url, inputDto) as raporCevapDVO;
            return result;
        }
        public static async raporBilgisiBulTCKimlikNodanSync(siteID: Guid, raporOku: raporOkuTCKimlikNodanDVO): Promise<raporCevapTCKimlikNodanDVO> {
            let url = '/api/RaporIslemleri/raporBilgisiBulTCKimlikNodanSync';
            let inputDto = { 'siteID': siteID, 'raporOku': raporOku };
            let result = await ServiceLocator.post(url, inputDto) as raporCevapTCKimlikNodanDVO;
            return result;
        }
        public static async raporBilgisiKaydetSync(siteID: Guid, raporGiris: raporGirisDVO): Promise<raporCevapDVO> {
            let url = '/api/RaporIslemleri/raporBilgisiKaydetSync';
            let inputDto = { 'siteID': siteID, 'raporGiris': raporGiris };
            let result = await ServiceLocator.post(url, inputDto) as raporCevapDVO;
            return result;
        }
        public static async raporBilgisiSilSync(siteID: Guid, raporBilgisi: raporSorguDVO): Promise<raporCevapDVO> {
            let url = '/api/RaporIslemleri/raporBilgisiSilSync';
            let inputDto = { 'siteID': siteID, 'raporBilgisi': raporBilgisi };
            let result = await ServiceLocator.post(url, inputDto) as raporCevapDVO;
            return result;
        }
        public static async takipNoileRaporBilgisiKaydetSync(siteID: Guid, raporGiris: raporGirisDVO): Promise<raporCevapDVO> {
            let url = '/api/RaporIslemleri/takipNoileRaporBilgisiKaydetSync';
            let inputDto = { 'siteID': siteID, 'raporGiris': raporGiris };
            let result = await ServiceLocator.post(url, inputDto) as raporCevapDVO;
            return result;
        }
    }
}
