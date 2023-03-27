//$E0FD499D
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { ParticipatnFreeDrugReport } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaReportResult } from 'NebulaClient/Model/AtlasClientModel';
import { ParticipationFreeDrgGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { EtkinMadde } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Teshis } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { UsageDoseUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { FrequencyEnum } from 'NebulaClient/Model/AtlasClientModel';
import { IlacRaporuServis } from 'NebulaClient/Services/External/IlacRaporuServis';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';

export class ParticipationFreeDrugReportNewFormViewModel extends BaseViewModel {
    @Type(() => ParticipatnFreeDrugReport)
    public _ParticipatnFreeDrugReport: ParticipatnFreeDrugReport = new ParticipatnFreeDrugReport();
    @Type(() => MedulaReportResult)
    public MedulaReportResultsGridList: Array<MedulaReportResult> = new Array<MedulaReportResult>();
    @Type(() => ParticipationFreeDrgGrid)
    public ParticipationFreeDrugsGridList: Array<ParticipationFreeDrgGrid> = new Array<ParticipationFreeDrgGrid>();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => EtkinMadde)
    public EtkinMaddes: Array<EtkinMadde> = new Array<EtkinMadde>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => Teshis)
    public Teshiss: Array<Teshis> = new Array<Teshis>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => DozAraligiListModel)
    public DozAraligiList: Array<DozAraligiListModel> = new Array<DozAraligiListModel>();
    @Type(() => TaniTeshisListModel)
    public TaniTeshisList: Array<TaniTeshisListModel> = new Array<TaniTeshisListModel>();
    @Type(() => EtkinMaddeListModel)
    public EtkinMaddeList: Array<EtkinMaddeListModel> = new Array<EtkinMaddeListModel>();
    @Type(() => AddedDiagnosisListModel)
    public AddedDiagnosisList: Array<AddedDiagnosisListModel> = new Array<AddedDiagnosisListModel>();
    @Type(() => TeshisListModel)
    public TeshisList: Array<TeshisListModel> = new Array<TeshisListModel>();
    @Type(() => AddedDiagnosisListModel)
    public SelectedTeshisTaniList: Array<AddedDiagnosisListModel> = new Array<AddedDiagnosisListModel>();
    @Type(() => EtkenMaddeTeshisListModel)
    public EtkenMaddeTeshisList: EtkenMaddeTeshisListModel;
    @Type(() => SubEpisodeProtocol)
    public SubEpisodeProtocol: SubEpisodeProtocol = new SubEpisodeProtocol();
    @Type(() => Boolean)
    public IsSuperUser: boolean;
    @Type(() => Boolean)
    public IsPatientSGK: boolean;
    @Type(() => Boolean)
    public closeMedula: boolean;
    @Type(() => Boolean)
    public SecondDoctorApprove: boolean;
    @Type(() => Boolean)
    public ThirdDoctorApprove: boolean;
    public EtkinMaddeListFilter: string;
    public TeshisFilter: string;
    @Type(() => Guid)
    public ToState: Guid;
    @Type(() => MedulaReportResult)
    public SelectededulaReportResult: MedulaReportResult;
    @Type(() => IlacRaporuServis.eraporAciklamaEkleIstekDVO)
    public AciklamaEkleIstekDVO: IlacRaporuServis.eraporAciklamaEkleIstekDVO;
    @Type(() => IlacRaporuServis.eraporTaniEkleIstekDVO)
    public TaniEkleIstekDVO: IlacRaporuServis.eraporTaniEkleIstekDVO;
    @Type(() => IlacRaporuServis.eraporTeshisEkleIstekDVO)
    public TeshisEkleIstekDVO: IlacRaporuServis.eraporTeshisEkleIstekDVO;
    @Type(() => IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO)
    public EtkinMaddeEkleIstekDVO: IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO;
    @Type(() => Date)
    public TeshistStartDate: Date;
    @Type(() => Date)
    public TeshisEndDate: Date;
    public cmbEklenecekDozAraligi: FrequencyEnum;
    public sonucKodu: string;
    public sonucMesaji: string;
    public uyariMesaji: string;
    public ReportReasonList: Array<any> = new Array<any>();
    public medulaUsername: string;
    public medulaPassword: string;
    public minReportDate: string = "";
    public maxReportDate: string = "";
    public secondDoctor: string;
    public thirdDoctor: string;

    @Type(() => UserTemplateModel)
    public userTemplateList: Array<UserTemplateModel> = new Array<UserTemplateModel>();

    @Type(() => UserTemplateModel)
    public selectedUserTemplate: UserTemplateModel;
    public hasAuthorityForUndo: boolean;
}

export class UserTemplateModel {
    ObjectID: Guid;
    Description: string;
    TAObjectID: Guid;
    TAObjectDefID: Guid;
}

export class EtkenMaddeTeshisListModel {
    @Type(() => Guid)
    public etkenMaddeObjectId: Guid;
    @Type(() => TeshisListModel)
    public TeshisList: Array<TeshisListModel> = new Array<TeshisListModel>();
}
export class TeshisListModel {
    @Type(() => Teshis)
    public teshis: Teshis;
    public teshisKodu: string;
    public teshisAdi: string;
    @Type(() => AddedDiagnosisListModel)
    public AddedDiagnosisList: Array<AddedDiagnosisListModel> = new Array<AddedDiagnosisListModel>();
    @Type(() => AddedDiagnosisListModel)
    public SelectedDiagnosisList: Array<AddedDiagnosisListModel> = new Array<AddedDiagnosisListModel>();
    public SelectedDiagnosisListKeys: Array<string> = new Array<string>();
    @Type(() => EtkinMadde)
    public relatedEtkenMaddeList: Array<EtkinMadde> = new Array<EtkinMadde>();
    public relatedEtkenMaddeNames: string;
    public selectedDiagnoses: string;
}

export class DozAraligiListModel {
    @Type(() => Number)
    public DozAraligiID: number;
    public DozAraligiText: string;
}
export class TaniTeshisListModel {
    @Type(() => Guid)
    public Tani: Guid;
    @Type(() => Guid)
    public Teshis: Guid;

}
export class EtkinMaddeListModel {
    @Type(() => Guid)
    public EtkinMadde: Guid;
    @Type(() => Guid)
    public ParticipatientFreeDrugObjectID: Guid;
    public EtkinMaddeName: string;
    public EtkinMaddeMudalaHarici: string;
    public DozAraligi: FrequencyEnum;
    @Type(() => Number)
    public Doz: number;
    public Doz2: number;
    public DozBirimi: UsageDoseUnitTypeEnum;
    @Type(() => Number)
    public Periyod: number;
    public PeriyodBirimi: PeriodUnitTypeEnum;

}
export class AddedDiagnosisListModel {
    @Type(() => DiagnosisDefinition)
    public Tani: DiagnosisDefinition;
    @Type(() => Guid)
    public teshisObjectID: Guid;
    public taniKodu: string;
    public taniAdi: string;
    @Type(() => Boolean)
    public selected: boolean;
}
export class MedulaResult {
    @Type(() => Boolean)
    public Succes: boolean;
    public BasvuruNo: string;
    public TakipNo: string;
    public SonucMesaji: string;
    public SonucKodu: string;
    public BagliTakipNo: string;
    public SEPObjectID: string;

    constructor() {
        this.SonucKodu = "";
        this.SonucMesaji = "";
        this.Succes = false;
        this.TakipNo = "";
        this.BasvuruNo = "";
        this.SEPObjectID = "";
    }
}

export class DrugReportApproveModel {
    @Type(() => ParticipatnFreeDrugReport)
    public participatnFreeDrugReport: ParticipatnFreeDrugReport = new ParticipatnFreeDrugReport();
    public medulaUsername: string;
    public medulaPassword: string;
}

export class SendSignedReportApproveModel {
    @Type(() => ParticipatnFreeDrugReport)
    public participatnFreeDrugReport: ParticipatnFreeDrugReport = new ParticipatnFreeDrugReport();
    public medulaUsername: string;
    public medulaPassword: string;
    public signContent: string;
    public isSecondDoctorApprove: boolean = false;
    public isThirdDoctorApprove: boolean = false;
}

export class SendSignedReport_Input {   //  İmzalı Rapor Gönderilirken kullanılan nesne
    public signContent: string;
    //public ReportObjectID: Guid;
    public viewModel: ParticipationFreeDrugReportNewFormViewModel;
}

export class SendSignedReportDelete_Input {   //  İmzalı Rapor Silme işleminde kullanılan nesne
    public signContent: string;
    //public ReportObjectID: Guid;
    public viewModel: ParticipationFreeDrugReportNewFormViewModel;
}

export class SendSignedReportAddDescription_Input {   //  İmzalı Rapor Silme işleminde kullanılan nesne
    public signContent: string;
    //public ReportObjectID: Guid;
    public viewModel: ParticipationFreeDrugReportNewFormViewModel;
}

export class SendSignedReportAddDiagnosis_Input {   //  İmzalı Rapor Silme işleminde kullanılan nesne
    public signContent: string;
    //public ReportObjectID: Guid;
    public viewModel: ParticipationFreeDrugReportNewFormViewModel;
}

export class SendSignedReportAddTeshis_Input {   //  İmzalı Rapor Silme işleminde kullanılan nesne
    public signContentList: Array<TeshisImzalanacakXml> = new Array<TeshisImzalanacakXml>();
    //public ReportObjectID: Guid;
    public viewModel: ParticipationFreeDrugReportNewFormViewModel;
}

export class TeshisImzalanacakXml {
    public imzalanacakXml: string;
    public Type: number;
}

export class SendSignedReportAddEtkinMadde_Input {   //  İmzalı Rapor Silme işleminde kullanılan nesne
    public signContent: string;
    //public ReportObjectID: Guid;
    public viewModel: ParticipationFreeDrugReportNewFormViewModel;
}