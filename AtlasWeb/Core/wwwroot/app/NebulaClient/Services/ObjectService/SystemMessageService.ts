//$CF6371C0
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemMessage } from 'NebulaClient/Model/AtlasClientModel';

export class SystemMessageService {
    public static async GetMessage(code: number): Promise<string> {
        let url: string = "/api/SystemMessageService/GetMessage";
        let input = { "code": code };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetMessageV2(code: number, sDefaultValue: string): Promise<string> {
        let url: string = "/api/SystemMessageService/GetMessage";
        let input = { "code": code, "sDefaultValue": sDefaultValue };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetMessageV3(code: number, parameters: string[]): Promise<string> {
        let url: string = "/api/SystemMessageService/GetMessage";
        let input = { "code": code, "parameters": parameters };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetMessageV4(code: number, sDefaultValue: string, parameters: string[]): Promise<string> {
        let url: string = "/api/SystemMessageService/GetMessage";
        let input = { "code": code, "sDefaultValue": sDefaultValue, "parameters": parameters };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetMessageType(code: number): Promise<string> {
        let url: string = "/api/SystemMessageService/GetMessageType";
        let input = { "code": code };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetSystem_Message(CODE: number): Promise<Array<SystemMessage>> {
        let url: string = "/api/SystemMessageService/GetSystem_Message";
        let input = { "CODE": CODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemMessage>>(url, input);
        return result;
    }
    public static async GetSystemMessagesDefinition(injectionSQL: string): Promise<Array<SystemMessage.GetSystemMessagesDefinition_Class>> {
        let url: string = "/api/SystemMessageService/GetSystemMessagesDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemMessage.GetSystemMessagesDefinition_Class>>(url, input);
        return result;
    }
    public static async GetSystemMessageByLastUpdateDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<SystemMessage>> {
        let url: string = "/api/SystemMessageService/GetSystemMessageByLastUpdateDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemMessage>>(url, input);
        return result;
    }
}