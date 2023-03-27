//$B351C930
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';

export class SubEpisodeService {
    public static async GetActiveSubEpisodeProtocol(subEpisode: SubEpisode): Promise<SubEpisodeProtocol> {
        let url: string = "/api/SubEpisodeService/GetActiveSubEpisodeProtocol";
        let input = { "subEpisode": subEpisode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SubEpisodeProtocol>(url, input);
        return result;
    }
    public static async MyAddress(subEpisode: SubEpisode): Promise<string> {
        let url: string = "/api/SubEpisodeService/MyAddress";
        let input = { "subEpisode": subEpisode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async MyDocumentNumber(subEpisode: SubEpisode): Promise<string> {
        let url: string = "/api/SubEpisodeService/MyDocumentNumber";
        let input = { "subEpisode": subEpisode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async MyDocumentDate(subEpisode: SubEpisode): Promise<Date> {
        let url: string = "/api/SubEpisodeService/MyDocumentDate";
        let input = { "subEpisode": subEpisode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Date>(url, input);
        return result;
    }
    public static async GetNotDiagnosisExistsByPatientGroup(STARTDATE: Date, ENDDATE: Date, RESOURCEFLAG: number, RESOURCE: Array<string>): Promise<Array<SubEpisode.GetNotDiagnosisExistsByPatientGroup_Class>> {
        let url: string = "/api/SubEpisodeService/GetNotDiagnosisExistsByPatientGroup";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "RESOURCEFLAG": RESOURCEFLAG, "RESOURCE": RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode.GetNotDiagnosisExistsByPatientGroup_Class>>(url, input);
        return result;
    }
    public static async GetPatientInformationBySubepisodeid(SUBEPISODE: string): Promise<Array<SubEpisode.GetPatientInformationBySubepisodeid_Class>> {
        let url: string = "/api/SubEpisodeService/GetPatientInformationBySubepisodeid";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode.GetPatientInformationBySubepisodeid_Class>>(url, input);
        return result;
    }
    public static async GetInpatientAndDischargeByEpisode(EPISODE: string): Promise<Array<SubEpisode>> {
        let url: string = "/api/SubEpisodeService/GetInpatientAndDischargeByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode>>(url, input);
        return result;
    }
    public static async GetByEpisodeAndStarterEpisodeAction(EPISODE: string, STARTEREPISODEACTION: string): Promise<Array<SubEpisode>> {
        let url: string = "/api/SubEpisodeService/GetByEpisodeAndStarterEpisodeAction";
        let input = { "EPISODE": EPISODE, "STARTEREPISODEACTION": STARTEREPISODEACTION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode>>(url, input);
        return result;
    }
    public static async GetMaxProtocolNo(EPISODE: Guid): Promise<Array<SubEpisode.GetMaxProtocolNo_Class>> {
        let url: string = "/api/SubEpisodeService/GetMaxProtocolNo";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode.GetMaxProtocolNo_Class>>(url, input);
        return result;
    }
    public static async GetByEpisode(EPISODE: string): Promise<Array<SubEpisode>> {
        let url: string = "/api/SubEpisodeService/GetByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode>>(url, input);
        return result;
    }
    public static async GetByDateAndPatientGroupAndDepartment(STARTDATE: Date, ENDDATE: Date, PATIENTSTATUS1: number, PATIENTSTATUS2: number, PATIENTSTATUS3: number, RESOURCE: Array<string>, RESOURCEFLAG: number, PATIENTSTATUS4: number, INPATIENTSTATUSFLAG: number): Promise<Array<SubEpisode.GetByDateAndPatientGroupAndDepartment_Class>> {
        let url: string = "/api/SubEpisodeService/GetByDateAndPatientGroupAndDepartment";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PATIENTSTATUS1": PATIENTSTATUS1, "PATIENTSTATUS2": PATIENTSTATUS2, "PATIENTSTATUS3": PATIENTSTATUS3, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG, "PATIENTSTATUS4": PATIENTSTATUS4, "INPATIENTSTATUSFLAG": INPATIENTSTATUSFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode.GetByDateAndPatientGroupAndDepartment_Class>>(url, input);
        return result;
    }
    public static async GetSubEpisodeExceptCancelled(injectionSQL: string): Promise<Array<SubEpisode.GetSubEpisodeExceptCancelled_Class>> {
        let url: string = "/api/SubEpisodeService/GetSubEpisodeExceptCancelled";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode.GetSubEpisodeExceptCancelled_Class>>(url, input);
        return result;
    }
    public static async GetSpecialityBySubEpisodeFilter(EPISODE: string, OBJECTID: string): Promise<Array<SubEpisode>> {
        let url: string = "/api/SubEpisodeService/GetSpecialityBySubEpisodeFilter";
        let input = { "EPISODE": EPISODE, "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode>>(url, input);
        return result;
    }
    public static async VEM_HASTA_BASVURU(): Promise<Array<SubEpisode.VEM_HASTA_BASVURU_Class>> {
        let url: string = "/api/SubEpisodeService/VEM_HASTA_BASVURU";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode.VEM_HASTA_BASVURU_Class>>(url, input);
        return result;
    }
    public static async GetByObjectId(OBJECTID: Guid): Promise<Array<SubEpisode>> {
        let url: string = "/api/SubEpisodeService/GetByObjectId";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisode>>(url, input);
        return result;
    }
}