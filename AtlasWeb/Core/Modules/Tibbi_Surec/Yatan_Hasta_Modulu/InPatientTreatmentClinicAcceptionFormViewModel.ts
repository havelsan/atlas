//$9D7760C5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InPatientTreatmentClinicApplication, InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { BaseInpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { InpatientAppointmentInfo } from "../Randevu_Modulu/GivenInpatientAppointmentFormViewModel";
import { Guid } from "../../../wwwroot/app/NebulaClient/Mscorlib/Guid";
export class InPatientTreatmentClinicAcceptionFormViewModel extends BaseViewModel {
    @Type(() => InPatientTreatmentClinicApplication)
    public _InPatientTreatmentClinicApplication: InPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication();
    @Type(() => BaseInpatientAdmission)
    public BaseInpatientAdmissions: Array<BaseInpatientAdmission> = new Array<BaseInpatientAdmission>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResRoom)
    public ResRooms: Array<ResRoom> = new Array<ResRoom>();
    @Type(() => ResWard)
    public ResWards: Array<ResWard> = new Array<ResWard>();
    @Type(() => ResRoomGroup)
    public ResRoomGroups: Array<ResRoomGroup> = new Array<ResRoomGroup>();
    @Type(() => ResBed)
    public ResBeds: Array<ResBed> = new Array<ResBed>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();

    //Pre Script i�in
    public QuarantineProtocolNo: string;
    @Type(() => Boolean)
    public ShowTurnReserveToUsed: boolean;
    @Type(() => Boolean)
    public IsPhysicalStateClinicReadOnly: boolean;
    public PatientSex: String;
    @Type(() => Date)
    public RecTime: Date;
    @Type(() => Date)
    public EpisodeOpeningDate: Date;

    public InpatientAcceptionMessage: string;

    public IsPreAcception: boolean;
    @Type(() => InpatientAdmission)
    public InpatientAdmissionList: Array<InpatientAdmission> = new Array<InpatientAdmission>();

    @Type(() => InpatientAppointmentInfo)
    public _InpatientAppointmentInfo: InpatientAppointmentInfo;

    public AppointmentId: string;

    public HasInpatientAppGiveRole: boolean;
    public HasInpatientAppShowRole: boolean;
    public IsClinicAllowAppointment: boolean;
    public HasDepositMaterial: boolean = false;
}


