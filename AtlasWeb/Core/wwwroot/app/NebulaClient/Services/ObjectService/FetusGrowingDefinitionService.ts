//$48F8B9E8
import { FetusGrowingDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";

export class FetusGrowingDefinitionService {
    public static async GetFetusGrowingByPregnancyWeek(context: TTObjectContext, pregnancyWeek: number): Promise<FetusGrowingDefinition> {
        let url: string = "/api/FetusGrowingDefinitionService/GetFetusGrowingByPregnancyWeek";
        let input = { "context": context, "pregnancyWeek": pregnancyWeek };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<FetusGrowingDefinition>(url, input);
        return result;
    }
    public static async GetFetusGrowingByWeekNQL(PWEEK: number, injectionSQL: string): Promise<Array<FetusGrowingDefinition>> {
        let url: string = "/api/FetusGrowingDefinitionService/GetFetusGrowingByWeekNQL";
        let input = { "PWEEK": PWEEK, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<FetusGrowingDefinition>>(url, input);
        return result;
    }
    public static async FetusGrowingDefinitionNQL(injectionSQL: string): Promise<Array<FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class>> {
        let url: string = "/api/FetusGrowingDefinitionService/FetusGrowingDefinitionNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class>>(url, input);
        return result;
    }
}