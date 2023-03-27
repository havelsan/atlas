//$17E4AD2E
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace KPSServis {
    export enum AdresTipi {
        Tanimsiz = -1,
        Koy = 3,
        Belde = 2,
        IlceMerkezi = 1,
        YurtDisi = 4
    }

    export class KPSServisSonucuArrayOfIl {
        public Hata: string;
        public Sonuc: Array<Il>;
    }

    export class Il {
        public Ad: string;
        public Kod: string;
    }

    export class KPSServisSonucuArrayOfIlce {
        public Hata: string;
        public Sonuc: Array<Ilce>;
    }

    export class Ilce {
        public Ad: string;
        public IlKod: string;
        public Kod: string;
    }

    export class KPSServisSonucuKisiTemelBilgisi {
        public Hata: string;
        public Sonuc: KisiTemelBilgisi;
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

    export class KPSServisSonucuArrayOfKisiTemelBilgisi {
        public Hata: string;
        public Sonuc: Array<KisiTemelBilgisi>;
    }

    export class KPSServisSonucuKisiCuzdanBilgisi {
        public Hata: string;
        public Sonuc: KisiCuzdanBilgisi;
    }

    export class KPSServisSonucuYabanciKisiBilgisi {
        public Hata: string;
        public Sonuc: YabanciKisiBilgisi;
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
        public KazanilanTCKimlikNO: string;
        public KimlikNo: string;
        public MedeniHal: string;
        public OlumTarihi: string;
        public Soyad: string;
        public Ulke: string;
        public UlkeKod: string;
    }

    export class KPSServisSonucuNufusKayitOrnegi {
        public Hata: string;
        public Sonuc: NufusKayitOrnegi;
    }

    export class NufusKayitOrnegi {
        public Kisiler: Array<KisiTemelBilgisi>;
        public Olaylar: Array<NufusKayitOrnegiOlay>;
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

    export class KayitYeriKodBilgisi {
        public AileSiraNo: string;
        public BireySiraNo: string;
        public Cilt: string;
        public Ilce: string;
    }

    export class KPSServisSonucuKisiAdresBilgisi {
        public Hata: string;
        public Sonuc: KisiAdresBilgisi;
    }

    export class KisiAdresBilgisi {
        public AdresNo: number;
        public AdresTipi: AdresTipi;
        public BeyanTarihi: string;
        public BeyandaBulunanKimlikNo: string;
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
        public TasinmaTarihi: string;
        public TescilTarihi: string;
        public YabanciAdres: string;
        public YabanciSehir: string;
        public YabanciUlke: string;
    }

    export class KPSServisSonucuAdresTipi {
        public Hata: string;
        public Sonuc: AdresTipi;
    }

    export class KPSServisSonucuMaviKartKisiBilgisi {
        public Hata: string;
        public Sonuc: MaviKartKisiBilgisi;
    }

    export class MaviKartKisiBilgisi {
        public AnneTCKimlikNo: string;
        public BabaTCKimlikNo: string;
        public DogumYerKod: string;
        public Durum: string;
        public EsTCKimlikNo: string;
        public Hata: string;
        public KazanilanTCKimlikNo: string;
        public KimlikNo: string;
        public MedeniHal: string;
        public OlumTarih: string;
        public TemelBilgisi: MaviKartKisiTemelBilgisi;
        public Ulke: string;
        public UlkeKod: string;
        public Yakinlik: string;
    }

    export class MaviKartKisiTemelBilgisi {
        public Ad: string;
        public AnneAd: string;
        public BabaAd: string;
        public Cinsiyet: string;
        public DogumTarih: string;
        public DogumYer: string;
        public Soyad: string;
    }

    export class KPSServisSonucuMaviKartDegisimListesi {
        public Hata: string;
        public Sonuc: MaviKartDegisimListesi;
    }

    export class MaviKartDegisimListesi {
        public KimlikNoListesi: Array<number>;
        public SonrakiSayfa: number;
    }

    export class KPSServisSonucuKimlikNoSonuc {
        public Hata: string;
        public Sonuc: KimlikNoSonuc;
    }

    export class KimlikNoSonuc {
        public KisiBilgisi: KisiTemelBilgisi;
        public MaviKartKisiBilgisi: MaviKartKisiBilgisi;
        public YabanciKisiBilgisi: YabanciKisiBilgisi;
    }

    export class KPSServisSonucuNkoSonuc {
        public Hata: string;
        public Sonuc: NkoSonuc;
    }

    export class NkoSonuc {
        public MaviKartNko: MaviKartNko;
        public Nko: NufusKayitOrnegi;
    }

    export class MaviKartNko {
        public Kisiler: Array<MaviKartNkoKisi>;
        public Olaylar: Array<MaviKartNkoOlay>;
    }

    export class MaviKartNkoKisi {
        public AnneKimlikNo: string;
        public BabaKimlikNo: string;
        public BosanmaTarih: string;
        public Durum: string;
        public EsKimlikNo: string;
        public EvlenmeTarih: string;
        public KimlikNo: string;
        public TemelBilgisi: MaviKartKisiTemelBilgisi;
        public TescilTarih: string;
        public Ulke: string;
        public Yakinlik: string;
    }

    export class MaviKartNkoOlay {
        public Ad: string;
        public Dusunce: string;
        public HataBilgisi: string;
        public KimlikNo: string;
        public OlayTarih: string;
        public OlayTipi: string;
        public Soyad: string;
    }

    export class WebMethods {
        public static async ServisUTCZamaniSync(siteID: Guid): Promise<Date> {
            let url: string = "/api/KPSServisController/ServisUTCZamaniSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as Date;
            return result;
        }
        public static async IstekIpAdresSync(siteID: Guid): Promise<string> {
            let url: string = "/api/KPSServisController/IstekIpAdresSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as string;
            return result;
        }
        public static async KullanilabilirMetodListesiSync(siteID: Guid): Promise<string[]> {
            let url: string = "/api/KPSServisController/KullanilabilirMetodListesiSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as string[];
            return result;
        }
        public static async IlListesiSync(siteID: Guid): Promise<KPSServisSonucuArrayOfIl> {
            let url: string = "/api/KPSServisController/IlListesiSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuArrayOfIl;
            return result;
        }
        public static async IleAitIlceistesiSync(siteID: Guid, ilKod: number): Promise<KPSServisSonucuArrayOfIlce> {
            let url: string = "/api/KPSServisController/IleAitIlceistesiSync";
            let inputDto = { "siteID": siteID, "ilKod": ilKod };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuArrayOfIlce;
            return result;
        }
        public static async TcKimlikNoIleKisiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuKisiTemelBilgisi> {
            let url: string = "/api/KPSServisController/TcKimlikNoIleKisiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuKisiTemelBilgisi;
            return result;
        }
        public static async TcKimlikNoSorgulaSync(siteID: Guid, ad: string, soyad: string, babaAdi: string, anaAdi: string, dogumYeri: string, dogumTarihi: string, cinsiyet: string): Promise<KPSServisSonucuArrayOfKisiTemelBilgisi> {
            let url: string = "/api/KPSServisController/TcKimlikNoSorgulaSync";
            let inputDto = { "siteID": siteID, "ad": ad, "soyad": soyad, "babaAdi": babaAdi, "anaAdi": anaAdi, "dogumYeri": dogumYeri, "dogumTarihi": dogumTarihi, "cinsiyet": cinsiyet };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuArrayOfKisiTemelBilgisi;
            return result;
        }
        public static async TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuKisiCuzdanBilgisi> {
            let url: string = "/api/KPSServisController/TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuKisiCuzdanBilgisi;
            return result;
        }
        public static async YabanciTcKimlikNoIleKisiSorgulaSync(siteID: Guid, yabaciKimlikNo: number): Promise<KPSServisSonucuYabanciKisiBilgisi> {
            let url: string = "/api/KPSServisController/YabanciTcKimlikNoIleKisiSorgulaSync";
            let inputDto = { "siteID": siteID, "yabaciKimlikNo": yabaciKimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuYabanciKisiBilgisi;
            return result;
        }
        public static async TcKimlikNoIleNufusKayitOrnegiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuNufusKayitOrnegi> {
            let url: string = "/api/KPSServisController/TcKimlikNoIleNufusKayitOrnegiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuNufusKayitOrnegi;
            return result;
        }
        public static async TcKimlikNoIleAdresBilgisiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuKisiAdresBilgisi> {
            let url: string = "/api/KPSServisController/TcKimlikNoIleAdresBilgisiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuKisiAdresBilgisi;
            return result;
        }
        public static async TcKimlikNoIleKoyAdresBilgisiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuKisiAdresBilgisi> {
            let url: string = "/api/KPSServisController/TcKimlikNoIleKoyAdresBilgisiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuKisiAdresBilgisi;
            return result;
        }
        public static async TcKimlikNoIleBeldeAdresBilgisiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuKisiAdresBilgisi> {
            let url: string = "/api/KPSServisController/TcKimlikNoIleBeldeAdresBilgisiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuKisiAdresBilgisi;
            return result;
        }
        public static async TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuKisiAdresBilgisi> {
            let url: string = "/api/KPSServisController/TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuKisiAdresBilgisi;
            return result;
        }
        public static async TcKimlikNoAdresTipiSorgulaSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuAdresTipi> {
            let url: string = "/api/KPSServisController/TcKimlikNoAdresTipiSorgulaSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuAdresTipi;
            return result;
        }
        public static async KimlikNoIleMaviKartGetirSync(siteID: Guid, tcNo: number): Promise<KPSServisSonucuMaviKartKisiBilgisi> {
            let url: string = "/api/KPSServisController/KimlikNoIleMaviKartGetirSync";
            let inputDto = { "siteID": siteID, "tcNo": tcNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuMaviKartKisiBilgisi;
            return result;
        }
        public static async MaviKartKisiDegisenListeleSync(siteID: Guid, tarih: Date, sayfa: number): Promise<KPSServisSonucuMaviKartDegisimListesi> {
            let url: string = "/api/KPSServisController/MaviKartKisiDegisenListeleSync";
            let inputDto = { "siteID": siteID, "tarih": tarih, "sayfa": sayfa };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuMaviKartDegisimListesi;
            return result;
        }
        public static async MaviKartAdresDegisenListeleSync(siteID: Guid, tarih: Date, sayfa: number): Promise<KPSServisSonucuMaviKartDegisimListesi> {
            let url: string = "/api/KPSServisController/MaviKartAdresDegisenListeleSync";
            let inputDto = { "siteID": siteID, "tarih": tarih, "sayfa": sayfa };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuMaviKartDegisimListesi;
            return result;
        }
        public static async MaviKartDegisenListeleSync(siteID: Guid, tarih: Date, sayfa: number): Promise<KPSServisSonucuMaviKartDegisimListesi> {
            let url: string = "/api/KPSServisController/MaviKartDegisenListeleSync";
            let inputDto = { "siteID": siteID, "tarih": tarih, "sayfa": sayfa };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuMaviKartDegisimListesi;
            return result;
        }
        public static async GenelKimlikNoIleKisiSorgulaSync(siteID: Guid, kimlikNo: number): Promise<KPSServisSonucuKimlikNoSonuc> {
            let url: string = "/api/KPSServisController/GenelKimlikNoIleKisiSorgulaSync";
            let inputDto = { "siteID": siteID, "kimlikNo": kimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuKimlikNoSonuc;
            return result;
        }
        public static async GenelKimlikNoIleNufusKayitOrnegiSorgulaSync(siteID: Guid, kimlikNo: number): Promise<KPSServisSonucuNkoSonuc> {
            let url: string = "/api/KPSServisController/GenelKimlikNoIleNufusKayitOrnegiSorgulaSync";
            let inputDto = { "siteID": siteID, "kimlikNo": kimlikNo };
            let result = await ServiceLocator.post(url, inputDto) as KPSServisSonucuNkoSonuc;
            return result;
        }
    }
}
