//$FCBFA105
import { ChattelDocumentInputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ChattelDocumentInputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';

export class ChattelDocumentInputWithAccountancyService {
    public static async InputDetailsWithAccountancyRQ(TTOBJECTID: Guid): Promise<Array<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class>> {
        let url: string = '/api/ChattelDocumentInputWithAccountancyService/InputDetailsWithAccountancyRQ';
        let input = { "TTOBJECTID": TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class>>(url, input);
        return result;
    }
    public static async GetSameBaseNumberNQL(TERMID: Guid, BASENUMBER: string, ACCOUNTANCY: Guid): Promise<Array<ChattelDocumentInputWithAccountancy>> {
        let url: string = '/api/ChattelDocumentInputWithAccountancyService/GetSameBaseNumberNQL';
        let input = { "TERMID": TERMID, "BASENUMBER": BASENUMBER, "ACCOUNTANCY": ACCOUNTANCY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ChattelDocumentInputWithAccountancy>>(url, input);
        return result;
    }
    public static async GetWaybillForInputDocumentTS(stockAction: ChattelDocumentInputWithAccountancy): Promise<GetWaybillForInputDetailDocument_Output> {
        let url: string = "/api/ChattelDocumentInputWithAccountancyService/GetWaybillForInputDocumentTS";
        let input = { "stockAction": stockAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetWaybillForInputDetailDocument_Output>(url, input);
        return result;
    }
}
export class GetWaybillForInputDetailDocument_Output {
    chattelDocumentInputWithAccountancy: ChattelDocumentInputWithAccountancy;
    chattelDocumentInputDetailWithAccountancy: Array<ChattelDocumentInputDetailWithAccountancy>;
}
