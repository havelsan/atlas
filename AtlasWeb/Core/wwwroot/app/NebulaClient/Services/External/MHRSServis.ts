//$5A84878B
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace MHRSServis {
    export class RandevuAltKlinikVeHekimlerSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IlKodu: number;
        public IlceKodu: number;
        public IlceKoduSpecified: boolean;
        public KurumKodu: number;
        public KurumKoduSpecified: boolean;
        public SemtPoliklinikKodu: number;
        public SemtPoliklinikKoduSpecified: boolean;
        public KlinikKodu: number;
    }

    export class YetkilendirmeGirisBilgileriType {
        public KullaniciKodu: number;
        public KullaniciSifre: string;
        public KulaniciTuru: number;
    }

    export class RandevuVatandasSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public VatandasBilgileri: VatandasBilgileriType;
        public VatandasRandevuBilgileri: Array<RandevuVatandasSorgulamaObjCevapTypeVatandasRandevuBilgileri>;
    }

    export class TemelCevapBilgileriType {
        public ServisBasarisi: boolean;
        public ServisZamani: string;
        public Aciklama: string;
    }

    export class VatandasBilgileriType {
        public TCKimlikNo: string;
        public Ad: string;
        public Soyad: string;
        public VatandasIletisimBilgileri: VatandasIletisimBilgileriType;
        public Cinsiyet: number;
        public DogumTarihi: string;
        public DogumYeri: string;
        public Engelli: boolean;
        public EngelliSpecified: boolean;
        public Kimsesiz: boolean;
        public KimsesizSpecified: boolean;
    }

    export class VatandasIletisimBilgileriType {
        public TelefonIletisimBilgileri: Array<TelefonIletisimBilgileriType>;
        public Email: string;
    }

    export class TelefonIletisimBilgileriType {
        public AlanKodu: string;
        public TelefonNo: string;
        public NumaraTipi: number;
    }

    export class RandevuVatandasSorgulamaObjCevapTypeVatandasRandevuBilgileri {
        public RandevuHrn: string;
        public Tarih: string;
        public KurumAd: string;
        public KlinikAdi: string;
        public EskiAltKlinikAdi: string;
        public YeniAltKlinikAdi: string;
        public HekimAdiSoyadi: string;
        public KayitDurumKodu: number;
        public DurumKodu: number;
    }

    export class RandevuVatandasSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TCKimlikNo: string;
        public Ad: string;
        public Soyad: string;
        public DogumTarihi: string;
        public Cinsiyet: number;
        public CinsiyetSpecified: boolean;
    }

    export class KurumBilgileriType {
        public KurumKodu: number;
        public KurumKoduSpecified: boolean;
        public IslemYapanKisiTCNo: number;
        public GonderenBirim: string;
    }

    export class YesilListeVatandasSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class YesilListeVatandasSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public TCKimlikNo: string;
    }

    export class KurumIstisnaEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IstisnaDetayBilgileri: Array<IstisnaDetayBilgileriType>;
    }

    export class IstisnaDetayBilgileriType {
        public IstisnaId: number;
        public KurumKodu: number;
        public KlinikKodu: number;
        public HekimKodu: string;
        public TarihBilgileri: TarihBilgileriType;
        public AksiyonKodu: number;
        public Aciklama: string;
        public Email: string;
        public istisnaTipi: number;
        public IstisnaDurumKodu: number;
        public RedNedeni: string;
    }

    export class TarihBilgileriType {
        public BaslangicTarihi: string;
        public BitisTarihi: string;
    }

    export class IstisnaDokumanType {
        public IstisnaDokumanAdi: string;
        public IstisnaDokuman: Array<number>;
    }

    export class KurumIstisnaEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public HekimKodu: string;
        public KlinikKodu: number;
        public TarihBilgileri: TarihBilgileriType;
        public AksiyonKodu: number;
        public Aciklama: string;
        public Email: string;
        public TelefonIletisimBilgileri: TelefonIletisimBilgileriType;
        public IstisnaDokumanBilgileri: IstisnaDokumanType;
    }

    export class TelefonTipiBilgileriType {
        public NumaraTipi: number;
        public Aciklama: string;
    }

    export class TelefonTipiSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public TelefonTipiBilgileri: Array<TelefonTipiBilgileriType>;
    }

    export class TelefonTipiSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class KurumHekimEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class KurumHekimEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public HekimKodu: string;
        public GeciciGorevli: boolean;
    }

    export class KurumHekimSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class KurumHekimSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public HekimKodu: string;
    }

    export class KurumIstisnaSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IstisnaId: number;
        public IstisnaIdSpecified: boolean;
    }

    export class KurumIstisnaSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IstisnaId: number;
    }

    export class KurumTaslakCetvelGuncellemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public TaslakCetvelId: number;
    }

    export class KurumTaslakCetvelGuncellemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TaslakCetvelId: number;
        public CetvelDetayBilgileri: CetvelDetayBilgileriType;
    }

    export class CetvelDetayBilgileriType {
        public HekimKlinikBilgileri: HekimKlinikBilgileriType;
        public AksiyonKodu: number;
        public TedaviSuresi: number;
        public TedaviSuresiSpecified: boolean;
        public SlotBasinaDusenHastaSayisi: number;
        public SlotBasinaDusenHastaSayisiSpecified: boolean;
        public TarihBilgileri: TarihBilgileriType;
    }

    export class HekimKlinikBilgileriType {
        public HekimBilgileri: HekimBilgileriType;
        public KlinikKodu: number;
        public KlinikAdi: string;
        public AltKlinikBilgileri: AltKlinikBilgileriType;
    }

    export class HekimBilgileriType {
        public HekimKodu: string;
        public Ad: string;
        public Soyad: string;
        public Cinsiyet: number;
        public CinsiyetSpecified: boolean;
    }

    export class AltKlinikBilgileriType {
        public AltKlinikKodu: number;
        public AltKlinikAdi: string;
    }

    export class KurumAltKlinikSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public AltKlinikBilgileri: Array<AltKlinikBilgileriType>;
    }

    export class KurumAltKlinikSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
    }

    export class KurumKesinCetvelGuncellemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KesinCetvelId: number;
    }

    export class KurumKesinCetvelGuncellemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KesinCetvelId: number;
        public CetvelDetayBilgileri: CetvelDetayBilgileriType;
    }

    export class TaslakCetvelCevapType {
        public ReferansNo: string;
        public Aciklama: string;
        public TaslakCetvelId: Array<number>;
    }

    export class KurumTaslakCetvelEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public TaslakCetvelCevap: Array<TaslakCetvelCevapType>;
    }

    export class TaslakCetvelBilgileriType {
        public ReferansNo: string;
        public CetvelDetayBilgileri: CetvelDetayBilgileriType;
    }

    export class KurumTaslakCetvelEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TaslakCetvelBilgileri: Array<TaslakCetvelBilgileriType>;
    }

    export class KurumTaslakCetvelTarihleriGuncelleCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class KurumTaslakCetvelTarihleriGuncelleTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TaslakCetvelId: number;
        public TarihBilgileri: TarihBilgileriType;
    }

    export class KurumSemtPoliklinikSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public SemtPoliklinikleri: Array<KurumType>;
    }

    export class KurumType {
        public KurumKodu: number;
        public KurumAd: string;
    }

    export class KurumSemtPoliklinikSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class KurumBelirsizRandevuSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public HekimKodu: string;
        public TarihBilgileri: TarihBilgileriType;
    }

    export class KurumAdAdresType {
        public KurumAd: string;
        public KurumAdresi: string;
    }

    export class KurumBilgileriSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KurumAdAdres: Array<KurumAdAdresType>;
    }

    export class KurumBilgileriSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IlKodu: number;
        public IlKoduSpecified: boolean;
        public IlceKodu: number;
        public IlceKoduSpecified: boolean;
    }

    export class taslakKesinMapType {
        public TaslakCetvelId: number;
        public KesinCetvelId: number;
    }

    export class KurumTaslakCetvelKesinlestirmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public taslakKesinMap: Array<taslakKesinMapType>;
    }

    export class KurumTaslakCetvelKesinlestirmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TarihBilgileri: TarihBilgileriType;
        public HekimBilgileri: HekimBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
    }

    export class KlinikBilgileriSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KlinikBilgileri: Array<KlinikBilgileriType>;
    }

    export class KlinikBilgileriType {
        public KlinikKodu: number;
        public KlinikAdi: string;
    }

    export class KlinikBilgileriSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class YesilListeVatandasEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class YesilListeVatandasEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TCKimlikNo: string;
        public KlinikKodu: number;
    }

    export class KskRandevuVatandasSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public VatandasBilgileri: VatandasBilgileriType;
        public KskVatandasRandevuBilgileri: Array<KskRandevuVatandasSorgulamaCevapTypeKskVatandasRandevuBilgileri>;
    }

    export class KskRandevuVatandasSorgulamaCevapTypeKskVatandasRandevuBilgileri {
        public RandevuHrn: string;
        public Tarih: string;
        public KurumKodu: number;
        public KurumAd: string;
        public KlinikKodu: number;
        public KlinikAdi: string;
        public EskiAltKlinikAdi: string;
        public YeniAltKlinikAdi: string;
        public HekimKodu: string;
        public HekimAdiSoyadi: string;
        public KayitDurumKodu: number;
        public DurumKodu: number;
        public RandevuNotu: string;
    }

    export class KskRandevuVatandasSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public TCKimlikNo: string;
    }

    export class KurumKlinikSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KlinikBilgileri: Array<KlinikBilgileriType>;
    }

    export class KurumKlinikSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class IstisnaOnayCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class IstisnaOnayTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IstisnaId: number;
    }

    export class KlinikHekimBilgileriType {
        public KlinikKodu: number;
        public KlinikAdi: string;
        public HekimBilgileri: Array<HekimBilgileriType>;
    }

    export class KurumHekimSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KlinikHekimBilgileri: Array<KlinikHekimBilgileriType>;
    }

    export class KurumHekimSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
    }

    export class KurumAltKlinikEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public AltKlinikKodu: number;
        public AltKlinikKoduSpecified: boolean;
    }

    export class KurumAltKlinikEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public AltKlinikAdi: string;
    }

    export class RandevuNotuDuzenlemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class RandevuNotuDuzenlemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public RandevuHrn: string;
        public RandevuNotu: string;
    }

    export class KurumIstisnaSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IstisnaDetayBilgileri: Array<IstisnaDetayBilgileriType>;
    }

    export class KurumIstisnaSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TarihBilgileri: TarihBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public HekimBilgileri: HekimBilgileriType;
        public AksiyonKodu: number;
        public AksiyonKoduSpecified: boolean;
        public IstisnaDurumKodu: number;
        public IstisnaDurumKoduSpecified: boolean;
    }

    export class KurumIsKuraliEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IsKuraliId: number;
        public IsKuraliIdSpecified: boolean;
    }

    export class KurumIsKuraliEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public HekimKodu: string;
        public IsKuraliTipiKodu: number;
        public ZamanKriteri: number;
        public ZamanKriteriSpecified: boolean;
        public Deger: string;
    }

    export class KurumTaslakCetvelSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public TaslakCetvelId: Array<number>;
    }

    export class KurumTaslakCetvelSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TaslakCetvelId: Array<number>;
    }

    export class DurumKoduBilgileriType {
        public DurumKodu: number;
        public Aciklama: string;
    }

    export class DurumKoduSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public DurumKoduBilgileri: Array<DurumKoduBilgileriType>;
    }

    export class DurumKoduSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class YesilListeVatandasOnaylamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class YesilListeVatandasOnaylamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TCKimlikNo: string;
        public KlinikKodu: number;
    }

    export class RandevuXXXXXXVeSemtPoliklinikleriSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public XXXXXXler: Array<KurumType>;
        public SemtPoliklinikleri: Array<KurumType>;
    }

    export class RandevuXXXXXXVeSemtPoliklinikleriSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IlKodu: number;
        public IlceKodu: number;
    }

    export class RandevuDurumSonucType {
        public RandevuHrn: string;
        public GuncellemeBasarisi: boolean;
        public HataKodu: string;
        public Aciklama: string;
    }

    export class RandevuDurumGuncelleCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public RandevuDurumSonuc: Array<RandevuDurumSonucType>;
    }

    export class RandevuDurumGuncelleTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public RandevuBilgileri: Array<RandevuDurumGuncelleTalepTypeRandevuBilgileri>;
    }

    export class RandevuDurumGuncelleTalepTypeRandevuBilgileri {
        public RandevuHrn: string;
        public DurumKodu: number;
        public GelisZamani: string;
        public RandevuGerceklesmeZamani: string;
    }

    export class KurumBazliKumulatifVeriBilgisiType {
        public TarihBilgileri: TarihBilgileriType;
        public KurumKodu: number;
        public GerceklesenRandevuSayisi: number;
        public GerceklesmeyenRandevuSayisi: number;
        public BelirsizRandevuSayisi: number;
    }

    export class KurumKumulatifVeriSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KurumBazliKumulatifVeriBilgisi: Array<KurumBazliKumulatifVeriBilgisiType>;
    }

    export class KurumKumulatifVeriSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TarihBilgileri: TarihBilgileriType;
    }

    export class KurumKlinikSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class KurumKlinikSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
    }

    export class IsKuraliTipiType {
        public IsKuraliTipiKodu: number;
        public Aciklama: string;
    }

    export class IsKuraliTipiSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IsKuraliTipi: Array<IsKuraliTipiType>;
    }

    export class IsKuraliTipiSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class KurumRandevuSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KurumRandevuBilgileri: Array<KurumRandevuSorgulamaObjCevapTypeKurumRandevuBilgileri>;
    }

    export class KurumRandevuSorgulamaObjCevapTypeKurumRandevuBilgileri {
        public RandevuHrn: string;
        public TarihBilgileri: TarihBilgileriType;
        public KurumAd: string;
        public KlinikBilgileri: KlinikBilgileriType;
        public AltKlinikKodu: number;
        public EskiAltKlinikAdi: string;
        public YeniAltKlinikAdi: string;
        public HekimKodu: string;
        public HekimAdiSoyadi: string;
        public HastaTCKimlikNo: number;
        public HastaAdi: string;
        public HastaSoyadi: string;
        public HastaDogumTarihi: string;
        public Cinsiyet: number;
        public VatandasTelefonBilgileri: Array<TelefonIletisimBilgileriType>;
        public KayitDurumKodu: number;
        public DurumKodu: number;
        public RefakatciIstiyormu: boolean;
        public Engelli: boolean;
        public Kimsesiz: boolean;
        public YuksekRiskliGebe: boolean;
        public RandevuTuru: number;
        public RandevuNotu: string;
        public SanalTC: boolean;
        public EklenmeZamani: string;
        public EkleyenKullaniciTipi: number;
    }

    export class KurumRandevuSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public HekimKodu: string;
        public TarihBilgileri: TarihBilgileriType;
        public DurumKodu: number;
        public DurumKoduSpecified: boolean;
        public KayitDurumKodu: number;
        public KayitDurumKoduSpecified: boolean;
    }

    export class RandevuIptalCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public RandevuHrn: string;
    }

    export class RandevuIptalTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public RandevuHrn: string;
        public OnlineProtokol: string;
    }

    export class KurumKesinCetvelSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KesinCetvelId: Array<number>;
        public IstisnaId: Array<number>;
    }

    export class KurumKesinCetvelSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KesinCetvelId: Array<number>;
    }

    export class CetvelOzetType {
        public BosRandevuSayisi: number;
        public Tarih: string;
        public HekimKodu: string;
        public HekimAdiSoyadi: string;
        public Cinsiyet: number;
        public KlinikBilgileri: KlinikBilgileriType;
        public KurumKodu: number;
        public KurumAd: string;
        public AltKlinikAdi: string;
    }

    export class RandevuCetvelOzetSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public CetvelOzetListesi: Array<CetvelOzetType>;
        public AlternatifCetvelOzetListesi: Array<CetvelOzetType>;
    }

    export class RandevuCetvelOzetSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IlKodu: number;
        public IlceKodu: number;
        public IlceKoduSpecified: boolean;
        public AltKlinikKodu: number;
        public AltKlinikKoduSpecified: boolean;
        public Tarih: string;
        public TCKimlikNo: string;
        public KurumKodu: number;
        public KurumKoduSpecified: boolean;
        public SemtPoliklinikKodu: number;
        public SemtPoliklinikKoduSpecified: boolean;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public HekimKodu: string;
    }

    export class AksiyonBilgileriType {
        public AksiyonKodu: number;
        public Aciklama: string;
        public AksiyonTipi: number;
        public Mustesna: number;
        public Gun: number;
        public IslemTipi: number;
    }

    export class AksiyonBilgileriSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public AksiyonBilgileri: Array<AksiyonBilgileriType>;
    }

    export class AksiyonBilgileriSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class RandevuCetvelOzetDetaySorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public CalismaGunDetaylari: Array<RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylari>;
        public RandevuGunDurumlari: Array<RandevuCetvelOzetDetaySorgulamaCevapTypeRandevuGunDurumlari>;
    }

    export class RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylari {
        public Tarih: string;
        public CalismaSaatleri: Array<RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleri>;
    }

    export class RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleri {
        public Saat: number;
        public Slotlar: Array<RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleriSlotlar>;
    }

    export class RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleriSlotlar {
        public Baslangic: string;
        public Bitis: string;
        public Durum: string;
        public EgitimArastirmaUyarisi: boolean;
        public KesinCetvelId: number;
        public AltKlinikBilgileri: AltKlinikBilgileriType;
        public RandevuTuru: number;
    }

    export class RandevuCetvelOzetDetaySorgulamaCevapTypeRandevuGunDurumlari {
        public Tarih: string;
        public Durum: string;
    }

    export class RandevuCetvelOzetDetaySorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KurumKodu: number;
        public KlinikKodu: number;
        public HekimKodu: string;
        public Tarih: string;
        public TCKimlikNo: string;
    }

    export class IlceType {
        public IlceKodu: number;
        public IlceAdi: string;
    }

    export class RandevuIlceVeXXXXXXVeSemtPoliklinikleriSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public Ilceler: Array<IlceType>;
        public XXXXXXler: Array<KurumType>;
        public SemtPoliklinikleri: Array<KurumType>;
    }

    export class RandevuIlceVeXXXXXXVeSemtPoliklinikleriSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IlKodu: number;
    }

    export class KurumKesinCetvelSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KesinCetvelDetayBilgileri: Array<KurumKesinCetvelSorgulamaCevapTypeKesinCetvelDetayBilgileri>;
    }

    export class KurumKesinCetvelSorgulamaCevapTypeKesinCetvelDetayBilgileri {
        public KesinCetvelId: number;
        public TaslakCetvelId: number;
        public TaslakCetvelIdSpecified: boolean;
        public CetvelDetayBilgileri: CetvelDetayBilgileriType;
    }

    export class KurumKesinCetvelSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TarihBilgileri: TarihBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public AltKlinikKodu: number;
        public AltKlinikKoduSpecified: boolean;
        public HekimBilgileri: HekimBilgileriType;
        public AksiyonKodu: number;
        public AksiyonKoduSpecified: boolean;
    }

    export class KurumIsKuraliSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IsKuraliId: number;
        public IsKuraliIdSpecified: boolean;
    }

    export class KurumIsKuraliSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IsKuraliId: number;
    }

    export class KurumKlinikEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class KurumKlinikEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
    }

    export class RandevuSemtPoliklinikleriVeKliniklerSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public SemtPoliklinikleri: Array<KurumType>;
        public KlinikBilgileri: Array<KlinikBilgileriType>;
    }

    export class RandevuSemtPoliklinikleriVeKliniklerSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KurumKodu: number;
    }

    export class YesilListeBilgileriType {
        public KlinikKodu: number;
        public KlinikAdi: string;
        public EklenmeZamani: string;
        public OnayDurumu: number;
        public OnaylanmaZamani: string;
    }

    export class YesilListeVatandasSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public YesilListeBilgileri: Array<YesilListeBilgileriType>;
    }

    export class YesilListeVatandasSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TCKimlikNo: string;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
    }

    export class KurumTaslakCetvelSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public TaslakCetvelDetayBilgileri: Array<KurumTaslakCetvelSorgulamaCevapTypeTaslakCetvelDetayBilgileri>;
    }

    export class KurumTaslakCetvelSorgulamaCevapTypeTaslakCetvelDetayBilgileri {
        public TaslakCetvelId: number;
        public CetvelDetayBilgileri: CetvelDetayBilgileriType;
    }

    export class KurumTaslakCetvelSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public TarihBilgileri: TarihBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public AltKlinikKodu: number;
        public AltKlinikKoduSpecified: boolean;
        public HekimBilgileri: HekimBilgileriType;
        public AksiyonKodu: number;
        public AksiyonKoduSpecified: boolean;
    }

    export class RandevuKlinikSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KlinikBilgileri: Array<KlinikBilgileriType>;
    }

    export class RandevuKlinikSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KurumKodu: number;
    }

    export class IstisnaRedCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class IstisnaRedTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public IstisnaId: number;
        public RedNedeni: string;
    }

    export class KayitDurumKoduBilgileriType {
        public KayitDurumKodu: number;
        public Aciklama: string;
    }

    export class KayitDurumKoduSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public KayitDurumKoduBilgileri: Array<KayitDurumKoduBilgileriType>;
    }

    export class KayitDurumKoduSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class KurumIsKuraliSorgulamaCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IsKuraliBilgileri: Array<KurumIsKuraliSorgulamaCevapTypeIsKuraliBilgileri>;
    }

    export class KurumIsKuraliSorgulamaCevapTypeIsKuraliBilgileri {
        public IsKuraliId: number;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public HekimKodu: string;
        public IsKuraliTipiKodu: number;
        public ZamanKriteri: number;
        public ZamanKriteriSpecified: boolean;
        public Deger: string;
    }

    export class KurumIsKuraliSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KlinikKodu: number;
        public KlinikKoduSpecified: boolean;
        public HekimKodu: string;
        public IsKuraliTipiKodu: number;
        public IsKuraliTipiKoduSpecified: boolean;
        public ZamanKriteri: number;
        public ZamanKriteriSpecified: boolean;
        public Deger: string;
    }

    export class KurumAltKlinikAdiGuncellemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class KurumAltKlinikAdiGuncellemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public AltKlinikKodu: number;
        public AltKlinikAdi: string;
        public LokasyonDegisikligineDusurme: boolean;
    }

    export class KskVatandasTicketUretmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public Ticket: string;
        public Parola: string;
    }

    export class KskVatandasTicketUretmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public randevu_alinan_tc_kimlik_no: string;
        public randevu_alan_tc_kimlik_no: string;
        public VatandasIletisimBilgileri: VatandasIletisimBilgileriType;
    }

    export class RandevuEklemeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public RandevuHrn: string;
    }

    export class RandevuZamanBilgisiType {
        public RandevuBaslangicZamani: string;
        public RandevuBitisZamani: string;
    }

    export class RandevuEklemeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public KesinCetvelId: number;
        public RandevuZamanBilgisi: RandevuZamanBilgisiType;
        public VatandasBilgileri: VatandasBilgileriType;
        public RefakatciIstiyormu: boolean;
        public RefakatciIstiyormuSpecified: boolean;
        public RandevuNotu: string;
    }

    export class KurumAltKlinikSilmeCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
    }

    export class KurumAltKlinikSilmeTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
        public AltKlinikKodu: number;
    }

    export class RandevuIlSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public IlBilgileri: Array<RandevuIlSorgulamaObjCevapTypeIlBilgileri>;
    }

    export class RandevuIlSorgulamaObjCevapTypeIlBilgileri {
        public Kodu: number;
        public Adi: string;
    }

    export class RandevuIlSorgulamaTalepType {
        public YetkilendirmeGirisBilgileri: YetkilendirmeGirisBilgileriType;
        public KurumBilgileri: KurumBilgileriType;
    }

    export class RandevuAltKlinikVeHekimlerSorgulamaObjCevapType {
        public TemelCevapBilgileri: TemelCevapBilgileriType;
        public AltKlinikBilgileri: Array<AltKlinikBilgileriType>;
        public Hekimler: Array<RandevuAltKlinikVeHekimlerSorgulamaObjCevapTypeHekimler>;
    }

    export class RandevuAltKlinikVeHekimlerSorgulamaObjCevapTypeHekimler {
        public HekimKodu: string;
        public AdSoyad: string;
    }

    export class WebMethods {
        public static async RandevuDurumGuncelleSync(siteID: Guid, RandevuDurumGuncelleTalep: RandevuDurumGuncelleTalepType): Promise<RandevuDurumGuncelleCevapType> {
            let url: string = "/api/MHRSServisController/RandevuDurumGuncelleSync";
            let inputDto = { "siteID": siteID, "RandevuDurumGuncelleTalep": RandevuDurumGuncelleTalep };
            let result = await ServiceLocator.post(url, inputDto) as RandevuDurumGuncelleCevapType;
            return result;
        }
        public static async KurumTaslakCetvelEklemeSync(siteID: Guid, KurumTaslakCetvelEklemeTalep: KurumTaslakCetvelEklemeTalepType): Promise<KurumTaslakCetvelEklemeCevapType> {
            let url: string = "/api/MHRSServisController/KurumTaslakCetvelEklemeSync";
            let inputDto = { "siteID": siteID, "KurumTaslakCetvelEklemeTalep": KurumTaslakCetvelEklemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumTaslakCetvelEklemeCevapType;
            return result;
        }
        public static async KurumTaslakCetvelGuncellemeSync(siteID: Guid, KurumTaslakCetvelGuncellemeTalep: KurumTaslakCetvelGuncellemeTalepType): Promise<KurumTaslakCetvelGuncellemeCevapType> {
            let url: string = "/api/MHRSServisController/KurumTaslakCetvelGuncellemeSync";
            let inputDto = { "siteID": siteID, "KurumTaslakCetvelGuncellemeTalep": KurumTaslakCetvelGuncellemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumTaslakCetvelGuncellemeCevapType;
            return result;
        }
        public static async KurumTaslakCetvelKesinlestirmeSync(siteID: Guid, KurumTaslakCetvelKesinlestirmeTalep: KurumTaslakCetvelKesinlestirmeTalepType): Promise<KurumTaslakCetvelKesinlestirmeCevapType> {
            let url: string = "/api/MHRSServisController/KurumTaslakCetvelKesinlestirmeSync";
            let inputDto = { "siteID": siteID, "KurumTaslakCetvelKesinlestirmeTalep": KurumTaslakCetvelKesinlestirmeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumTaslakCetvelKesinlestirmeCevapType;
            return result;
        }
        public static async RandevuEklemeSync(siteID: Guid, RandevuEklemeTalep: RandevuEklemeTalepType): Promise<RandevuEklemeCevapType> {
            let url: string = "/api/MHRSServisController/RandevuEklemeSync";
            let inputDto = { "siteID": siteID, "RandevuEklemeTalep": RandevuEklemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as RandevuEklemeCevapType;
            return result;
        }
        public static async RandevuKlinikSorgulamaObjSync(siteID: Guid, RandevuKlinikSorgulamaObjTalep: RandevuKlinikSorgulamaTalepType): Promise<RandevuKlinikSorgulamaObjCevapType> {
            let url: string = "/api/MHRSServisController/RandevuKlinikSorgulamaObjSync";
            let inputDto = { "siteID": siteID, "RandevuKlinikSorgulamaObjTalep": RandevuKlinikSorgulamaObjTalep };
            let result = await ServiceLocator.post(url, inputDto) as RandevuKlinikSorgulamaObjCevapType;
            return result;
        }
        public static async KurumTaslakCetvelSilmeSync(siteID: Guid, KurumTaslakCetvelSilmeTalep: KurumTaslakCetvelSilmeTalepType): Promise<KurumTaslakCetvelSilmeCevapType> {
            let url: string = "/api/MHRSServisController/KurumTaslakCetvelSilmeSync";
            let inputDto = { "siteID": siteID, "KurumTaslakCetvelSilmeTalep": KurumTaslakCetvelSilmeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumTaslakCetvelSilmeCevapType;
            return result;
        }
        public static async KurumKesinCetvelSilmeSync(siteID: Guid, KurumKesinCetvelSilmeTalep: KurumKesinCetvelSilmeTalepType): Promise<KurumKesinCetvelSilmeCevapType> {
            let url: string = "/api/MHRSServisController/KurumKesinCetvelSilmeSync";
            let inputDto = { "siteID": siteID, "KurumKesinCetvelSilmeTalep": KurumKesinCetvelSilmeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumKesinCetvelSilmeCevapType;
            return result;
        }
        public static async RandevuIptalSync(siteID: Guid, RandevuIptalTalep: RandevuIptalTalepType): Promise<RandevuIptalCevapType> {
            let url: string = "/api/MHRSServisController/RandevuIptalSync";
            let inputDto = { "siteID": siteID, "RandevuIptalTalep": RandevuIptalTalep };
            let result = await ServiceLocator.post(url, inputDto) as RandevuIptalCevapType;
            return result;
        }
        public static async KurumRandevuSorgulamaObjSync(siteID: Guid, KurumRandevuSorgulamaTalep: KurumRandevuSorgulamaTalepType): Promise<KurumRandevuSorgulamaObjCevapType> {
            let url: string = "/api/MHRSServisController/KurumRandevuSorgulamaObjSync";
            let inputDto = { "siteID": siteID, "KurumRandevuSorgulamaTalep": KurumRandevuSorgulamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumRandevuSorgulamaObjCevapType;
            return result;
        }
        public static async KurumIstisnaEklemeSync(siteID: Guid, KurumIstisnaEklemeTalep: KurumIstisnaEklemeTalepType): Promise<KurumIstisnaEklemeCevapType> {
            let url: string = "/api/MHRSServisController/KurumIstisnaEklemeSync";
            let inputDto = { "siteID": siteID, "KurumIstisnaEklemeTalep": KurumIstisnaEklemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumIstisnaEklemeCevapType;
            return result;
        }
        public static async KurumIstisnaSilmeSync(siteID: Guid, KurumIstisnaSilmeTalep: KurumIstisnaSilmeTalepType): Promise<KurumIstisnaSilmeCevapType> {
            let url: string = "/api/MHRSServisController/KurumIstisnaSilmeSync";
            let inputDto = { "siteID": siteID, "KurumIstisnaSilmeTalep": KurumIstisnaSilmeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumIstisnaSilmeCevapType;
            return result;
        }
        public static async KurumIstisnaSorgulamaSync(siteID: Guid, KurumIstisnaSorgulamaTalep: KurumIstisnaSorgulamaTalepType): Promise<KurumIstisnaSorgulamaCevapType> {
            let url: string = "/api/MHRSServisController/KurumIstisnaSorgulamaSync";
            let inputDto = { "siteID": siteID, "KurumIstisnaSorgulamaTalep": KurumIstisnaSorgulamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumIstisnaSorgulamaCevapType;
            return result;
        }
        public static async KurumTaslakCetvelSorgulamaSync(siteID: Guid, KurumTaslakCetvelSorgulamaTalep: KurumTaslakCetvelSorgulamaTalepType): Promise<KurumTaslakCetvelSorgulamaCevapType> {
            let url: string = "/api/MHRSServisController/KurumTaslakCetvelSorgulamaSync";
            let inputDto = { "siteID": siteID, "KurumTaslakCetvelSorgulamaTalep": KurumTaslakCetvelSorgulamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumTaslakCetvelSorgulamaCevapType;
            return result;
        }
        public static async KurumKesinCetvelSorgulamaSync(siteID: Guid, KurumKesinCetvelSorgulamaTalep: KurumKesinCetvelSorgulamaTalepType): Promise<KurumKesinCetvelSorgulamaCevapType> {
            let url: string = "/api/MHRSServisController/KurumKesinCetvelSorgulamaSync";
            let inputDto = { "siteID": siteID, "KurumKesinCetvelSorgulamaTalep": KurumKesinCetvelSorgulamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumKesinCetvelSorgulamaCevapType;
            return result;
        }
        public static async YesilListeVatandasEklemeSync(siteID: Guid, YesilListeVatandasEklemeTalep: YesilListeVatandasEklemeTalepType): Promise<YesilListeVatandasEklemeCevapType> {
            let url: string = "/api/MHRSServisController/YesilListeVatandasEklemeSync";
            let inputDto = { "siteID": siteID, "YesilListeVatandasEklemeTalep": YesilListeVatandasEklemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as YesilListeVatandasEklemeCevapType;
            return result;
        }
        public static async YesilListeVatandasSorgulamaSync(siteID: Guid, YesilListeVatandasSorgulamaTalep: YesilListeVatandasSorgulamaTalepType): Promise<YesilListeVatandasSorgulamaCevapType> {
            let url: string = "/api/MHRSServisController/YesilListeVatandasSorgulamaSync";
            let inputDto = { "siteID": siteID, "YesilListeVatandasSorgulamaTalep": YesilListeVatandasSorgulamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as YesilListeVatandasSorgulamaCevapType;
            return result;
        }
        public static async YesilListeVatandasOnaylamaSync(siteID: Guid, YesilListeVatandasOnaylamaTalep: YesilListeVatandasOnaylamaTalepType): Promise<YesilListeVatandasOnaylamaCevapType> {
            let url: string = "/api/MHRSServisController/YesilListeVatandasOnaylamaSync";
            let inputDto = { "siteID": siteID, "YesilListeVatandasOnaylamaTalep": YesilListeVatandasOnaylamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as YesilListeVatandasOnaylamaCevapType;
            return result;
        }
        public static async KurumAltKlinikSorgulamaSync(siteID: Guid, KurumAltKlinikSorgulamaTalep: KurumAltKlinikSorgulamaTalepType): Promise<KurumAltKlinikSorgulamaCevapType> {
            let url: string = "/api/MHRSServisController/KurumAltKlinikSorgulamaSync";
            let inputDto = { "siteID": siteID, "KurumAltKlinikSorgulamaTalep": KurumAltKlinikSorgulamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumAltKlinikSorgulamaCevapType;
            return result;
        }
        public static async KurumKlinikSorgulamaSync(siteID: Guid, KurumKlinikSorgulamaTalep: KurumKlinikSorgulamaTalepType): Promise<KurumKlinikSorgulamaCevapType> {
            let url: string = "/api/MHRSServisController/KurumKlinikSorgulamaSync";
            let inputDto = { "siteID": siteID, "KurumKlinikSorgulamaTalep": KurumKlinikSorgulamaTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumKlinikSorgulamaCevapType;
            return result;
        }
        public static async KurumAltKlinikEklemeSync(siteID: Guid, KurumAltKlinikEklemeTalep: KurumAltKlinikEklemeTalepType): Promise<KurumAltKlinikEklemeCevapType> {
            let url: string = "/api/MHRSServisController/KurumAltKlinikEklemeSync";
            let inputDto = { "siteID": siteID, "KurumAltKlinikEklemeTalep": KurumAltKlinikEklemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumAltKlinikEklemeCevapType;
            return result;
        }
        public static async KurumKlinikEklemeSync(siteID: Guid, KurumKlinikEklemeTalep: KurumKlinikEklemeTalepType): Promise<KurumKlinikEklemeCevapType> {
            let url: string = "/api/MHRSServisController/KurumKlinikEklemeSync";
            let inputDto = { "siteID": siteID, "KurumKlinikEklemeTalep": KurumKlinikEklemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumKlinikEklemeCevapType;
            return result;
        }
        public static async KurumHekimEklemeSync(siteID: Guid, KurumHekimEklemeTalep: KurumHekimEklemeTalepType): Promise<KurumHekimEklemeCevapType> {
            let url: string = "/api/MHRSServisController/KurumHekimEklemeSync";
            let inputDto = { "siteID": siteID, "KurumHekimEklemeTalep": KurumHekimEklemeTalep };
            let result = await ServiceLocator.post(url, inputDto) as KurumHekimEklemeCevapType;
            return result;
        }
    }
}
