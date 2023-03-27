//$E49B48C2
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace KPSKisiSorgulaKimlikNoServis {
    export class KisiSorgulaTCKimlikNoSorguKriteri {
        public TCKimlikNo: number;
    }

    export class KisiBilgisiSonucu {
        public HataBilgisi: Parametre;
        public SorguSonucu: Array<KisiBilgisi>;
    }

    export class Parametre {
        public Aciklama: string;
        public Kod: number;
    }

    export class KisiBilgisi {
        public AnneTCKimlikNo: number;
        public BabaTCKimlikNo: number;
        public DogumYerKod: number;
        public DurumBilgisi: KisiDurumBilgisi;
        public EsTCKimlikNo: number;
        public HataBilgisi: Parametre;
        public KayitYeriBilgisi: KisiKayitYeriBilgisi;
        public TCKimlikNo: number;
        public TemelBilgisi: KisiTemelBilgisi;
    }

    export class KisiDurumBilgisi {
        public Din: Parametre;
        public Durum: Parametre;
        public MedeniHal: Parametre;
        public OlumTarih: TarihBilgisi;
    }

    export class KisiKayitYeriBilgisi {
        public AileSiraNo: number;
        public BireySiraNo: number;
        public Cilt: Parametre;
        public Il: Parametre;
        public Ilce: Parametre;
    }

    export class KisiTemelBilgisi {
        public Ad: string;
        public AnneAd: string;
        public BabaAd: string;
        public Cinsiyet: Parametre;
        public DogumTarih: TarihBilgisi;
        public DogumYer: string;
        public Soyad: string;
    }

    export class TarihBilgisi {
        public Ay: number;
        public Gun: number;
        public Yil: number;
    }

    export class WebMethods {
        public static async ListeleCokluSync(siteID: Guid, kriter: KisiSorgulaTCKimlikNoSorguKriteri): Promise<KisiBilgisiSonucu> {
            let url: string = "/api/KPSKisiSorgulaKimlikNoServisController/ListeleCokluSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as KisiBilgisiSonucu;
            return result;
        }
    }
}
