//$F10E1007
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class InPatientPhysicianApplicationService {
    public static async GetActiveInPatientPhysicianApplication(episodeID: Guid): Promise<InPatientPhysicianApplication> {
        let url: string = '/api/InPatientPhysicianApplicationService/GetActiveInPatientPhysicianApplication';
        let input = { "episodeID": episodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<InPatientPhysicianApplication>(url, input);
        return result;
    }
    public static async GetUnCompletedEmergencyPhyAppForClosedEpisodes(): Promise<Array<InPatientPhysicianApplication>> {
        let url: string = '/api/InPatientPhysicianApplicationService/GetUnCompletedEmergencyPhyAppForClosedEpisodes';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientPhysicianApplication>>(url, input);
        return result;
    }
    public static async GetOldInfoForClinic(PATIENT: Guid): Promise<Array<InPatientPhysicianApplication.GetOldInfoForClinic_Class>> {
        let url: string = '/api/InPatientPhysicianApplicationService/GetOldInfoForClinic';
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientPhysicianApplication.GetOldInfoForClinic_Class>>(url, input);
        return result;
    }
    public static async GetActiveInpatientPhAppByEpisode(EPISODEPARAM: Guid): Promise<Array<InPatientPhysicianApplication>> {
        let url: string = '/api/InPatientPhysicianApplicationService/GetActiveInpatientPhAppByEpisode';
        let input = { "EPISODEPARAM": EPISODEPARAM };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientPhysicianApplication>>(url, input);
        return result;
    }
}