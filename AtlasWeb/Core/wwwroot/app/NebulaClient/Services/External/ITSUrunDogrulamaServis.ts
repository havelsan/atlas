//$8EF2C05C
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace ITSUrunDogrulamaServis {
    export class UrunDogrulamaBildirimType {
        public DT: string;
        public FR: string;
        public URUNLER: Array<UrunDogrulamaBildirimTypeURUN>;
    }

    export class UrunDogrulamaBildirimTypeURUN {
        public GTIN: string;
        public BN: string;
        public SN: string;
        public XD: Date;
    }

    export class UrunDogrulamaBildirimCevapType {
        public BILDIRIMID: string;
        public URUNLER: Array<UrunDogrulamaBildirimCevapTypeURUNDURUM>;
    }

    export class UrunDogrulamaBildirimCevapTypeURUNDURUM {
        public GTIN: string;
        public SN: string;
        public UC: string;
    }

    export class WebMethods {
        public static async UrunDogrulamaBildir(siteID: Guid, callerObject: IWebMethodCallback, urun: ITSUrunDogrulamaServis.UrunDogrulamaBildirimType): Promise<ITSUrunDogrulamaServis.UrunDogrulamaBildirimCevapType> {
            let url: string = "/api/ITSUrunDogrulamaServisController/UrunDogrulamaBildir";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "urun": urun };
            let result = await ServiceLocator.post(url, inputDto) as ITSUrunDogrulamaServis.UrunDogrulamaBildirimCevapType;
            return result;
        }
    }
}
