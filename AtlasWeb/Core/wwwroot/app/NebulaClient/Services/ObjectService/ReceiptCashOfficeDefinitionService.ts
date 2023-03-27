//$65E08716
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ReceiptCashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";

export class ReceiptCashOfficeDefinitionService {
    public static async GetCurrentReceiptNumber(receiptCashOfficeDefinition: ReceiptCashOfficeDefinition): Promise<string> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/GetCurrentReceiptNumber";
        let input = { "receiptCashOfficeDefinition": receiptCashOfficeDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async SetNextReceiptNumber(receiptCashOfficeDefinition: ReceiptCashOfficeDefinition): Promise<void> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/SetNextReceiptNumber";
        let input = { "receiptCashOfficeDefinition": receiptCashOfficeDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetCurrentCreditCardReceiptNumber(receiptCashOfficeDefinition: ReceiptCashOfficeDefinition): Promise<string> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/GetCurrentCreditCardReceiptNumber";
        let input = { "receiptCashOfficeDefinition": receiptCashOfficeDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async SetNextCreditCardReceiptNumber(receiptCashOfficeDefinition: ReceiptCashOfficeDefinition): Promise<void> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/SetNextCreditCardReceiptNumber";
        let input = { "receiptCashOfficeDefinition": receiptCashOfficeDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async AutoActiveDeActivateReceiptCashOfficeDef(receiptCashOfficeDefinition: ReceiptCashOfficeDefinition): Promise<ReceiptCashOfficeDefinition> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/AutoActiveDeActivateReceiptCashOfficeDef";
        let input = { "receiptCashOfficeDefinition": receiptCashOfficeDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ReceiptCashOfficeDefinition>(url, input);
        return result;
    }
    public static async GetActiveCashOfficeDefinition(objContext: TTObjectContext, cashOfficeGuid: Guid): Promise<ReceiptCashOfficeDefinition> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/GetActiveCashOfficeDefinition";
        let input = { "objContext": objContext, "cashOfficeGuid": cashOfficeGuid };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ReceiptCashOfficeDefinition>(url, input);
        return result;
    }
    public static async GetReceiptCashOfficeDefinitions(injectionSQL: string): Promise<Array<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class>> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/GetReceiptCashOfficeDefinitions";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class>>(url, input);
        return result;
    }
    public static async GetByCashOffice(PARAMCASHOFFICE: string): Promise<Array<ReceiptCashOfficeDefinition>> {
        let url: string = "/api/ReceiptCashOfficeDefinitionService/GetByCashOffice";
        let input = { "PARAMCASHOFFICE": PARAMCASHOFFICE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ReceiptCashOfficeDefinition>>(url, input);
        return result;
    }
}