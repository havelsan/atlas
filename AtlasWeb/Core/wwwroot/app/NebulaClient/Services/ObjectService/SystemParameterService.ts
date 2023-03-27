//$B58B940D
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ResHospital } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Sites } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameter } from 'NebulaClient/Model/AtlasClientModel';

export class SystemParameterService {
    public static async GetSaglikTesisKodu(): Promise<number> {
        let url = '/api/SystemParameterService/GetSaglikTesisKodu';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetSite(): Promise<Sites> {
        let url = '/api/SystemParameterService/GetSite';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Sites>(url, input);
        return result;
    }
    public static async GetHospital(): Promise<ResHospital> {
        let url = '/api/SystemParameterService/GetHospital';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ResHospital>(url, input);
        return result;
    }
    public static async GetParameterValue(name: string, defaultValue: string): Promise<string> {
        let url = '/api/SystemParameter/GetParameterValue';
        let input = { 'name': name, 'defaultValue': defaultValue };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async RefreshCache(): Promise<void> {
        let url = '/api/SystemParameterService/RefreshCache';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        await httpService.post<void>(url, input);
    }
    public static async GetSystemParameterDefinition(injectionSQL: string): Promise<Array<SystemParameter.GetSystemParameterDefinition_Class>> {
        let url = '/api/SystemParameterService/GetSystemParameterDefinition';
        let input = { 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemParameter.GetSystemParameterDefinition_Class>>(url, input);
        return result;
    }
    public static async AllSysParams(): Promise<Array<SystemParameter.AllSysParams_Class>> {
        let url = '/api/SystemParameterService/AllSysParams';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemParameter.AllSysParams_Class>>(url, input);
        return result;
    }
    public static async GetSystemParameterByLastUpdateDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<SystemParameter>> {
        let url = '/api/SystemParameterService/GetSystemParameterByLastUpdateDate';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemParameter>>(url, input);
        return result;
    }
    public static async GetApplicationParameterDefinition(injectionSQL: string): Promise<Array<SystemParameter.GetApplicationParameterDefinition_Class>> {
        let url = '/api/SystemParameterService/GetApplicationParameterDefinition';
        let input = { 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemParameter.GetApplicationParameterDefinition_Class>>(url, input);
        return result;
    }
}