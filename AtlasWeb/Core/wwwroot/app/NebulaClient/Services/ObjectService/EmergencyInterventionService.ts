//$A9676AF5
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class EmergencyInterventionService {
    public static async GetByEpisode(PARAMEPISODE: string): Promise<Array<EmergencyIntervention>> {
        let url: string = "/api/EmergencyInterventionService/GetByEpisode";
        let input = { "PARAMEPISODE": PARAMEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EmergencyIntervention>>(url, input);
        return result;
    }
    public static async OLAP_GetEmergencyObservation(EPISODE: string): Promise<Array<EmergencyIntervention.OLAP_GetEmergencyObservation_Class>> {
        let url: string = "/api/EmergencyInterventionService/OLAP_GetEmergencyObservation";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EmergencyIntervention.OLAP_GetEmergencyObservation_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeInfo(PARAMEPISODE: string): Promise<Array<EmergencyIntervention.GetByEpisodeInfo_Class>> {
        let url: string = "/api/EmergencyInterventionService/GetByEpisodeInfo";
        let input = { "PARAMEPISODE": PARAMEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EmergencyIntervention.GetByEpisodeInfo_Class>>(url, input);
        return result;
    }
    public static async GetEmergencyInterventionsByDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<EmergencyIntervention>> {
        let url: string = "/api/EmergencyInterventionService/GetEmergencyInterventionsByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EmergencyIntervention>>(url, input);
        return result;
    }
    public static async GetEpisodeAndPatientInfoAccordingToDiagnosis(STARTDATE: Date, ENDDATE: Date, DIAGNOSIS: Array<string>): Promise<Array<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class>> {
        let url: string = "/api/EmergencyInterventionService/GetEpisodeAndPatientInfoAccordingToDiagnosis";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "DIAGNOSIS": DIAGNOSIS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeAndPatientInfo(PARAMEPISPODE: string): Promise<Array<EmergencyIntervention.GetEpisodeAndPatientInfo_Class>> {
        let url: string = "/api/EmergencyInterventionService/GetEpisodeAndPatientInfo";
        let input = { "PARAMEPISPODE": PARAMEPISPODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EmergencyIntervention.GetEpisodeAndPatientInfo_Class>>(url, input);
        return result;
    }
    public static async GetEmergencyInterventionsByDateForReport(STARTDATE: Date, ENDDATE: Date): Promise<Array<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class>> {
        let url: string = "/api/EmergencyInterventionService/GetEmergencyInterventionsByDateForReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class>>(url, input);
        return result;
    }
}