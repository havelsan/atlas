//$DB89F690
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from '../../../../wwwroot/app/NebulaClient/Mscorlib/Guid';

export class InPatientWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {
    @Type(() => InPatientWorkListItem)
    WorkList: Array<InPatientWorkListItem> = new Array<InPatientWorkListItem>();
    _SearchCriteria: InPatientWorkListSearchCriteria = new InPatientWorkListSearchCriteria();
    // _SearchCriteria  dx-tag-box 'ı doldurmak için
    @Type(() => ResSection)
    ResourceList: Array<ResSection> = new Array<ResSection>();

}



export class InPatientWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {

    //Getirilecek EpisodeAction Tipi
    public inPatientPhysicianApplication_EA: boolean;
    public consultation_EA: boolean;
    public participatnFreeDrugReport_EA: boolean;

       // inPatientPhysicianApplication ise state sorguları
    public acception: boolean; //Yatış Bekleyen Hasta
    public inpatient: boolean; //Yatan Hasta
    public predischarge: boolean; // Taburcu
    public discharge: boolean; //Ön Taburcu
    public dailyInpatient: boolean; //Gunubirlik Yatis

       // consultation_EA ise state sorguları
    public waiting_consultation: boolean; //Bekleyen
    public in_consultation: boolean; //Takipte
    public closed_consultation: boolean; //Bitirilen
    public rejected_consultation: boolean; //Reddedilen
    public send_consultation: boolean; //Gönderilen

    //participatnFreeDrugReport_EA ise state sorguları
    public report: boolean; //Rapor adımında
    public waiting_doctor: boolean; //ikinci-üçüncü doktor adımında
    public waiting_headdoctor: boolean; //başhekim adımında
    public completed_report: boolean; //Tamamlanan (Rapor onayı tamamlanan hastalar)
    public rejected_report: boolean; //Reddedilen (Rapor onayı reddedilen hastalar)

    public OnlyOwnPatient: boolean; // Yalnız Kendi Hastaları
    public HasSurgery: boolean; // Ameliyat İstemi olan Hastalar
    public HasVacation: boolean;//İzinli hastalar

    @Type(() => ResSection)
    public Resources: Array<ResSection>;

    public ProtocolNo: string;
    public ReportChasingNo: string;
}


export class InPatientWorkListItem extends BaseEpisodeActionWorkListItem {
    public OrderNumber: number;

    // Yatan hasta ikonları için
    public HasTightContactIsolation: boolean;
    public HasFallingRisk: boolean;
    public HasDropletIsolation: boolean;
    public HasAirborneContactIsolation: boolean;
    public HasContactIsolation: boolean;

    // Kolonları İçin
    @Type(() => Date)
    public Date: Date; //Tarih
    public PatientNameSurname: string; //Adı Soyadı
    public EpisodeActionName: string; //İşlem
    public StateName: string; //Durumu
    public MasterResource: string; //  Birim
    public RoomBed: string; //Oda / Yatak
    public DoctorName: string; //Doktor Adı
    public InpatientDay: string;//hastanın yattığı gün bilgisi

      // Gizli Kolonları için
    public UniqueRefno: string; // Kimlik No
    public KabulNo: string; //Kabul No
    public NurseName: string; //Hemşire Adı
    public AdmissionType: string; // Geliş Sebebi
    public PayerName: string; // Kurumu
    @Type(() => Date)
    public BirthDate: Date; // Doğum Tarihi
    public FatherName: string; // Baba adı
    public TelNo: string; // Telefon Numarası

    public HastaTuru: string;
    public BasvuruTuru: string;
    public OncelikDurumu: string;
    public Diagnosis: string;
    public Companion: string;
    @Type(() => Date)
    public InpatientDate: Date; // Yatis Tarihi
}

export class InpatientStatisticReportViewModel {
    @Type(() => ReportBaseModel)
    public ClinicList: Array<ReportBaseModel>;
    @Type(() => ReportBaseModel)
    public SpecialityList: Array<ReportBaseModel>;
    @Type(() => Date)
    public ReportDate: Date;
    @Type(() => Date)
    public InpatientStartDate: Date = null;
    @Type(() => Date)
    public InpatientEndDate: Date = null;
    @Type(() => Date)
    public DischargeStartDate: Date = null;
    @Type(() => Date)
    public DischargeEndDate: Date = null;
}

export class ReportBaseModel {
    public ObjectID: Guid;
    public Name: string;
}

export class DiagnosisAndProcedureBaseModel {
    public ObjectID: Guid;
    public Code: string;
    public Name: string;
}

export class InPatientListForStatisticReport {
    public PatientNameSurame: string;
    public UniqueRefNo: string;
    public ClinicInpatientDate: string;
    public ClinicDischargeDate: string;
    public SubepisodeID: string;
    public EpisodeID: string;
    public Medicines: string;
    public Diagnosis: string;
    public RadiologyTests: Array<RadiologyTestInfo>;
}

export class RadiologyTestInfo {
    public ObjectID: string;
    public Code: string;
    public Name: string;
    public CurrentStateID: string;
    public CurrentStateName: string;
}

