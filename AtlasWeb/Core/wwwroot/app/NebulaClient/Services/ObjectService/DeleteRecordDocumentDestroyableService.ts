//$BA44374D
import { DeleteRecordDocumentDestroyable } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class DeleteRecordDocumentDestroyableService {
    public static async GetDeleteRecordDocDestroyableCensusReportQuery(TERMID: string): Promise<Array<DeleteRecordDocumentDestroyable.GetDeleteRecordDocDestroyableCensusReportQuery_Class>> {
        let url: string = '/api/DeleteRecordDocumentDestroyableService/GetDeleteRecordDocDestroyableCensusReportQuery';
        let input = { "TERMID": TERMID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DeleteRecordDocumentDestroyable.GetDeleteRecordDocDestroyableCensusReportQuery_Class>>(url, input);
        return result;
    }
    public static async CensusReportNQL_DeleteRecordDocument(TERMID: string): Promise<Array<DeleteRecordDocumentDestroyable.CensusReportNQL_DeleteRecordDocument_Class>> {
        let url: string = '/api/DeleteRecordDocumentDestroyableService/CensusReportNQL_DeleteRecordDocument';
        let input = { "TERMID": TERMID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DeleteRecordDocumentDestroyable.CensusReportNQL_DeleteRecordDocument_Class>>(url, input);
        return result;
    }
    public static async DeleteRecordDocumentDestroyableDestroyedReportRQ(TTOBJECTID: Guid): Promise<Array<DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ_Class>> {
        let url: string = '/api/DeleteRecordDocumentDestroyableService/DeleteRecordDocumentDestroyableDestroyedReportRQ';
        let input = { "TTOBJECTID": TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ_Class>>(url, input);
        return result;
    }
}