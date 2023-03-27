//$C08D0406
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SubactionProcedureFlowable } from 'NebulaClient/Model/AtlasClientModel';

export class SubactionProcedureFlowableService {
    public static async SetMandatorySubactionProcedureFlowableProperties(episodeAction: EpisodeAction, masterResource: ResSection, fromResource: ResSection, subactionProcedureFlowable: SubactionProcedureFlowable): Promise<void> {
        let url: string = "/api/SubactionProcedureFlowableService/SetMandatorySubactionProcedureFlowableProperties";
        let input = { "episodeAction": episodeAction, "masterResource": masterResource, "fromResource": fromResource, "subactionProcedureFlowable": subactionProcedureFlowable };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async CheckPaid(subactionProcedureFlowable: SubactionProcedureFlowable): Promise<void> {
        let url: string = "/api/SubactionProcedureFlowableService/CheckPaid";
        let input = { "subactionProcedureFlowable": subactionProcedureFlowable };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async IsPaid(subActProcFlowID: Guid): Promise<boolean> {
        let url: string = "/api/SubactionProcedureFlowableService/IsPaid";
        let input = { "subActProcFlowID": subActProcFlowID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async AllowedToCancel(subActProcFlowID: Guid): Promise<boolean> {
        let url: string = "/api/SubactionProcedureFlowableService/AllowedToCancel";
        let input = { "subActProcFlowID": subActProcFlowID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetSpecialResourceForStore(subactionProcedureFlowable: SubactionProcedureFlowable): Promise<Resource> {
        let url: string = "/api/SubactionProcedureFlowableService/GetSpecialResourceForStore";
        let input = { "subactionProcedureFlowable": subactionProcedureFlowable };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Resource>(url, input);
        return result;
    }
    public static async GetAllConsultationProcOfPatient(PATIENTOBJECTID: string): Promise<Array<SubactionProcedureFlowable>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetAllConsultationProcOfPatient";
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable>>(url, input);
        return result;
    }
    public static async GetByWorklistDate(STARTDATE: Date, ENDDATE: Date, MINDATE: Date, injectionSQL: string): Promise<Array<SubactionProcedureFlowable>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetByWorklistDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MINDATE": MINDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable>>(url, input);
        return result;
    }
    public static async GetAllConsultationProcOfSubEpisode(SUBEPISODE: string, EPISODE: string): Promise<Array<SubactionProcedureFlowable>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetAllConsultationProcOfSubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable>>(url, input);
        return result;
    }
    public static async GetSubactionProceduresByEpisodeAction(EPISODEACTION: string): Promise<Array<SubactionProcedureFlowable>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetSubactionProceduresByEpisodeAction";
        let input = { "EPISODEACTION": EPISODEACTION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable>>(url, input);
        return result;
    }
    public static async GetUncompletedSPFsByEpisode(EPISODE: Guid): Promise<Array<SubactionProcedureFlowable.GetUncompletedSPFsByEpisode_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetUncompletedSPFsByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.GetUncompletedSPFsByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetAllConsultationProceduresOfPatient(PATIENT: Guid): Promise<Array<SubactionProcedureFlowable>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetAllConsultationProceduresOfPatient";
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable>>(url, input);
        return result;
    }
    public static async GetByFilterExpression(injectionSQL: string): Promise<Array<SubactionProcedureFlowable>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetByFilterExpression";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable>>(url, input);
        return result;
    }
    public static async GetBySPFWorklistDateReport(STARTDATE: Date, ENDDATE: Date, MINDATE: Date, injectionSQL: string): Promise<Array<SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetBySPFWorklistDateReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MINDATE": MINDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class>>(url, input);
        return result;
    }
    public static async GetBySPFFilterExpressionReport(injectionSQL: string): Promise<Array<SubactionProcedureFlowable.GetBySPFFilterExpressionReport_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetBySPFFilterExpressionReport";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.GetBySPFFilterExpressionReport_Class>>(url, input);
        return result;
    }
    public static async GetSubactionProceduresByObjectIDs(OBJECTIDS: Array<string>): Promise<Array<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetSubactionProceduresByObjectIDs";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class>>(url, input);
        return result;
    }
    public static async GetAllConsultationProcOfEpisode(EPISODEOBJECTID: string): Promise<Array<SubactionProcedureFlowable>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetAllConsultationProcOfEpisode";
        let input = { "EPISODEOBJECTID": EPISODEOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable>>(url, input);
        return result;
    }
    public static async GetPatientFolderEpisodeSubactions(EPISODEID: Guid, injectionSQL: string): Promise<Array<SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetPatientFolderEpisodeSubactions";
        let input = { "EPISODEID": EPISODEID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions_Class>>(url, input);
        return result;
    }
    public static async GetEndOfDayConsultationPoliclinicReport(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCE: Guid): Promise<Array<SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/GetEndOfDayConsultationPoliclinicReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport_Class>>(url, input);
        return result;
    }
    public static async VEM_TETKIK_ORNEK(): Promise<Array<SubactionProcedureFlowable.VEM_TETKIK_ORNEK_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/VEM_TETKIK_ORNEK";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.VEM_TETKIK_ORNEK_Class>>(url, input);
        return result;
    }
    public static async VEM_TETKIK_SONUC(): Promise<Array<SubactionProcedureFlowable.VEM_TETKIK_SONUC_Class>> {
        let url: string = "/api/SubactionProcedureFlowableService/VEM_TETKIK_SONUC";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubactionProcedureFlowable.VEM_TETKIK_SONUC_Class>>(url, input);
        return result;
    }
}