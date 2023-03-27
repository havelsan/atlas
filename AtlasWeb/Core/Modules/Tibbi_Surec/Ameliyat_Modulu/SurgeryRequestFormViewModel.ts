//$EC73984E
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Surgery, SurgeryAppointment, KvcRiskScore } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { MainSurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "../../../wwwroot/app/NebulaClient/Mscorlib/Guid";

export class SurgeryRequestFormViewModel extends BaseViewModel {
    @Type(() => Surgery)
    public _Surgery: Surgery = new Surgery();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => MainSurgeryProcedure)
    public GridMainSurgeryProceduresGridList: Array<MainSurgeryProcedure> = new Array<MainSurgeryProcedure>();
    @Type(() => ResSurgeryDesk)
    public ResSurgeryDesks: Array<ResSurgeryDesk> = new Array<ResSurgeryDesk>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSurgeryRoom)
    public ResSurgeryRooms: Array<ResSurgeryRoom> = new Array<ResSurgeryRoom>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();

    //pre
    @Type(() => Boolean)
    public HasOtherSurgery: Boolean;
    @Type(() => Number)
    public ConsLimitIfHasAnesthesiaConsultation: number;
    public AnesthesiaAndReanimationMasterResourceFilterString: string;
    // post
    @Type(() => ResSection)
    public AnesthesiaAndReanimationMasterResource: ResSection;

    public KvcScoreId: string;

    @Type(() => SurgeryAppointmentCarrierClass)
    public PatientSurgeryAppointments: Array<SurgeryAppointmentCarrierClass> = new Array<SurgeryAppointmentCarrierClass>();

    @Type(() => SurgeryAppointment)
    public LinkedSurgeryAppointment: SurgeryAppointment;


    @Type(() => KvcRiskScore)
    public KvcRiskScore: KvcRiskScore;
    public KvcTotalRisk: string;
}


export class SurgeryAppointmentCarrierClass {
    public AppointmentObjectID: Guid;
    public PlannedStartDate: Date;
    public ProcedureDoctor: string;
}