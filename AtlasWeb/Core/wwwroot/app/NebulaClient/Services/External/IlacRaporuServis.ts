//$0B86103A
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace IlacRaporuServis {
    export class eraporGirisIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public eraporDVO: eraporDVO;
    }

    export class eraporDVO {
        public tesisKodu: string;
        public raporTakipNo: string;
        public hastaTcKimlikNo: string;
        public raporNo: string;
        public raporTarihi: string;
        public protokolNo: string;
        public aciklama: string;
        public klinikTani: string;
        public raporDuzenlemeTuru: string;
        public takipNo: string;
        public raporOnayDurumu: string;
        public kisiDVO: kisiDVO;
        public eraporTeshisListesi: Array<eraporTeshisDVO>;
        public eraporDoktorListesi: Array<eraporDoktorDVO>;
        public eraporEtkinMaddeListesi: Array<eraporEtkinMaddeDVO>;
        public eraporAciklamaListesi: Array<eraporAciklamaDVO>;
        public eraporTaniListesi: Array<eraporTaniDVO>;
    }

    export class kisiDVO {
        public adi: string;
        public cinsiyeti: string;
        public dogumTarihi: string;
        public soyadi: string;
        public tcKimlikNo: number;
    }

    export class eraporTeshisEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporTeshisEkleIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
        public eraporTeshisDVO: eraporTeshisDVO;
    }

    export class eraporTeshisDVO {
        public raporTeshisKodu: string;
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public taniListesi: Array<taniDVO>;
    }

    export class taniDVO {
        public kodu: string;
        public adi: string;
    }

    export class eraporTaniEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporTaniEkleIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
        public raporTeshisKodu: string;
        public eraporTaniDVO: eraporTaniDVO;
    }

    export class eraporTaniDVO {
        public taniAdi: string;
        public taniKodu: string;
    }

    export class eraporEtkinMaddeEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporEtkinMaddeEkleIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
        public eraporEtkinMaddeDVO: eraporEtkinMaddeDVO;
    }

    export class eraporEtkinMaddeDVO {
        public etkinMaddeKodu: string;
        public kullanimDoz1: string;
        public kullanimDoz2: string;
        public kullanimDozBirimi: string;
        public kullanimDozPeriyot: string;
        public kullanimDozPeriyotBirimi: string;
        public etkinMaddeDVO: etkinMaddeDVO;
    }

    export class etkinMaddeDVO {
        public kodu: string;
        public adi: string;
        public icerikMiktari: string;
        public formu: string;
    }

    export class eraporAciklamaEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporAciklamaEkleIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
        public eraporAciklamaDVO: eraporAciklamaDVO;
    }

    export class eraporAciklamaDVO {
        public aciklama: string;
        public takipFormuNo: string;
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

    export class imzaliEraporBashekimOnayCevapDVO {
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

    export class imzaliEraporOnayCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporOnayIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class eraporListeSorguCevapDVO {
        public kisiDVO: kisiDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public eraporListesi: Array<eraporDVO>;
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
        public eraporDVO: eraporDVO;
    }

    export class eraporSorguIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class eraporSilCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }
    export class imzaliEraporSilCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class eraporSilIstekDVO {
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public raporTakipNo: string;
    }

    export class eraporGirisCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public eraporDVO: eraporDVO;
    }

    export class imzaliEraporGirisCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public eraporDVO: eraporDVO;
    }

    export class eraporDoktorDVO {
        public tcKimlikNo: string;
        public bransKodu: string;
        public sertifikaKodu: string;
        public adi: string;
        public soyadi: string;
    }

    export class WebMethods {
        public static async eraporAciklamaEkle(siteID: Guid, userName: string, password: string, istekDVO: eraporAciklamaEkleIstekDVO): Promise<eraporAciklamaEkleCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporAciklamaEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporAciklamaEkleCevapDVO;
            return result;
        }
        public static async eraporBashekimOnay(siteID: Guid, userName: string, password: string, istekDVO: eraporBashekimOnayIstekDVO): Promise<eraporBashekimOnayCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporBashekimOnay";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporBashekimOnayCevapDVO;
            return result;
        }
        public static async eraporBashekimOnayBekleyenListeSorgu(siteID: Guid, istekDVO: eraporBashekimOnayBekleyenListeSorguIstekDVO): Promise<eraporBashekimOnayBekleyenListeSorguCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporBashekimOnayBekleyenListeSorgu";
            let inputDto = { "siteID": siteID, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporBashekimOnayBekleyenListeSorguCevapDVO;
            return result;
        }
        public static async eraporBashekimOnayRed(siteID: Guid, istekDVO: eraporBashekimOnayRedIstekDVO): Promise<eraporBashekimOnayRedCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporBashekimOnayRed";
            let inputDto = { "siteID": siteID, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporBashekimOnayRedCevapDVO;
            return result;
        }
        public static async eraporEtkinMaddeEkle(siteID: Guid, userName: string, password: string, istekDVO: eraporEtkinMaddeEkleIstekDVO): Promise<eraporEtkinMaddeEkleCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporEtkinMaddeEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporEtkinMaddeEkleCevapDVO;
            return result;
        }
        public static async eraporGiris(siteID: Guid, userName: string, password: string, istekDVO: eraporGirisIstekDVO): Promise<eraporGirisCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporGiris";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporGirisCevapDVO;
            return result;
        }
        public static async eraporListeSorgula(siteID: Guid, userName: string, password: string, istekDVO: eraporListeSorguIstekDVO): Promise<eraporListeSorguCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporListeSorgula";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporListeSorguCevapDVO;
            return result;
        }
        public static async eraporOnay(siteID: Guid, userName: string, password: string, istekDVO: eraporOnayIstekDVO): Promise<eraporOnayCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporOnay";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporOnayCevapDVO;
            return result;
        }
        public static async eraporOnayBekleyenListeSorgu(siteID: Guid, istekDVO: eraporOnayBekleyenListeSorguIstekDVO): Promise<eraporOnayBekleyenListeSorguCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporOnayBekleyenListeSorgu";
            let inputDto = { "siteID": siteID, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporOnayBekleyenListeSorguCevapDVO;
            return result;
        }
        public static async eraporOnayRed(siteID: Guid, userName: string, password: string, istekDVO: eraporOnayRedIstekDVO): Promise<eraporOnayRedCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporOnayRed";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporOnayRedCevapDVO;
            return result;
        }
        public static async eraporSil(siteID: Guid, userName: string, password: string, istekDVO: eraporSilIstekDVO): Promise<eraporSilCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporSil";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporSilCevapDVO;
            return result;
        }
        public static async eraporSorgula(siteID: Guid, istekDVO: eraporSorguIstekDVO): Promise<eraporSorguCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporSorgula";
            let inputDto = { "siteID": siteID, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporSorguCevapDVO;
            return result;
        }
        public static async eraporTaniEkle(siteID: Guid, userName: string, password: string, istekDVO: eraporTaniEkleIstekDVO): Promise<eraporTaniEkleCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporTaniEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporTaniEkleCevapDVO;
            return result;
        }
        public static async eraporTeshisEkle(siteID: Guid, userName: string, password: string, istekDVO: eraporTeshisEkleIstekDVO): Promise<eraporTeshisEkleCevapDVO> {
            let url: string = "/api/IlacRaporuServisController/eraporTeshisEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as eraporTeshisEkleCevapDVO;
            return result;
        }
    }
}
