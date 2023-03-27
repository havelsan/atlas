//$0D0B1D04
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace MedulaYardimciIslemler {
    export class saglikTesisiAraGirisDVO {
        public saglikTesisKodu: number;
        public tesisKodu: string;
        public tesisTuru: string;
        public tesisIlKodu: string;
        public tesisAdi: string;
    }

    export class barkodSutDVO {
        public barkod: string;
        public firmaTanimlayiciNo: string;
        public sutKodu: string;
        public baslangicTarihi: string;
        public bitisTarihi: string;
    }

    export class barkodSutEslesmeSorguCevapDVO {
        public eslesmeler: Array<barkodSutDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class barkodSutEslesmeSorguGirisDVO {
        public saglikTesisKodu: number;
        public barkod: string;
        public firmaTanimlayiciNo: string;
        public sutKodu: string;
        public tarih: string;
    }

    export class tesisYatakBilgiDVO {
        public yatakKodu: string;
        public turu: string;
        public tescilTuru: number;
        public seviye: number;
        public gecerlilikBaslangicTarihi: string;
        public gecerlilikBitisTarihi: string;
    }

    export class tesisYatakSorguCevapDVO {
        public yataklar: Array<tesisYatakBilgiDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class tesisYatakSorguGirisDVO {
        public saglikTesisKodu: number;
        public tarih: string;
    }

    export class evrakTakipGrupKoduDVO {
        public kodu: number;
        public adi: string;
    }

    export class evrakTakipGrupKoduSorguCevapDVO {
        public grupKodlari: Array<evrakTakipGrupKoduDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class evrakTakipGrupKoduSorguGirisDVO {
        public saglikTesisKodu: number;
    }

    export class sutFiyatDVO {
        public sutKodu: string;
        public adi: string;
        public fiyat: number;
        public turu: number;
        public gecerlilikTarihi: string;
    }

    export class guncelSutSorguCevapDVO {
        public sutKodlari: Array<sutFiyatDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class guncelSutSorguGirisDVO {
        public saglikTesisKodu: number;
        public tarih: string;
    }

    export class damarIziDogrulamaDetayDVO {
        public tckNo: string;
        public islemTarihi: string;
        public brans: string;
        public tesisKodu: number;
        public firmaAdi: string;
        public islemSaati: string;
        public durum: string;
    }

    export class damarIziDogrulamaSorguCevapDVO {
        public damarIziSorguDetay: Array<damarIziDogrulamaDetayDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class damarIziDogrulamaSorguGirisDVO {
        public saglikTesisKodu: number;
        public tckNo: string;
        public islemTarihi: string;
    }

    export class yurtDisiYardimHakkiGetirCevapDetayDVO {
        public id: number;
        public kisiNo: string;
        public adi: string;
        public soyadi: string;
        public formulAdi: string;
        public odemeTuru: string;
        public tedaviKapsami: string;
        public sorguTarihi: string;
        public aciklama: string;
    }

    export class yurtDisiYardimHakkiGetirCevapDVO {
        public yurtDisiDetay: Array<yurtDisiYardimHakkiGetirCevapDetayDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class yurtDisiYardimHakkiGetirGirisDVO {
        public saglikTesisKodu: number;
        public kisiNo: string;
        public provizyonTarihi: string;
    }

    export class takipBilgisiListDVO {
        public takipNo: string;
        public grupTuru: string;
        public grupAdi: string;
        public toplamTutar: number;
    }

    export class takipBilgisiCevapDVO {
        public takipBilgisiListDVO: Array<takipBilgisiListDVO>;
        public saglikTesisKodu: number;
        public evrakRefNo: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class takipBilgisiGirisDVO {
        public saglikTesisKodu: number;
        public evrakRefNo: number;
        public grupTuru: string;
        public grupKodu: number;
    }

    export class katilimPayiDVO {
        public takipNo: string;
        public muayeneKatilimTutari: number;
        public malzemeKatilimTutari: number;
        public tupBebekKatilimTutari: number;
    }

    export class katilimPayiCevapDVO {
        public evrakRefNo: number;
        public katilimPayi: Array<katilimPayiDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class katilimPayiGirisDVO {
        public saglikTesisKodu: number;
        public evrakRefNo: number;
    }

    export class evrakKesintiCevapDVO {
        public evrakRefNo: number;
        public muayeneKatilimTutari: number;
        public malzemeKatilimTutari: number;
        public tupBebekKatilimTutari: number;
        public takipler: Array<evrakTakipDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class evrakTakipDVO {
        public takipNo: string;
        public grupTuru: string;
        public grupKodu: number;
        public toplamTutar: number;
        public kesintiler: Array<takipIslemKesintiDVO>;
    }

    export class takipIslemKesintiDVO {
        public islemSiraNo: string;
        public hizmetSunucuRefNo: string;
        public islemTarihi: string;
        public sutKodu: string;
        public islemAdi: string;
        public tutar: number;
        public kesintiTutari: number;
        public aciklama: string;
    }

    export class evrakKesintiGirisDVO {
        public saglikTesisKodu: number;
        public evrakRefNo: number;
        public grupTuru: string;
        public grupKodu: number;
    }

    export class orneklenmisCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public saglikTesisKodu: number;
        public evrakRefNo: number;
        public takipler: Array<evrakTakipDVO>;
    }

    export class orneklenmisGirisDVO {
        public saglikTesisKodu: number;
        public evrakRefNo: number;
        public grupTuru: string;
        public grupKodu: number;
    }

    export class ilacIndirimDVO {
        public gecerlilikTarihi: string;
        public ilac_id: number;
        public kamuIndOranUst: number;
        public kamuIndOranAlt: number;
        public indirimOrani1: number;
        public indirimOrani2: number;
        public indirimOrani3: number;
        public indirimOrani4: number;
    }

    export class fiyatListDVO {
        public gecerlilikTarihi: string;
        public fiyat: number;
    }

    export class ilacListDVO {
        public barkod: string;
        public ilacAdi: string;
        public kullanimBirimi: number;
        public ilacFiyatlari: Array<fiyatListDVO>;
        public ilacIndirimleri: Array<ilacIndirimDVO>;
        public eczAktifPasif: string;
        public hasAktifPasif: string;
        public ayaktanOdenme: string;
        public yatanOdenme: string;
    }

    export class ilacAraCevapDVO {
        public ilaclar: Array<ilacListDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class ilacAraGirisDVO {
        public barkod: string;
        public ilacAdi: string;
        public saglikTesisKodu: number;
    }

    export class hastaBilgileriDVO {
        public tcKimlikNo: string;
        public ad: string;
        public soyad: string;
        public cinsiyet: string;
        public dogumTarihi: string;
        public sigortaliTuru: string;
        public devredilenKurum: string;
        public katilimPayindanMuaf: string;
        public kapsamAdi: string;
    }

    export class takipDVO {
        public faturaTeslimNo: string;
        public ilkTakipNo: string;
        public bransKodu: string;
        public donorTCKimlikNo: string;
        public hastaBasvuruNo: string;
        public hastaBilgileri: hastaBilgileriDVO;
        public kayitTarihi: string;
        public provizyonTipi: string;
        public takipDurumu: string;
        public takipNo: string;
        public takipTarihi: string;
        public takipTipi: string;
        public tedaviTipi: string;
        public tedaviTuru: string;
        public tesisKodu: number;
        public sevkDurumu: string;
        public yeniDoganCocukSiraNo: string;
        public yeniDoganDogumTarihi: string;
        public arvFlag: string;
        public evrakID: number;
        public istisnaiHal: string;
        public fatutaIptalHakki: number;
        public faturaTarihi: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class takipAraCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public takipler: Array<takipDVO>;
    }

    export class takipAraGirisDVO {
        public hastaTCK: string;
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public sevkDurumu: string;
        public saglikTesisKodu: number;
    }

    export class doktorListDVO {
        public drTescilNo: string;
        public drAdi: string;
        public drSoyadi: string;
        public drDiplomaNo: string;
    }

    export class doktorAraCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public doktorlar: Array<doktorListDVO>;
    }

    export class doktorAraGirisDVO {
        public saglikTesisKodu: number;
        public drTescilNo: string;
        public drAdi: string;
        public drSoyadi: string;
        public drDiplomaNo: string;
        public drBransKodu: string;
    }

    export class saglikTesisiListDVO {
        public tesisKodu: number;
        public tesisAdi: string;
        public tesisIl: string;
        public tesisTuru: string;
        public tesisSinifKodu: string;
    }

    export class saglikTesisiAraCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public tesisler: Array<saglikTesisiListDVO>;
    }

    export class WebMethods {
        public static async doktorAraSync(siteID: Guid, doktorAraGiris: doktorAraGirisDVO): Promise<doktorAraCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/doktorAraSync";
            let inputDto = { "siteID": siteID, "doktorAraGiris": doktorAraGiris };
            let result = await ServiceLocator.post(url, inputDto) as doktorAraCevapDVO;
            return result;
        }
        public static async getOrneklenmisTakiplerSync(siteID: Guid, orneklenmisGirisDVO: orneklenmisGirisDVO): Promise<orneklenmisCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/getOrneklenmisTakiplerSync";
            let inputDto = { "siteID": siteID, "orneklenmisGirisDVO": orneklenmisGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as orneklenmisCevapDVO;
            return result;
        }
        public static async getRemoteAddrSync(siteID: Guid): Promise<string> {
            let url: string = "/api/MedulaYardimciIslemler/getRemoteAddrSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as string;
            return result;
        }
        public static async ilacAraSync(siteID: Guid, ilacAraGiris: ilacAraGirisDVO): Promise<ilacAraCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/ilacAraSync";
            let inputDto = { "siteID": siteID, "ilacAraGiris": ilacAraGiris };
            let result = await ServiceLocator.post(url, inputDto) as ilacAraCevapDVO;
            return result;
        }
        public static async katilimPayiUcretiSync(siteID: Guid, katilimPayiGiris: katilimPayiGirisDVO): Promise<katilimPayiCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/katilimPayiUcretiSync";
            let inputDto = { "siteID": siteID, "katilimPayiGiris": katilimPayiGiris };
            let result = await ServiceLocator.post(url, inputDto) as katilimPayiCevapDVO;
            return result;
        }
        public static async kesintiYapilmisIslemlerSync(siteID: Guid, evrakKesintiGiris: evrakKesintiGirisDVO): Promise<evrakKesintiCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/kesintiYapilmisIslemlerSync";
            let inputDto = { "siteID": siteID, "evrakKesintiGiris": evrakKesintiGiris };
            let result = await ServiceLocator.post(url, inputDto) as evrakKesintiCevapDVO;
            return result;
        }
        public static async saglikTesisiAraSync(siteID: Guid, saglikTesisiAraGiris: saglikTesisiAraGirisDVO): Promise<saglikTesisiAraCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/saglikTesisiAraSync";
            let inputDto = { "siteID": siteID.valueOf(), "saglikTesisiAraGiris": saglikTesisiAraGiris };
            let result = await ServiceLocator.post(url, inputDto) as saglikTesisiAraCevapDVO;
            return result;
        }
        public static async takipAraSync(siteID: Guid, takipAraGiris: takipAraGirisDVO): Promise<takipAraCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/takipAraSync";
            let inputDto = { "siteID": siteID, "takipAraGiris": takipAraGiris };
            let result = await ServiceLocator.post(url, inputDto) as takipAraCevapDVO;
            return result;
        }
        public static async takipBilgileriListesiSync(siteID: Guid, takipBilgisiGirisDVO: takipBilgisiGirisDVO): Promise<takipBilgisiCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/takipBilgileriListesiSync";
            let inputDto = { "siteID": siteID, "takipBilgisiGirisDVO": takipBilgisiGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as takipBilgisiCevapDVO;
            return result;
        }
        public static async yurtDisiYardimHakkiGetirSync(siteID: Guid, yurtDisiYardimHakkiGetirGiris: yurtDisiYardimHakkiGetirGirisDVO): Promise<yurtDisiYardimHakkiGetirCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/yurtDisiYardimHakkiGetirSync";
            let inputDto = { "siteID": siteID, "yurtDisiYardimHakkiGetirGiris": yurtDisiYardimHakkiGetirGiris };
            let result = await ServiceLocator.post(url, inputDto) as yurtDisiYardimHakkiGetirCevapDVO;
            return result;
        }
        public static async tesisYatakSorguSync(siteID: Guid, tesisYatakSorguGiris: tesisYatakSorguGirisDVO): Promise<tesisYatakSorguCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/tesisYatakSorguSync";
            let inputDto = { "siteID": siteID, "tesisYatakSorguGiris": tesisYatakSorguGiris };
            let result = await ServiceLocator.post(url, inputDto) as tesisYatakSorguCevapDVO;
            return result;
        }
        public static async barkodSutEslesmeSorguSync(siteID: Guid, barkodSutEslesmeSorguGiris: barkodSutEslesmeSorguGirisDVO): Promise<barkodSutEslesmeSorguCevapDVO> {
            let url: string = "/api/MedulaYardimciIslemler/barkodSutEslesmeSorguSync";
            let inputDto = { "siteID": siteID, "barkodSutEslesmeSorguGiris": barkodSutEslesmeSorguGiris };
            let result = await ServiceLocator.post(url, inputDto) as barkodSutEslesmeSorguCevapDVO;
            return result;
        }
    }
}
