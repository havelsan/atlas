//$4FF53A72
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace KPSYbKisiSorgulaYbKimlikNoServis {
    export class YbKisiSorgulaYbKimlikNoSorguKriteri {
        public KimlikNo: number;
    }

    export class YbKimlikNoIleYbKisiBilgisiSonucu {
        public HataBilgisi: Parametre;
        public SorguSonucu: Array<YbKimlikNoIleYbKisiBilgisi>;
    }

    export class Parametre {
        public Aciklama: string;
        public Kod: number;
    }

    export class YbKimlikNoIleYbKisiBilgisi {
        public Ad: string;
        public AnneAd: string;
        public AnneKimlikNo: number;
        public BabaAd: string;
        public BabaKimlikNo: number;
        public BitisTarihiBelirsizOlmaNeden: Parametre;
        public Cinsiyet: Parametre;
        public DogumTarih: TarihBilgisi;
        public DogumYer: string;
        public DogumYerKod: number;
        public Durum: Parametre;
        public EsKimlikNo: number;
        public HataBilgisi: Parametre;
        public IzinBaslangicTarih: Date;
        public IzinBitisTarih: Date;
        public IzinDuzenlenenIl: Parametre;
        public IzinNo: string;
        public KaynakBirim: Parametre;
        public KazanilanTCKimlikNo: number;
        public KimlikNo: number;
        public MedeniHal: Parametre;
        public OlumTarih: TarihBilgisi;
        public Soyad: string;
        public Uyruk: Parametre;
    }

    export class TarihBilgisi {
        public Ay: number;
        public Gun: number;
        public Yil: number;
    }

    export class WebMethods {
        public static async ListeleCokluSync(siteID: Guid, kriter: YbKisiSorgulaYbKimlikNoSorguKriteri): Promise<YbKimlikNoIleYbKisiBilgisiSonucu> {
            let url: string = "/api/KPSYbKisiSorgulaYbKimlikNoServisController/ListeleCokluSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as YbKimlikNoIleYbKisiBilgisiSonucu;
            return result;
        }
    }
}
