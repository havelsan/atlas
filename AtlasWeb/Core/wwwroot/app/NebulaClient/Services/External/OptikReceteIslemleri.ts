//$3D3E865F
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace OptikReceteIslemleri {
    export class receteTesisDVO {
        public tcKimlikNo: string;
        public takipNo: string;
        public receteTarihi: string;
        public protokolNo: string;
        public receteTeshis: string;
        public tesisKodu: string;
        public drTescilNo: string;
        public doktorTcKimlikNo: string;
        public eReceteNo: string;
        public sagCam1: string;
        public solCam1: string;
        public gozlukTuru1: string;
        public camTipi1: string;
        public camRengi1: string;
        public sagSferik1: string;
        public sagSilendirik1: string;
        public sagAks1: string;
        public solSferik1: string;
        public solSilendirik1: string;
        public solAks1: string;
        public sagCam2: string;
        public solCam2: string;
        public gozlukTuru2: string;
        public camRengi2: string;
        public camTipi2: string;
        public sagSferik2: string;
        public sagSilendirik2: string;
        public sagAks2: string;
        public solSferik2: string;
        public solSilendirik2: string;
        public solAks2: string;
        public lensSagCam: string;
        public lensSagCamSferik: string;
        public lensSagCamSilendirik: string;
        public lensSagCamEgim: string;
        public lensSagCamAks: string;
        public lensSagCamCap: string;
        public lensSolCam: string;
        public lensSolCamSferik: string;
        public lensSolCamSilendirik: string;
        public lensSolCamEgim: string;
        public lensSolCamAks: string;
        public lensSolCamCap: string;
        public lensGeciciMadde: string;
        public keratakonusSagCamSilendirik: string;
        public keratakonusSagCamEgim: string;
        public keratakonusSagCamAks: string;
        public keratakonusSolCamSilendirik: string;
        public keratakonusSolCamEgim: string;
        public keratakonusSolCamAks: string;
        public keratakonusSagCam: string;
        public keratakonusSagCamSferik: string;
        public keratakonusSagCamCap: string;
        public keratakonusSolCam: string;
        public keratakonusSolCamSferik: string;
        public keratakonusSolCamCap: string;
        public teleskobikSagCam1: string;
        public teleskobikSolCam1: string;
        public teleskobikGozlukTuru1: string;
        public teleskopikGozlukTipi1: string;
        public teleskopikSagSol1: string;
        public teleskobikSagCam2: string;
        public teleskobikSolCam2: string;
        public teleskobikGozlukTuru2: string;
        public teleskopikGozlukTipi2: string;
        public teleskopikSagSol2: string;
        public provizyonTipi: string;
        public receteTipi: string;
        public ereceteTaniListesi: Array<ereceteTaniDVO>;
    }

    export class ereceteTaniDVO {
        public taniAdi: string;
        public taniKodu: string;
    }

    export class ereceteListeSorguCevapDVO {
        public ereceteListesi: Array<receteTesisDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteListeSorguIstekDVO {
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public hastaTcKimlikNo: number;
    }

    export class ereceteSorguCevapDVO {
        public receteTesisDVO: receteTesisDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class ereceteSorguIstekDVO {
        public tesisKodu: number;
        public ereceteNo: string;
        public doktorTcKimlikNo: number;
    }

    export class imzaliEreceteGirisCevapDVO {
        public ereceteDVO: receteTesisDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class imzaliEreceteGirisIstekDVO {
        public imzaliErecete: Array<number>;
        public tesisKodu: number;
        public surumNumarasi: number;
        public doktorTcKimlikNo: number;
    }

    export class ereceteSilDVO {
        public eReceteNo: string;
        public tesisKodu: string;
        public doktorTcKimlikNo: string;
    }

    export class sonucDVO {
        public ereceteDVO: receteTesisDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public eReceteNo: string;
    }

    export class WebMethods {
        public static async ereceteListeSorgu(siteID: Guid, userName: string, password: string, ereceteListeSorguIstek: ereceteListeSorguIstekDVO): Promise<ereceteListeSorguCevapDVO> {
            let url: string = "/api/OptikReceteIslemleriController/ereceteListeSorgu";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteListeSorguIstek": ereceteListeSorguIstek };
            let result = await ServiceLocator.post(url, inputDto) as ereceteListeSorguCevapDVO;
            return result;
        }
        public static async ereceteSil(siteID: Guid, userName: string, password: string, ereceteSil: ereceteSilDVO): Promise<sonucDVO> {
            let url: string = "/api/OptikReceteIslemleriController/ereceteSil";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "ereceteSil": ereceteSil };
            let result = await ServiceLocator.post(url, inputDto) as sonucDVO;
            return result;
        }
        public static async ereceteKaydet(siteID: Guid, userName: string, password: string, receteTesis: receteTesisDVO): Promise<sonucDVO> {
            let url: string = "/api/OptikReceteIslemleriController/ereceteKaydet";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "receteTesis": receteTesis };
            let result = await ServiceLocator.post(url, inputDto) as sonucDVO;
            return result;
        }
    }
}
