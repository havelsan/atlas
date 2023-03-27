//$6940EDCB
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace YardimciIslemler {
    export class IlacListesiSorguIstekDVO {
        public islemTarihi: string;
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class EtkinMaddeSutDVO {
        public etkinMaddeSutNo: string;
        public raporTeshisListesi: Array<RaporTeshisDVO>;
        public doktorBransListesi: Array<string>;
        public doktorSertifikaListesi: Array<string>;
        public tesisAnaGrupListesi: Array<string>;
        public raporDuzenlemeTuru: string;
        public cinsiyeti: string;
        public maksimumRaporTarihi: string;
        public minimumYasi: string;
        public maksimumYasi: string;
        public maksimumRaporSuresi: string;
        public maksimumRaporSuresiBirimi: string;
    }

    export class RaporTeshisDVO {
        public raporTeshisKodu: string;
        public aciklama: string;
    }

    export class EtkinMaddeSutListesiSorguCevapDVO {
        public etkinMaddeSutListesi: Array<EtkinMaddeSutDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class EtkinMaddeSutListesiSorguIstekDVO {
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
        public etkinMaddeKodu: string;
        public raporTarihi: string;
    }

    export class RaporTeshisListesiSorguCevapDVO {
        public raporTeshisListesi: Array<RaporTeshisDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class RaporTeshisListesiSorguIstekDVO {
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class EtkinMaddeDVO {
        public kodu: string;
        public adi: string;
        public icerikMiktari: string;
        public formu: string;
    }

    export class EtkinMaddeListesiSorguCevapDVO {
        public etkinMaddeListesi: Array<EtkinMaddeDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class EtkinMaddeListesiSorguIstekDVO {
        public tesisKodu: number;
        public doktorTcKimlikNo: number;
    }

    export class IlacDVO {
        public barkod: number;
        public ilacAdi: string;
        public sgkIlacKodu: number;
        public ambalajMiktari: number;
        public tekDozMiktari: number;
        public kutuBirimMiktari: number;
    }

    export class IlacListesiSorguCevapDVO {
        public ilacListesi: Array<IlacDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }

    export class WebMethods {
        public static async aktifIlacListesiSorgulaSync(siteID: Guid, ilacListesiSorguIstekDVO: IlacListesiSorguIstekDVO): Promise<IlacListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/aktifIlacListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "ilacListesiSorguIstekDVO": ilacListesiSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as IlacListesiSorguCevapDVO;
            return result;
        }
        public static async etkinMaddeListesiSorgula(siteID: Guid, callerObject: IWebMethodCallback, istekDVO: EtkinMaddeListesiSorguIstekDVO): Promise<EtkinMaddeListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/etkinMaddeListesiSorgula";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as EtkinMaddeListesiSorguCevapDVO;
            return result;
        }
        public static async etkinMaddeSutListesiSorgulaSync(siteID: Guid, istekDVO: EtkinMaddeSutListesiSorguIstekDVO): Promise<EtkinMaddeSutListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/etkinMaddeSutListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as EtkinMaddeSutListesiSorguCevapDVO;
            return result;
        }
        public static async kirmiziReceteIlacListesiSorgulaSync(siteID: Guid, ilacListesiSorguIstekDVO: IlacListesiSorguIstekDVO): Promise<IlacListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/kirmiziReceteIlacListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "ilacListesiSorguIstekDVO": ilacListesiSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as IlacListesiSorguCevapDVO;
            return result;
        }
        public static async morReceteIlacListesiSorgulaSync(siteID: Guid, ilacListesiSorguIstekDVO: IlacListesiSorguIstekDVO): Promise<IlacListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/morReceteIlacListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "ilacListesiSorguIstekDVO": ilacListesiSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as IlacListesiSorguCevapDVO;
            return result;
        }
        public static async normalReceteIlacListesiSorgulaSync(siteID: Guid, ilacListesiSorguIstekDVO: IlacListesiSorguIstekDVO): Promise<IlacListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/normalReceteIlacListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "ilacListesiSorguIstekDVO": ilacListesiSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as IlacListesiSorguCevapDVO;
            return result;
        }
        public static async pasifIlacListesiSorgulaSync(siteID: Guid, ilacListesiSorguIstekDVO: IlacListesiSorguIstekDVO): Promise<IlacListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/pasifIlacListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "ilacListesiSorguIstekDVO": ilacListesiSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as IlacListesiSorguCevapDVO;
            return result;
        }
        public static async raporTeshisListesiSorgula(siteID: Guid, callerObject: IWebMethodCallback, istekDVO: RaporTeshisListesiSorguIstekDVO): Promise<RaporTeshisListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/raporTeshisListesiSorgula";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "istekDVO": istekDVO };
            let result = await ServiceLocator.post(url, inputDto) as RaporTeshisListesiSorguCevapDVO;
            return result;
        }
        public static async turuncuReceteIlacListesiSorgulaSync(siteID: Guid, ilacListesiSorguIstekDVO: IlacListesiSorguIstekDVO): Promise<IlacListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/turuncuReceteIlacListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "ilacListesiSorguIstekDVO": ilacListesiSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as IlacListesiSorguCevapDVO;
            return result;
        }
        public static async yesilReceteIlacListesiSorgulaSync(siteID: Guid, ilacListesiSorguIstekDVO: IlacListesiSorguIstekDVO): Promise<IlacListesiSorguCevapDVO> {
            let url: string = "/api/YardimciIslemlerController/yesilReceteIlacListesiSorgulaSync";
            let inputDto = { "siteID": siteID, "ilacListesiSorguIstekDVO": ilacListesiSorguIstekDVO };
            let result = await ServiceLocator.post(url, inputDto) as IlacListesiSorguCevapDVO;
            return result;
        }
    }
}
