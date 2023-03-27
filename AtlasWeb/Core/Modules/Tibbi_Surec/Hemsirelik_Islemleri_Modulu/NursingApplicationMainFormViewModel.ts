//$6B584D58
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingApplication, ResSection, Patient, BaseTreatmentMaterial, SubEpisode, EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { OrderTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NursingApplicationTreatmentMaterial, SurfaceSupportSystemsDef, PreventionAndMonitoringPlanDef, EducationDef, WoundAssessmentDef } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";

export class NursingApplicationMainFormViewModel extends BaseViewModel {
    @Type(() => NursingApplication)
    public _NursingApplication: NursingApplication = new NursingApplication();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => NursingApplicationTreatmentMaterial)
    public TreatmentMaterialsGridList: Array<NursingApplicationTreatmentMaterial> = new Array<NursingApplicationTreatmentMaterial>();
    @Type(() => InPatientTreatmentClinicApplication)
    public InPatientTreatmentClinicApplications: Array<InPatientTreatmentClinicApplication> = new Array<InPatientTreatmentClinicApplication>();
    //public BaseInpatientAdmissions: Array<BaseInpatientAdmission> = new Array<BaseInpatientAdmission>();
    //public ResBeds: Array<ResBed> = new Array<ResBed>();
    //public ResRooms: Array<ResRoom> = new Array<ResRoom>();
    //public ResRoomGroups: Array<ResRoomGroup> = new Array<ResRoomGroup>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => EmergencyIntervention)
    public EmergencyInterventions: Array<EmergencyIntervention> = new Array<EmergencyIntervention>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();

    //Eklendi
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingAppProgressSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingGlaskowComaScaleSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingPupilSymptomsSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingPainScaleSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingSpiritualSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingNutritionAssessmentSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingFunctionalLifeActivitySummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingPatientAndFamilyInstructionSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingCareSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingSystemInterrogationSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingDischargingInstructionPlanSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingFallingDownRiskSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingWoundAssessmentScaleInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingLegMeasurementInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingNutritionalRiskAssessmentInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();

    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingBodyFluidAnalysisInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();

    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingpatientPreAssesmentInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();

    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingWoundedAssessmentInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();

    @Type(() => Boolean)
    public PatientPreAssesmentAddVisible: boolean = false;
    @Type(() => Boolean)
    public NursingPatientAndFamilyInstructionAddVisible: boolean = false;
    @Type(() => Boolean)
    public NursingDischargingInstructionPlanSummaryAddVisible: boolean = false;
    @Type(() => Boolean)
    public includeDrugDefinition: boolean;
    @Type(() => Boolean)
    public toolOption: boolean;
    @Type(() => Boolean)
    public HasFalling: boolean;
    @Type(() => Number)
    public fallingWarningAge: number;
    @Type(() => Boolean)
    public HasPainInfo: boolean;
    @Type(() => String)
    public LastPainScaleInfo: string;
    @Type(() => Boolean)
    public HasWoundInfo: boolean;
    @Type(() => WoundAssessmentInfo)
    public woundAssessmentInfo: WoundAssessmentInfo;
    @Type(() => String)
    public LastWoundAssessmentInfo: string;
    public VitalSignWarningInfo: string = "";
    @Type(() => Boolean)
    public HasVitalSignWarning: boolean = false;
    @Type(() => Boolean)
    public HasOutDatedForm: boolean = false;
    @Type(() => String)
    public OutDatedFormsInfo: string;
    @Type(() => Boolean)
    public HasOutDatedFallingRiskForm: boolean = false;
    @Type(() => String)
    public OutDatedFallingRiskInfo: string;
    @Type(() => Boolean)
    public IsFallingRiskBiggerThanFive: boolean = false;
    @Type(() => Boolean)
    public hasOrthesisRequestRole: boolean;
    public PatientNameSurname: string;
    public NurseName: string;
    @Type(() => Boolean)
    public showFallingRiskParameter: boolean;
    @Type(() => BaseTreatmentMaterial)
    public NewTreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();
    @Type(() => SubEpisode)
    public SubEpisodeList: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => EpisodeAction)
    public EpisodeActionList: Array<EpisodeAction> = new Array<EpisodeAction>();
    @Type(() => Boolean)
    public HasYaraHemsireRole: boolean;
    @Type(() => Boolean)
    public ShowNewOrderTab: boolean;
    @Type(() => Patient)
    public _Patient: Patient;
}

export class NursingDynamicComponent_SummaryInfo {
    public ObjectID: Guid;
    public ApplicationDate?: Date;
    public ApplicationUserName: string;
    public ApplicationSummary: string;
    public RowColor: string;
    public isDeleted: boolean;
}
export class GetBarcode {
    public startDate: Date;
    public endDate: Date;
    public NursingApplicationObjectid: Guid;
}

export class WoundAssessmentInfo {
    public preventionDef: Array<PreventionAndMonitoringPlanDef> = new Array<PreventionAndMonitoringPlanDef>();
    public surfaceSupportDef: Array<SurfaceSupportSystemsDef> = new Array<SurfaceSupportSystemsDef>();
    public educationDef: Array<EducationDef> = new Array<EducationDef>();
    public woundAssessmentDef: Array<WoundAssessmentDef> = new Array<WoundAssessmentDef>();
}

export class ReportController {
    @Type(() => ResSection)
    public ResourceList: Array<ResSection>;
    @Type(() => ResSection)
    public selectedReportResource: ResSection;
    @Type(() => Patient)
    public PatientList: Array<Patient>;
    @Type(() => Patient)
    public selectedPatient: Array<Patient>;
    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
}

export class NewOrderDetailDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public ObjectDefID: Guid;
    public StateID: string;
    public OrderDate: Date;
    public OrderName: string;
    public Result: string;
    public DrugOrderDetailStatus: string;
    public NursingOrderStatus: string;
    public OrderType: string;
    public User: string;
    public typeId: OrderTypeEnum;
}

export class GetNewOrderDetail_Input{
    @Type(() => Guid)
    public nursingApplicationID: Guid;
    public startDate: Date;
    public endDate:Date;
    public allDate:boolean;
    public orderTypeId: number;
    public drugOrderDetailStateIDs: Array<Guid> = new Array<Guid>();
    public nursingOrderDetailStateIDs: Array<Guid> = new Array<Guid>();
}

export class ApplyNewOrderDetail_Output {
    public isError: boolean;
    public msg: string;
}


