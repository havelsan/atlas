//$1193EAB0
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class ConsultationService {
    public static async GetByMasterActionNQL(MASTERACTION: Guid): Promise<Array<Consultation.GetByMasterActionNQL_Class>> {
        let url: string = '/api/ConsultationService/GetByMasterActionNQL';
        let input = { "MASTERACTION": MASTERACTION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Consultation.GetByMasterActionNQL_Class>>(url, input);
        return result;
    }
    public static async GetAllConsultationsOfPatient(PATIENTOBJECTID: string): Promise<Array<Consultation>> {
        let url: string = '/api/ConsultationService/GetAllConsultationsOfPatient';
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Consultation>>(url, input);
        return result;
    }
    public static async GetConsultationReportNQL(OBJECTID: Guid): Promise<Array<Consultation.GetConsultationReportNQL_Class>> {
        let url: string = '/api/ConsultationService/GetConsultationReportNQL';
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Consultation.GetConsultationReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetAllConsultationsOfEpisode(EPISODEOBJECTID: string): Promise<Array<Consultation>> {
        let url: string = '/api/ConsultationService/GetAllConsultationsOfEpisode';
        let input = { "EPISODEOBJECTID": EPISODEOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Consultation>>(url, input);
        return result;
    }
}