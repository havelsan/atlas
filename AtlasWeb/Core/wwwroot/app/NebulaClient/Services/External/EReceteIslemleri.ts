//$D6C709BC
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace EReceteIslemleri {
    export class ereceteSorguIstekDVO {
        public tesisKodu: number;
        public ereceteNo: string;
        public doktorTcKimlikNo: number;
    }

    export class imzaliEreceteIlacAciklamaEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteIlacAciklamaEkleIstekDVO {
        public imzaliEreceteIlacAciklama: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteIlacAciklamaEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteIlacAciklamaEkleIstekDVO {
        public ereceteNo: string;
        public barkod: number;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public ereceteIlacAciklamaDVO: ereceteIlacAciklamaDVO;
    }

    export class ereceteIlacAciklamaDVO {
        public aciklama: string;
        public aciklamaTuru: number;
    }

    export class imzaliEreceteAciklamaEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteAciklamaEkleIstekDVO {
        public imzaliEreceteAciklama: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteAciklamaEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteAciklamaEkleIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public ereceteAciklamaDVO: ereceteAciklamaDVO;
    }

    export class ereceteAciklamaDVO {
        public aciklama: string;
        public aciklamaTuru: number;
    }

    export class imzaliEreceteTaniEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteTaniEkleIstekDVO {
        public imzaliEreceteTani: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteTaniEkleCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteTaniEkleIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public ereceteTaniDVO: ereceteTaniDVO;
    }

    export class ereceteTaniDVO {
        public taniAdi: string;
        public taniKodu: string;
    }

    export class imzaliEreceteOnayIptalCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteOnayIptalIstekDVO {
        public imzaliEreceteOnayIptal: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteOnayIptalCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteOnayIptalIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public receteOnayTuru: string;
    }

    export class imzaliEreceteOnayCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteOnayIstekDVO {
        public imzaliEreceteOnay: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteOnayCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteOnayIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public receteOnayTuru: string;
    }

    export class ereceteYatanHastaOnayiIptalCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteYatanHastaOnayiIptalIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class ereceteYatanHastaOnayiCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteYatanHastaOnayiIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class ereceteEhuOnayiIptalCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteEhuOnayiIptalIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class ereceteEhuOnayiCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteEhuOnayiIstekDVO {
        public ereceteNo: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class imzaliEreceteSilCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteSilIstekDVO {
        public imzaliEreceteSil: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteSilCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteSilIstekDVO {
        public tesisKodu: number;
        public ereceteNo: string;
        public doktorTcKimlikNo: number;
    }

    export class imzaliEreceteGirisCevapDVO {
        public ereceteDVO: ereceteDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteDVO {
        public protokolNo: string;
        public provizyonTipi: number;
        public receteAltTuru: number;
        public receteTarihi: string;
        public receteTuru: number;
        public takipNo: string;
        public tcKimlikNo: number;
        public tesisKodu: number;
        public seriNo: string;
        public doktorBransKodu: number;
        public doktorSertifikaKodu: number;
        public kisiDVO: kisiDVO;
        public ereceteNo: string;
        public ereceteIlacListesi: Array<ereceteIlacDVO>;
        public ereceteTaniListesi: Array<ereceteTaniDVO>;
        public ereceteAciklamaListesi: Array<ereceteAciklamaDVO>;
        public doktorAdi: string;
        public doktorSoyadi: string;
        public doktorTcKimlikNo: number;
    }

    export class kisiDVO {
        public adi: string;
        public cinsiyeti: string;
        public dogumTarihi: string;
        public soyadi: string;
        public tcKimlikNo: number;
    }

    export class ereceteIlacDVO {
        public adet: number;
        public barkod: number;
        public ilacAdi: string;
        public kullanimDoz1: number;
        public kullanimPeriyotBirimi: number;
        public kullanimSekli: number;
        public ereceteIlacAciklamaListesi: Array<ereceteIlacAciklamaDVO>;
        public kullanimDoz2: number;
        public kullanimPeriyot: number;
        public geriOdemeKapsaminda: string;
    }

    export class imzaliEreceteGirisIstekDVO {
        public imzaliErecete: Array<number>;
        public tesisKodu: number;
        public surumNumarasi: number;
        public doktorTcKimlikNo: number;
    }

    export class ereceteGirisCevapDVO {
        public ereceteDVO: ereceteDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteGirisIstekDVO {
        public ereceteDVO: ereceteDVO;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class imzaliEreceteListeSorguCevapDVO {
        public ereceteListesi: Array<ereceteDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteListeSorguIstekDVO {
        public imzaliEreceteListeSorgula: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteListeSorguCevapDVO {
        public ereceteListesi: Array<ereceteDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteListeSorguIstekDVO {
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public hastaTcKimlikNo: number;
    }

    export class imzaliEreceteSorguCevapDVO {
        public ereceteDVO: ereceteDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteSorguIstekDVO {
        public imzaliEreceteSorgula: Array<number>;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
        public surumNumarasi: string;
    }

    export class ereceteSorguCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public ereceteDVO: ereceteDVO;
    }

    export class WebMethods {
        public static async ereceteAciklamaEkle(siteID: Guid, userName: string, password: string, ereceteAciklamaEkleIstekDVO: EReceteIslemleri.ereceteAciklamaEkleIstekDVO): Promise<EReceteIslemleri.ereceteAciklamaEkleCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteAciklamaEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteAciklamaEkleIstekDVO": ereceteAciklamaEkleIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as EReceteIslemleri.ereceteAciklamaEkleCevapDVO;
            return result;
        }
        public static async imzaliEreceteGirisSync(siteID: Guid, userName: string, password: string, imzaliEreceteGirisIstekDVO: imzaliEreceteGirisIstekDVO): Promise<imzaliEreceteGirisCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteGirisSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteGirisIstekDVO": imzaliEreceteGirisIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteGirisCevapDVO;
            return result;
        }
        public static async imzaliEreceteSilSync(siteID: Guid, userName: string, password: string, imzaliEreceteSilIstekDVO: imzaliEreceteSilIstekDVO): Promise<imzaliEreceteSilCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteSilSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteSilIstekDVO": imzaliEreceteSilIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteSilCevapDVO;
            return result;
        }
        public static async imzaliEreceteOnaySync(siteID: Guid, userName: string, password: string, imzaliEreceteOnayIstekDVO: imzaliEreceteOnayIstekDVO): Promise<imzaliEreceteOnayCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteOnaySync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteOnayIstekDVO": imzaliEreceteOnayIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteOnayCevapDVO;
            return result;
        }
        public static async imzaliEreceteOnayIptalSync(siteID: Guid, userName: string, password: string, imzaliEreceteOnayIptalIstekDVO: imzaliEreceteOnayIptalIstekDVO): Promise<imzaliEreceteOnayIptalCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteOnayIptalSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteOnayIptalIstekDVO": imzaliEreceteOnayIptalIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteOnayIptalCevapDVO;
            return result;
        }
        public static async imzaliEreceteTaniEkleSync(siteID: Guid, userName: string, password: string, imzaliEreceteTaniEkleIstekDVO: imzaliEreceteTaniEkleIstekDVO): Promise<imzaliEreceteTaniEkleCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteTaniEkleSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteTaniEkleIstekDVO": imzaliEreceteTaniEkleIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteTaniEkleCevapDVO;
            return result;
        }
        public static async ereceteEhuOnayi(siteID: Guid, userName: string, password: string, ereceteEhuOnayiIstekDVO: ereceteEhuOnayiIstekDVO): Promise<ereceteEhuOnayiCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteEhuOnayi";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteEhuOnayiIstekDVO": ereceteEhuOnayiIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteEhuOnayiCevapDVO;
            return result;
        }
        public static async ereceteEhuOnayiIptal(siteID: Guid, userName: string, password: string, callerObject: IWebMethodCallback, ereceteEhuOnayiIptalIstekDVO: ereceteEhuOnayiIptalIstekDVO): Promise<ereceteEhuOnayiIptalCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteEhuOnayiIptal";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "callerObject": callerObject, "ereceteEhuOnayiIptalIstekDVO": ereceteEhuOnayiIptalIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteEhuOnayiIptalCevapDVO;
            return result;
        }
        public static async ereceteGiris(siteID: Guid, userName: string, password: string, callerObject: IWebMethodCallback, ereceteGirisIstekDVO: EReceteIslemleri.ereceteGirisIstekDVO): Promise<EReceteIslemleri.ereceteGirisCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteGiris";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "callerObject": callerObject, "ereceteGirisIstekDVO": ereceteGirisIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as EReceteIslemleri.ereceteGirisCevapDVO;
            return result;
        }
        public static async ereceteGirisSynCall(siteID: Guid, userName: string, password: string, ereceteGirisIstekDVO: EReceteIslemleri.ereceteGirisIstekDVO): Promise<EReceteIslemleri.ereceteGirisCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteGirisSynCall";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteGirisIstekDVO": ereceteGirisIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as EReceteIslemleri.ereceteGirisCevapDVO;
            return result;
        }
        public static async ereceteIlacAciklamaEkle(siteID: Guid, userName: string, password: string, ereceteIlacAciklamaEkleIstekDVO: ereceteIlacAciklamaEkleIstekDVO): Promise<ereceteIlacAciklamaEkleCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteIlacAciklamaEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteIlacAciklamaEkleIstekDVO": ereceteIlacAciklamaEkleIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteIlacAciklamaEkleCevapDVO;
            return result;
        }
        public static async ereceteListeSorgulaSync(siteID: Guid, userName: string, password: string, ereceteListeSorguIstekDVO: ereceteListeSorguIstekDVO): Promise<ereceteListeSorguCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteListeSorgulaSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteListeSorguIstekDVO": ereceteListeSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteListeSorguCevapDVO;
            return result;
        }
        public static async ereceteOnay(siteID: Guid, userName: string, password: string, istekDVO: ereceteOnayIstekDVO): Promise<ereceteOnayCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteOnay";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteOnayCevapDVO;
            return result;
        }
        public static async ereceteOnayIptal(siteID: Guid, userName: string, password: string, callerObject: IWebMethodCallback, istekDVO: ereceteOnayIptalIstekDVO): Promise<ereceteOnayIptalCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteOnayIptal";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "callerObject": callerObject, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteOnayIptalCevapDVO;
            return result;
        }
        public static async ereceteSil(siteID: Guid, userName: string, password: string, ereceteSilIstekDVO: EReceteIslemleri.ereceteSilIstekDVO): Promise<EReceteIslemleri.ereceteSilCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteSil";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteSilIstekDVO": ereceteSilIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as EReceteIslemleri.ereceteSilCevapDVO;
            return result;
        }
        public static async ereceteSorgulaSync(siteID: Guid, userName: string, password: string, ereceteSorguIstekDVO: EReceteIslemleri.ereceteSorguIstekDVO): Promise<EReceteIslemleri.ereceteSorguCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteSorgulaSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteSorguIstekDVO": ereceteSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as EReceteIslemleri.ereceteSorguCevapDVO;
            return result;
        }
        public static async ereceteTaniEkle(siteID: Guid, userName: string, password: string, ereceteTaniEkleIstekDVO: ereceteTaniEkleIstekDVO): Promise<ereceteTaniEkleCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteTaniEkle";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteTaniEkleIstekDVO": ereceteTaniEkleIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteTaniEkleCevapDVO;
            return result;
        }
        public static async ereceteYatanHastaOnayi(siteID: Guid, userName: string, password: string, ereceteYatanHastaOnayiIstekDVO: ereceteYatanHastaOnayiIstekDVO): Promise<ereceteYatanHastaOnayiCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteYatanHastaOnayi";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteYatanHastaOnayiIstekDVO": ereceteYatanHastaOnayiIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteYatanHastaOnayiCevapDVO;
            return result;
        }
        public static async ereceteYatanHastaOnayiIptal(siteID: Guid, userName: string, password: string, ereceteYatanHastaOnayiIptalIstekDVO: ereceteYatanHastaOnayiIptalIstekDVO): Promise<ereceteYatanHastaOnayiIptalCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/ereceteYatanHastaOnayiIptal";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteYatanHastaOnayiIptalIstekDVO": ereceteYatanHastaOnayiIptalIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as ereceteYatanHastaOnayiIptalCevapDVO;
            return result;
        }
        public static async imzaliEreceteGiris(siteID: Guid, callerObject: IWebMethodCallback, imzaliEreceteGirisIstekDVO: imzaliEreceteGirisIstekDVO): Promise<imzaliEreceteGirisCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteGiris";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "imzaliEreceteGirisIstekDVO": imzaliEreceteGirisIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteGirisCevapDVO;
            return result;
        }
        public static async imzaliEreceteOnayIptalAsync(siteID: Guid, userName: string, password: string, callerObject: IWebMethodCallback, imzaliEreceteOnayIptalIstekDVO: imzaliEreceteOnayIptalIstekDVO): Promise<imzaliEreceteOnayIptalCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteOnayIptalAsync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "callerObject": callerObject, "imzaliEreceteOnayIptalIstekDVO": imzaliEreceteOnayIptalIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteOnayIptalCevapDVO;
            return result;
        }
        public static async imzaliEreceteAciklamaEkleSync(siteID: Guid, userName: string, password: string, imzaliEreceteAciklamaEkleIstekDVO: imzaliEreceteAciklamaEkleIstekDVO): Promise<imzaliEreceteAciklamaEkleCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteAciklamaEkleSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteAciklamaEkleIstekDVO": imzaliEreceteAciklamaEkleIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteAciklamaEkleCevapDVO;
            return result;
        }
        public static async imzaliEreceteIlacAciklamaEkleSync(siteID: Guid, userName: string, password: string, imzaliEreceteIlacAciklamaEkleIstekDVO: imzaliEreceteIlacAciklamaEkleIstekDVO): Promise<imzaliEreceteIlacAciklamaEkleCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteIlacAciklamaEkleSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteIlacAciklamaEkleIstekDVO": imzaliEreceteIlacAciklamaEkleIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteIlacAciklamaEkleCevapDVO;
            return result;
        }
        public static async imzaliEreceteSorguSync(siteID: Guid, userName: string, password: string, imzaliEreceteSorguIstekDVO: imzaliEreceteSorguIstekDVO): Promise<imzaliEreceteSorguCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteSorguSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteSorguIstekDVO": imzaliEreceteSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteSorguCevapDVO;
            return result;
        }
        public static async imzaliEreceteListeSorguSync(siteID: Guid, userName: string, password: string, imzaliEreceteListeSorguIstekDVO: imzaliEreceteListeSorguIstekDVO): Promise<imzaliEreceteListeSorguCevapDVO> {
            let url: string = "/api/EReceteIslemleriController/imzaliEreceteListeSorguSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "imzaliEreceteListeSorguIstekDVO": imzaliEreceteListeSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as imzaliEreceteListeSorguCevapDVO;
            return result;
        }
    }
}
