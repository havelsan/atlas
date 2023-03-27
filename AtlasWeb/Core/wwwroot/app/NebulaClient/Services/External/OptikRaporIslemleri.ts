//$E4B59984
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace OptikRaporIslemleri {
    export class raporTesisDVO {
        public sigortaliTckNo: string;
        public tesisKodu: string;
        public raporBaslangicTarih: string;
        public raporBitisTarih: string;
        public raporTeshis: string;
        public doktorTcKimlikNo: string;
        public raporNoTesis: string;
        public dr1TckNo: string;
        public dr2TckNo: string;
        public dr3TckNo: string;
        public dr4TckNo: string;
        public dr5TckNo: string;
        public dr6TckNo: string;
        public durum: string;
        public tip: string;
        public aciklama: string;
        public takipNo: string;
        public raporTarih: string;
        public protokolNo: string;
        public raporDuzenlemeTuru: string;
        public raporKayitSekli: string;
        public eraporTaniListesi: eraporTaniDVO;
    }

    export class eraporTaniDVO {
        public taniAdi: string;
        public taniKodu: string;
    }

    export class eraporAciklamaEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporAciklamaDVO {
        public aciklama: string;
        public takipFormuNo: string;
    }

    export class eraporAciklamaEkleIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
        public eraporAciklamaDVO: eraporAciklamaDVO;
    }

    export class eraporBashekimOnayBekleyenListeSorguCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public raporTakipNoListesi: number;
    }

    export class eraporBashekimOnayBekleyenListeSorguIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
    }

    export class eraporBashekimOnayRedCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporBashekimOnayRedIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class eraporBashekimOnayCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporBashekimOnayIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class eraporOnayBekleyenListeSorguCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public raporTakipNoListesi: number;
    }

    export class eraporOnayBekleyenListeSorguIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
    }

    export class eraporOnayRedCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporOnayRedIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class eraporOnayCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporOnayIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class kisiDVO {
        public adi: string;
        public cinsiyeti: string;
        public dogumTarihi: string;
        public soyadi: string;
        public tcKimlikNo: number;
    }

    export class eraporListeSorguCevapDVO {
        public kisiDVO: kisiDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public eraporListesi: Array<raporTesisDVO>;
    }

    export class eraporListeSorguIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public hastaTcKimlikNo: string;
    }

    export class eraporSorguCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public eraporDVO: raporTesisDVO;
    }

    export class eraporSorguIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class eraporSilDVO {
        public takipNo: string;
        public raporNoTesis: string;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
    }

    export class eRaporSonucDVO {
        public raporTesisDVO: raporTesisDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public raporId: string;
    }

    export class WebMethods {
        public static async eraporAciklamaEkle(siteID: Guid, userName: string, password: string, eraporAciklamaEkleIstek: eraporAciklamaEkleIstekDVO): Promise<eraporAciklamaEkleCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporAciklamaEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporAciklamaEkleIstek": eraporAciklamaEkleIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporAciklamaEkleCevapDVO;
            return result;
        }
        public static async eraporBashekimOnayBekleyenListeSorgu(siteID: Guid, userName: string, password: string, eraporBashekimOnayBekleyenListeSorguIstek: eraporBashekimOnayBekleyenListeSorguIstekDVO): Promise<eraporBashekimOnayBekleyenListeSorguCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporBashekimOnayBekleyenListeSorgu";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporBashekimOnayBekleyenListeSorguIstek": eraporBashekimOnayBekleyenListeSorguIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporBashekimOnayBekleyenListeSorguCevapDVO;
            return result;
        }
        public static async eraporBashekimOnayRed(siteID: Guid, userName: string, password: string, eraporBashekimOnayRedIstek: eraporBashekimOnayRedIstekDVO): Promise<eraporBashekimOnayRedCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporBashekimOnayRed";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporBashekimOnayRedIstek": eraporBashekimOnayRedIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporBashekimOnayRedCevapDVO;
            return result;
        }
        public static async eraporBashekimOnay(siteID: Guid, userName: string, password: string, eraporBashekimOnayIstek: eraporBashekimOnayIstekDVO): Promise<eraporBashekimOnayCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporBashekimOnay";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporBashekimOnayIstek": eraporBashekimOnayIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporBashekimOnayCevapDVO;
            return result;
        }
        public static async eraporGiris(siteID: Guid, userName: string, password: string, raporTesis: raporTesisDVO): Promise<eRaporSonucDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporGiris";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "raporTesis": raporTesis };
            let result = await ServiceLocator.post(url, inputDto) as eRaporSonucDVO;
            return result;
        }
        public static async eraporListeSorgula(siteID: Guid, userName: string, password: string, eraporListeSorguIstek: eraporListeSorguIstekDVO): Promise<eraporListeSorguCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporListeSorgula";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporListeSorguIstek": eraporListeSorguIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporListeSorguCevapDVO;
            return result;
        }
        public static async eraporOnayBekleyenListeSorgu(siteID: Guid, userName: string, password: string, eraporOnayBekleyenListeSorguIstek: eraporOnayBekleyenListeSorguIstekDVO): Promise<eraporOnayBekleyenListeSorguCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporOnayBekleyenListeSorgu";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporOnayBekleyenListeSorguIstek": eraporOnayBekleyenListeSorguIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporOnayBekleyenListeSorguCevapDVO;
            return result;
        }
        public static async eraporOnayRed(siteID: Guid, userName: string, password: string, eraporOnayRedIstek: eraporOnayRedIstekDVO): Promise<eraporOnayRedCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporOnayRed";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporOnayRedIstek": eraporOnayRedIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporOnayRedCevapDVO;
            return result;
        }
        public static async eraporOnay(siteID: Guid, userName: string, password: string, eraporOnayIstek: eraporOnayIstekDVO): Promise<eraporOnayCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporOnay";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporOnayIstek": eraporOnayIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporOnayCevapDVO;
            return result;
        }
        public static async eraporSil(siteID: Guid, userName: string, password: string, eraporSil: eraporSilDVO): Promise<eRaporSonucDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporSil";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporSil": eraporSil };
            let result = await ServiceLocator.post(url, inputDto) as eRaporSonucDVO;
            return result;
        }
        public static async eraporSorgula(siteID: Guid, userName: string, password: string, eraporSorguIstek: eraporSorguIstekDVO): Promise<eraporSorguCevapDVO> {
            let url: string = "/api/OptikRaporIslemleriController/eraporSorgula";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "eraporSorguIstek": eraporSorguIstek };
            let result = await ServiceLocator.post(url, inputDto) as eraporSorguCevapDVO;
            return result;
        }
    }
}
