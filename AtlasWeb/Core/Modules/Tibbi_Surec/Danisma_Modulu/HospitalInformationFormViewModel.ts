//$5B0C6BBE
import { HospitalInformation, ResSection, UserTypeEnum, UserTitleEnum, ResDepartment, SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PatientVisitor } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

export class HospitalInformationFormViewModel extends BaseViewModel {
    public _HospitalInformation: HospitalInformation = new HospitalInformation();
    public PatientVisitors: Array<PatientVisitor> = new Array<PatientVisitor>();
    public Patients: Array<Patient> = new Array<Patient>();

    /// Defined By mt
    public _PersonnelSearchModel: PersonnelSearchModel;
    public _LocationSearchModel: LocationSearchModel;
    public _ShiftSearchModel: ShiftSearchModel;
    public _AppointmentSearchModel: AppointmentSearchModel;
    public _ExaminationSearchModel: ExaminationSearchModel;
    @Type(() => PatientVisitor)
    public _RecordPatientVisitor: PatientVisitor;
    @Type(() => ResSection)
    public ClinicList: Array<ResSection> = new Array <ResSection>();


}



export class PersonnelSearchModel {

    public Surname: string;
    public Name: string;
    public Mission: UserTypeEnum;
    public Title: UserTitleEnum;
    @Type(() => SpecialityDefinition)
    public Department: SpecialityDefinition;
    @Type(() => ResSection)
    public Section: ResSection;
    public DateOfJoin: Date;
    public DateOfLeave: Date;


}

export class VisitorSearchModel {

    public firstDate: Date;
    public secondDate: Date;
    constructor() {

    }
}

export class LocationSearchModel {

    public Building: any;
    public Policlinic: any;
    constructor() {

    }
}

export class AppointmentSearchModel {

    public ObjectID: string;
    public ObjectDefName: string;
    public UnicRefNo: string;
    public PassportNo: string;
    public Surname: string;
    public Name: string;
    public Doctor: string;
    public AdmissionNo: number;
    public MotherName: string;
    public FatherName: string;
    public BirthCity: string;
    public BirthDate: Date;
    public DateFirst: Date;
    public DateSecond: Date;
    constructor() {
        let dateNow: Date = new Date();
        this.DateFirst = Convert.ToDateTime(Convert.ToDateTime(dateNow).ToShortDateString() + " 00:00:00");
        this.DateSecond = Convert.ToDateTime(Convert.ToDateTime(dateNow).ToShortDateString() + " 23:59:59");
    }
}

export class ShiftSearchModel {

    public ObjectID: string;
    public ObjectDefName: string;
    public Surname: string;
    public Name: string;
    public Mission: string;
    public Title: string;
    public Department: string;
    public Section: string;

}

export class ExaminationSearchModel {

    public ResourceID: Guid;
    constructor() {

    }
}

export class ExaminationSearchingResultModel {

    public AdmissionQueueNo: string;
    public PatientNameSurname: string;
    public KabulNo: string;
    public UniqueRefno: string;
    public StateName: string;
    public DoctorName: string;
    public ExaminationProtocolNo: string;
    public ExpectedExaminationTime: string;

}

