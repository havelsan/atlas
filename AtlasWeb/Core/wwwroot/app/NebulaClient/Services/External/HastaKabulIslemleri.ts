//$09CBD94A
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace HastaKabulIslemleri {
    export class provizyonGirisDVO {
        public hastaTCKimlikNo: string;
        public provizyonTarihi: string;
        public saglikTesisKodu: number;
        public bransKodu: string;
        public provizyonTipi: string;
        public tedaviTuru: string;
        public tedaviTipi: string;
        public takipTipi: string;
        public takipNo: string;
        public istisnaiHal: string;
        public yatisBitisTarihi: string;
        public yeniDoganBilgisi: yeniDoganBilgisiDVO;
        public donorTCKimlikNo: string;
        public yesilKartSevkEdenTesisKodu: number;
        public yesilKartSevkEdenTedaviTipi: number;
        public yesilKartSevkEdenTakipTipi: string;
        public yardimHakkiID: number;
        public plakaNo: string;
        public devredilenKurum: string;
        public sigortaliTuru: string;
        public yakinlikKodu: string;
        public hastaTelefon: string;
        public hastaAdres: string;
    }

    export class yeniDoganBilgisiDVO {
        public dogumTarihi: string;
        public cocukSira: number;
    }

    export class mustehaklikCevapDVO {
        public kapsamTuru: number;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class mustehaklikGirisDVO {
        public tcKimlikNo: number;
        public tarih: string;
        public saglikTesisKodu: number;
    }

    export class takipTipiDegistirCevapDVO {
        public takipNo: string;
        public yeniTakipTipi: string;
        public hastaBasvuruNo: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class takipTipiDegistirGirisDVO {
        public takipNo: string;
        public yeniTakiTipi: string;
        public saglikTesisKodu: number;
    }

    export class tedaviTuruDegistirCevapDVO {
        public takipNo: string;
        public yeniTedaviTuru: string;
        public hastaBasvuruNo: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class tedaviTuruDegistirGirisDVO {
        public takipNo: string;
        public yeniTedaviTuru: string;
        public yatisBitisTarihi: string;
        public saglikTesisKodu: number;
    }

    export class yesilKartliHastaSevkBilgileriDVO {
        public takipNo: string;
        public sevkEdilmeTarihi: string;
        public sevkEdenTesisKodu: number;
        public sevkEdilenBransKodu: string;
        public provizyonTipi: string;
        public tedaviTuru: string;
        public tedaviTipi: string;
        public bransKodu: string;
        public takipTipi: string;
        public sevkEdilenTesisAdi: string;
        public sevkEdilenTakipTipi: string;
        public sevkEdilenTedaviTipi: string;
        public sevkAciklama: string;
    }

    export class yesilKartliSevkliHastaCevapDVO {
        public hastaBilgileri: hastaBilgileriDVO;
        public yesilKartliHastaSevkBilgileri: Array<yesilKartliHastaSevkBilgileriDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
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

    export class yesilKartliSevkliHastaGirisDVO {
        public hastaTCKNo: string;
        public saglikTesisKodu: number;
    }

    export class provizyonDegistirCevapDVO {
        public hastaBasvuruNo: string;
        public takipNo: string;
        public yeniProvizyonTipi: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class provizyonDegistirGirisDVO {
        public takipNo: string;
        public yeniProvizyonTipi: string;
        public saglikTesisKodu: number;
    }

    export class sevkBildirSonucDVO {
        public sevkEdilisTarihi: string;
        public takipNo: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class sevkBildirGirisDVO {
        public takipNo: string;
        public sevkEdilisTarihi: string;
        public saglikTesisKodu: number;
        public yesilKartSevkEdilenBransKodu: string;
        public yesilKartSevkEdilenTedaviTipi: number;
        public yesilKartSevkEdilenTakipTipi: string;
    }

    export class basvuruTakipDVO {
        public takipNo: string;
        public takipFaturaDurumu: string;
    }

    export class basvuruTakipOkuCevapDVO {
        public basvuruTakip: Array<basvuruTakipDVO>;
        public hastaBasvuruNo: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class basvuruTakipOkuDVO {
        public hastaBasvuruNo: string;
        public saglikTesisKodu: number;
    }

    export class basvuruYatisBilgileriDVO {
        public baslangicTarihi: string;
        public bitisTarihi: string;
        public durum: string;
    }

    export class hastaYatisOkuCevapDVO {
        public donorTck: string;
        public yeniDoganCocukSiraNo: string;
        public yeniDoganDogumTarihi: string;
        public sonucKodu: string;
        public sonucMesaji: string;
        public basvuruYatisBilgileri: Array<basvuruYatisBilgileriDVO>;
        public hastaBasvuruNo: string;
        public saglikTesisiKodu: number;
    }

    export class hastaYatisOkuDVO {
        public hastaBasvuruNo: string;
        public saglikTesisKodu: number;
    }

    export class hastaCikisIptalDVO {
        public hastaBasvuruNo: string;
        public hastaCikisTarihi: string;
        public yeniHastaCikisTarihi: string;
        public saglikTesisKodu: number;
    }

    export class hastaCikisCevapDVO {
        public yatisBaslangicTarihi: string;
        public yatisBitisTarihi: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class hastaCikisDVO {
        public hastaBasvuruNo: string;
        public hastaCikisTarihi: string;
        public saglikTesisKodu: number;
    }

    export class takipSilCevapDVO {
        public takipNo: string;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class takipSilGirisDVO {
        public saglikTesisKodu: number;
        public takipNo: string;
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

    export class takipOkuGirisDVO {
        public takipNo: string;
        public yeniTedaviTipi: number;
        public saglikTesisKodu: number;
    }

    export class sigortaliAdliGecmisDVO {
        public tckNo: string;
        public provTipi: string;
        public provTarihi: string;
    }

    export class provizyonCevapDVO {
        public takipNo: string;
        public hastaBasvuruNo: string;
        public hastaBilgileri: hastaBilgileriDVO;
        public sigortaliAdliGecmisi: Array<sigortaliAdliGecmisDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class WebMethods {
        public static async updateTakipTipiASync(siteID: Guid, callerObject: IWebMethodCallback, takipTipiDegistirGirisDVO: takipTipiDegistirGirisDVO): Promise<takipTipiDegistirCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateTakipTipiASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "takipTipiDegistirGirisDVO": takipTipiDegistirGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as takipTipiDegistirCevapDVO;
            return result;
        }
        public static async updateTakipTipiSync(siteID: Guid, takipTipiDegistirDVO: takipTipiDegistirGirisDVO): Promise<takipTipiDegistirCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateTakipTipiSync";
            let inputDto = { "siteID": siteID, "takipTipiDegistirDVO": takipTipiDegistirDVO };
            let result = await ServiceLocator.post(url, inputDto) as takipTipiDegistirCevapDVO;
            return result;
        }
        public static async updateTedaviTipiASync(siteID: Guid, callerObject: IWebMethodCallback, takipOkuGirisDVO: takipOkuGirisDVO): Promise<takipDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateTedaviTipiASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "takipOkuGirisDVO": takipOkuGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as takipDVO;
            return result;
        }
        public static async updateTedaviTipiSync(siteID: Guid, takipOkuDVO: takipOkuGirisDVO): Promise<takipDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateTedaviTipiSync";
            let inputDto = { "siteID": siteID, "takipOkuDVO": takipOkuDVO };
            let result = await ServiceLocator.post(url, inputDto) as takipDVO;
            return result;
        }
        public static async updateTedaviTuruASync(siteID: Guid, callerObject: IWebMethodCallback, tedaviTuruDegistirDVO: tedaviTuruDegistirGirisDVO): Promise<tedaviTuruDegistirCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateTedaviTuruASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "tedaviTuruDegistirDVO": tedaviTuruDegistirDVO };
            let result = await ServiceLocator.post(url, inputDto) as tedaviTuruDegistirCevapDVO;
            return result;
        }
        public static async updateTedaviTuruSync(siteID: Guid, tedaviTuruDegistirDVO: tedaviTuruDegistirGirisDVO): Promise<tedaviTuruDegistirCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateTedaviTuruSync";
            let inputDto = { "siteID": siteID, "tedaviTuruDegistirDVO": tedaviTuruDegistirDVO };
            let result = await ServiceLocator.post(url, inputDto) as tedaviTuruDegistirCevapDVO;
            return result;
        }
        public static async basvuruTakipOkuASync(siteID: Guid, callerObject: IWebMethodCallback, basvuruTakipOkuDVO: basvuruTakipOkuDVO): Promise<basvuruTakipOkuCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/basvuruTakipOkuASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "basvuruTakipOkuDVO": basvuruTakipOkuDVO };
            let result = await ServiceLocator.post(url, inputDto) as basvuruTakipOkuCevapDVO;
            return result;
        }
        public static async basvuruTakipOkuSync(siteID: Guid, basvuruTakipOkuDVO: basvuruTakipOkuDVO): Promise<basvuruTakipOkuCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/basvuruTakipOkuSync";
            let inputDto = { "siteID": siteID, "basvuruTakipOkuDVO": basvuruTakipOkuDVO };
            let result = await ServiceLocator.post(url, inputDto) as basvuruTakipOkuCevapDVO;
            return result;
        }
        public static async getMustehaklikKapsamKoduSync(siteID: Guid, mustehaklikGirisDVO: mustehaklikGirisDVO): Promise<mustehaklikCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/getMustehaklikKapsamKoduSync";
            let inputDto = { "siteID": siteID, "mustehaklikGirisDVO": mustehaklikGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as mustehaklikCevapDVO;
            return result;
        }
        public static async getYesilKartliSevkliHastaSync(siteID: Guid, yesilKartliSevkliHastaGiris: yesilKartliSevkliHastaGirisDVO): Promise<yesilKartliSevkliHastaCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/getYesilKartliSevkliHastaSync";
            let inputDto = { "siteID": siteID, "yesilKartliSevkliHastaGiris": yesilKartliSevkliHastaGiris };
            let result = await ServiceLocator.post(url, inputDto) as yesilKartliSevkliHastaCevapDVO;
            return result;
        }
        public static async hastaCikisIptalSync(siteID: Guid, hastaCikisIptal: hastaCikisIptalDVO): Promise<hastaCikisCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaCikisIptalSync";
            let inputDto = { "siteID": siteID, "hastaCikisIptal": hastaCikisIptal };
            let result = await ServiceLocator.post(url, inputDto) as hastaCikisCevapDVO;
            return result;
        }
        public static async hastaCikisKayitSync(siteID: Guid, hastaCikis: hastaCikisDVO): Promise<hastaCikisCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaCikisKayitSync";
            let inputDto = { "siteID": siteID, "hastaCikis": hastaCikis };
            let result = await ServiceLocator.post(url, inputDto) as hastaCikisCevapDVO;
            return result;
        }
        public static async hastaKabulASync(siteID: Guid, callerObject: IWebMethodCallback, provizyonGiris: provizyonGirisDVO): Promise<provizyonCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaKabulASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "provizyonGiris": provizyonGiris };
            let result = await ServiceLocator.post(url, inputDto) as provizyonCevapDVO;
            return result;
        }
        public static async hastaKabulIptalSync(siteID: Guid, takipSilGiris: takipSilGirisDVO): Promise<takipSilCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaKabulIptalSync";
            let inputDto = { "siteID": siteID, "takipSilGiris": takipSilGiris };
            let result = await ServiceLocator.post(url, inputDto) as takipSilCevapDVO;
            return result;
        }
        public static async hastaKabulKimlikDogrulamaSync(siteID: Guid, provizyonGiris: provizyonGirisDVO): Promise<provizyonCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaKabulKimlikDogrulamaSync";
            let inputDto = { "siteID": siteID, "provizyonGiris": provizyonGiris };
            let result = await ServiceLocator.post(url, inputDto) as provizyonCevapDVO;
            return result;
        }
        public static async hastaKabulOkuASync(siteID: Guid, callerObject: IWebMethodCallback, takipOkuGirisDVO: takipOkuGirisDVO): Promise<takipDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaKabulOkuASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "takipOkuGirisDVO": takipOkuGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as takipDVO;
            return result;
        }
        public static async hastaKabulOkuSync(siteID: Guid, takipOkuGirisDVO: takipOkuGirisDVO): Promise<takipDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaKabulOkuSync";
            let inputDto = { "siteID": siteID, "takipOkuGirisDVO": takipOkuGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as takipDVO;
            return result;
        }
        public static async hastaKabulSync(siteID: Guid, provizyonGiris: provizyonGirisDVO): Promise<provizyonCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaKabulSync";
            let inputDto = { "siteID": siteID, "provizyonGiris": provizyonGiris };
            let result = await ServiceLocator.post(url, inputDto) as provizyonCevapDVO;
            return result;
        }
        public static async hastaYatisOkuSync(siteID: Guid, hastaYatisOkuDVO: hastaYatisOkuDVO): Promise<hastaYatisOkuCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/hastaYatisOkuSync";
            let inputDto = { "siteID": siteID, "hastaYatisOkuDVO": hastaYatisOkuDVO };
            let result = await ServiceLocator.post(url, inputDto) as hastaYatisOkuCevapDVO;
            return result;
        }
        public static async sevkBildirSync(siteID: Guid, sevkBildirGiris: sevkBildirGirisDVO): Promise<sevkBildirSonucDVO> {
            let url: string = "/api/HastaKabulIslemleriController/sevkBildirSync";
            let inputDto = { "siteID": siteID, "sevkBildirGiris": sevkBildirGiris };
            let result = await ServiceLocator.post(url, inputDto) as sevkBildirSonucDVO;
            return result;
        }
        public static async updateProvizyonTipiASync(siteID: Guid, callerObject: IWebMethodCallback, provizyonDegistirGirisDVO: provizyonDegistirGirisDVO): Promise<provizyonDegistirCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateProvizyonTipiASync";
            let inputDto = { "siteID": siteID, "callerObject": callerObject, "provizyonDegistirGirisDVO": provizyonDegistirGirisDVO };
            let result = await ServiceLocator.post(url, inputDto) as provizyonDegistirCevapDVO;
            return result;
        }
        public static async updateProvizyonTipiSync(siteID: Guid, provizyonDegistirDVO: provizyonDegistirGirisDVO): Promise<provizyonDegistirCevapDVO> {
            let url: string = "/api/HastaKabulIslemleriController/updateProvizyonTipiSync";
            let inputDto = { "siteID": siteID, "provizyonDegistirDVO": provizyonDegistirDVO };
            let result = await ServiceLocator.post(url, inputDto) as provizyonDegistirCevapDVO;
            return result;
        }
    }
}
