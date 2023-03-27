//$7679E6A7
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace FaturaKayitIslemleri {
    export class faturaGirisDVO {
        public hastaBasvuruNo: string;
        public faturaTarihi: string;
        public faturaRefNo: string;
        public saglikTesisKodu: number;
        public hizmetDetaylari: Array<hizmetDetayDVO>;
        public yesilKartSevkEdilenBransKodu: string;
        public yesilKartSevkEdilenTesisKodu: number;
        public yesilKartSevkEdilenTesisAdi: string;
        public yesilKartSevkEdilenTakipTipi: string;
        public yesilKartSevkEdilenAciklama: string;
        public trafikKazasiOdemeYuzdesi: number;
        public ilaveUcret: number;
    }

    export class hizmetDetayDVO {
        public takipNo: string;
        public protokolNo: string;
        public taburcuKodu: string;
        public aciklama: string;
    }

    export class faturaCevapDetayDVO {
        public aciklama: string;
        public islemDetaylari: Array<islemDetayDVO>;
        public protokolNo: string;
        public taburcuKodu: string;
        public takipNo: string;
        public takipToplamTutar: number;
    }

    export class islemDetayDVO {
        public islemSiraNo: string;
        public islemTutari: number;
    }

    export class faturaOkuCevapDVO {
        public faturaDetaylari: Array<faturaCevapDetayDVO>;
        public faturaRefNo: string;
        public faturaTarihi: string;
        public faturaTeslimNo: string;
        public faturaTutari: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class faturaOkuGirisDVO {
        public faturaTeslimNo: string;
        public faturaRefNo: string;
        public faturaTarihi: string;
        public saglikTesisKodu: number;
    }

    export class faturaIptalHataliKayitDVO {
        public faturaTeslimNo: string;
        public hataKodu: string;
        public hataMesaji: string;
    }

    export class faturaIptalCevapDVO {
        public hataliKayitlar: Array<faturaIptalHataliKayitDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class faturaIptalGirisDVO {
        public faturaTeslimNo: Array<string>;
        public saglikTesisKodu: number;
    }

    export class faturaHataDVO {
        public takipNo: string;
        public hataKodu: string;
        public hataMesaji: string;
    }

    export class faturaDetayDVO {
        public takipNo: string;
        public takipToplamTutar: number;
        public islemDetaylari: Array<islemDetayDVO>;
    }

    export class faturaCevapDVO {
        public faturaTeslimNo: string;
        public faturaTutari: number;
        public hastaBasvuruNo: string;
        public faturaRefNo: string;
        public faturaDetaylari: Array<faturaDetayDVO>;
        public hataliKayitlar: Array<faturaHataDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class WebMethods {
        public static async faturaIptalSync(siteID: Guid, faturaIptalGiris: faturaIptalGirisDVO): Promise<faturaIptalCevapDVO> {
            let url: string = "/api/FaturaKayitIslemleriController/faturaIptalSync";
            let inputDto = { "siteID": siteID, "faturaIptalGiris": faturaIptalGiris };
            let result = await ServiceLocator.post(url, inputDto) as faturaIptalCevapDVO;
            return result;
        }
        public static async faturaKayitASync(siteID: Guid, callerObject: IWebMethodCallback, faturaGiris: faturaGirisDVO): Promise<faturaCevapDVO> {
            let url: string = "/api/FaturaKayitIslemleriController/faturaKayitASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "faturaGiris": faturaGiris };
            let result = await ServiceLocator.post(url, inputDto) as faturaCevapDVO;
            return result;
        }
        public static async faturaKayitSync(siteID: Guid, faturaGiris: faturaGirisDVO): Promise<faturaCevapDVO> {
            let url: string = "/api/FaturaKayitIslemleriController/faturaKayitSync";
            let inputDto = { "siteID": siteID, "faturaGiris": faturaGiris };
            let result = await ServiceLocator.post(url, inputDto) as faturaCevapDVO;
            return result;
        }
        public static async faturaOkuSync(siteID: Guid, faturaOkuGiris: faturaOkuGirisDVO): Promise<faturaOkuCevapDVO> {
            let url: string = "/api/FaturaKayitIslemleriController/faturaOkuSync";
            let inputDto = { "siteID": siteID, "faturaOkuGiris": faturaOkuGiris };
            let result = await ServiceLocator.post(url, inputDto) as faturaOkuCevapDVO;
            return result;
        }
        public static async faturaTutarOkuSync(siteID: Guid, faturaOkuGiris: faturaGirisDVO): Promise<faturaCevapDVO> {
            let url: string = "/api/FaturaKayitIslemleriController/faturaTutarOkuSync";
            let inputDto = { "siteID": siteID, "faturaOkuGiris": faturaOkuGiris };
            let result = await ServiceLocator.post(url, inputDto) as faturaCevapDVO;
            return result;
        }
    }
}
