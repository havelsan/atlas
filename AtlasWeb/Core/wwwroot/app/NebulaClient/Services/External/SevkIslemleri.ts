//$DA2F7DDA
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace SevkIslemleri {
    export class sevkListeDVO {
        public tcKimlikNo: number;
        public saglikTesisKodu: number;
    }

    export class sevkKayitIptalDVO {
        public sevkTakipNo: string;
        public saglikTesisKodu: number;
    }

    export class sevkIptalCevapDVO {
        public sevkTakipNo: string;
        public esevkNo: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class sevkBildirimIptalDVO {
        public sevkTakipNo: string;
        public saglikTesisKodu: number;
    }

    export class sevkTedaviDVO {
        public tedaviTuru: string;
        public baslangicTarihi: string;
        public bitisTarihi: string;
    }

    export class sevkKayitDVO {
        public kabulTakipNo: string;
        public donusVasitasi: number;
        public refakatci: string;
        public saglikTesisKodu: number;
        public ayrilisTarihi: string;
        public raporId: number;
        public tedaviTani: Array<sevkTaniDVO>;
        public tedaviEdenDoktor: Array<sevkDoktorDVO>;
        public sevkTedavi: Array<sevkTedaviDVO>;
    }

    export class sevkTaniDVO {
        public sevkTaniKodu: string;
    }

    export class sevkDoktorDVO {
        public doktorTescilNo: string;
        public doktorTipi: string;
        public bransKodu: string;
    }

    export class sevkCevapDVO {
        public sevkTakipNo: string;
        public esevkNo: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class sevkBildirimDVO {
        public sevkTakipNo: string;
        public protokolNo: string;
        public sevkEdilenIl: number;
        public sevkEdilenBrans: string;
        public sevkVasitasi: number;
        public sevkNedeni: number;
        public sevkNedeniAciklama: string;
        public tedaviTipi: number;
        public refakakciGerekcesi: string;
        public refakatci: string;
        public sevkTani: Array<sevkTaniDVO>;
        public sevkEdenDoktor: Array<sevkDoktorDVO>;
        public saglikTesisKodu: number;
        public raporId: number;
        public sevkEdilenTesis: number;
    }

    export class mutatDisiIptalCevapDVO {
        public raporID: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class mutatDisiRaporIptalDVO {
        public raporID: number;
        public saglikTesisKodu: number;
    }

    export class mutatDisiRaporCevapDVO {
        public raporId: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class mutatDisiRaporDVO {
        public haksahibiTCNO: number;
        public raporNo: string;
        public protokolNo: string;
        public sevkVasitasi: number;
        public raporTarihi: string;
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public refakatciGerekcesi: string;
        public mutatDisiGerekcesi: string;
        public sevkTani: Array<sevkTaniDVO>;
        public sevkEdenDoktor: Array<sevkDoktorDVO>;
        public saglikTesisKodu: number;
    }

    export class sevkDVO {
        public sevkId: number;
        public tcKimlikNo: number;
        public sevkEdenTesis: number;
        public sevkTakipNo: string;
        public protokolNo: string;
        public sevkEdilenIl: number;
        public sevkTarihi: string;
        public sevkEdilenBrans: string;
        public sevkVasitasi: number;
        public sevkNedeni: number;
        public sevkNedeniAciklama: string;
        public tedaviTipi: number;
        public kabulEdenTesis: number;
        public kabulEdenTakip: string;
        public sevkEdenBrans: string;
    }

    export class sevkListeCevapDVO {
        public sevkListesi: Array<sevkDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class WebMethods {
        public static async mutatDisiAracRaporKaydetSync(siteID: Guid, mutatDisiRaporDVO: mutatDisiRaporDVO): Promise<mutatDisiRaporCevapDVO> {
            let url: string = "/api/SevkIslemleriController/mutatDisiAracRaporKaydetSync";
            let inputDto = { "siteID": siteID, "mutatDisiRaporDVO": mutatDisiRaporDVO };
            let result = await ServiceLocator.post(url, inputDto) as mutatDisiRaporCevapDVO;
            return result;
        }
        public static async mutatDisiAracRaporSilSync(siteID: Guid, mutatDisiRaporIptalDVO: mutatDisiRaporIptalDVO): Promise<mutatDisiIptalCevapDVO> {
            let url: string = "/api/SevkIslemleriController/mutatDisiAracRaporSilSync";
            let inputDto = { "siteID": siteID, "mutatDisiRaporIptalDVO": mutatDisiRaporIptalDVO };
            let result = await ServiceLocator.post(url, inputDto) as mutatDisiIptalCevapDVO;
            return result;
        }
        public static async sevkBildirimIptalSync(siteID: Guid, sevkBildirimIptalDVO: sevkBildirimIptalDVO): Promise<sevkIptalCevapDVO> {
            let url: string = "/api/SevkIslemleriController/sevkBildirimIptalSync";
            let inputDto = { "siteID": siteID, "sevkBildirimIptalDVO": sevkBildirimIptalDVO };
            let result = await ServiceLocator.post(url, inputDto) as sevkIptalCevapDVO;
            return result;
        }
        public static async sevkBildirSync(siteID: Guid, sevkBildirimDVO: sevkBildirimDVO): Promise<sevkCevapDVO> {
            let url: string = "/api/SevkIslemleriController/sevkBildirSync";
            let inputDto = { "siteID": siteID, "sevkBildirimDVO": sevkBildirimDVO };
            let result = await ServiceLocator.post(url, inputDto) as sevkCevapDVO;
            return result;
        }
        public static async sevkKayitIptalSync(siteID: Guid, sevkKayitIptalDVO: sevkKayitIptalDVO): Promise<sevkIptalCevapDVO> {
            let url: string = "/api/SevkIslemleriController/sevkKayitIptalSync";
            let inputDto = { "siteID": siteID, "sevkKayitIptalDVO": sevkKayitIptalDVO };
            let result = await ServiceLocator.post(url, inputDto) as sevkIptalCevapDVO;
            return result;
        }
        public static async sevkKayitSync(siteID: Guid, sevkKayitDVO: sevkKayitDVO): Promise<sevkCevapDVO> {
            let url: string = "/api/SevkIslemleriController/sevkKayitSync";
            let inputDto = { "siteID": siteID, "sevkKayitDVO": sevkKayitDVO };
            let result = await ServiceLocator.post(url, inputDto) as sevkCevapDVO;
            return result;
        }
        public static async sevkListeleSync(siteID: Guid, sevkListeDVO: sevkListeDVO): Promise<sevkListeCevapDVO> {
            let url: string = "/api/SevkIslemleriController/sevkListeleSync";
            let inputDto = { "siteID": siteID, "sevkListeDVO": sevkListeDVO };
            let result = await ServiceLocator.post(url, inputDto) as sevkListeCevapDVO;
            return result;
        }
    }
}
