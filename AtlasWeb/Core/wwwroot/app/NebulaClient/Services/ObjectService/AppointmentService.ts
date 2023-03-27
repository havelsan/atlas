//$2945140D
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class AppointmentService {
    public static async GetAppointmentListReportNQL(OBJECTIDS: Array<string>): Promise<Array<Appointment.GetAppointmentListReportNQL_Class>> {
        let url: string = "/api/AppointmentService/GetAppointmentListReportNQL";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetAppointmentListReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetByPatientAndAppDate(STARTTIME: Date, ENDTIME: Date, PATIENT: string, APPDATE: Date, injectionSQL: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByPatientAndAppDate";
        let input = { "STARTTIME": STARTTIME, "ENDTIME": ENDTIME, "PATIENT": PATIENT, "APPDATE": APPDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetBySubActionProcedureAndState(SUBACTIONPROCEDURE: string, STATE: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetBySubActionProcedureAndState";
        let input = { "SUBACTIONPROCEDURE": SUBACTIONPROCEDURE, "STATE": STATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetByStartTimeAndResource(APPDATE: Date, STARTTIME: Date, RESOURCE: string, ENDTIME: Date, injectionSQL: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByStartTimeAndResource";
        let input = { "APPDATE": APPDATE, "STARTTIME": STARTTIME, "RESOURCE": RESOURCE, "ENDTIME": ENDTIME, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetByInjection(injectionSQL: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetByActionAndState(ACTION: string, STATE: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByActionAndState";
        let input = { "ACTION": ACTION, "STATE": STATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetByPatientByDateByResource(PATIENT: string, APPDATE: Date, MASTERRESOURCE: string, RESOURCE: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByPatientByDateByResource";
        let input = { "PATIENT": PATIENT, "APPDATE": APPDATE, "MASTERRESOURCE": MASTERRESOURCE, "RESOURCE": RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetByAppDateAndResource(STARTTIME: Date, ENDTIME: Date, RESOURCE: string, injectionSQL: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByAppDateAndResource";
        let input = { "STARTTIME": STARTTIME, "ENDTIME": ENDTIME, "RESOURCE": RESOURCE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetByAppDate(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByAppDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetAppointmentByPatientExaminationID(PATIENTEXAMINATIONOBJECTID: string): Promise<Array<Appointment.GetAppointmentByPatientExaminationID_Class>> {
        let url: string = "/api/AppointmentService/GetAppointmentByPatientExaminationID";
        let input = { "PATIENTEXAMINATIONOBJECTID": PATIENTEXAMINATIONOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetAppointmentByPatientExaminationID_Class>>(url, input);
        return result;
    }
    public static async GetAppointmentsForAppViewer(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCEOBJECTIDS: Array<string>): Promise<Array<Appointment.GetAppointmentsForAppViewer_Class>> {
        let url: string = "/api/AppointmentService/GetAppointmentsForAppViewer";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCEOBJECTIDS": MASTERRESOURCEOBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetAppointmentsForAppViewer_Class>>(url, input);
        return result;
    }
    public static async GetPatientAppointmentsByDate(PATIENT: Guid, APPSTARTDATE: Date, APPENDDATE: Date): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetPatientAppointmentsByDate";
        let input = { "PATIENT": PATIENT, "APPSTARTDATE": APPSTARTDATE, "APPENDDATE": APPENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetMinNumaratorAppointmentResource(MASTERRESOURCE: Guid, STARTDATE: Date, ENDDATE: Date): Promise<Array<Appointment.GetMinNumaratorAppointmentResource_Class>> {
        let url: string = "/api/AppointmentService/GetMinNumaratorAppointmentResource";
        let input = { "MASTERRESOURCE": MASTERRESOURCE, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetMinNumaratorAppointmentResource_Class>>(url, input);
        return result;
    }
    public static async GetAppointmentByResourceAndPatient(STARTTIME: Date, ENDTIME: Date, RESOURCE: Guid, PATIENT: Guid, MASTERRESOURCE: Guid): Promise<Array<Appointment.GetAppointmentByResourceAndPatient_Class>> {
        let url: string = "/api/AppointmentService/GetAppointmentByResourceAndPatient";
        let input = { "STARTTIME": STARTTIME, "ENDTIME": ENDTIME, "RESOURCE": RESOURCE, "PATIENT": PATIENT, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetAppointmentByResourceAndPatient_Class>>(url, input);
        return result;
    }
    public static async GetByMHRSRandevuHrn(MHRSRANDEVUHRN: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByMHRSRandevuHrn";
        let input = { "MHRSRANDEVUHRN": MHRSRANDEVUHRN };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetPatientComeToMHRSAppointment(STARTTIME: Date): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetPatientComeToMHRSAppointment";
        let input = { "STARTTIME": STARTTIME };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetBySchedule(SCHEDULE: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetBySchedule";
        let input = { "SCHEDULE": SCHEDULE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetMHRSAppointment(STARTTIME: Date, ENDTIME: Date, RESOURCE: Guid, MASTERRESOURCE: Guid): Promise<Array<Appointment.GetMHRSAppointment_Class>> {
        let url: string = "/api/AppointmentService/GetMHRSAppointment";
        let input = { "STARTTIME": STARTTIME, "ENDTIME": ENDTIME, "RESOURCE": RESOURCE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetMHRSAppointment_Class>>(url, input);
        return result;
    }
    public static async GetBreakAppointmentListReportNQL(OBJECTIDS: Array<string>): Promise<Array<Appointment.GetBreakAppointmentListReportNQL_Class>> {
        let url: string = "/api/AppointmentService/GetBreakAppointmentListReportNQL";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetBreakAppointmentListReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetByFirstAvailableAppoinmentResource(STARTTIME: Date, RESOURCE: string, ENDTIME: Date, injectionSQL: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByFirstAvailableAppoinmentResource";
        let input = { "STARTTIME": STARTTIME, "RESOURCE": RESOURCE, "ENDTIME": ENDTIME, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetAppointmentBySchedule(SCHEDULE: Guid): Promise<Array<Appointment.GetAppointmentBySchedule_Class>> {
        let url: string = "/api/AppointmentService/GetAppointmentBySchedule";
        let input = { "SCHEDULE": SCHEDULE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.GetAppointmentBySchedule_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeActionAndState(EPISODEACTION: string, STATE: string): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetByEpisodeActionAndState";
        let input = { "EPISODEACTION": EPISODEACTION, "STATE": STATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async VEM_RANDEVU(): Promise<Array<Appointment.VEM_RANDEVU_Class>> {
        let url: string = "/api/AppointmentService/VEM_RANDEVU";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment.VEM_RANDEVU_Class>>(url, input);
        return result;
    }
    public static async GetPatientComeToMHRSApp(): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetPatientComeToMHRSApp";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetPatientAdmissionAppointmentsByDate(PATIENT: Guid, APPSTARTDATE: Date, APPENDDATE: Date): Promise<Array<Appointment>> {
        let url: string = "/api/AppointmentService/GetPatientAdmissionAppointmentsByDate";
        let input = { "PATIENT": PATIENT, "APPSTARTDATE": APPSTARTDATE, "APPENDDATE": APPENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
}