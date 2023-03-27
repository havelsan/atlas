//$046DB1AD
import { MedulaTreatmentReport } from 'NebulaClient/Model/AtlasClientModel';
import { RaporIslemleri } from 'NebulaClient/Services/External/RaporIslemleri';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviRaporiIslemKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { FTRVucutBolgesi } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DiyalizSeansGunEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaRaporOzelDurumEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviRaporTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaRaporTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TupBebekRaporTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Bobrek } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";
import { TedaviTuru } from "NebulaClient/Model/AtlasClientModel";
import { FTRReportDetailGrid, ESWTReportDetailGrid } from "NebulaClient/Model/AtlasClientModel";
import { FTRReport, ESWTReport } from "NebulaClient/Model/AtlasClientModel";
import { ReportDiagnosisFormViewModel } from '../Tani_Modulu/ReportDiagnosisFormViewModel';
import { ESWLReportDetailGrid } from "NebulaClient/Model/AtlasClientModel";
import { ESWLReport } from "NebulaClient/Model/AtlasClientModel";
import { TasLokalizasyon } from "NebulaClient/Model/AtlasClientModel";
import { HBTReport } from "NebulaClient/Model/AtlasClientModel";
import { TubeBabyReport } from "NebulaClient/Model/AtlasClientModel";
import { DialysisReport } from "NebulaClient/Model/AtlasClientModel";
import { HomeHemodialysisReport } from "NebulaClient/Model/AtlasClientModel";
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

export class MedulaTedaviRaporlariViewModel extends BaseViewModel{
    @Type(() => MedulaTreatmentReport)
    public _MedulaTreatmentReport: MedulaTreatmentReport = new MedulaTreatmentReport();
    @Type(() => FTRReportDetailGrid)
    public gridFizyoTerapiIslemleriGridList: Array<FTRReportDetailGrid> = new Array<FTRReportDetailGrid>();
    @Type(() => ESWTReportDetailGrid)
    public gridEswtIslemiGridList: Array<ESWTReportDetailGrid> = new Array<ESWTReportDetailGrid>();
    @Type(() => FTRReport)
    public FTRReports: Array<FTRReport> = new Array<FTRReport>();
    @Type(() => TedaviRaporiIslemKodlari)
    public TedaviRaporiIslemKodlaris: Array<TedaviRaporiIslemKodlari> = new Array<TedaviRaporiIslemKodlari>();
    @Type(() => FTRVucutBolgesi)
    public FTRVucutBolgesis: Array<FTRVucutBolgesi> = new Array<FTRVucutBolgesi>();
    @Type(() => TedaviTuru)
    public TedaviTurus: Array<TedaviTuru> = new Array<TedaviTuru>();
    @Type(() => ESWTReport)
    public ESWTReports: Array<ESWTReport> = new Array<ESWTReport>();
    @Type(() => ESWLReportDetailGrid)
    public gridTasBilgisiGridList: Array<ESWLReportDetailGrid> = new Array<ESWLReportDetailGrid>();
    @Type(() => ESWLReport)
    public ESWLReports: Array<ESWLReport> = new Array<ESWLReport>();
    @Type(() => Bobrek)
    public Bobreks: Array<Bobrek> = new Array<Bobrek>();
    @Type(() => TasLokalizasyon)
    public TasLokalizasyons: Array<TasLokalizasyon> = new Array<TasLokalizasyon>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => HBTReport)
    public HBTReports: Array<HBTReport> = new Array<HBTReport>();
    @Type(() => TubeBabyReport)
    public TubeBabyReports: Array<TubeBabyReport> = new Array<TubeBabyReport>();
    @Type(() => DialysisReport)
    public DialysisReports: Array<DialysisReport> = new Array<DialysisReport>();
    @Type(() => HomeHemodialysisReport)
    public HomeHemodialysisReports: Array<HomeHemodialysisReport> = new Array<HomeHemodialysisReport>();
    @Type(() => Boolean)
    public IsNew: boolean;
    @Type(() => Boolean)
    public IsPatientSGK: boolean;
    @Type(() => Guid)
    public ToState: Guid;
    public cmbDiyalizSeansGun: DiyalizSeansGunEnum;
    public cmbEvHemodiyalizSeansGun: DiyalizSeansGunEnum;
    public OzelDurum?: MedulaRaporOzelDurumEnum;
    @Type(() => Boolean)
    public chkOzelDurum: boolean;
    @Type(() => Boolean)
    public chkRefakatVarYok: boolean;
    public RaporTuru: TedaviRaporTuruEnum;
    public RBReportType: MedulaRaporTuruEnum;
    public ReportType: MedulaRaporTuruEnum;
    public cmbTupBebekTuru: TupBebekRaporTuruEnum;
    @Type(() => Date)
    public ReportDate: Date;
    @Type(() => Boolean)
    public FtrHeyetRaporu: boolean;
    @Type(() => Boolean)
    public patientExisting: boolean;
    @Type(() => Boolean)
    public willSendToMedula: boolean;
    @Type(() => Number)
    public kur: number;
    //@Type(() => Bobrek)
    //public lstBobrekBilgisi: Bobrek;
    @Type(() => TedaviRaporiIslemKodlari)
    public lstDiyalizRaporKodu: TedaviRaporiIslemKodlari;
    //@Type(() => TedaviRaporiIslemKodlari)
    //public lstEswlRaporKodu: TedaviRaporiIslemKodlari;
    @Type(() => TedaviRaporiIslemKodlari)
    public lstEvHemodiyalizRaporKodu: TedaviRaporiIslemKodlari;
    @Type(() => ResUser)
    public Tabip: ResUser;
    @Type(() => ResUser)
    public Tabip2: ResUser;
    @Type(() => ResUser)
    public Tabip3: ResUser;
    @Type(() => TedaviRaporiIslemKodlari)
    public lstTupBebekRaporKodu: TedaviRaporiIslemKodlari;
    @Type(() => Date)
    public RaporBaslangicTarihi: Date;
    //@Type(() => Date)
    //public RaporBitisTarihi: Date;
    @Type(() => Number)
    public txtDiyalizSeansSayisi: number;
    //@Type(() => Number)
    //public txtEswlSeansSayisi: number;
    @Type(() => Number)
    public txtEvHemodiyalizSeansSayisi: number;
    @Type(() => Number)
    public txtEvHemodiyalizTedaviSuresi: number;
    @Type(() => Number)
    public txtHOTSeansSayisi: number;
    @Type(() => Number)
    public txtHOTTedaviSuresi: number;
    public txtRaporTakipNo: string;
    public txtRaporAciklama: string;
    @Type(() => Number)
    public RBReportChasing: number;
    @Type(() => Number)
    public RBReportRow: number;
    @Type(() => Number)
    public ReportChasing: number;
    @Type(() => Number)
    public ReportRow: Object;
    @Type(() => Number)
    public txtResult: Object;
    public TedaviTipi: string = "";
    public TedaviTuru: string = "";
    //@Type(() => Number)
    //public txtTasSayisi: number;
    @Type(() => Number)
    public txtRaporSuresi: number;
    public cmbRaporSureTuru: PeriodUnitTypeEnum;
    @Type(() => Patient)
    public Patient: Patient = new Patient();
    public minReportDate: string = "";
    public maxReportDate: string = "";
    @Type(() => ReportDiagnosisFormViewModel)
    public reportDiagnosisFormViewModel: ReportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();


    public HistoryPatientAdmission: Array<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class> = new Array<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class>();
    public FizyoterapiIslemleriList: FizyoterapiIslemleriListModel[];
    public ESWTIslemleriList: ESWTIslemleriListModel[];
    public TasBilgisiIslemleriList: TasBilgisiIslemleriListModel[];
    public HastaAktifTakipleriList: HastaAktifTakipleriListModel[];
    public HastaAktifTumTakipleriList: HastaAktifTumTakipleriListModel[];
    public GridFtrRaporlariList: GridFtrRaporlariListModel[];
    public GridEswlRaporlariList: GridEswlRaporlariListModel[];
    public GridDiyalizRaporlariList: GridDiyalizRaporlariListModel[];
    public GridEvdiyalizRaporlariList: GridEvdiyalizRaporlariListModel[];
    public GridTupBebekRaporlariList: GridTupBebekRaporlariListModel[];
    public GridHOTRaporlariList: GridHOTRaporlariListModel[];
    public TaniGridList: TaniGridListModel[];
    public SelectedTakip: HastaAktifTakipleriListModel;
    public fTRVucutBolgesiList: FTRVucutBolgesiListModel[];

    public ActiveIDsModel:ActiveIDsModel;
    constructor() {
        super();
        this.RaporBaslangicTarihi = new Date();
       // this.RaporBitisTarihi = new Date();
        this.FizyoterapiIslemleriList = new Array<FizyoterapiIslemleriListModel>();
        this.ESWTIslemleriList = new Array<ESWTIslemleriListModel>();
        this.TasBilgisiIslemleriList = new Array<TasBilgisiIslemleriListModel>();
        this.HastaAktifTakipleriList = new Array<HastaAktifTakipleriListModel>();
        this.HastaAktifTumTakipleriList = new Array<HastaAktifTumTakipleriListModel>();
        this.GridFtrRaporlariList = new Array<GridFtrRaporlariListModel>();
        this.GridEswlRaporlariList = new Array<GridEswlRaporlariListModel>();
        this.GridDiyalizRaporlariList = new Array<GridDiyalizRaporlariListModel>();
        this.GridEvdiyalizRaporlariList = new Array<GridEvdiyalizRaporlariListModel>();
        this.GridTupBebekRaporlariList = new Array<GridTupBebekRaporlariListModel>();
        this.GridHOTRaporlariList = new Array<GridHOTRaporlariListModel>();
        this.TaniGridList = new Array<TaniGridListModel>();
        this.fTRVucutBolgesiList = new Array<FTRVucutBolgesiListModel>();
    }
}
export class Save_InputParam {
    @Type(() => RaporIslemleri.raporGirisDVO)
    public raporGirisDVO: RaporIslemleri.raporGirisDVO = new RaporIslemleri.raporGirisDVO();
    @Type(() => Number)
    public raporTuru: number ;
}
export class FizyoterapiIslemleriListModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public FizyoterapiIslemi: Guid;
    @Type(() => Guid)
    public VucutBolgesi: Guid;
    @Type(() => Number)
    public SeansSayisi: number;
    @Type(() => Guid)
    public TedaviTuru: Guid;
}
export class ESWTIslemleriListModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public FizyoterapiIslemiESWT: Guid;
    @Type(() => Guid)
    public VucutBolgesiESWT: Guid;
    @Type(() => Number)
    public SeansSayisiESWT: number;
}
export class TasBilgisiIslemleriListModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public Lokalizasyon: Guid;
    @Type(() => Number)
    public LokalizasyonKodu: number;
    @Type(() => Number)
    public TasBoyutu: number;
}
export class HastaAktifTakipleriListModel {
    public TakipNo: string;
    public Brans: string;
    @Type(() => Date)
    public ProvizyonTarihi: Date;
    public BagliTakipNo: string;
    public HProtocolNo: string;
    @Type(() => Date)
    public VakaAcilisTarihi: Date;
    public BransKodu: string;
    public TedaviTuru: string;
    @Type(() => Guid)
    public SubEpisode: Guid;
    @Type(() => Guid)
    public EAObjectId: Guid;
}
export class HastaAktifTumTakipleriListModel {
    public TakipNo: string;
    public Brans: string;
    @Type(() => Date)
    public ProvizyonTarihi: Date;
    public BagliTakipNo: string;
    public HProtocolNo: string;
    @Type(() => Date)
    public VakaAcilisTarihi: Date;
    public BransKodu: string;
    public TedaviTuru: string;
    @Type(() => Guid)
    public SubEpisode: Guid;
    @Type(() => Guid)
    public EAObjectId: Guid;
}
export class TaniGridListModel {
    public Tani: string;
    public TaniKodu: string;
    public FTRTaniGrup: string;
}
export class GridFtrRaporlariListModel {
    @Type(() => Number)
    public TakipNo: number;
    public RaporNo: string;
    @Type(() => Number)
    public RaporSiraNo: number;
    public VucutBolgesi: string;
    @Type(() => Number)
    public Kur: number;
    public RaporBaslangicTarihi: string;
    public VerildigiTesis: string;
    public Detail: string;
    public SonucMesaji: string;
    @Type(() => Number)
    public SonucKodu: number;
}
export class GridEswlRaporlariListModel {
    @Type(() => Number)
    public TakipNo: number;
    public RaporNo: string;
    @Type(() => Number)
    public RaporSiraNo: number;
    public SonucMesaji: string;
    @Type(() => Number)
    public SonucKodu: number;
    public RaporBaslangicTarihi: string;
    public VerildigiTesis: string;
    public Detail: string;
}
export class GridDiyalizRaporlariListModel {
    @Type(() => Number)
    public TakipNo: number;
    public RaporNo: string;
    @Type(() => Number)
    public RaporSiraNo: number;
    public SonucMesaji: string;
    @Type(() => Number)
    public SonucKodu: number;
    public RaporBaslangicTarihi: string;
    public VerildigiTesis: string;
    public Detail: string;
}
export class GridEvdiyalizRaporlariListModel {
    @Type(() => Number)
    public TakipNo: number;
    public RaporNo: string;
    @Type(() => Number)
    public RaporSiraNo: number;
    public SonucMesaji: string;
    @Type(() => Number)
    public SonucKodu: number;
    public RaporBaslangicTarihi: string;
    public VerildigiTesis: string;
    public Detail: string;
}
export class GridTupBebekRaporlariListModel {
    @Type(() => Number)
    public TakipNo: number;
    public RaporNo: string;
    @Type(() => Number)
    public RaporSiraNo: number;
    public SonucMesaji: string;
    @Type(() => Number)
    public SonucKodu: number;
    public RaporBaslangicTarihi: string;
    public VerildigiTesis: string;
    public Detail: string;
}
export class GridHOTRaporlariListModel {
    @Type(() => Number)
    public TakipNo: number;
    public RaporNo: string;
    @Type(() => Number)
    public RaporSiraNo: number;
    public SonucMesaji: string;
    @Type(() => Number)
    public SonucKodu: number;
    public RaporBaslangicTarihi: string;
    public VerildigiTesis: string;
    public Detail: string;
}
export class FTRVucutBolgesiListModel {
    public ftrVucutBolgesiKodu: string;
    public ftrVucutBolgesiAdi: string;
}

