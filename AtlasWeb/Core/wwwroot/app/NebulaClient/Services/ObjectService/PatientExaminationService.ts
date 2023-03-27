//$FDA44FC0
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class PatientExaminationService {
    /*public static async Serialize(item: T): Promise<string> {
        let url: string = '/api/PatientExaminationService/Serialize';
        let input = { "item": item };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async Deserialize(xmlString: string): Promise<T> {
        let url: string = '/api/PatientExaminationService/Deserialize';
        let input = { "xmlString": xmlString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<T>(url, input);
        return result;
    }*/
    public static async OLAP_GetPatientExamination(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<PatientExamination.OLAP_GetPatientExamination_Class>> {
        let url: string = '/api/PatientExaminationService/OLAP_GetPatientExamination';
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.OLAP_GetPatientExamination_Class>>(url, input);
        return result;
    }
    public static async GetPatientExaminationByEpisode(EPISODE: string): Promise<Array<PatientExamination>> {
        let url: string = '/api/PatientExaminationService/GetPatientExaminationByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination>>(url, input);
        return result;
    }
    public static async GetPatientExaminationNQL(PATIENTEXAMINATION: string): Promise<Array<PatientExamination.GetPatientExaminationNQL_Class>> {
        let url: string = '/api/PatientExaminationService/GetPatientExaminationNQL';
        let input = { "PATIENTEXAMINATION": PATIENTEXAMINATION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.GetPatientExaminationNQL_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledPatientExamination(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<PatientExamination.OLAP_GetCancelledPatientExamination_Class>> {
        let url: string = '/api/PatientExaminationService/OLAP_GetCancelledPatientExamination';
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.OLAP_GetCancelledPatientExamination_Class>>(url, input);
        return result;
    }
    public static async GetUnCompletedExaminationForClosedEpisode(): Promise<Array<PatientExamination>> {
        let url: string = '/api/PatientExaminationService/GetUnCompletedExaminationForClosedEpisode';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination>>(url, input);
        return result;
    }
    public static async GetPatientExaminationByResponsibleDoctor(PROCEDUREDOCTOR: string, CURRENTDATE: Date): Promise<Array<PatientExamination>> {
        let url: string = '/api/PatientExaminationService/GetPatientExaminationByResponsibleDoctor';
        let input = { "PROCEDUREDOCTOR": PROCEDUREDOCTOR, "CURRENTDATE": CURRENTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination>>(url, input);
        return result;
    }
    public static async GetPatientAbsentNQL(TARIH: Date, MASTERRESOURCE: Guid): Promise<Array<PatientExamination.GetPatientAbsentNQL_Class>> {
        let url: string = '/api/PatientExaminationService/GetPatientAbsentNQL';
        let input = { "TARIH": TARIH, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.GetPatientAbsentNQL_Class>>(url, input);
        return result;
    }
    public static async GetPatientExaminationByMasterResource(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCE: Guid): Promise<Array<PatientExamination.GetPatientExaminationByMasterResource_Class>> {
        let url: string = '/api/PatientExaminationService/GetPatientExaminationByMasterResource';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.GetPatientExaminationByMasterResource_Class>>(url, input);
        return result;
    }
    public static async InactiveExaminationsNQL(TARIH: Date, STATE: Guid): Promise<Array<PatientExamination>> {
        let url: string = '/api/PatientExaminationService/InactiveExaminationsNQL';
        let input = { "TARIH": TARIH, "STATE": STATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination>>(url, input);
        return result;
    }
    public static async GetPatientExamiationsForBeatenAndAlcohol(STARTDATE: Date, ENDDATE: Date): Promise<Array<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class>> {
        let url: string = '/api/PatientExaminationService/GetPatientExamiationsForBeatenAndAlcohol';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class>>(url, input);
        return result;
    }
    public static async GetPEByPatientAndAdmissionResource(PATIENT: Guid, ADMISSIONRESOURCE: string): Promise<Array<PatientExamination>> {
        let url: string = '/api/PatientExaminationService/GetPEByPatientAndAdmissionResource';
        let input = { "PATIENT": PATIENT, "ADMISSIONRESOURCE": ADMISSIONRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination>>(url, input);
        return result;
    }
    public static async GetPatientExaminationByObjectIDs(OBJECTIDS: Guid): Promise<Array<PatientExamination.GetPatientExaminationByObjectIDs_Class>> {
        let url: string = '/api/PatientExaminationService/GetPatientExaminationByObjectIDs';
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.GetPatientExaminationByObjectIDs_Class>>(url, input);
        return result;
    }
    public static async GetPANoDiagnose(STARTDATE: Date, ENDDATE: Date): Promise<Array<PatientExamination.GetPANoDiagnose_Class>> {
        let url: string = '/api/PatientExaminationService/GetPANoDiagnose';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.GetPANoDiagnose_Class>>(url, input);
        return result;
    }
    public static async GetPEByPatientAndMainSpecialty(PATIENT: Guid, MAINSPECIALITY: Guid): Promise<Array<PatientExamination>> {
        let url: string = '/api/PatientExaminationService/GetPEByPatientAndMainSpecialty';
        let input = { "PATIENT": PATIENT, "MAINSPECIALITY": MAINSPECIALITY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination>>(url, input);
        return result;
    }
    public static async GetDailyOpenPatientExaminations(DATE: Date): Promise<Array<PatientExamination>> {
        let url: string = '/api/PatientExaminationService/GetDailyOpenPatientExaminations';
        let input = { "DATE": DATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination>>(url, input);
        return result;
    }
    public static async GetDoctorsWorkListReportNQL(STARTDATE: Date, ENDDATE: Date, MINDATE: Date, injectionSQL: string): Promise<Array<PatientExamination.GetDoctorsWorkListReportNQL_Class>> {
        let url: string = '/api/PatientExaminationService/GetDoctorsWorkListReportNQL';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MINDATE": MINDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientExamination.GetDoctorsWorkListReportNQL_Class>>(url, input);
        return result;
    }

    public static async CheckPatientSubEpisodeDiagnosisExistence(SubEpisodeID: Guid): Promise<boolean> {
        let url: string = '/api/PatientExaminationService/CheckPatientSubEpisodeDiagnosisExistence';
        let input = { "SubEpisodeID": SubEpisodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }

}