//$B21FF4D0
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace TakipFormuIslemleri {
    export class takipFormuKaydetGirisDVO {
        public diabetTakipFormu: diabetTakipFormuKayitDVO;
        public saglikTesisKodu: number;
    }

    export class diabetTakipFormuKayitDVO {
        public tcKimlikNo: string;
        public ad: string;
        public soyad: string;
        public cinsiyet: string;
        public cepTel: string;
        public taniKodu: string;
        public taniTarihi: string;
        public vizitTarihi: string;
        public glukoMetre: string;
        public antiGAD: string;
        public mikroalbuminuri: string;
        public periferikSensoryal: string;
        public koronerArterH: string;
        public serebrovaskulerH: string;
        public ayakMuayenesi: string;
        public insulinPompasi: string;
        public insulinPompasiDegTarihi: string;
        public protokolNo: string;
        public saglikTesisKodu: number;
        public ikametTuru: number;
        public doktorBilgileri: Array<takipFormuDoktorBilgisiDVO>;
        public diabetEgitimi: takipFormuDiabetEgitimiDVO;
        public tibbiBeslenmeTedavisi: number;
        public egzersiz: number;
        public hastaliklar: Array<takipFormuHastalikDVO>;
        public basvuruNedeni: number;
        public aliskanliklar: Array<takipFormuAliskanlikDVO>;
        public kanSekeriTakipSayisi: number;
        public kullanilanIlaclar: Array<takipFormuKullanilanIlaclarDVO>;
        public sistolikKanBasinci: number;
        public diyastolikKanBasinci: number;
        public boy: number;
        public kilo: number;
        public vki: number;
        public apg: number;
        public tpg: number;
        public hbA1c: number;
        public kreatinin: number;
        public trigliserid: number;
        public ldlKol: number;
        public hdlKol: number;
        public alt: number;
        public ekg: number;
        public gozMuayenesi: number;
        public akutKomplikasyon: number;
        public yatisGun: number;
        public insulinPompasiVerTarihi: string;
    }

    export class takipFormuDoktorBilgisiDVO {
        public drTescilNo: string;
        public drBransKodu: string;
        public dmEgitimiAlmisMi: string;
    }

    export class takipFormuOkuCevapDVO {
        public diabetTakipFormlari: Array<diabetTakipFormuDVO>;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class diabetTakipFormuDVO {
        public takipFormuNo: string;
        public tcKimlikNo: string;
        public ad: string;
        public soyad: string;
        public cinsiyet: string;
        public cepTel: string;
        public taniKodu: string;
        public taniTarihi: string;
        public vizitTarihi: string;
        public glukoMetre: string;
        public antiGAD: string;
        public mikroalbuminuri: string;
        public periferikSensoryal: string;
        public koronerArterH: string;
        public serebrovaskulerH: string;
        public ayakMuayenesi: string;
        public insulinPompasi: string;
        public insulinPompasiDegTarihi: string;
        public protokolNo: string;
        public saglikTesisKodu: number;
        public ikametTuru: number;
        public doktorBilgileri: Array<takipFormuDoktorBilgisiDVO>;
        public diabetEgitimi: takipFormuDiabetEgitimiDVO;
        public tibbiBeslenmeTedavisi: number;
        public egzersiz: number;
        public hastaliklar: Array<takipFormuHastalikDVO>;
        public basvuruNedeni: number;
        public aliskanliklar: Array<takipFormuAliskanlikDVO>;
        public kanSekeriTakipSayisi: number;
        public kullanilanIlaclar: Array<takipFormuKullanilanIlaclarDVO>;
        public sistolikKanBasinci: number;
        public diyastolikKanBasinci: number;
        public boy: number;
        public kilo: number;
        public vki: number;
        public apg: number;
        public tpg: number;
        public hbA1c: number;
        public kreatinin: number;
        public trigliserid: number;
        public ldlKol: number;
        public hdlKol: number;
        public alt: number;
        public ekg: number;
        public gozMuayenesi: number;
        public akutKomplikasyon: number;
        public yatisGun: number;
        public insulinPompasiVerTarihi: string;
    }

    export class takipFormuDiabetEgitimiDVO {
        public bireyselEgitimSayisi: number;
        public grupEgitimiSayisi: number;
        public dmEgitimiAlmisMi: string;
    }

    export class takipFormuHastalikDVO {
        public digerHastalikTaniKodu: string;
        public hastalikKodu: number;
    }

    export class takipFormuAliskanlikDVO {
        public aliskanlik: number;
    }

    export class takipFormuKullanilanIlaclarDVO {
        public barkod: string;
        public gunlukDoz: string;
    }

    export class takipFormuOkuGirisDVO {
        public saglikTesisKodu: number;
        public tcKimlikNo: string;
    }

    export class takipFormuSilCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class takipFormuSilGirisDVO {
        public takipFormuNo: string;
        public saglikTesisKodu: number;
    }

    export class takipFormuKaydetCevapDVO {
        public diabetTakipFormu: diabetTakipFormuDVO;
        public sonucKodu: string;
        public sonucMesaji: string;
    }

    export class WebMethods {
        public static async takipFormuKaydet(siteID: Guid, takipFormuGiris: takipFormuKaydetGirisDVO): Promise<takipFormuKaydetCevapDVO> {
            let url: string = "/api/TakipFormuIslemleriController/takipFormuKaydet";
            let inputDto = { "siteID": siteID, "takipFormuGiris": takipFormuGiris };
            let result = await ServiceLocator.post(url, inputDto) as takipFormuKaydetCevapDVO;
            return result;
        }
        public static async takipFormuOku(siteID: Guid, takipFormuOkuGiris: takipFormuOkuGirisDVO): Promise<takipFormuOkuCevapDVO> {
            let url: string = "/api/TakipFormuIslemleriController/takipFormuOku";
            let inputDto = { "siteID": siteID, "takipFormuOkuGiris": takipFormuOkuGiris };
            let result = await ServiceLocator.post(url, inputDto) as takipFormuOkuCevapDVO;
            return result;
        }
        public static async takipFormuSil(siteID: Guid, takipFormuSilGiris: takipFormuSilGirisDVO): Promise<takipFormuSilCevapDVO> {
            let url: string = "/api/TakipFormuIslemleriController/takipFormuSil";
            let inputDto = { "siteID": siteID, "takipFormuSilGiris": takipFormuSilGiris };
            let result = await ServiceLocator.post(url, inputDto) as takipFormuSilCevapDVO;
            return result;
        }
    }
}
