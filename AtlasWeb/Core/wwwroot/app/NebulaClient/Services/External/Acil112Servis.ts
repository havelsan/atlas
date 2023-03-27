//$4F45B2A4
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { TTWebServiceUri } from "NebulaClient/Utils/TTWebServiceUri";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace Acil112Servis {
    export enum BolumKodlari {
        /// <remarks/>
        AcilEriskin,
        /// <remarks/>
        AcilCocuk,
        /// <remarks/>
        YogunBakimKoroner,
        /// <remarks/>
        YogunBakimKalpDamar,
        /// <remarks/>
        YogunBakimAnestezi_Reanimasyon,
        /// <remarks/>
        YogunBakimNoroloji,
        /// <remarks/>
        YogunBakimBeyinCerrahisi,
        /// <remarks/>
        YogunBakimGenelCerrahi,
        /// <remarks/>
        YogunBakimDahiliye,
        /// <remarks/>
        YogunBakimGogusHastaliklari,
        /// <remarks/>
        YogunBakimKadinDogum,
        /// <remarks/>
        YogunBakimPediatri,
        /// <remarks/>
        YogunBakimYenidogan,
        /// <remarks/>
        YogunBakimYanik,
        /// <remarks/>
        ServisPediatri,
        /// <remarks/>
        ServisDahiliye,
        /// <remarks/>
        ServisKalpDamar,
        /// <remarks/>
        ServisKadinDogum,
        /// <remarks/>
        ServisGenelCerrahi,
        /// <remarks/>
        ServisOrtopedi,
        /// <remarks/>
        ServisKalpDamarCerrahisi,
        /// <remarks/>
        ServisBeyinCerrahisi,
        /// <remarks/>
        ServisYenidogan,
        /// <remarks/>
        ServisDializ,
        /// <remarks/>
        ServisDiger,
        /// <remarks/>
        Ameliyathane,
        /// <remarks/>
        Morg,
        /// <remarks/>
        YogunBakimCocukCerrahi,
        /// <remarks/>
        ServisCocukCerrahi,
        /// <remarks/>
        ServisCocukKardiyolojisi,
        /// <remarks/>
        ServisCocukHematolojiOnkoloji,
        /// <remarks/>
        ServisCocukKKB,
        /// <remarks/>
        ServisCocukGastroloji,
        /// <remarks/>
        ServisCocukPsikoloji,
        /// <remarks/>
        ServisCocukNoroloji,
        /// <remarks/>
        ServisCocukHastaliklari,
        /// <remarks/>
        ServisKardiyoloji,
        /// <remarks/>
        YogunBakimDiger,
        /// <remarks/>
        ServisEnfeksiyon,
        /// <remarks/>
        YogunBakimEnfeksiyon
    }

    export class VakaBilgileri {
        public protokolNo: number;
        public hastaAdiSoyadi: string;
        public vakaSenesi: string;
        public kimlikNo: string;
    }

    export class BolumBilgileri {
        public BolumAdi: string;
        public ToplamYatak: number;
        public BosYatak: number;
        public ToplamVentil: number;
        public BosVentil: number;
        public ToplamKuvez: number;
        public BosKuvez: number;
    }

    export class HastaBilgileri {
        public AdiSoyadi: string;
        public TCKimlikNo: string;
        public Yas: number;
        public Cinsiyet: string;
        public HastaGirisZamani: string;
        public YatarakTedavi: boolean;
        public Il: string;
        public Ilce: string;
        public Mahalle: string;
    }

    export class BolumBilgisi {
        public BolumKod: BolumKodlari;
        public ToplamYatak: number;
        public BosYatak: number;
        public ToplamVentil: number;
        public BosVentil: number;
        public ToplamKuvez: number;
        public BosKuvez: number;
    }

    export class NobetciPersonelBilgileri {
        public gorev: string;
        public brans: string;
        public bolum: string;
        public personelSicilNo: string;
        public nobetTarihiBaslangic: string;
        public nobetTarihiBitis: string;
        public personelAdi: string;
        public personelSoyadi: string;
        public telefon: string;
        public icap: boolean;
    }

    export class PersonelBilgileri {
        public gorev: string;
        public brans: string;
        public bolum: string;
        public personelSicilNo: string;
        public nobetTarihiBaslangic: string;
        public nobetTarihiBitis: string;
        public personelAdi: string;
        public personelSoyadi: string;
        public telefon: string;
    }

    export class WebMethods {
        public static async KayitNoProtokolNoDonusumSync(siteID: Guid, webServisUri: TTWebServiceUri, kayitNo: string, protokolNo: string, sorguYili: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/KayitNoProtokolNoDonusumSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "kayitNo": kayitNo, "protokolNo": protokolNo, "sorguYili": sorguYili };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async NobetciPersonelGonder_ArraySync(siteID: Guid, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, personelListesi: PersonelBilgileri[]): Promise<number> {
            let url: string = "/api/Acil112ServisController/NobetciPersonelGonder_ArraySync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "personelListesi": personelListesi };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async NobetciPersonelGondermeMetodu_ArraySync(siteID: Guid, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, nobetciler: NobetciPersonelBilgileri[]): Promise<number> {
            let url: string = "/api/Acil112ServisController/NobetciPersonelGondermeMetodu_ArraySync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "nobetciler": nobetciler };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async EUYSTaniGonderASync(siteID: Guid, callerObject: IWebMethodCallback, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, hasta: HastaBilgileri, ICD10Kodu: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/EUYSTaniGonderASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "hasta": hasta, "ICD10Kodu": ICD10Kodu };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async VakaSonlandirmaMetoduASync(siteID: Guid, callerObject: IWebMethodCallback, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, protokolNo: string, tarih: string, hastaKabulTarihi: string, hastaAyrilisTarihi: string, vakaSonuc: string, aciklama: string, XXXXXXSonucTanisi: string, sosyalGuvenlikKurumu: string, sosyalGuvenlikNo: string, tcKimlikNo: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/VakaSonlandirmaMetoduASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "protokolNo": protokolNo, "tarih": tarih, "hastaKabulTarihi": hastaKabulTarihi, "hastaAyrilisTarihi": hastaAyrilisTarihi, "vakaSonuc": vakaSonuc, "aciklama": aciklama, "XXXXXXSonucTanisi": XXXXXXSonucTanisi, "sosyalGuvenlikKurumu": sosyalGuvenlikKurumu, "sosyalGuvenlikNo": sosyalGuvenlikNo, "tcKimlikNo": tcKimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async NobetciPersonelGondermeMetoduSync(siteID: Guid, webServisUri: TTWebServiceUri, nobetci: NobetciPersonelBilgileri): Promise<number> {
            let url: string = "/api/Acil112ServisController/NobetciPersonelGondermeMetoduSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "nobetci": nobetci };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async NobetciPersonelGonderSync(siteID: Guid, webServisUri: TTWebServiceUri, personelListesi: Object): Promise<number> {
            let url: string = "/api/Acil112ServisController/NobetciPersonelGonderSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "personelListesi": personelListesi };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async ProtokolDetaylariDonderSync(siteID: Guid, webServisUri: TTWebServiceUri, protokolNo: string, sene: string, hastaAdiSoyadi: string, TCKimlikNo: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/ProtokolDetaylariDonderSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "protokolNo": protokolNo, "sene": sene, "hastaAdiSoyadi": hastaAdiSoyadi, "TCKimlikNo": TCKimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async ServiceTestSync(siteID: Guid, webServisUri: TTWebServiceUri): Promise<string> {
            let url: string = "/api/Acil112ServisController/ServiceTestSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri };
            let result = await ServiceLocator.post(url, inputDto) as string;
            return result;
        }
        public static async SonlandirilmamisVakalarListesiDetayliSync(siteID: Guid, webServisUri: TTWebServiceUri, acikVakalar: VakaBilgileri[]): Promise<number> {
            let url: string = "/api/Acil112ServisController/SonlandirilmamisVakalarListesiDetayliSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "acikVakalar": acikVakalar };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async SonlandirilmamisVakalarListesiSync(siteID: Guid, webServisUri: TTWebServiceUri, protokoller: number[]): Promise<number> {
            let url: string = "/api/Acil112ServisController/SonlandirilmamisVakalarListesiSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "protokoller": protokoller };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async SosyalGuvenceKodlariDonderSync(siteID: Guid, webServisUri: TTWebServiceUri, kurumKodlari: string[]): Promise<number> {
            let url: string = "/api/Acil112ServisController/SosyalGuvenceKodlariDonderSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "kurumKodlari": kurumKodlari };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async VakaGuncellemeMetoduSync(siteID: Guid, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, protokolNo: string, tarih: string, XXXXXXKabulTarihi: string, aciklama: string, ip: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/VakaGuncellemeMetoduSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "protokolNo": protokolNo, "tarih": tarih, "XXXXXXKabulTarihi": XXXXXXKabulTarihi, "aciklama": aciklama, "ip": ip };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async VakaSonlandirmaMetoduSync(siteID: Guid, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, protokolNo: string, tarih: string, hastaKabulTarihi: string, hastaAyrilisTarihi: string, vakaSonuc: string, aciklama: string, XXXXXXSonucTanisi: string, sosyalGuvenlikKurumu: string, sosyalGuvenlikNo: string, tcKimlikNo: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/VakaSonlandirmaMetoduSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "protokolNo": protokolNo, "tarih": tarih, "hastaKabulTarihi": hastaKabulTarihi, "hastaAyrilisTarihi": hastaAyrilisTarihi, "vakaSonuc": vakaSonuc, "aciklama": aciklama, "XXXXXXSonucTanisi": XXXXXXSonucTanisi, "sosyalGuvenlikKurumu": sosyalGuvenlikKurumu, "sosyalGuvenlikNo": sosyalGuvenlikNo, "tcKimlikNo": tcKimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async AdetleriGonder_ArraySync(siteID: Guid, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, bolumler: BolumBilgisi[], ipAddr: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/AdetleriGonder_ArraySync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "bolumler": bolumler, "ipAddr": ipAddr };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async AdetleriGonderSync(siteID: Guid, webServisUri: TTWebServiceUri, acilEriskin: BolumBilgileri, acilCocuk: BolumBilgileri, ybKoroner: BolumBilgileri, ybKalpDamar: BolumBilgileri, ybAnestezi: BolumBilgileri, ybNoroloji: BolumBilgileri, ybBeyinCerrahi: BolumBilgileri, ybGenelCerrahi: BolumBilgileri, ybDahiliye: BolumBilgileri, ybGogusHastaliklari: BolumBilgileri, ybKadinDogum: BolumBilgileri, ybPediatri: BolumBilgileri, ybYenidogan: BolumBilgileri, ybYanik: BolumBilgileri, srvPediatri: BolumBilgileri, srvDahiliye: BolumBilgileri, srvKalpDamar: BolumBilgileri, srvKadinDogum: BolumBilgileri, srvGenelCerrahi: BolumBilgileri, srvOrtopedi: BolumBilgileri, srvKalpDamarCerrahi: BolumBilgileri, srvBeyinCerrahi: BolumBilgileri, srvYenidogan: BolumBilgileri, srvDializ: BolumBilgileri, srvDiger: BolumBilgileri, ameliyathane: BolumBilgileri, morg: BolumBilgileri, ipAddr: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/AdetleriGonderSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "acilEriskin": acilEriskin, "acilCocuk": acilCocuk, "ybKoroner": ybKoroner, "ybKalpDamar": ybKalpDamar, "ybAnestezi": ybAnestezi, "ybNoroloji": ybNoroloji, "ybBeyinCerrahi": ybBeyinCerrahi, "ybGenelCerrahi": ybGenelCerrahi, "ybDahiliye": ybDahiliye, "ybGogusHastaliklari": ybGogusHastaliklari, "ybKadinDogum": ybKadinDogum, "ybPediatri": ybPediatri, "ybYenidogan": ybYenidogan, "ybYanik": ybYanik, "srvPediatri": srvPediatri, "srvDahiliye": srvDahiliye, "srvKalpDamar": srvKalpDamar, "srvKadinDogum": srvKadinDogum, "srvGenelCerrahi": srvGenelCerrahi, "srvOrtopedi": srvOrtopedi, "srvKalpDamarCerrahi": srvKalpDamarCerrahi, "srvBeyinCerrahi": srvBeyinCerrahi, "srvYenidogan": srvYenidogan, "srvDializ": srvDializ, "srvDiger": srvDiger, "ameliyathane": ameliyathane, "morg": morg, "ipAddr": ipAddr };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async EUYSTaniGonderSync(siteID: Guid, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, hasta: HastaBilgileri, ICD10Kodu: string): Promise<number> {
            let url: string = "/api/Acil112ServisController/EUYSTaniGonderSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "hasta": hasta, "ICD10Kodu": ICD10Kodu };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
        public static async GetVersionNoSync(siteID: Guid, webServisUri: TTWebServiceUri): Promise<string> {
            let url: string = "/api/Acil112ServisController/GetVersionNoSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri };
            let result = await ServiceLocator.post(url, inputDto) as string;
            return result;
        }
        public static async XXXXXXPersoneliniDonderSync(siteID: Guid, webServisUri: TTWebServiceUri, userName1: string, userPassword1: string, personelListesi: PersonelBilgileri[]): Promise<number> {
            let url: string = "/api/Acil112ServisController/XXXXXXPersoneliniDonderSync";
            let inputDto = { "siteID": siteID, "webServisUri": webServisUri, "userName1": userName1, "userPassword1": userPassword1, "personelListesi": personelListesi };
            let result = await ServiceLocator.post(url, inputDto) as number;
            return result;
        }
    }
}
