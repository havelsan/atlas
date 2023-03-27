//$32596BB5
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InvoiceCollection } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class InvoiceCollectionService {
    public static async GetICbyTerm(TERM: Guid): Promise<Array<InvoiceCollection>> {
        let url: string = "/api/InvoiceCollectionService/GetICbyTerm";
        let input = { "TERM": TERM };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InvoiceCollection>>(url, input);
        return result;
    }
    public static async GetInvoiceCollectionByInjection(injectionSQL: string): Promise<Array<InvoiceCollection.GetInvoiceCollectionByInjection_Class>> {
        let url: string = "/api/InvoiceCollectionService/GetInvoiceCollectionByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InvoiceCollection.GetInvoiceCollectionByInjection_Class>>(url, input);
        return result;
    }
}