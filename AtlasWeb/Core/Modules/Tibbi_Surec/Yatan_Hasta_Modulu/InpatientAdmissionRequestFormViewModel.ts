//$F20606B5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResBuilding } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class InpatientAdmissionRequestFormViewModel extends BaseViewModel {
    @Type(() => InpatientAdmission)
    public _InpatientAdmission: InpatientAdmission = new InpatientAdmission();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResClinic)
    public ResClinics: Array<ResClinic> = new Array<ResClinic>();
    @Type(() => ResBed)
    public ResBeds: Array<ResBed> = new Array<ResBed>();
    @Type(() => ResRoomGroup)
    public ResRoomGroups: Array<ResRoomGroup> = new Array<ResRoomGroup>();
    @Type(() => ResRoom)
    public ResRooms: Array<ResRoom> = new Array<ResRoom>();
    @Type(() => ResWard)
    public ResWards: Array<ResWard> = new Array<ResWard>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => InpatientReasonDefinition)
    public InpatientReasonDefinitions: Array<InpatientReasonDefinition> = new Array<InpatientReasonDefinition>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => ResRoom)
    public RoomOfBed: ResRoom = new ResRoom();
    @Type(() => ResRoomGroup)
    public RoomGroupOfRoom: ResRoomGroup = new ResRoomGroup();
    @Type(() => ResBuilding)
    public DefaultBulding: ResBuilding;
    public TreatmentClinicFilter: string;
    public PatientSex: String;
}
