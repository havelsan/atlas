//$52361692
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ChattelDocumentWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { EntryTicketModel } from 'app/Logistic/Views/GirisIslemleriComponents/CreateEntryTicketComponent';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
export class ChattelDocumentWithPurchaseService {
    public static async GetWaybillForInputDocumentTS(stockAction: ChattelDocumentWithPurchase): Promise<GetWaybillForInputDetailDocument_Output> {
        let url: string = "/api/ChattelDocumentWithPurchaseService/GetWaybillForInputDocumentTS";
        let input = { "stockAction": stockAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetWaybillForInputDetailDocument_Output>(url, input);
        return result;
    }

    public static async GetWaybillForInputDocument(storeId: Guid, number: string): Promise<EntryTicketModel> {
        let url: string = "/api/EntryOperation/GetWaybillForInputDocument";
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<EntryTicketModel>(url + "?storeId" + storeId + "&waybillNumber=" + number);
        return result;
    }

    public static async GetWaybillForInputDocumentTSFastSoft(stockAction: ChattelDocumentWithPurchase): Promise<GetWaybillForInputDetailDocument_Output> {
        let url: string = "/api/ChattelDocumentWithPurchaseService/GetWaybillForInputDocumentTSFastsoft";
        let input = { "stockAction": stockAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetWaybillForInputDetailDocument_Output>(url, input);
        return result;
    }

    public static async SendMuayeneKabulCevapToXXXXXXTS(stockAction: ChattelDocumentWithPurchase): Promise<ChattelDocumentWithPurchase> {
        let url: string = "/api/ChattelDocumentWithPurchaseService/SendMuayeneKabulCevapToXXXXXXTS";
        let input = { "stockAction": stockAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ChattelDocumentWithPurchase>(url, input);
        return result;
    }
}
export class GetWaybillForInputDetailDocument_Output {
    chattelDocumentWithPurchase: ChattelDocumentWithPurchase;
    chattelDocumentDetailWithPurchase: Array<ChattelDocumentDetailWithPurchase>;
}