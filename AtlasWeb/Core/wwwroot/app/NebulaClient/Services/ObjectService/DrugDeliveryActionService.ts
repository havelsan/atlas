//$80F6BB36
import { DrugDeliveryAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';

export class DrugDeliveryActionService {
    public static async GetDrugDeliveryReportQuery(TTOBJECTID: Guid): Promise<Array<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>> {
        let url: string = '/api/DrugDeliveryActionService/GetDrugDeliveryReportQuery';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDetails(episodeID: Guid): Promise<Array<GetDetails_Output>> {
        let url: string = '/api/DrugDeliveryActionService/GetDetails';
        let input = { 'episodeID': episodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetDetails_Output>>(url, input);
        return result;
    }
}
export class GetDetails_Output {
    public drugName: string;
    public Amount: number;
    public drugOrderTransaction: DrugOrderTransaction;
    @Type(() => DrugOrderDetail)
    public DrugOrderDetails: Array<DrugOrderDetail>;
}