//$6AE1B431
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace AsiEntegrasyonServis {
    export enum EUygulamaDurum {
        /// <remarks/>
        Basarili,
        /// <remarks/>
        Basarisiz,
        /// <remarks/>
        YetkiYok,
        /// <remarks/>
        StokYok,
        /// <remarks/>
        KullaniciadiParolaHatali
    }

    export enum EKullanilabilirlikDurumu {
        /// <remarks/>
        Kullanilabilir,
        /// <remarks/>
        Kullanilamaz,
        /// <remarks/>
        YetkiYok,
        /// <remarks/>
        StokYok,
        /// <remarks/>
        KullaniciadiParolaHatali,
        /// <remarks/>
        TasimaBirimiUrunDegil,
        /// <remarks/>
        SogukZincirMaruziyet,
        /// <remarks/>
        TasimaDurumunda,
        /// <remarks/>
        GeziciHizmetTuketimyok,
        /// <remarks/>
        GeziciHizmette
    }

    export enum EKisiTipi {
        /// <remarks/>
        Vatandas,
        /// <remarks/>
        Yabanci,
        /// <remarks/>
        Vatansiz,
        /// <remarks/>
        YeniDogan
    }

    export class AsiKullanilabilirlikSorgusuGirdi {
        public KullaniciBilgisi: KullaniciBilgisi;
        public SorguBilgisi: AsiSorguBilgisi;
    }

    export class KullaniciBilgisi {
        public KullaniciAdi: string;
        public Parola: string;
    }

    export class UygulamaSorgusuCikti {
        public Bilgi: string;
        public VarMi: boolean;
        public VarMiSpecified: boolean;
    }

    export class ResponseBase {
        public Bilgi: string;
    }

    export class AsiUygulamaCikti extends ResponseBase {
        public SorguNumarasi: string;
        public UygulamaDurum: EUygulamaDurum;
        public UygulamaDurumSpecified: boolean;
    }

    export class AsiUygulamaBilgisi {
        public OnlineProtokolNo: string;
        public SorguNumarasi: string;
        public UygulamaZamani: Date;
    }

    export class AsiUygulamaParametre {
        public KullaniciBilgisi: KullaniciBilgisi;
        public UygulamaSorguBilgisi: AsiUygulamaBilgisi;
    }

    export class AsiKullanilabilirlikSorgusuCikti {
        public Bilgi: string;
        public SorguKullanilabilirlikDurumu: EKullanilabilirlikDurumu;
        public SorguKullanilabilirlikDurumuSpecified: boolean;
        public SorguNumarasi: string;
    }

    export class AsiSorguBilgisi {
        public AsiKodu: string;
        public DogumTarihi: Date;
        public DozBilgisi: number;
        public GeziciHizmetMi: boolean;
        public HekimKimlikNo: string;
        public KirilimBilgisi: string;
        public OnlineProtokolNo: string;
        public SonKullanmaTarihi: Date;
        public StokBarkod: string;
        public StokPartiNo: string;
        public StokSeriNo: string;
        public UygulanacakKisiId: string;
        public UygulanacakKisiTipi: EKisiTipi;
    }

    export class WebMethods {
        public static async AsiKullanilabilirlikSorgusuSync(siteID: Guid, asiKullanilabilirlikSorgusuGirdi: AsiKullanilabilirlikSorgusuGirdi): Promise<AsiKullanilabilirlikSorgusuCikti> {
            let url: string = "/api/AsiEntegrasyonServisController/AsiKullanilabilirlikSorgusuSync";
            let inputDto = { "siteID": siteID, "asiKullanilabilirlikSorgusuGirdi": asiKullanilabilirlikSorgusuGirdi };
            let result = await ServiceLocator.post(url, inputDto) as AsiKullanilabilirlikSorgusuCikti;
            return result;
        }
        public static async AsiUygulamaSync(siteID: Guid, istek: AsiUygulamaParametre): Promise<AsiUygulamaCikti> {
            let url: string = "/api/AsiEntegrasyonServisController/AsiUygulamaSync";
            let inputDto = { "siteID": siteID, "istek": istek };
            let result = await ServiceLocator.post(url, inputDto) as AsiUygulamaCikti;
            return result;
        }
        public static async UygulamaSorgusuSync(siteID: Guid, SorguNo: string): Promise<UygulamaSorgusuCikti> {
            let url: string = "/api/AsiEntegrasyonServisController/UygulamaSorgusuSync";
            let inputDto = { "siteID": siteID, "SorguNo": SorguNo };
            let result = await ServiceLocator.post(url, inputDto) as UygulamaSorgusuCikti;
            return result;
        }
    }
}
