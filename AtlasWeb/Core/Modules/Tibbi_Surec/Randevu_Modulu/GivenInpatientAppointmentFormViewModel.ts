//$311110F5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientAppointment } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";
import { Guid } from "../../../wwwroot/app/NebulaClient/Mscorlib/Guid";

export class GivenInpatientAppointmentFormViewModel extends BaseViewModel {
    @Type(() => InpatientAppointment)
    public _InpatientAppointment: InpatientAppointment = new InpatientAppointment();
    
    @Type(() => InpatientAppointmentInfo)
    public InpatientAppointmentList: Array<InpatientAppointmentInfo> = new Array<InpatientAppointmentInfo>();

    @Type(() => InpatientAppointmentInfo)
    public selectedRowKeysResultList: Array<InpatientAppointmentInfo> = new Array<InpatientAppointmentInfo>();
}

export class InpatientAppointmentInfo {
    @Type(() => Guid)
    public ObjectId: Guid;

    public ObjectDefName: string;
    public ClinicName: string;
    public DoctorName: string;

    @Type(() => Date)
    public AppDate: Date;
}