//$9A92937D
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace ITSSarfBildirimServis {
    export class XXXXXXSarfType {
        public DT: string;
        public FR: string;
        public ISACIKLAMA: string;
        public BELGE: XXXXXXSarfTypeBELGE;
        public URUNLER: Array<XXXXXXSarfTypeURUN>;
    }

    export class XXXXXXSarfTypeBELGE {
        public DD: Date;
        public DN: string;
    }

    export class XXXXXXSarfCevapType {
        public BILDIRIMID: string;
        public URUNLER: Array<XXXXXXSarfCevapTypeURUNDURUM>;
    }

    export class XXXXXXSarfCevapTypeURUNDURUM {
        public GTIN: string;
        public SN: string;
        public UC: string;
    }

    export class XXXXXXSarfTypeURUN {
        public GTIN: string;
        public BN: string;
        public SN: string;
        public XD: Date;
    }

    export class WebMethods {
        public static async XXXXXXSarfBildir(siteID: Guid, XXXXXXSarfType: ITSSarfBildirimServis.XXXXXXSarfType): Promise<XXXXXXSarfCevapType> {
            let url: string = "/api/ITSSarfBildirimServisController/XXXXXXSarfBildir";
            let inputDto = { "siteID": siteID, "XXXXXXSarfType": XXXXXXSarfType };
            let result = await ServiceLocator.post(url, inputDto) as XXXXXXSarfCevapType;
            return result;
        }
    }
}
