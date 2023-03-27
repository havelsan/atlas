//$11D3341F

export namespace MernisServis {
    export enum AdresTipi {
        /// <remarks/>
        Tanimsiz,
        /// <remarks/>
        Koy,
        /// <remarks/>
        Belde,
        /// <remarks/>
        IlceMerkezi,
        /// <remarks/>
        YurtDisi
    }

    export class SorguPaket {
        public TcNoSpecified: boolean;
        public TcNo: number;
    }

    export class TCKimlikPaket {
        constructor() {
        }

        public Ad: string;
        public TCKimlikNo: number;
        public DogumYili: number;
        public Soyad: string;
    }


    export class KPSServisSonucuArrayOfIl {
        public Hata: string;
        public Sonuc: Array<Il>;
    }

    export class Il {
        public Ad: string;
        public Kod: string;
    }

    export class KPSServisSonucuAdresTipi {
        public Hata: string;
        public Sonuc: AdresTipi;
        public SonucSpecified: boolean;
    }

    export class KisiAdresBilgisi {
        public AdresNo: number;
        public AdresNoSpecified: boolean;
        public AdresTipi: AdresTipi;
        public AdresTipiSpecified: boolean;
        public BinaAda: string;
        public BinaBlokAdi: string;
        public BinaKodu: string;
        public BinaNo: string;
        public BinaPafta: string;
        public BinaParsel: string;
        public BinaSiteAdi: string;
        public Bucak: string;
        public BucakKodu: string;
        public Csbm: string;
        public CsbmKodu: string;
        public DisKapiNo: string;
        public DisTemsDuzeltmeBeyanTarih: string;
        public DisTemsDuzeltmeKararTarih: string;
        public DisTemsDuzeltmeNeden: string;
        public DisTemsilcilik: string;
        public Hata: string;
        public HataBilgisi: string;
        public IcKapiNo: string;
        public Il: string;
        public IlKodu: string;
        public Ilce: string;
        public IlceKodu: string;
        public Koy: string;
        public KoyKayitNo: string;
        public KoyKodu: string;
        public Mahalle: string;
        public MahalleKodu: string;
        public YabanciAdres: string;
        public YabanciSehir: string;
        public YabanciUlke: string;
    }

    export class KPSServisSonucuKisiAdresBilgisi {
        public Hata: string;
        public Sonuc: KisiAdresBilgisi;
    }

    export class KayitYeriKodBilgisi {
        public AileSiraNo: string;
        public BireySiraNo: string;
        public Cilt: string;
        public Ilce: string;
    }

    export class NufusKayitOrnegiOlay {
        public Ad: string;
        public Dusunce: string;
        public HataBilgisi: string;
        public KayitYeri: KayitYeriKodBilgisi;
        public OlayTarih: string;
        public OlayTipi: string;
        public Soyad: string;
    }

    export class NufusKayitOrnegi {
        public Kisiler: Array<KisiTemelBilgisi>;
        public Olaylar: Array<NufusKayitOrnegiOlay>;
    }

    export class KisiTemelBilgisi {
        public Ad: string;
        public AileSiraNo: string;
        public AnaAd: string;
        public BabaAd: string;
        public BireySiraNo: string;
        public CiltAd: string;
        public CiltKod: string;
        public Cinsiyet: string;
        public Din: string;
        public DogumTarihi: string;
        public DogumYer: string;
        public Durum: string;
        public Hata: string;
        public IlAd: string;
        public IlKod: string;
        public IlceAd: string;
        public IlceKod: string;
        public MedeniHal: string;
        public OlayTarihBilgileri: NufusKayitOrnegiOlayTarihBilgisi;
        public OlumTarih: string;
        public Soyad: string;
        public TCKimlikNo: string;
        public Yakinlik: string;
    }

    export class NufusKayitOrnegiOlayTarihBilgisi {
        public BosanmaTarihi: string;
        public EvlenmeTarihi: string;
        public HataBilgisi: string;
        public TescilTarihi: string;
    }

    export class KisiCuzdanBilgisi extends KisiTemelBilgisi {
        public CuzdanNo: string;
        public CuzdanSeri: string;
        public VerildigiIlceAd: string;
        public VerildigiIlceKod: string;
        public VerilmeNeden: string;
        public VerilmeTarih: string;
    }

    export class KPSServisSonucuNufusKayitOrnegi {
        public Hata: string;
        public Sonuc: NufusKayitOrnegi;
    }

    export class YabanciKisiBilgisi {
        public Ad: string;
        public AnneAd: string;
        public AnneEgmSahisId: string;
        public AnneKimlikNo: string;
        public BabaAd: string;
        public BabaEgmSahisId: string;
        public BabaKimlikNo: string;
        public Cinsiyet: string;
        public DogumTarih: string;
        public DogumYer: string;
        public DogumYil: string;
        public Durum: string;
        public EgmSahisId: string;
        public EsEgmSahisId: string;
        public EsKimlikNo: string;
        public Hata: string;
        public HataBilgisi: string;
        public IkametAdres: string;
        public IkametAdresIl: string;
        public IkametAdresIlKod: string;
        public IkametAdresIlce: string;
        public IkametDuzenleIl: string;
        public IkametSure: string;
        public IkametTezkereNo: string;
        public IzinBaslangicTarih: string;
        public KimlikNo: string;
        public MedeniHal: string;
        public Soyad: string;
        public Ulke: string;
        public UlkeKod: string;
    }

    export class KPSServisSonucuYabanciKisiBilgisi {
        public Hata: string;
        public Sonuc: YabanciKisiBilgisi;
    }

    export class KPSServisSonucuKisiCuzdanBilgisi {
        public Hata: string;
        public Sonuc: KisiCuzdanBilgisi;
    }

    export class KPSServisSonucuArrayOfKisiTemelBilgisi {
        public Hata: string;
        public Sonuc: Array<KisiTemelBilgisi>;
    }

    export class KPSServisSonucuKisiTemelBilgisi {
        public Hata: string;
        public Sonuc: KisiTemelBilgisi;
    }

    export class Ilce {
        public Ad: string;
        public IlKod: string;
        public Kod: string;
    }

    export class KPSServisSonucuArrayOfIlce {
        public Hata: string;
        public Sonuc: Array<Ilce>;
    }

    export class WebMethods {

    }
}
