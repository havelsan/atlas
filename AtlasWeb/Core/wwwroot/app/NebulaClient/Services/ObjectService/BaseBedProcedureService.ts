//$8F5F8A37
import { BaseBedProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { UsedStatusEnum } from 'NebulaClient/Model/AtlasClientModel';

export class BaseBedProcedureService {
    public static async OLAP_GetLastUsedBedByEpisode(EPISODEID: string): Promise<Array<BaseBedProcedure.OLAP_GetLastUsedBedByEpisode_Class>> {
        let url: string = "/api/BaseBedProcedureService/OLAP_GetLastUsedBedByEpisode";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure.OLAP_GetLastUsedBedByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetByPatientAndUseStatus(PATIENT: string, USEDSTATUS: UsedStatusEnum): Promise<Array<BaseBedProcedure>> {
        let url: string = "/api/BaseBedProcedureService/GetByPatientAndUseStatus";
        let input = { "PATIENT": PATIENT, "USEDSTATUS": USEDSTATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure>>(url, input);
        return result;
    }
    public static async GetByBaseInpatientAdmissionAndUseStatus(BASEINPATIENTADMISSION: string, USEDSTATUS: UsedStatusEnum): Promise<Array<BaseBedProcedure>> {
        let url: string = "/api/BaseBedProcedureService/GetByBaseInpatientAdmissionAndUseStatus";
        let input = { "BASEINPATIENTADMISSION": BASEINPATIENTADMISSION, "USEDSTATUS": USEDSTATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure>>(url, input);
        return result;
    }
    public static async OLAP_GetEpisodeFromUsedBed(EPISODE: string): Promise<Array<BaseBedProcedure.OLAP_GetEpisodeFromUsedBed_Class>> {
        let url: string = "/api/BaseBedProcedureService/OLAP_GetEpisodeFromUsedBed";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure.OLAP_GetEpisodeFromUsedBed_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetUsedBedByDate(DATETIME: Date): Promise<Array<BaseBedProcedure.OLAP_GetUsedBedByDate_Class>> {
        let url: string = "/api/BaseBedProcedureService/OLAP_GetUsedBedByDate";
        let input = { "DATETIME": DATETIME };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure.OLAP_GetUsedBedByDate_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeOrderByLastBed(EPISODE: Guid): Promise<Array<BaseBedProcedure>> {
        let url: string = "/api/BaseBedProcedureService/GetByEpisodeOrderByLastBed";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure>>(url, input);
        return result;
    }
    public static async GetByEpisodeOrderByFirstBed(EPISODE: string): Promise<Array<BaseBedProcedure>> {
        let url: string = "/api/BaseBedProcedureService/GetByEpisodeOrderByFirstBed";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure>>(url, input);
        return result;
    }
    public static async VEM_HASTA_YATAK(): Promise<Array<BaseBedProcedure.VEM_HASTA_YATAK_Class>> {
        let url: string = "/api/BaseBedProcedureService/VEM_HASTA_YATAK";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure.VEM_HASTA_YATAK_Class>>(url, input);
        return result;
    }
    public static async VEM_ANLIK_YATAN_HASTA(): Promise<Array<BaseBedProcedure.VEM_ANLIK_YATAN_HASTA_Class>> {
        let url: string = "/api/BaseBedProcedureService/VEM_ANLIK_YATAN_HASTA";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseBedProcedure.VEM_ANLIK_YATAN_HASTA_Class>>(url, input);
        return result;
    }
}