//$89626F97
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class OrthesisProsthesisRequestService {
    public static async MakingDirectPurchaseHasUsed(orthesisProsthesisRequest: OrthesisProsthesisRequest): Promise<void> {
        let url: string = '/api/OrthesisProsthesisRequestService/MakingDirectPurchaseHasUsed';
        let input = { "orthesisProsthesisRequest": orthesisProsthesisRequest };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async CreateSubActionMatPricingDet(orthesisProsthesisRequest: OrthesisProsthesisRequest): Promise<void> {
        let url: string = '/api/OrthesisProsthesisRequestService/CreateSubActionMatPricingDet';
        let input = { "orthesisProsthesisRequest": orthesisProsthesisRequest };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async UnCompletedLinkedActions(orthesisProsthesisRequest: OrthesisProsthesisRequest): Promise<Array<any>> {
        let url: string = '/api/OrthesisProsthesisRequestService/UnCompletedLinkedActions';
        let input = { "orthesisProsthesisRequest": orthesisProsthesisRequest };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<any>>(url, input);
        return result;
    }
    public static async GetOrthesisProsthesisRequest(OBJECTID: string): Promise<Array<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>> {
        let url: string = '/api/OrthesisProsthesisRequestService/GetOrthesisProsthesisRequest';
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>>(url, input);
        return result;
    }
}