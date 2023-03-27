//$9806F35F
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace ITSDeaktivasyonServis {
    export class DeaktivasyonBildirimType {
        public DT: string;
        public FR: string;
        public DS: string;
        public ISACIKLAMA: string;
        public BELGE: DeaktivasyonBildirimTypeBELGE;
        public URUNLER: Array<DeaktivasyonBildirimTypeURUN>;
    }

    export class DeaktivasyonBildirimTypeBELGE {
        public DD: Date;
        public DN: string;
    }

    export class DeaktivasyonBildirimCevapType {
        public BILDIRIMID: string;
        public URUNLER: Array<DeaktivasyonBildirimCevapTypeURUNDURUM>;
    }

    export class DeaktivasyonBildirimCevapTypeURUNDURUM {
        public GTIN: string;
        public SN: string;
        public UC: string;
    }

    export class DeaktivasyonBildirimTypeURUN {
        public GTIN: string;
        public BN: string;
        public SN: string;
        public XD: Date;
    }

    export class WebMethods {
        public static async deaktivasyonBildir(siteID: Guid, deaktivasyonBildirimType: ITSDeaktivasyonServis.DeaktivasyonBildirimType): Promise<ITSDeaktivasyonServis.DeaktivasyonBildirimCevapType> {
            let url: string = "/api/ITSDeaktivasyonServisController/deaktivasyonBildir";
            let inputDto = { "siteID": siteID, "deaktivasyonBildirimType": deaktivasyonBildirimType };
            let result = await ServiceLocator.post(url, inputDto) as ITSDeaktivasyonServis.DeaktivasyonBildirimCevapType;
            return result;
        }
    }
}
