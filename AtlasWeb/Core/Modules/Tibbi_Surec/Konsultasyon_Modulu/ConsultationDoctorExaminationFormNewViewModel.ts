//$E8C22FFA
import { Consultation, BaseTreatmentMaterial, SubEpisode, EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SingleNursingOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DietMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIngredientDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ImportantMedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { VitalSignAndNursingDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseNewDoctorExaminationFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseNewDoctorExaminationFormViewModel';
import { SingleNursingOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { vmRequestedProcedure } from "../Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { vmProcedureRequestFormDefinition } from "../Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { ConsultationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { ReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

export class ConsultationDoctorExaminationFormNewViewModel extends BaseNewDoctorExaminationFormViewModel{
    @Type(() => Consultation)
    public _Consultation: Consultation = new Consultation();
    @Type(() => DiagnosisGrid)
    public DiagnosisHistoryGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ConsultationTreatmentMaterial)
    public GridTreatmentMaterialsGridList: Array<ConsultationTreatmentMaterial> = new Array<ConsultationTreatmentMaterial>();
    @Type(() => Consultation)
    public GrdConsultationGridList: Array<Consultation> = new Array<Consultation>();
    @Type(() => SingleNursingOrder)
    public GridNursingOrdersGridList: Array<SingleNursingOrder> = new Array<SingleNursingOrder>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => DietMaterialDefinition)
    public DietMaterialDefinitions: Array<DietMaterialDefinition> = new Array<DietMaterialDefinition>();
    @Type(() => ActiveIngredientDefinition)
    public ActiveIngredientDefinitions: Array<ActiveIngredientDefinition> = new Array<ActiveIngredientDefinition>();
    @Type(() => ImportantMedicalInformation)
    public ImportantMedicalInformations: Array<ImportantMedicalInformation> = new Array<ImportantMedicalInformation>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    @Type(() => VitalSignAndNursingDefinition)
    public VitalSignAndNursingDefinitions: Array<VitalSignAndNursingDefinition> = new Array<VitalSignAndNursingDefinition>();
    @Type(() => SingleNursingOrderDetail)
    public SingleNursingOrderDetails: Array<SingleNursingOrderDetail> = new Array<SingleNursingOrderDetail>();
    @Type(() => Guid)
    public _ConsultationMasterResourseID: Guid;
    @Type(() => vmRequestedProcedure)
    public RequestedProcedures: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    @Type(() => Guid)
    public _EpisodeActionObjectId: Guid;
    @Type(() => EpisodeActionRequestedProcedureInfo)
    public EpisodeActionRequestedProcedureInfo: EpisodeActionRequestedProcedureInfo;
    @Type(() => Guid)
    public ProcedureRequestFormResourceIDs: Array<Guid> = new Array<Guid>();
    @Type(() => vmProcedureRequestFormDefinition)
    public UserMostUsedFormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();
    public reportType: ReportTypeEnum = 0;
    @Type(() => PatientReportInfo)
    public PatientReportInfoList: Array<PatientReportInfo> = new Array<PatientReportInfo>();
    public SpecialityBasedObjectViewModels: Array<any> = new Array<any>();
    //public _selectedMaterialValue: Object;
   // public _isComplete: boolean;
    @Type(() => Boolean)
    public IsAuthorizedToWriteTreatmentReport: boolean;
    public BedRoomInfo: string;
    @Type(() => BaseTreatmentMaterial)
    public NewGridTreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();

    @Type(() => SubEpisode)
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => SubEpisode)
    public SubEpisodeList: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => EpisodeAction)
    public EpisodeActionList: Array<EpisodeAction> = new Array<EpisodeAction>();
}

export class EpisodeActionRequestedProcedureInfo {
    @Type(() => Consultation)
    public EpisodeAction: Consultation;
    @Type(() => Guid)
    public ProcedureRequestFormDetailDefinitionIDs: Array<Guid> = new Array<Guid>();
    @Type(() => Guid)
    public ProcedureRequestAdditionalApplicationIDs: Array<Guid> = new Array<Guid>();
}

export class PatientReportInfo {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ObjectDefName: string;
    public ID: string;
    public StartDate: string;
    public EndDate: string;
    public ReportName: string;
}

