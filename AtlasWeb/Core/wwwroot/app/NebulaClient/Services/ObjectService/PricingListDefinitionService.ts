//$F1F59F2C
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PricingListDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class PricingListDefinitionService {
    public static async GetByCode(PARAMCODE: string): Promise<Array<PricingListDefinition>> {
        let url: string = "/api/PricingListDefinitionService/GetByCode";
        let input = { "PARAMCODE": PARAMCODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PricingListDefinition>>(url, input);
        return result;
    }
    public static async GetPricingListDefinitions(injectionSQL: string): Promise<Array<PricingListDefinition.GetPricingListDefinitions_Class>> {
        let url: string = "/api/PricingListDefinitionService/GetPricingListDefinitions";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PricingListDefinition.GetPricingListDefinitions_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetPricingListDef(): Promise<Array<PricingListDefinition.OLAP_GetPricingListDef_Class>> {
        let url: string = "/api/PricingListDefinitionService/OLAP_GetPricingListDef";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PricingListDefinition.OLAP_GetPricingListDef_Class>>(url, input);
        return result;
    }
    public static async GetByObjectID(PARAMOBJECTID: string): Promise<Array<PricingListDefinition>> {
        let url: string = "/api/PricingListDefinitionService/GetByObjectID";
        let input = { "PARAMOBJECTID": PARAMOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PricingListDefinition>>(url, input);
        return result;
    }
    public static async GetPricingListDefByLastUpdateDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<PricingListDefinition>> {
        let url: string = "/api/PricingListDefinitionService/GetPricingListDefByLastUpdateDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PricingListDefinition>>(url, input);
        return result;
    }
}