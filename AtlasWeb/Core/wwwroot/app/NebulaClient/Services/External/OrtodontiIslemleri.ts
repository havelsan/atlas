//$3E1A6E9C
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace OrtodontiIslemleri {
    export class ortodontiFormuKaydetGirisDVO {
        public saglikTesisKodu: number;
        public provizyonNo: string;
        public sutKodu: string;
        public formNo: string;
        public islemTarihi: string;
        public tcKimlikNo: string;
    }

    export class ortodontiFormuOkuCevapDVO {
        public formNo: number;
        public islemTuru: string;
        public tesis_kodu_1: number;
        public tesis_kodu_2: number;
        public tesis_kodu_3: number;
        public islem_tarihi_1: string;
        public islem_tarihi_2: string;
        public islem_tarihi_3: string;
        public provizyonNo1: string;
        public provizyonNo2: string;
        public provizyonNo3: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class ortodontiFormuOkuGirisDVO {
        public saglikTesisKodu: number;
        public formNo: string;
        public tcKimlikNo: string;
        public sutKodu: string;
    }

    export class ortodontiFormuIptalCevapDVO {
        public formNo: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class ortodontiFormuIptalGirisDVO {
        public saglikTesisKodu: number;
        public sutKodu: string;
        public formNo: string;
        public tcKimlikNo: string;
    }

    export class ortodontiFormuKaydetCevapDVO {
        public formNo: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class WebMethods {
        public static async ortodontiFormuIptalSync(siteID: Guid, ortodontiFormuIptalGiris: ortodontiFormuIptalGirisDVO): Promise<ortodontiFormuIptalCevapDVO> {
            let url: string = "/api/OrtodontiIslemleriController/ortodontiFormuIptalSync";
            let inputDto = { "siteID": siteID, "ortodontiFormuIptalGiris": ortodontiFormuIptalGiris };
            let result = await ServiceLocator.post(url, inputDto) as ortodontiFormuIptalCevapDVO;
            return result;
        }
        public static async ortodontiFormuKaydetSync(siteID: Guid, ortodontiFormuKaydetGiris: ortodontiFormuKaydetGirisDVO): Promise<ortodontiFormuKaydetCevapDVO> {
            let url: string = "/api/OrtodontiIslemleriController/ortodontiFormuKaydetSync";
            let inputDto = { "siteID": siteID, "ortodontiFormuKaydetGiris": ortodontiFormuKaydetGiris };
            let result = await ServiceLocator.post(url, inputDto) as ortodontiFormuKaydetCevapDVO;
            return result;
        }
        public static async ortodontiFormuOkuSync(siteID: Guid, ortodontiFormuOkuGiris: ortodontiFormuOkuGirisDVO): Promise<ortodontiFormuOkuCevapDVO> {
            let url: string = "/api/OrtodontiIslemleriController/ortodontiFormuOkuSync";
            let inputDto = { "siteID": siteID, "ortodontiFormuOkuGiris": ortodontiFormuOkuGiris };
            let result = await ServiceLocator.post(url, inputDto) as ortodontiFormuOkuCevapDVO;
            return result;
        }
    }
}
