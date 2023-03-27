//$1E6CECB1
import { SurgeryAppointment, Patient } from "NebulaClient/Model/AtlasClientModel";
import { SurgeryAppointmentProc } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ResSurgeryRoom } from "NebulaClient/Model/AtlasClientModel";
import { ResSurgeryDesk } from "NebulaClient/Model/AtlasClientModel";
import { BaseViewModel } from "app/NebulaClient/Model/BaseViewModel";
import { Type } from "app/NebulaClient/ClassTransformer";

export class SurgeryAppointmentFormViewModel extends BaseViewModel {
    @Type(()=>SurgeryAppointment)
    public _SurgeryAppointment: SurgeryAppointment = new SurgeryAppointment();
    @Type(()=>Patient)
    public PatientObject: Patient = new Patient();
    @Type(()=>SurgeryAppointmentProc)
    public SurgeryAppointmentProceduresGridList: Array<SurgeryAppointmentProc> = new Array<SurgeryAppointmentProc>();
    @Type(()=>ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(()=>ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(()=>ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(()=>ResSurgeryRoom)
    public ResSurgeryRooms: Array<ResSurgeryRoom> = new Array<ResSurgeryRoom>();
    @Type(()=>ResSurgeryDesk)
    public ResSurgeryDesks: Array<ResSurgeryDesk> = new Array<ResSurgeryDesk>();
}
