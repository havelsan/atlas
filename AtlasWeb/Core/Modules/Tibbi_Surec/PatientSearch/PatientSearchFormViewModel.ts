
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class PatientSearchFormViewModel extends BaseViewModel {

    public SearchText: string = "";
    @Type(() => BasePatientInfoListsModel)
    public PatientInfoLists: BasePatientInfoListsModel;
    @Type(() => BasePatientSearchResultModel)
    public PatientSearchResult: BasePatientSearchResultModel;
    @Type(() => Guid)
    public SelectedPatientObjectID: Guid;
    @Type(() => BasePatientInfoDet)
    public SelectedPatient: BasePatientInfoDet;


    constructor() {
        super();
        this.PatientSearchResult = new BasePatientSearchResultModel();
        this.PatientInfoLists = new BasePatientInfoListsModel();
        this.SelectedPatient = new BasePatientInfoDet();

    }
}

export class BasePatientSearchResultModel {


    @Type(() => Patient)
    public PatientInfo: Patient;
    @Type(() => Appointment)
    public AppointmentInfo: Appointment;
   // public PatientAdmissionInfo: PatientAdmission;

    public PatientIDandFullName: string;
    public PatientRefNo: string;
    public PatientPhoneNumber: string;

    constructor() {
    }
}

export class BasePatientInfoListsModel {

    @Type(() => BasePatientInfoDet)
    public PatientList: BasePatientInfoDet[];
   // public PatientAdmissionList: BasePatientAdmissionInfoDet[];
     //public PatientInfo: Patient;
     //public AppointmentInfo: Appointment;
     //public AdmissionSpecOrResOfCurrentDayEpisodes: string = "";
     //public PatientAdmissionInfo: PatientAdmission;

    constructor() {
        this.PatientList = new Array<BasePatientInfoDet>();
       // this.PatientAdmissionList = new Array<BasePatientAdmissionInfoDet>();
    }
}

 export class BasePatientInfoDet
 {
     @Type(() => Guid)
    public ObjectID: Guid ;
    public NameSurname: string;
    public Info: string;

}
// export class PatientAdmissionInfoDet
//{
//     public ObjectID: Guid;
//     public ActionDate: string;
//     public Info: string;
//}
// class AppointmentInfo
//{
//    public  ObjectID: Guid;
//}
