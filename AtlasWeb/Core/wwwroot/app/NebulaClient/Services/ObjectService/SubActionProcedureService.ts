//$2757FC25
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';

export class SubActionProcedureService {
    public static async GetMyNewAppointments(objectID: Guid): Promise<Array<Appointment>> {
        let url: string = '/api/SubActionProcedureService/GetMyNewAppointments';
        let input = { "objectID": objectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, Appointment);
        return result;
    }
    public static async GetMyCompletedAppointments(objectID: Guid): Promise<Array<Appointment>> {
        let url: string = '/api/SubActionProcedureService/GetMyCompletedAppointments';
        let input = { "objectID": objectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, Appointment);
        return result;
    }
    public static async GetMyCancelledAppointments(objectID: Guid): Promise<Array<Appointment>> {
        let url: string = '/api/SubActionProcedureService/GetMyCancelledAppointments';
        let input = { "objectID": objectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, Appointment);
        return result;
    }
    public static async MyNotApprovedAppointments(objectID: Guid): Promise<Array<Appointment>> {
        let url: string = '/api/SubActionProcedureService/MyNotApprovedAppointments';
        let input = { "objectID": objectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, Appointment);
        return result;
    }
    public static async GetFullAppointmentDescription(subactionProcedure: SubActionProcedure): Promise<string> {
        let url: string = '/api/SubActionProcedureService/GetFullAppointmentDescription';
        let input = { "subactionProcedure": subactionProcedure };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetAllConsultationProceduresOfPatient(PATIENT: Guid): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetAllConsultationProceduresOfPatient';
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetAllConsultationProcOfEpisode(EPISODEOBJECTID: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetAllConsultationProcOfEpisode';
        let input = { "EPISODEOBJECTID": EPISODEOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetAllConsultationProcOfPatient(PATIENTOBJECTID: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetAllConsultationProcOfPatient';
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetAllConsultationProcOfSubEpisode(EPISODE: string, SUBEPISODE: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetAllConsultationProcOfSubEpisode';
        let input = { "EPISODE": EPISODE, "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetByObjectID(PARAMOBJECTID: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetByObjectID';
        let input = { "PARAMOBJECTID": PARAMOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetSubActionsByDate(PARAMSTARTDATE: Date, PARAMENDDATE: Date): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetSubActionsByDate';
        let input = { "PARAMSTARTDATE": PARAMSTARTDATE, "PARAMENDDATE": PARAMENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetTestsByPatient(PATIENTID: string, MINDATE: Date): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetTestsByPatient';
        let input = { "PATIENTID": PATIENTID, "MINDATE": MINDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetTestsByPatientByTestByDate(PATIENTID: string, STARTDATE: Date, ENDDATE: Date, TESTID: string, OBJECTDEFNAME: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetTestsByPatientByTestByDate';
        let input = { "PATIENTID": PATIENTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "TESTID": TESTID, "OBJECTDEFNAME": OBJECTDEFNAME };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetSubActionProcedureByPObject(POBJECT: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetSubActionProcedureByPObject';
        let input = { "POBJECT": POBJECT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetExaminationTestListNQL(OBJECTIDS: Array<string>): Promise<Array<SubActionProcedure.GetExaminationTestListNQL_Class>> {
        let url: string = '/api/SubActionProcedureService/GetExaminationTestListNQL';
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.GetExaminationTestListNQL_Class);
        return result;
    }
    public static async GetTestsByEpisode(OBJECTDEFNAME: string, TESTID: string, EPISODE: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetTestsByEpisode';
        let input = { "OBJECTDEFNAME": OBJECTDEFNAME, "TESTID": TESTID, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetAllTestsByEpisode(EPISODE: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetAllTestsByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetByEpisodeAndSEP(EPISODE: Guid, SEP: Guid, injectionSQL: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetByEpisodeAndSEP';
        let input = { "EPISODE": EPISODE, "SEP": SEP, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async OLAP_SGKStatisticQuery1_SECount(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubActionProcedure.OLAP_SGKStatisticQuery1_SECount_Class>> {
        let url: string = '/api/SubActionProcedureService/OLAP_SGKStatisticQuery1_SECount';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.OLAP_SGKStatisticQuery1_SECount_Class);
        return result;
    }
    public static async OLAP_SGKStatisticQuery1_PatientCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount_Class>> {
        let url: string = '/api/SubActionProcedureService/OLAP_SGKStatisticQuery1_PatientCount';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount_Class);
        return result;
    }
    public static async OLAP_SGKStatisticQuery2_PatientCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount_Class>> {
        let url: string = '/api/SubActionProcedureService/OLAP_SGKStatisticQuery2_PatientCount';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount_Class);
        return result;
    }
    public static async GetByEpisode(EPISODE: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async OLAP_GetDentalTreatments(EID: string): Promise<Array<SubActionProcedure.OLAP_GetDentalTreatments_Class>> {
        let url: string = '/api/SubActionProcedureService/OLAP_GetDentalTreatments';
        let input = { "EID": EID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.OLAP_GetDentalTreatments_Class);
        return result;
    }
    public static async OLAP_SGKStatisticQuery2_SECount(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubActionProcedure.OLAP_SGKStatisticQuery2_SECount_Class>> {
        let url: string = '/api/SubActionProcedureService/OLAP_SGKStatisticQuery2_SECount';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.OLAP_SGKStatisticQuery2_SECount_Class);
        return result;
    }
    public static async GetByEpisodeAndMasterPackage(EPISODE: string, MASTERPACKAGESP: string): Promise<Array<SubActionProcedure>> {
        let url: string = '/api/SubActionProcedureService/GetByEpisodeAndMasterPackage';
        let input = { "EPISODE": EPISODE, "MASTERPACKAGESP": MASTERPACKAGESP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure);
        return result;
    }
    public static async GetProcedureNameAndCode(OBJECTID: Guid): Promise<Array<SubActionProcedure.GetProcedureNameAndCode_Class>> {
        let url: string = '/api/SubActionProcedureService/GetProcedureNameAndCode';
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.GetProcedureNameAndCode_Class);
        return result;
    }
    public static async GetOldInfoForRequestedProcedures(PATIENT: Guid): Promise<Array<SubActionProcedure.GetOldInfoForRequestedProcedures_Class>> {
        let url: string = '/api/SubActionProcedureService/GetOldInfoForRequestedProcedures';
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.GetOldInfoForRequestedProcedures_Class);
        return result;
    }
    public static async GetOldInfoCountForRequestedProcedures(PATIENT: Guid): Promise<Array<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class>> {
        let url: string = '/api/SubActionProcedureService/GetOldInfoCountForRequestedProcedures';
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class);
        return result;
    }
    public static async GetSubActionProcedureByTimeInterval(PATIENTID: Guid, STARTDATE: Date, ENDDATE: Date): Promise<Array<SubActionProcedure.GetSubActionProcedureByTimeInterval_Class>> {
        let url: string = '/api/SubActionProcedureService/GetSubActionProcedureByTimeInterval';
        let input = { "PATIENTID": PATIENTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.GetSubActionProcedureByTimeInterval_Class);
        return result;
    }
    public static async GetRequestedProceduresBySubEpisode(SUBEPISODE: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class>> {
        let url: string = '/api/SubActionProcedureService/GetRequestedProceduresBySubEpisode';
        let input = { "SUBEPISODE": SUBEPISODE, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input, SubActionProcedure.GetRequestedProceduresBySubEpisode_Class);
        return result;
    }
}