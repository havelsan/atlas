//$785DE0A9
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace TaahhutIslemleri {
    export class taahhutKayitDVO {
        public takipNo: string;
        public taahhut: taahhutDVO;
        public taahhutDiss: Array<taahhutDisDVO>;
        public saglikTesisKodu: number;
    }

    export class taahhutDVO {
        public hastaTCKimlikNo: string;
        public adressIlPlaka: number;
        public adressIlce: string;
        public adressPostaKodu: string;
        public adressCaddeSokak: string;
        public adressDisKapiNo: string;
        public adressIcKapiNo: string;
        public adressTelefon: string;
        public adressEposta: string;
        public taahhutAlanAd: string;
        public taahhutAlanSoyad: string;
    }

    export class taahhutKisiCevapDVO {
        public taahhutNo: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class taahhutKisiOkuDVO {
        public saglikTesisKodu: number;
        public tcKimlikNo: number;
    }

    export class taahhutOkuDVO {
        public taahhutNo: number;
        public saglikTesisKodu: number;
    }

    export class taahhutCevapDVO {
        public taahhutNo: number;
        public taahhutCikti: Array<number>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class taahhutDisDVO {
        public sutKodu: string;
        public disNo: number;
    }

    export class WebMethods {
        public static async disTaahhutKayit(siteID: Guid, taahhutKayit: taahhutKayitDVO): Promise<taahhutCevapDVO> {
            let url: string = "/api/TaahhutIslemleriController/disTaahhutKayit";
            let inputDto = { "siteID": siteID, "taahhutKayit": taahhutKayit };
            let result = await ServiceLocator.post(url, inputDto) as taahhutCevapDVO;
            return result;
        }
        public static async okuDisTaahhut(siteID: Guid, taahhutOku: taahhutOkuDVO): Promise<taahhutCevapDVO> {
            let url: string = "/api/TaahhutIslemleriController/okuDisTaahhut";
            let inputDto = { "siteID": siteID, "taahhutOku": taahhutOku };
            let result = await ServiceLocator.post(url, inputDto) as taahhutCevapDVO;
            return result;
        }
        public static async okuKisiDisTaahhut(siteID: Guid, taahhutOku: taahhutKisiOkuDVO): Promise<taahhutKisiCevapDVO> {
            let url: string = "/api/TaahhutIslemleriController/okuKisiDisTaahhut";
            let inputDto = { "siteID": siteID, "taahhutOku": taahhutOku };
            let result = await ServiceLocator.post(url, inputDto) as taahhutKisiCevapDVO;
            return result;
        }
        public static async silDisTaahhut(siteID: Guid, taahhutOku: taahhutOkuDVO): Promise<taahhutCevapDVO> {
            let url: string = "/api/TaahhutIslemleriController/silDisTaahhut";
            let inputDto = { "siteID": siteID, "taahhutOku": taahhutOku };
            let result = await ServiceLocator.post(url, inputDto) as taahhutCevapDVO;
            return result;
        }
    }
}
