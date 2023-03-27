//$BC731C2A
import { ActionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PricingListDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';

export class ProcedureDefinitionService {
    public static async GetProcedurePricingDetail(procedureDefinition: ProcedureDefinition, pPricingList: PricingListDefinition, pDate: Date): Promise<Array<any>> {
        let url: string = '/api/ProcedureDefinitionService/GetProcedurePricingDetail';
        let input = { "procedureDefinition": procedureDefinition, "pPricingList": pPricingList, "pDate": pDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<any>>(url, input);
        return result;
    }
    public static async GetActiveByCode(context: TTObjectContext, Code: string): Promise<ProcedureDefinition> {
        let url: string = '/api/ProcedureDefinitionService/GetActiveByCode';
        let input = { "context": context, "Code": Code };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ProcedureDefinition>(url, input);
        return result;
    }
    public static async GetSUTPointByProcedureObjectId(procedureObjId: Guid): Promise<number> {
        let url: string = '/api/ProcedureDefinitionService/GetSUTPointByProcedureObjectId';
        let input = { "procedureObjId": procedureObjId };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetSUTPoint(procedureDef: ProcedureDefinition): Promise<number> {
        let url: string = '/api/ProcedureDefinitionService/GetSUTPoint';
        let input = { "procedureDef": procedureDef };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetProcedureDefinitionNames(actionType: ActionTypeEnum): Promise<string> {
        let url: string = '/api/ProcedureDefinitionService/GetProcedureDefinitionNames';
        let input = { "actionType": actionType };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async OLAP_Procedure(): Promise<Array<ProcedureDefinition>> {
        let url: string = '/api/ProcedureDefinitionService/OLAP_Procedure';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition>>(url, input);
        return result;
    }
    public static async GetProcedureDefinitionListDefinition(injectionSQL: string): Promise<Array<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class>> {
        let url: string = '/api/ProcedureDefinitionService/GetProcedureDefinitionListDefinition';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class>>(url, input);
        return result;
    }
    public static async GetByCode(CODE: string, injectionSQL: string): Promise<Array<ProcedureDefinition>> {
        let url: string = '/api/ProcedureDefinitionService/GetByCode';
        let input = { "CODE": CODE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition>>(url, input);
        return result;
    }
    public static async GetProcedureWithNoEffectivePrice(): Promise<Array<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class>> {
        let url: string = '/api/ProcedureDefinitionService/GetProcedureWithNoEffectivePrice';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class>>(url, input);
        return result;
    }
    public static async GetProcedureWithMultiEffectivePriceByPriceList(PRICELIST: string): Promise<Array<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class>> {
        let url: string = '/api/ProcedureDefinitionService/GetProcedureWithMultiEffectivePriceByPriceList';
        let input = { "PRICELIST": PRICELIST };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class>>(url, input);
        return result;
    }
    public static async GetAllProcedureDefinitions(injectionSQL: string): Promise<Array<ProcedureDefinition>> {
        let url: string = '/api/ProcedureDefinitionService/GetAllProcedureDefinitions';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition>>(url, input);
        return result;
    }
    public static async GetProcedureDefByLastUpdateDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<ProcedureDefinition>> {
        let url: string = '/api/ProcedureDefinitionService/GetProcedureDefByLastUpdateDate';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition>>(url, input);
        return result;
    }
    public static async OLAP_GetProcedures(): Promise<Array<ProcedureDefinition.OLAP_GetProcedures_Class>> {
        let url: string = '/api/ProcedureDefinitionService/OLAP_GetProcedures';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition.OLAP_GetProcedures_Class>>(url, input);
        return result;
    }
    public static async GetProcedureDefForProcedureRequest(injectionSQL: string): Promise<Array<ProcedureDefinition.GetProcedureDefForProcedureRequest_Class>> {
        let url: string = '/api/ProcedureDefinitionService/GetProcedureDefForProcedureRequest';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition.GetProcedureDefForProcedureRequest_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetProcedures_WithDate(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<ProcedureDefinition.OLAP_GetProcedures_WithDate_Class>> {
        let url: string = '/api/ProcedureDefinitionService/OLAP_GetProcedures_WithDate';
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition.OLAP_GetProcedures_WithDate_Class>>(url, input);
        return result;
    }
    public static async VEM_HIZMET(): Promise<Array<ProcedureDefinition.VEM_HIZMET_Class>> {
        let url: string = '/api/ProcedureDefinitionService/VEM_HIZMET';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition.VEM_HIZMET_Class>>(url, input);
        return result;
    }
    public static async GetByLOINCCode(LOINCCODE: string): Promise<Array<ProcedureDefinition>> {
        let url: string = '/api/ProcedureDefinitionService/GetByLOINCCode';
        let input = { "LOINCCODE": LOINCCODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition>>(url, input);
        return result;
    }
}