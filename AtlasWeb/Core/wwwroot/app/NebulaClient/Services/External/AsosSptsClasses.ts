//$61F2EDAA

export namespace XXXXXXSptsClasses {
    export class DrugDefinitionInfo {
        public ID: number;
        public name: string;
        public barkod: string;
        public GroupID: number;
        public GroupName: string;
        public GenericID: number;
        public GenericName: string;
        public RecipeType: number;
        // NFC ler hepsi veritabanına atılmış olduğundan sadece ID'si gönderiliyor.
        public NfcID: number;
        public NfcImplementationTypeID: number;
        public NfcImplementationTypeName: string;
        public Dose: number;
        public Volume: number;
        public UnitID: number;
        public UnitName: string;
        public PackageAmount: number;
        public NoDoseCounting: boolean;
        // Etken maddeler hepsi veritabanına atılmış olduğundan sadece ilaca ait IngredientID ve değerleri gönderiliyor.
        public alDrugIngredients: Array<Ingredients>;
        // ATC ler hepsi veritabanına atılmış olduğundan sadece ID'si gönderiliyor.
        public AtcCodes: Array<number>;
        public FirmID: number;
        public FirmName: string;
        public LicenseNo: string;
        public LicenceDate: Date;
        public LicenceInstitute: number;
        public alActiveIngredients: Array<Ingredients>;
        public Active: boolean;
        public MuadilCRC: string;
        public pricingDetail: SPTSPricingDetail;
        public ToString(): string {
            return this.ID + " " + this.name + " " + this.barkod;
        }
    }

    export class Ingredients {
        public IngredientID: number;
        public value: number;
        public UnitID: number;
        public UnitName: string;
        public MaxDoze: number;
    }

    export class DrugRelationInfo {
        public ID: number;
        public DrugRelations: Array<number>;
    }

    export class SPTSPricingDetail {
        public SPTSPricingDetailID: number;
        public Price: number;
        public StartDate: Date;
        public EndDate: Date;
    }

    export class HastaIlacInfo {
        public ActionId: number;
        public DailyDose: string;
        public DrugExpDate: string;
        public DrugName: string;
        public PrescDate: string;
    }

    export class HastaInfo {
        public TCNo: string;
        public sptsId: number;
        public ad: string;
        public soyad: string;
        public patientGuid: string;
        public cinsiyet: string;
        public dogumTarihi: string;
        public dogumYeri: string;
        public yakinlikId: string;
        public yakinlikDerecesi: string;
        public anaAdi: string;
        public babaAdi: string;
        public emekliNo: string;
        public sicilNo: string;
        public sskNo: string;
        public deleted: string;
        public srcTable: string;
        public XXXXXXeGirisTarihi: Date;
        public sonGuncellenmeTarihi: Date;
        public hasSahiplikGrubu: number;
    }

    export class ReceteIlacSonuc {
        public ilacId: number;
        public odenir: boolean;
        public ilacSonucAciklamasi: string;
        public hastaPayi: number;
    }

    export class DrugInfo {
        public name: string;
        public barkod: number;
        public packageAmount: number;
        public dosageForm: string;
        public licenseNo: string;
        public licenseDate: string;
        public price: number;
        public KurumFiyati: number;
        public priceDate: string;
        public GenericEsdeger: string;
        public birimIlacSayisi: string;
        public birimIlacBirimi: string;
        public dozajHesapTuru: string;
        public alActiveSubstances: Array<ActiveSubstance>;
        public alEquivalentDrugs: Array<DrugInfo>;
        public alEK2EquivalentDrugs: Array<DrugInfo>;
        public alDrugRules: Array<DrugRule>;
    }

    export class ActiveSubstance {
        public name: string;
        public amount: number;
        public substanceUnit: string;
    }

    export class DrugRule {
        public RuleText: string;
        public RuleParPredefined: string;
        public RuleParFreeText: string;
    }

    export class ProvReturn {
        public SonucAcıklaması: string;
        public sonuckodu: number;
        public ReceteSonucAcıklaması: string;
        public ilac: DrugInfo;
        public HastaIlac: Array<HastaIlacInfo>;
        public receteIlacSonuc: Array<ReceteIlacSonuc>;
        public hastaBilgileri: Array<HastaInfo>;
    }

    export class RaporInfo {
        public HastaId: string;
        public kurumId: number;
        public kurumturu: number;
        public raporno: string;
        public raporbaslangictarihi: string;
        public raporbitistarihi: string;
        public tedavisema: string;
        public zdegeri: string;
        public patoloji: string;
        public agizdanbeslenemez: string;
        public yasboy: string;
        public ovulasyon: string;
        public intrauterin: string;
        public diplomano: number;
        public uzmanlikdali: number;
        public protokolno: string;
        public acildurum: string;
        public XXXXXX: string;
        public ilaclar: Array<raporilac>;
        public tanilar: Array<raportani>;
        public uzmanliklar: Array<uzmanlik>;
    }

    export class raporilac {
        public Id: number;
        public name: string;
        public PacketAmount: number;
        public Dosage: number;
        public DosageAmount: number;
        public AlternativeId: number;
        public weeklyMonthly: number;
        public hasReport: boolean;
        public hasTenDays: boolean;
    }

    export class raportani {
        public kodu: string;
        public adi: string;
    }

    export class uzmanlik {
        public kodu: string;
        public adi: string;
    }

    export class ReceteInfo {
        public HastaId: string;
        public ReceteObjectId: string;
        public ayaktanyatan: number;
        public sicilno: string;
        public patientgroup: string;
        public receteturu: string;
        public serbesttani: string;
        public diplomano: number;
        public kurumId: number;
        public recetetarihi: string;
        public ilacverilistarihi: string;
        public uzmanlikdali: number;
        public protokolno: string;
        public acildurum: string;
        public XXXXXX: string;
        public ilaclar: Array<receteilac>;
        public tanilar: Array<recetetani>;
    }

    export class receteilac {
        public Id: number;
        public name: string;
        public PacketAmount: number;
        public Dosage: number;
        public DosageAmount: number;
        public AlternativeId: number;
        public weeklyMonthly: number;
        public hasReport: boolean;
        public hasTenDays: boolean;
    }

    export class recetetani {
        public kodu: string;
        public adi: string;
    }

    export class WebMethods {

    }
}
