//$459A42FD
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HealthCommittee } from 'NebulaClient/Model/AtlasClientModel';
import { MemberOfHealthCommiittee } from "NebulaClient/Model/AtlasClientModel";
import { BaseHealthCommittee_ExtDoctorGrid } from "NebulaClient/Model/AtlasClientModel";
import { BaseHealthCommittee_HospitalsUnitsGrid } from "NebulaClient/Model/AtlasClientModel";
import { SystemForHealthCommitteeGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SystemForDisabledReportDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDisabledGroup } from 'NebulaClient/Model/AtlasClientModel';
import { IntendedUseOfDisabledReport } from 'NebulaClient/Model/AtlasClientModel';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { AnamnesisFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnesisFormViewModel';
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";

export class HCExaminationFormViewModel extends BaseViewModel {
    @Type(() => HealthCommittee)
    public _HealthCommittee: HealthCommittee = new HealthCommittee();
    @Type(() => MemberOfHealthCommiittee)
    public MembersGridList: Array<MemberOfHealthCommiittee> = new Array<MemberOfHealthCommiittee>();
    @Type(() => BaseHealthCommittee_ExtDoctorGrid)
    public ExternalDoctorsGridList: Array<BaseHealthCommittee_ExtDoctorGrid> = new Array<BaseHealthCommittee_ExtDoctorGrid>();
    @Type(() => BaseHealthCommittee_HospitalsUnitsGrid)
    public HospitalsUnitsGridList: Array<BaseHealthCommittee_HospitalsUnitsGrid> = new Array<BaseHealthCommittee_HospitalsUnitsGrid>();
    @Type(() => SystemForHealthCommitteeGrid)
    public SystemForHealthCommitteeGridGridList: Array<SystemForHealthCommitteeGrid> = new Array<SystemForHealthCommitteeGrid>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => DiagnosisGrid)
    public DiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    @Type(() => SystemForDisabledReportDefinition)
    public SystemForDisabledReportDefinitions: Array<SystemForDisabledReportDefinition> = new Array<SystemForDisabledReportDefinition>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => MedicalInformation)
    public MedicalInformations: Array<MedicalInformation> = new Array<MedicalInformation>();
    @Type(() => MedicalInfoDisabledGroup)
    public MedicalInfoDisabledGroups: Array<MedicalInfoDisabledGroup> = new Array<MedicalInfoDisabledGroup>();
    @Type(() => IntendedUseOfDisabledReport)
    public IntendedUseOfDisabledReports: Array<IntendedUseOfDisabledReport> = new Array<IntendedUseOfDisabledReport>();
    @Type(() => HCRequestReason)
    public HCRequestReasons: Array<HCRequestReason> = new Array<HCRequestReason>();
    @Type(() => ReasonForExaminationDefinition)
    public ReasonForExaminationDefinitions: Array<ReasonForExaminationDefinition> = new Array<ReasonForExaminationDefinition>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => Boolean)
    public IsDisabled: Boolean;
    @Type(() => Boolean)
    public UnCompletedExaminationExists: Boolean;
    public IntendedUseEvaluationParameter: string;
    @Type(() => SystemForHealthCommitteeGridListViewModel)
    public SystemForHealthCommitteList: SystemForHealthCommitteeGridListViewModel[];

    @Type(() => HCExaminationInfo)
    public HCExaminationInfoList: Array<HCExaminationInfo>;

    @Type(() => ConsultationInfo)
    public HCConsultationInfoList: Array<ConsultationInfo>;

    @Type(() => Boolean)
    public hasUndoTransRight: Boolean;

    @Type(() => AnamnesisFormViewModel)
    public anamnesisFormViewModel: AnamnesisFormViewModel;

    @Type(() => UserTemplateModel)
    public userTemplateList : Array<UserTemplateModel> = new Array<UserTemplateModel>();

    @Type(() => UserTemplateModel)
    public selectedUserTemplate : UserTemplateModel;

    //constructor() {
    //    this.SystemForHealthCommitteeGridList = new Array<SystemForHealthCommitteeGridListViewModel>();
    //}
}
export class SystemForHealthCommitteeGridListViewModel {
    public DisabledOfferDecision: string;
    @Type(() => Number)
    public DisabledRatio: number;
    public SystemForDisabled: string;
    @Type(() => Guid)
    public SystemForDisabledID: Guid;
}

export class HCExaminationInfo {

    @Type(() => Guid)
    public ObjectId: Guid;

    public ObjectDefName: string;
    public FormDefId: string;
    public MasterResource: string;
    public ProcedureDoctor: string;
    public ExaminationDate: string;

    public OfferOfDecision: string;
    public TreatmentInfo: string;
    public ClinicalInfo: string;
    public RadiologicalInfo: string;
    public LabrotoryInfo: string;
}

export class ConsultationInfo {

    @Type(() => Guid)
    public ObjectId: Guid;

    public MasterResource: string;
    public ProcedureDoctor: string;
    public ConsultationResult: object;
    public ConsultationResultSummary: string;

    public ProcessDate: string;
}

export class HcExaminationTemplate
{
    @Type(() => Guid)
    public _healthCommitteeDecision: Guid ;
}
