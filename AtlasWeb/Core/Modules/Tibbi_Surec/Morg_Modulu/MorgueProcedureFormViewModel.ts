//$5B8F15A3
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Morgue } from "NebulaClient/Model/AtlasClientModel";
import { DeathReasonDiagnosis } from "NebulaClient/Model/AtlasClientModel";
import { MorgueDeathType } from "NebulaClient/Model/AtlasClientModel";
import { BaseTreatmentMaterial } from "NebulaClient/Model/AtlasClientModel";
import { CupboardDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { SKRSICD } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOlumNedeniTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSYaralanmaninYeri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOlumYeri } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { MernisDeathReasonDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOlumSekli } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Patient, SKRSILKodlari, SKRSIlceKodlari, MorgueTreatmentMaterial, StockCard, DistributionTypeDefinition, OzelDurum } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class MorgueProcedureFormViewModel extends BaseViewModel {
    @Type(() => Morgue)
    public _Morgue: Morgue = new Morgue();
    @Type(() => DeathReasonDiagnosis)
    public DeathReasonDiagnosisGridList: Array<DeathReasonDiagnosis> = new Array<DeathReasonDiagnosis>();
    @Type(() => MorgueDeathType)
    public MorgueDeathTypeGridList: Array<MorgueDeathType> = new Array<MorgueDeathType>();
    @Type(() => BaseTreatmentMaterial)
    public MaterialsGridGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();
    @Type(() => CupboardDefinition)
    public CupboardDefinitions: Array<CupboardDefinition> = new Array<CupboardDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSICD)
    public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();
    @Type(() => SKRSOlumNedeniTuru)
    public SKRSOlumNedeniTurus: Array<SKRSOlumNedeniTuru> = new Array<SKRSOlumNedeniTuru>();
    @Type(() => SKRSYaralanmaninYeri)
    public SKRSYaralanmaninYeris: Array<SKRSYaralanmaninYeri> = new Array<SKRSYaralanmaninYeri>();
    @Type(() => SKRSOlumYeri)
    public SKRSOlumYeris: Array<SKRSOlumYeri> = new Array<SKRSOlumYeri>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => MernisDeathReasonDefinition)
    public MernisDeathReasonDefinitions: Array<MernisDeathReasonDefinition> = new Array<MernisDeathReasonDefinition>();
    @Type(() => SKRSOlumSekli)
    public SKRSOlumSeklis: Array<SKRSOlumSekli> = new Array<SKRSOlumSekli>();
    @Type(() => Morgue)
    public Morgues: Array<Morgue> = new Array<Morgue>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type(() => SKRSIlceKodlari)
    public SKRSIlceKodlaris: Array<SKRSIlceKodlari> = new Array<SKRSIlceKodlari>();
    @Type(() => MorgueTreatmentMaterial)
    public GridTreatmentMaterialsGridList: Array<MorgueTreatmentMaterial> = new Array<MorgueTreatmentMaterial>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();

    @Type(() => Boolean)
    public OBSZorla: Boolean = new Boolean();
}

export class ObsInput{
    @Type(() => Number)
    public TcKimlikNo: number;
    @Type(() => Number)
    public UyrukKodu: number;
    public Adi: string;
    public Soyadi: string;
    public BabaAdi: string;
    public AnaAdi: string;
    public DogumTarihi: string;
    public DogumYeri: string;
    @Type(() => Number)
    public Cinsiyet: number;
    @Type(() => Number)
    public AdresIl: number;
    @Type(() => Number)
    public AdresIlce: number;
    public KoyMahalleAdi: string;
    public BulvarCaddeSokakAdi: string;
    public SiteBlokAdi: string;
    public DisKapiNo: string;
    public IcKapiNo: string;
    public OlumZamani: string;
    @Type(() => Number)
    public OlumYeri: number;
    @Type(() => Number)
    public OlumSekli: number;
    @Type(() => Number)
    public AnneOlumZamani: number;
    @Type(() => Number)
    public BebekOlumSekli: number;
    public DogumSaati: string;
    @Type(() => Number)
    public AnneTc: number;
    @Type(() => Number)
    public AnneYas: number;
    @Type(() => Number)
    public DogumSirasi: number;
    @Type(() => Number)
    public GebelikSuresi: number;
    @Type(() => Number)
    public DogumAgirligi: number;
    public OlumNedenleri: string;
    public SysTakipNo: string;
    public SaglikKurulusuReferansNo: string;
    public FixedDoctorUniqueID: string;//ölümü tespit eden doktor, token almak için
    @Type(() => Guid)
    public FixedDoctorObjectID: Guid;//doktor combosundan seçildi ise Tc'yi çekebilmek için
}

