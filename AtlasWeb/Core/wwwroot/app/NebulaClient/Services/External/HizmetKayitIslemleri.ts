//$E705C4A5
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace HizmetKayitIslemleri {
    export class hizmetKayitGirisDVO {
        public triajBeyani: string;
        public kanBilgileri: Array<kanBilgisiDVO>;
        public ameliyatveGirisimBilgileri: Array<ameliyatveGirisimBilgisiDVO>;
        public digerIslemBilgileri: Array<digerIslemBilgisiDVO>;
        public disBilgileri: Array<disBilgisiDVO>;
        public hastaBasvuruNo: string;
        public hastaYatisBilgileri: Array<hastaYatisBilgisiDVO>;
        public ilacBilgileri: Array<ilacBilgisiDVO>;
        public konsultasyonBilgileri: Array<konsultasyonBilgisiDVO>;
        public malzemeBilgileri: Array<malzemeBilgisiDVO>;
        public muayeneBilgisi: muayeneBilgisiDVO;
        public saglikTesisKodu: number;
        public tahlilBilgileri: Array<tahlilBilgisiDVO>;
        public takipNo: string;
        public tanilar: Array<taniBilgisiDVO>;
        public tetkikveRadyolojiBilgileri: Array<tetkikveRadyolojiBilgisiDVO>;
    }

    export class kanBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public adet: number;
        public adetSpecified: boolean;
        public bransKodu: string;
        public drTescilNo: string;
        public islemSiraNo: string;
        public ozelDurum: string;
        public sutKodu: string;
        public hizmetSunucuRefNo: string;
        public islemTarihi: string;
        public isbtBilesenNo: string;
        public isbtUniteNo: string;
    }

    export class hizmetIptalCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class hizmetIptalGirisDVO {
        public islemSiraNumaralari: Array<string>;
        public saglikTesisKodu: number;
        public takipNo: string;
    }

    export class hizmetDVO {
        public triajBeyani: string;
        public kanBilgileri: Array<kanBilgisiDVO>;
        public odemeSorguDurum: string;
        public ameliyatveGirisimBilgileri: Array<ameliyatveGirisimBilgisiDVO>;
        public digerIslemBilgileri: Array<digerIslemBilgisiDVO>;
        public disBilgileri: Array<disBilgisiDVO>;
        public hastaYatisBilgileri: Array<hastaYatisBilgisiDVO>;
        public ilacBilgileri: Array<ilacBilgisiDVO>;
        public konsultasyonBilgileri: Array<konsultasyonBilgisiDVO>;
        public malzemeBilgileri: Array<malzemeBilgisiDVO>;
        public muayeneBilgisi: muayeneBilgisiDVO;
        public tahlilBilgileri: Array<tahlilBilgisiDVO>;
        public takipNo: string;
        public tanilar: Array<taniBilgisiDVO>;
        public tetkikveRadyolojiBilgileri: Array<tetkikveRadyolojiBilgisiDVO>;
    }

    export class ameliyatveGirisimBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public ozelDurum: string;
        public euroscore: string;
        public aciklama: string;
        public adet: number;
        public adetSpecified: boolean;
        public ayniFarkliKesi: string;
        public bransKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public sagSol: string;
        public sutKodu: string;
    }

    export class digerIslemBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public ayniFarkliKesi: string;
        public ozelDurum: string;
        public adet: number;
        public adetSpecified: boolean;
        public bransKodu: string;
        public sutKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public raporTakipNo: string;
    }

    export class disBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public disTaahhutNo: number;
        public disTaahhutNoSpecified: boolean;
        public ayniFarkliKesi: string;
        public ozelDurum: string;
        public adet: number;
        public adetSpecified: boolean;
        public anomali: string;
        public bransKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public sagAltCene: string;
        public sagSutAltCene: string;
        public sagSutUstCene: string;
        public sagUstCene: string;
        public solAltCene: string;
        public solSutAltCene: string;
        public solSutUstCene: string;
        public solUstCene: string;
        public sutKodu: string;
        public sagAltCeneAnomaliDis: string;
        public sagUstCeneAnomaliDis: string;
        public solAltCeneAnomaliDis: string;
        public solUstCeneAnomaliDis: string;
    }

    export class hastaYatisBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public aciklama: string;
        public ozelDurum: string;
        public bransKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public refakatciGunSayisi: string;
        public sutKodu: string;
        public yatisBaslangicTarihi: string;
        public yatisBitisTarihi: string;
        public yatakKodu: string;
    }

    export class ilacBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public ozelDurum: string;
        public paketHaric: string;
        public aciklama: string;
        public adet: number;
        public adetSpecified: boolean;
        public barkod: string;
        public hizmetSunucuRefNo: string;
        public ilacTuru: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public tutar: number;
        public tutarSpecified: boolean;
    }

    export class konsultasyonBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public ozelDurum: string;
        public bransKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public sutKodu: string;
    }

    export class malzemeBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public kdv: number;
        public kdvSpecified: boolean;
        public ozelDurum: string;
        public katkiPayi: string;
        public kodsuzMalzemeAdi: string;
        public adet: number;
        public adetSpecified: boolean;
        public barkod: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public kodsuzMalzemeFiyati: number;
        public kodsuzMalzemeFiyatiSpecified: boolean;
        public malzemeKodu: string;
        public malzemeTuru: string;
        public paketHaric: string;
        public firmaTanimlayiciNo: string;
        public bransKodu: string;
        public drTescilNo: string;
        public malzemeSatinAlisTarihi: string;
        public donorId: string;
        public ihaleKesinlesmeTarihi: string;
        public ikNoAlimNo: string;
    }

    export class muayeneBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public ozelDurum: string;
        public bransKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public muayeneTarihi: string;
        public sutKodu: string;
    }

    export class tahlilBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public tahlilSonuclari: Array<tahlilSonucDVO>;
        public ozelDurum: string;
        public adet: number;
        public adetSpecified: boolean;
        public bransKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public sutKodu: string;
    }

    export class tahlilSonucDVO {
        public islemSiraNo: string;
        public sonuc: string;
        public tahlilTipi: string;
        public birim: string;
    }

    export class taniBilgisiDVO {
        public cokluOzelDurum: Array<string>;
        public ozelDurum: string;
        public islemSiraNo: string;
        public hizmetSunucuRefNo: string;
        public birincilTani: string;
        public taniKodu: string;
        public taniTipi: string;
    }

    export class tetkikveRadyolojiBilgisiDVO {
        public modality: string;
        public cokluOzelDurum: Array<string>;
        public sagSol: string;
        public ayniFarkliKesi: string;
        public aciklama: string;
        public birim: string;
        public sonuc: string;
        public ozelDurum: string;
        public adet: number;
        public adetSpecified: boolean;
        public bransKodu: string;
        public drTescilNo: string;
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
        public islemTarihi: string;
        public sutKodu: string;
        public accession: string;
    }

    export class hizmetOkuCevapDVO {
        public hastaBasvuruNo: string;
        public hizmetler: hizmetDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class hizmetOkuGirisDVO {
        public islemSiraNumaralari: Array<string>;
        public saglikTesisKodu: number;
        public takipNo: string;
        public hizmetSunucuRefNolari: Array<string>;
    }

    export class kayitliIslemBilgisiDVO {
        public hizmetSunucuRefNo: string;
        public islemSiraNo: string;
    }

    export class oncekiIslemBilgisiDVO {
        public islemAdedi: number;
        public islemTarihi: string;
        public saglikTesisKodu: number;
        public tesisAdi: string;
    }

    export class hataliIslemBilgisiDVO {
        public hataKodu: string;
        public hataMesaji: string;
        public hizmetSunucuRefNo: string;
        public oncekiIslemBilgisi: oncekiIslemBilgisiDVO;
    }

    export class hizmetKayitCevapDVO {
        public hastaBasvuruNo: string;
        public hataliKayitlar: Array<hataliIslemBilgisiDVO>;
        public islemBilgileri: Array<kayitliIslemBilgisiDVO>;
        public saglikTesisKodu: number;
        public saglikTesisKoduSpecified: boolean;
        public sonucKodu: string;
        public sonucMesaji: string;
        public takipNo: string;
    }

    export class WebMethods {
        public static async hizmetIptalSync(siteID: Guid, hizmetIptalGiris: hizmetIptalGirisDVO): Promise<hizmetIptalCevapDVO> {
            let url: string = "/api/HizmetKayitIslemleriController/hizmetIptalSync";
            let inputDto = { "siteID": siteID, "hizmetIptalGiris": hizmetIptalGiris };
            let result = await ServiceLocator.post(url, inputDto) as hizmetIptalCevapDVO;
            return result;
        }
        public static async hizmetKayitASync(siteID: Guid, procedureObjectID: Guid, callerObject: IWebMethodCallback, hizmetKayitGiris: hizmetKayitGirisDVO): Promise<hizmetKayitCevapDVO> {
            let url: string = "/api/HizmetKayitIslemleriController/hizmetKayitASync";
            let inputDto = { "siteID": siteID, "procedureObjectID": procedureObjectID, "callerObject": callerObject, "hizmetKayitGiris": hizmetKayitGiris };
            let result = await ServiceLocator.post(url, inputDto) as hizmetKayitCevapDVO;
            return result;
        }
        public static async hizmetKayitSync(siteID: Guid, procedureObjectID: Guid, hizmetKayitGiris: hizmetKayitGirisDVO): Promise<hizmetKayitCevapDVO> {
            let url: string = "/api/HizmetKayitIslemleriController/hizmetKayitSync";
            let inputDto = { "siteID": siteID, "procedureObjectID": procedureObjectID, "hizmetKayitGiris": hizmetKayitGiris };
            let result = await ServiceLocator.post(url, inputDto) as hizmetKayitCevapDVO;
            return result;
        }
        public static async hizmetOkuSync(siteID: Guid, hizmetOkuGiris: hizmetOkuGirisDVO): Promise<hizmetOkuCevapDVO> {
            let url: string = "/api/HizmetKayitIslemleriController/hizmetOkuSync";
            let inputDto = { "siteID": siteID, "hizmetOkuGiris": hizmetOkuGiris };
            let result = await ServiceLocator.post(url, inputDto) as hizmetOkuCevapDVO;
            return result;
        }
    }
}
