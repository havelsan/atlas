//$8949F268
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';

export class ConsultationRequestViewModel {
    @Type(() => EpisodeAction)
    public _EpisodeAction: EpisodeAction = new EpisodeAction();
    @Type(() => EpisodeAction)
    public GrdConsAndPatientInterviewFormGridList: EpisodeAction[];
    @Type(() => Episode)
    public Episodes: Episode[];
    @Type(() => Patient)
    public Patients: Patient[];
    @Type(() => Guid)
    public _EpisodeActionObjectId: Guid;
    @Type(() => Boolean)
    public InPatientBedVisible: boolean;
    @Type(() => ConsReqOldConsultationInfo)
    public ConsultationsHistory: Array<ConsReqOldConsultationInfo> = new Array<ConsReqOldConsultationInfo>();
    @Type(() => ConsReqNewConsultationRequestInfo)
    public NewConsultationRequests: ConsReqNewConsultationRequestInfo[];
    public ResourceValue: ResSection;
    public RequestedUser: ResUser;
    public PatientSexCode: number;
}
export class ConsReqOldConsultationInfo {
    public consultationObjectID: Guid;
    @Type(() => Date)
    public consultationRequestDate: Date;
    public consultationRequesterDoctor: string;
    public consultationMasterResource: string;
    public consultationRequestedResource: string;
    public consultationRequestDescription: string;
    public consultationResult: string;
    public consultationReasonOfCancel: string;
    @Type(() => Date)
    public consultationProcessDate: Date;
    @Type(() => Date)
    public consultationProcessEndDate: Date;
    @Type(() => Guid)
    public consultationState: Guid;
    @Type(() => Number)
    public consultationStateStatus: number;
    public consultationStateDisplayText: string;
    @Type(() => ConsReqConsultationDiagnosis)
    public consultationDiagnosis: Array<ConsReqConsultationDiagnosis>;
    public consObjectDefName: string;
    public consReportDefName: string;
}
export class ConsReqNewConsultationRequestInfo {
    @Type(() => ResSection)
    public consultationMasterResource: ResSection;
    @Type(() => ResUser)
    public consultationProcedureDoctor: ResUser;
    @Type(() => Boolean)
    public consultationEmergency: boolean;
    @Type(() => Boolean)
    public consultationInBed: boolean;
}
export class ConsReqConsultationDiagnosis {
    public consultationDiagnose: string;
    public consultationFreeDiagnose: string;
}

export class ConsRequestResourceModel
{
    public ObjectID: Guid;
    public Name: string;
    public Qref: string;
}

export class ConsultationUserModel
{
    public ObjectID: Guid;
    public Name: string;
}