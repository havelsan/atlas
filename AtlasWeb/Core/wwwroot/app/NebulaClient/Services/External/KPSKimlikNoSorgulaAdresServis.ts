//$969D65A7
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace KPSKimlikNoSorgulaAdresServis {
    export class KimlikNoileAdresSorguKriteri {
        public KimlikNo: number;
    }

    export class KimlikNoileKisiAdresBilgileriSonucu {
        public HataBilgisi: Parametre;
        public SorguSonucu: Array<KimlikNoileKisiAdresBilgileri>;
    }

    export class Parametre {
        public Aciklama: string;
        public Kod: number;
    }

    export class KimlikNoileKisiAdresBilgileri {
        public DigerAdresBilgileri: Array<KimlikNoileKisiAdresBilgisi>;
        public HataBilgisi: Parametre;
        public KimlikNo: number;
        public YerlesimYeriAdresi: KimlikNoileKisiAdresBilgisi;
    }

    export class KimlikNoileKisiAdresBilgisi {
        public AcikAdres: string;
        public AdresNo: number;
        public AdresTip: Parametre;
        public BeldeAdresi: KimlikNoileBeldeAdresi;
        public BeyanTarihi: TarihBilgisi;
        public BeyandaBulunanKimlikNo: number;
        public HataBilgisi: Parametre;
        public IlIlceMerkezAdresi: KimlikNoileIlIlceMerkezi;
        public KoyAdresi: KimlikNoileKoyAdresi;
        public TasinmaTarihi: TarihBilgisi;
        public TescilTarihi: TarihBilgisi;
        public YurtDisiAdresi: KimlikNoileYurtDisiAdresi;
    }

    export class KimlikNoileBeldeAdresi {
        public BagimsizBolumDurum: Parametre;
        public BagimsizBolumTipi: Parametre;
        public BinaAda: string;
        public BinaBlokAdi: string;
        public BinaDurum: Parametre;
        public BinaKodu: number;
        public BinaNo: number;
        public BinaNumaratajTipi: Parametre;
        public BinaPafta: string;
        public BinaParsel: string;
        public BinaSiteAdi: string;
        public BinaYapiTipi: Parametre;
        public Csbm: string;
        public CsbmKodu: number;
        public DisKapiNo: string;
        public HataBilgisi: Parametre;
        public IcKapiNo: string;
        public Il: string;
        public IlKodu: number;
        public Ilce: string;
        public IlceKodu: number;
        public KatNo: string;
        public Koy: string;
        public KoyKayitNo: number;
        public KoyKodu: number;
        public Mahalle: string;
        public MahalleKodu: number;
        public TapuBagimsizBolumNo: string;
        public YapiKullanimAmac: Parametre;
        public YolAltiKatSayisi: number;
        public YolUstuKatSayisi: number;
    }

    export class TarihBilgisi {
        public Ay: number;
        public Gun: number;
        public Yil: number;
    }

    export class KimlikNoileIlIlceMerkezi {
        public BagimsizBolumDurum: Parametre;
        public BagimsizBolumTipi: Parametre;
        public BinaAda: string;
        public BinaBlokAdi: string;
        public BinaDurum: Parametre;
        public BinaKodu: number;
        public BinaNo: number;
        public BinaNumaratajTipi: Parametre;
        public BinaPafta: string;
        public BinaParsel: string;
        public BinaSiteAdi: string;
        public BinaYapiTipi: Parametre;
        public Csbm: string;
        public CsbmKodu: number;
        public DisKapiNo: string;
        public HataBilgisi: Parametre;
        public IcKapiNo: string;
        public Il: string;
        public IlKodu: number;
        public Ilce: string;
        public IlceKodu: number;
        public KatNo: string;
        public Mahalle: string;
        public MahalleKodu: number;
        public TapuBagimsizBolumNo: string;
        public YapiKullanimAmac: Parametre;
        public YolAltiKatSayisi: number;
        public YolUstuKatSayisi: number;
    }

    export class KimlikNoileKoyAdresi {
        public BagimsizBolumDurum: Parametre;
        public BagimsizBolumTipi: Parametre;
        public BinaAda: string;
        public BinaBlokAdi: string;
        public BinaDurum: Parametre;
        public BinaKodu: number;
        public BinaNo: number;
        public BinaNumaratajTipi: Parametre;
        public BinaPafta: string;
        public BinaParsel: string;
        public BinaSiteAdi: string;
        public BinaYapiTipi: Parametre;
        public Csbm: string;
        public CsbmKodu: number;
        public DisKapiNo: string;
        public HataBilgisi: Parametre;
        public IcKapiNo: string;
        public Il: string;
        public IlKodu: number;
        public Ilce: string;
        public IlceKodu: number;
        public KatNo: string;
        public Koy: string;
        public KoyKayitNo: number;
        public KoyKodu: number;
        public Mahalle: string;
        public MahalleKodu: number;
        public TapuBagimsizBolumNo: string;
        public YapiKullanimAmac: Parametre;
        public YolAltiKatSayisi: number;
        public YolUstuKatSayisi: number;
    }

    export class KimlikNoileYurtDisiAdresi {
        public DisTemsDuzeltmeBeyanTarih: Date;
        public DisTemsDuzeltmeKararTarih: Date;
        public DisTemsDuzeltmeNeden: Parametre;
        public DisTemsilcilik: Parametre;
        public HataBilgisi: Parametre;
        public YabanciAdres: string;
        public YabanciSehir: string;
        public YabanciUlke: Parametre;
    }

    export class WebMethods {
        public static async SorgulaSync(siteID: Guid, kriter: KimlikNoileAdresSorguKriteri): Promise<KimlikNoileKisiAdresBilgileriSonucu> {
            let url: string = "/api/KPSKimlikNoSorgulaAdresServisController/SorgulaSync";
            let inputDto = { "siteID": siteID, "kriter": kriter };
            let result = await ServiceLocator.post(url, inputDto) as KimlikNoileKisiAdresBilgileriSonucu;
            return result;
        }
    }
}
