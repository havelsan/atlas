//$A1734F46
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace IsGormezlikServis {
    export class IsgoremezlikRaporDVO {
        public raporBilgisi: RaporBilgisiDVO;
        public isGoremezlikRaporTuru: number;
        public bransKodu: number;
        public protokolNo: string;
        public protokolTarihi: string;
        public duzenlemeTuru: string;
        public teshis: string;
        public isKazasiRaporu: IsKazasiRaporDVO;
        public meslekHastaligiRaporu: MeslekHastaligiRaporDVO;
        public analikRaporu: AnalikRaporDVO;
        public emzirmeRaporu: EmzirmeRaporDVO;
        public hastalikRaporu: HastalikRaporDVO;
        public hakSahibi: HakSahibiBilgisiDVO;
        public aciklama: string;
        public olum: string;
        public klinikBulgular: string;
        public ronLabBilgileri: string;
        public karar: string;
        public doktorArr: Array<DoktorBilgisiDVO>;
        public bashekimOnayDurumu: number;
        public bashekimTCNo: string;
        public devammi: number;
        public yatisDevam: string;
    }

    export class RaporBilgisiDVO {
        public raporTesisKodu: number;
        public tarih: string;
        public raporTesisAdi: string;
        public no: string;
        public raporTakipNo: string;
        public raporSiraNo: number;
        public AVakaTKaza: number;
    }

    export class IgorIsKazasiMeslekHastalikDTO {
        public yaraninTuru: string;
        public yaraninYeri: string;
        public nuks: string;
        public AVakaTkaza: number;
        public isKazasiTarihi: Date;
    }

    export class IgorAnalikEmzirmeDTO {
        public analikRaporTipi: number;
        public gebelikTipi: number;
        public gebelikHaftasi1: number;
        public gebelikHaftasi2: number;
        public bebekDogumHaftasi: number;
        public aktarmaHaftasi: number;
        public bebekDogumTarihi: Date;
        public canliCocukSayisi: number;
        public doganCocukSayisi: number;
        public norSezFor: string;
        public anneTCKimlikNo: string;
    }

    export class IgorMedulaRaporDTO {
        public bashekimOnay: number;
        public baslangicTarihi: Date;
        public bitisTarihi: Date;
        public isKontTarihi: Date;
        public XXXXXXYatisTarihi: Date;
        public XXXXXXCikisTarihi: Date;
        public yatisDevam: string;
        public taburcuTarihi: Date;
        public taburcuKodu: number;
    }

    export class DoktorBilgisiDTO {
        public drTescilNo: string;
        public drAdi: string;
        public drSoyadi: string;
        public drBransKodu: string;
    }

    export class KullaniciDTO {
        public kullaniciadi: string;
        public islemtarihi: Date;
    }

    export class HaksahibiBilgisiDTO {
        public tckimlikNo: string;
        public sosyalGuvenlikNo: string;
        public sigortaliTuru: string;
        public provizyonTipi: string;
        public provizyonTarihi: Date;
        public adi: string;
        public soyadi: string;
        public cinsiyet: string;
        public adres: string;
        public telefon: string;
        public bagliBulunanBirim: string;
        public meslek: string;
        public mahiyet: string;
        public iskolu: string;
        public emeklimi: string;
        public yeniSubeKod: string;
        public eskiSubeKod: string;
        public isyeriNo: string;
        public naceKodu: string;
        public isyeriIl: string;
        public isyeriIlce: string;
        public cd: string;
        public aracino: string;
        public sgm: string;
    }

    export class RaporBilgisiDTO {
        public raporTesisKodu: number;
        public tarih: Date;
        public no: number;
        public raporTakipNo: string;
        public raporSiraNo: number;
        public raporTipi: number;
        public raporAcikKapali: string;
        public AVakaTKaza: number;
        public raporTesisAdi: string;
    }

    export class IsgoremezlikRaporDTO {
        public raporBilgisi: RaporBilgisiDTO;
        public isGoremezlikRaporTuru: number;
        public bransKodu: number;
        public protokolNo: number;
        public protokolTarihi: Date;
        public teshis: string;
        public aciklama: string;
        public olum: string;
        public hakSahibi: HaksahibiBilgisiDTO;
        public kullanici: KullaniciDTO;
        public karar: string;
        public klinikBulgular: string;
        public ronLabBilgileri: string;
        public duzenlemeTuru: string;
        public doktorArr: Array<DoktorBilgisiDTO>;
        public medulaRapor: IgorMedulaRaporDTO;
        public analikEmzirme: IgorAnalikEmzirmeDTO;
        public iskazasiHastalik: IgorIsKazasiMeslekHastalikDTO;
        public bashekimOnayDurumu: number;
        public bashekimTCNo: string;
        public devammi: number;
        public raporDurumu: string;
    }

    export class CevapDTO {
        public raporID: number;
        public hataMesaji: string;
        public sonucKodu: number;
        public raporTakipNo: string;
        public raporSiraNo: number;
        public dogumSonrasiIsbasiTarihi: string;
        public isgoremezlikRapor: IsgoremezlikRaporDTO;
        public isgoremezlikRaporArr: Array<IsgoremezlikRaporDTO>;
    }

    export class DoktorBilgisiDVO {
        public drTescilNo: string;
        public drAdi: string;
        public drSoyadi: string;
        public drBransKodu: string;
        public tipi: string;
    }

    export class HakSahibiBilgisiDVO {
        public tckimlikNo: string;
        public sosyalGuvenlikNo: string;
        public sigortaliTuru: string;
        public provizyonTipi: string;
        public provizyonTarihi: string;
        public adi: string;
        public soyadi: string;
        public adres: string;
        public telefon: string;
        public bagliBulunanBirim: string;
        public emeklimi: string;
    }

    export class HastalikRaporDVO {
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

    export class EmzirmeRaporDVO {
        public bebekDogumTarihi: string;
        public canliCocukSayisi: number;
        public doganCocukSayisi: number;
        public anneTcKimlikNo: string;
    }

    export class AnalikRaporDVO {
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
        public analikRaporTipi: number;
        public gebelikTipi: number;
        public gebelikHaftasi1: number;
        public gebelikHaftasi2: number;
        public bebekDogumHaftasi: number;
        public aktarmaHaftasi: number;
    }

    export class MeslekHastaligiRaporDVO {
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

    export class IsKazasiRaporDVO {
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

    export class WebMethods {
        public static async mevcutRaporGetirSync(siteID: Guid, tcKimlikNo: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/mevcutRaporGetirSync";
            let inputDto = { "siteID": siteID, "tcKimlikNo": tcKimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async rapor2VerIptalSync(siteID: Guid, rtn: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/rapor2VerIptalSync";
            let inputDto = { "siteID": siteID, "rtn": rtn };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async rapor2VerSync(siteID: Guid, rtn: string, rsn: number, rapordurum: string, duzenlemeTuru: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/rapor2VerSync";
            let inputDto = { "siteID": siteID, "rtn": rtn, "rsn": rsn, "rapordurum": rapordurum, "duzenlemeTuru": duzenlemeTuru };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporGetirSync(siteID: Guid, raporTakipNo: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporGetirSync";
            let inputDto = { "siteID": siteID, "raporTakipNo": raporTakipNo };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporGuncelleSync(siteID: Guid, isgoremezlikRaporDVO: IsgoremezlikRaporDVO): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporGuncelleSync";
            let inputDto = { "siteID": siteID, "isgoremezlikRaporDVO": isgoremezlikRaporDVO };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporKaydetSync(siteID: Guid, isgoremezlikRaporDVO: IsgoremezlikRaporDVO): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporKaydetSync";
            let inputDto = { "siteID": siteID, "isgoremezlikRaporDVO": isgoremezlikRaporDVO };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporListeGetirSync(siteID: Guid, date1: string, tesisKodu: string, pass: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporListeGetirSync";
            let inputDto = { "siteID": siteID, "date1": date1, "tesisKodu": tesisKodu, "pass": pass };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporListesiGetirSync(siteID: Guid, tcNo: string, tesisKodu: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporListesiGetirSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo, "tesisKodu": tesisKodu };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporOnaylaSync(siteID: Guid, raporTakipNo: string, raporSiraNo: string, tesisKodu: string, bashekimTcNo: string, pass: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporOnaylaSync";
            let inputDto = { "siteID": siteID, "raporTakipNo": raporTakipNo, "raporSiraNo": raporSiraNo, "tesisKodu": tesisKodu, "bashekimTcNo": bashekimTcNo, "pass": pass };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporOnSecimSync(siteID: Guid, isgoremezlikRaporDVO: IsgoremezlikRaporDVO): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporOnSecimSync";
            let inputDto = { "siteID": siteID, "isgoremezlikRaporDVO": isgoremezlikRaporDVO };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async raporSilSync(siteID: Guid, rtn: string, rsn: number, vaka: number, tesisKodu: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/raporSilSync";
            let inputDto = { "siteID": siteID, "rtn": rtn, "rsn": rsn, "vaka": vaka, "tesisKodu": tesisKodu };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async saglikKurulunaSevketSync(siteID: Guid, rtn: string, rsn: number, rapordurum: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/saglikKurulunaSevketSync";
            let inputDto = { "siteID": siteID, "rtn": rtn, "rsn": rsn, "rapordurum": rapordurum };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
        public static async saglikKurulunaSevkIptalSync(siteID: Guid, rtn: string): Promise<CevapDTO> {
            let url: string = "/api/IsGormezlikServisController/saglikKurulunaSevkIptalSync";
            let inputDto = { "siteID": siteID, "rtn": rtn };
            let result = await ServiceLocator.post(url, inputDto) as CevapDTO;
            return result;
        }
    }
}
