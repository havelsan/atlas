
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { BasePatientSearchResultModel, BasePatientInfoListsModel, BasePatientInfoDet } from "../../PatientSearch/PatientSearchFormViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class PatientAdmissionSearchFormViewModel extends BaseViewModel {

    public SearchText: string = "";
    @Type(() => PatientInfoListsModel)
    public PatientInfoLists: PatientInfoListsModel;
    @Type(() => PatientSearchResultModel)
    public PatientSearchResult: PatientSearchResultModel;
    @Type(() => Guid)
    public SelectedPatientObjectID: Guid;
    //public SelectedAdmission : PatientAdmissionInfoDet;
    @Type(() => PatientInfoDet)
    public SelectedPatient: PatientInfoDet;


    constructor() {
        super();
        this.PatientSearchResult = new PatientSearchResultModel();
        this.PatientInfoLists = new PatientInfoListsModel();
        //this.SelectedAdmission = new PatientAdmissionInfoDet();
        this.SelectedPatient = new PatientInfoDet();

    }
}

export class PatientSearchResultModel extends BasePatientSearchResultModel {


    public PatientAdmissionInfo: PatientAdmission;

    constructor() {
        super();
    }
}

export class PatientInfoListsModel extends BasePatientInfoListsModel {


    public PatientAdmissionList: PatientAdmissionInfoDet[];
     //public PatientInfo: Patient;
     //public AppointmentInfo: Appointment;
     //public AdmissionSpecOrResOfCurrentDayEpisodes: string = "";
     //public PatientAdmissionInfo: PatientAdmission;

    constructor() {
        super();
        //super.PatientList = new Array<PatientInfoDet>();
        this.PatientAdmissionList = new Array<PatientAdmissionInfoDet>();
    }
}

export class PatientInfoDet extends BasePatientInfoDet
{

}

export class PatientAdmissionInfoDet
{
     public ObjectID: Guid;
     public ActionDate: string;
     public Info: string;
}
// class AppointmentInfo
//{
//    public  ObjectID: Guid;
//}