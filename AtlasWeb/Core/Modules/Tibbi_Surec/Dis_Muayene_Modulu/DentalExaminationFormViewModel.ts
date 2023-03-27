//$F1DB818D
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { DentalExamination, DentalCommitment } from 'NebulaClient/Model/AtlasClientModel';
import { BaseDentalEpisodeActionDiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DentalConsultationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DentalExaminationSuggestedProsthesis } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MalzemeTuru } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DentalExaminationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PatientReportInfo, NewConsultationRequestInfo, OldConsultationInfo } from "../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel";
import { Type } from "NebulaClient/ClassTransformer";
import { Consultation, PatientInterviewForm, ConsultationFromExternalHospital, EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { vmProcedureRequestFormDefinition } from "Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { AnamnesisFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnesisFormViewModel';

export class DentalExaminationFormViewModel extends BaseViewModel {
    @Type(() => DentalExamination)
    public _DentalExamination: DentalExamination = new DentalExamination();
    @Type(() => BaseDentalEpisodeActionDiagnosisGrid)
    public SecDiagnosisGridGridList: Array<BaseDentalEpisodeActionDiagnosisGrid> = new Array<BaseDentalEpisodeActionDiagnosisGrid>();
    @Type(() => DentalProcedure)
    public DentalProsthesisGridList: Array<DentalProcedure> = new Array<DentalProcedure>();
    @Type(() => DentalConsultationRequest)
    public DentalConsultationGridList: Array<DentalConsultationRequest> = new Array<DentalConsultationRequest>();
    @Type(() => DentalExaminationTreatmentMaterial)
    public UsedMaterialsGridList: Array<DentalExaminationTreatmentMaterial> = new Array<DentalExaminationTreatmentMaterial>();
    @Type(() => DentalExaminationSuggestedProsthesis)
    public ttgrid3GridList: Array<DentalExaminationSuggestedProsthesis> = new Array<DentalExaminationSuggestedProsthesis>();
    @Type(() => DiagnosisGrid)
    public DiagnosisGridGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => AyniFarkliKesi)
    public AyniFarkliKesis: Array<AyniFarkliKesi> = new Array<AyniFarkliKesi>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    @Type(() => ResPoliclinic)
    public ResPoliclinics: Array<ResPoliclinic> = new Array<ResPoliclinic>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => MalzemeTuru)
    public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();
    @Type(() => DentalProsthesisDefinition)
    public DentalProsthesisDefinitions: Array<DentalProsthesisDefinition> = new Array<DentalProsthesisDefinition>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    public reportType: ReportTypeEnum = 0;
    @Type(() => PatientReportInfo)
    public PatientReportInfoList: Array<PatientReportInfo> = new Array<PatientReportInfo>();
    @Type(() => Boolean)
    public createNewProcedure: boolean;
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => Consultation)
    public GrdConsultationGridList: Array<Consultation> = new Array<Consultation>();
    @Type(() => PatientInterviewForm)
    public GrdPatientInterviewFormGridList: Array<PatientInterviewForm> = new Array<PatientInterviewForm>();
    @Type(() => ConsultationFromExternalHospital)
    public GrdExternalConsultationGridList: Array<ConsultationFromExternalHospital> = new Array<ConsultationFromExternalHospital>();
    @Type(() => DentalCommitment)
    public DentalCommitments: Array<DentalCommitment> = new Array<DentalCommitment>();
    @Type(() => OldConsultationInfo)
    public ConsultationsHistory: Array<OldConsultationInfo> = new Array<OldConsultationInfo>();
    @Type(() => NewConsultationRequestInfo)
    public NewConsultationRequests: Array<NewConsultationRequestInfo> = new Array<NewConsultationRequestInfo>();
    @Type(() => EpisodeAction)
    public GrdConsAndPatientInterviewFormGridList: Array<EpisodeAction> = new Array<EpisodeAction>();
    @Type(() => DentalExamination)
    public GrdDentalExaminationGridList: Array<DentalExamination> = new Array<DentalExamination>();
    @Type(() => vmProcedureRequestFormDefinition)
    public UserMostUsedFormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();
    @Type(() => Boolean)
    public hasSavedDiagnosis: boolean;
    @Type(() => Boolean)
    public includeDrugDefinition: boolean;
    public ExaminationProcessAndEndDate: string;
    @Type(() => Guid)
    public ProcedureRequestFormResourceIDs: Array<Guid> = new Array<Guid>();
    @Type(() => Boolean)
    public IsAuthorizedToWriteTreatmentReport: boolean;
    public ENabizViewModels: Array<any> = new Array<any>();

    @Type(() => AnamnesisFormViewModel)
    public anamnesisFormViewModel: AnamnesisFormViewModel;
    @Type(() => Boolean)
    public isNewMHRS: boolean;
}

export class DisTaahuutInput
{
    @Type(() => Patient)
    public patient: Patient;
    public DentalExaminationID: Guid;
}