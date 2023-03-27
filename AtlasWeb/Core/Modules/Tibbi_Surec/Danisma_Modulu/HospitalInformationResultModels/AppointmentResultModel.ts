import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { DateTime } from "app/NebulaClient/System/Time/DateTime";

export class AppointmentResultModel {

    public ObjectID: Guid;
    public UniqueRefNo: String;
    public MotherName: String;
    public FatherName: String;
    public PatientFullName: String;
    public AppointmentObjectFullName: String;
    public AppointmentDate: DateTime;
    public AppointmentSection: String;
    public AppointmentSectionPhone: String;
    public AppointmentSectionLocation: String;
    public AppointmentDefinition: String;
    public AppointmentType: AppointmentTypeEnum;

}

export enum AppointmentTypeEnum {

    Test = 0,
    Examination = 1,
    Consultation = 2,
    Intervention = 3,
    ControlExamination = 4,
    Surgery = 5

}