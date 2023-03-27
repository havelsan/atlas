//$C286A37C
import { FTRVucutBolgesi } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class FTRVucutBolgesiService {
    public static async GetFTRVucutBolgesiDefinitionQuery(injectionSQL: string): Promise<Array<FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery_Class>> {
        let url: string = "/api/FTRVucutBolgesiService/GetFTRVucutBolgesiDefinitionQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery_Class>>(url, input);
        return result;
    }
    public static async GetFTRVucutBolgesiQuery(): Promise<Array<FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class>> {
        let url: string = "/api/FTRVucutBolgesiService/GetFTRVucutBolgesiQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class>>(url, input);
        return result;
    }
}