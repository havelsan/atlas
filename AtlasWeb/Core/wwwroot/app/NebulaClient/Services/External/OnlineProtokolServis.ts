//$3C0BC896
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace OnlineProtokolServis {
    export class kullanici {
        public kullaniciAdi: string;
        public kullaniciSifre: string;
        public erisimKodu: string;
    }

    export class protokolNoListObjesi {
        public protokolNumarasi: string;
        public protokolTipi: string;
        public USVSPaketID: number;
        public islemTarihi: string;
        public MHRS: string;
        public kayitTarihi: string;
        public otomasyonKayitID: string;
        public hekimTCK: string;
        public vatandasTCK: string;
        public hastaTipi: number;
    }

    export class protokolListesiCevap {
        public cvp: cevap;
        public protokolListesiObjesi: Array<protokolNoListObjesi>;
    }

    export class cevap {
        public cevapKodu: number;
        public cevapAciklama: string;
        public protokolNo: string;
        public hatalar: Array<string>;
    }

    export class protokol {
        public vatandasTCK: string;
        public islemTarihi: string;
        public kurumKodu: string;
        public MHRS: string;
        public USVSPaketId: number;
        public bagliProtokolNo: string;
        public klinikKodu: number;
        public protokolTipi: number;
        public otomasyonKayitId: string;
        public hekimTCK: string;
        public hastaTipi: number;
    }

    export class WebMethods {
        public static async getVersionSync(siteID: Guid): Promise<string> {
            let url: string = "/api/OnlineProtokolServisController/getVersionSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as string;
            return result;
        }
        public static async protokolVerSync(siteID: Guid, kullaniciBilgisi: kullanici, oProtokol: protokol): Promise<cevap> {
            let url: string = "/api/OnlineProtokolServisController/protokolVerSync";
            let inputDto = { "siteID": siteID, "kullaniciBilgisi": kullaniciBilgisi, "oProtokol": oProtokol };
            let result = await ServiceLocator.post(url, inputDto) as cevap;
            return result;
        }
        public static async protokolSilSync(siteID: Guid, protokolNo: string, silmeNedeni: number, kullaniciBilgisi: kullanici): Promise<cevap> {
            let url: string = "/api/OnlineProtokolServisController/protokolSilSync";
            let inputDto = { "siteID": siteID, "protokolNo": protokolNo, "silmeNedeni": silmeNedeni, "kullaniciBilgisi": kullaniciBilgisi };
            let result = await ServiceLocator.post(url, inputDto) as cevap;
            return result;
        }
        public static async protokolListesiSync(siteID: Guid, kullaniciBilgisi: kullanici, kurum: string, tarih: string, otomasyonKayitID: string): Promise<protokolListesiCevap> {
            let url: string = "/api/OnlineProtokolServisController/protokolListesiSync";
            let inputDto = { "siteID": siteID, "kullaniciBilgisi": kullaniciBilgisi, "kurum": kurum, "tarih": tarih, "otomasyonKayitID": otomasyonKayitID };
            let result = await ServiceLocator.post(url, inputDto) as protokolListesiCevap;
            return result;
        }
    }
}
