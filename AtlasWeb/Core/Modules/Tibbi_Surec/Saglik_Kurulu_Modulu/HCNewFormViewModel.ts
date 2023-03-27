//$F808DD7D
import { HealthCommittee, EpisodeAction, HCReportTypeDefinition, HCExaminationComponent } from 'NebulaClient/Model/AtlasClientModel';
import { BaseHealthCommittee_HospitalsUnitsGrid, BaseHealthCommittee_ExtDoctorGrid } from 'NebulaClient/Model/AtlasClientModel';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { HospitalsUnitsDefinitionGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { MemberOfHealthCommiittee } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

export class HCNewFormViewModel extends BaseViewModel {
    @Type(() => HealthCommittee)
    public _HealthCommittee: HealthCommittee = new HealthCommittee();
    @Type(() => MemberOfHealthCommiittee)
    public MembersGridList: Array<MemberOfHealthCommiittee> = new Array<MemberOfHealthCommiittee>();
    @Type(() => BaseHealthCommittee_HospitalsUnitsGrid)
    public HospitalsUnitsGridList: Array<BaseHealthCommittee_HospitalsUnitsGrid> = new Array<BaseHealthCommittee_HospitalsUnitsGrid>();
    @Type(() => BaseHealthCommittee_HospitalsUnitsGrid)
    public HospitalsUnitsGridListPre: Array<BaseHealthCommittee_HospitalsUnitsGrid> = new Array<BaseHealthCommittee_HospitalsUnitsGrid>();
    @Type(() => BaseHealthCommittee_ExtDoctorGrid)
    public ExternalDoctorsGridList: Array<BaseHealthCommittee_ExtDoctorGrid> = new Array<BaseHealthCommittee_ExtDoctorGrid>();
    @Type(() => EpisodeAction)
    public LinkedActions: Array<EpisodeAction> = new Array<EpisodeAction>();
    @Type(() => HCRequestReason)
    public HCRequestReasons: Array<HCRequestReason> = new Array<HCRequestReason>();
    @Type(() => ReasonForExaminationDefinition)
    public ReasonForExaminationDefinitions: Array<ReasonForExaminationDefinition> = new Array<ReasonForExaminationDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    @Type(() => HCRequestReasonDetail)
    public HCRequestReasonDetail: HCRequestReasonDetail;
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => SubEpisode)
    public SubEpisode: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => SubEpisodeProtocol)
    public SubEpisodeProtocolList: Array<SubEpisodeProtocol> = new Array<SubEpisodeProtocol>();
    @Type(() => Boolean)
    public IsUnCompletedExaminationExists: boolean;

    @Type(() => SpecialityDefinition)
    public SpecialityDefinitionsList: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();

    @Type(() => ResUser.GetDoctorandTechnicianList_Class)
    public DoctorandTechnicianList: Array<ResUser.GetDoctorandTechnicianList_Class> = new Array<ResUser.GetDoctorandTechnicianList_Class>();

    @Type(() => HCExaminationComponent)
    public HCExaminationComponents: Array<HCExaminationComponent> = new Array<HCExaminationComponent>();

    public IsDisabled: boolean;
}

export class HCRequestReasonDetail {
    @Type(() => ReasonForExaminationDefinition)
    public ReasonForExaminationDefinition: ReasonForExaminationDefinition;
    @Type(() => HCHospitalUnit)
    public HospitalsUnits: Array<HCHospitalUnit> = new Array<HCHospitalUnit>();
}

export class HCHospitalUnit {
    @Type(() => HospitalsUnitsDefinitionGrid)
    public HospitalsUnit: HospitalsUnitsDefinitionGrid;
    @Type(() => ResUser)
    public ProcedureDoctor: ResUser;
    @Type(() => ResPoliclinic)
    public Policklinic: ResPoliclinic;
}

export class GetHCRequestReasonDetailsResponse {
    @Type(() => HCRequestReasonDetail)
    public requestReasonDetail: HCRequestReasonDetail = new HCRequestReasonDetail();
    @Type(() => HCReportTypeDefinition)
    public reportTypeDefinition: HCReportTypeDefinition = new HCReportTypeDefinition();
}

export class HCCommissionList{
    @Type(() => Guid)
    public ObjectID:Guid;
    public Name:string;
}


