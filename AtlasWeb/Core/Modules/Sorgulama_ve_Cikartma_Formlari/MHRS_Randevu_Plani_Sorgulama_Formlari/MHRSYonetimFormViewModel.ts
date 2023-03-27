//$4FE3F479
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MHRSYonetim } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";

export class MHRSYonetimFormViewModel extends BaseViewModel {
    @Type(() => MHRSYonetim)
    public _MHRSYonetim: MHRSYonetim = new MHRSYonetim();
    @Type(() => PoliklinikMHRSKlinikKoduEslestirmeListModel)
    public PoliklinikMHRSKlinikKoduEslestirmeList: PoliklinikMHRSKlinikKoduEslestirmeListModel[];
    @Type(() => MHRSKlinikEkleListModel)
    public MHRSKlinikEkleList: MHRSKlinikEkleListModel[];
    @Type(() => MHRSAltKlinikEkleListModel)
    public MHRSAltKlinikEkleList: MHRSAltKlinikEkleListModel[];
    @Type(() => DoktorEkleListModel)
    public DoktorEkleList: DoktorEkleListModel[];
    @Type(() => ScheduleListModel)
    public ScheduleList: ScheduleListModel[];
    @Type(() => BransListModel)
    public BransList: BransListModel[];
    @Type(() => ResUser)
    public Doctor: ResUser;
    @Type(() => ResPoliclinic)
    public Policlinic: ResPoliclinic;
    @Type(() => Date)
    public BaslangicTarihi: Date;
    @Type(() => Date)
    public BitisTarihi: Date;
    @Type(() => Boolean)
    public Kesinlesmis: boolean;

    constructor() {
        super();
        this.PoliklinikMHRSKlinikKoduEslestirmeList = new Array<PoliklinikMHRSKlinikKoduEslestirmeListModel>();
        this.MHRSKlinikEkleList = new Array<MHRSKlinikEkleListModel>();
        this.MHRSAltKlinikEkleList = new Array<MHRSAltKlinikEkleListModel>();
        this.DoktorEkleList = new Array<DoktorEkleListModel>();
        this.ScheduleList = new Array<ScheduleListModel>();
        this.BransList = new Array<BransListModel>();
        this.BaslangicTarihi = new Date();
        this.BitisTarihi = new Date();
    }
}
export class PoliklinikMHRSKlinikKoduEslestirmeListModel {
    @Type(() => ResPoliclinic)
    public Poliklinik: ResPoliclinic;
    public PoliklinikName: string;
    public MHRSKlinik: string;
    @Type(() => Boolean)
    public Ekle: boolean;
}
export class MHRSKlinikEkleListModel {
    @Type(() => ResPoliclinic)
    public Poliklinik: ResPoliclinic;
    public PoliklinikName: string;
    public Eklendi: string;
}
export class MHRSAltKlinikEkleListModel {
    @Type(() => ResPoliclinic)
    public Poliklinik: ResPoliclinic;
    public PoliklinikName: string;
    public Eklendi: string;
}
export class DoktorEkleListModel {
    public Uzmanlik: string;
    public Doktor: string;
    public Eklendi: string;
}
export class ScheduleListModel {
    public PoliklinikName: string;
    public Doktor: string;
    public BaslangicTarihi: string;
    public BitisTarihi: string;
    @Type(() => Boolean)
    public Kesinlesti: boolean;
    public KesinlesmeHatasi: string;
}
export class BransListModel {
    public BransKodu: string;
}

export class CetvelSorgulaViewModel {
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    @Type(() => ResUser)
    public Doctor: ResUser;
    @Type(() => ResPoliclinic)
    public Birim: ResPoliclinic;
    @Type(() => Number)
    public SearchType: number;
}

export class CetvelSorgulamaReturnData 
                {
                 public cetvelId: number ;
 public cetvelDurumu: string ;
 public cetvelTipi: string ;
 public aksiyonId: number ;
 public baslangicZamani: string ;
 public bitisZamani: string ;
 public klinikKodu: number ;
 public klinikAdi: string ;
 public muayeneYeriId: number ;
 public muayeneYeriAdi: string ;
 public randevuSuresi: number ;
 public slotHastaSayisi: number ;
    public ikOzelDurum: string; 
    public hasSchedule: boolean;
    public CetvelKayitliMi: string;
    public resUserID: string;
    public cetvelTipiValue: string;
    public cetvelDurumuValue: string;
                }

