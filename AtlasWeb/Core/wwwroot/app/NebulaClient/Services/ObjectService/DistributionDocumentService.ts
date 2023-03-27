//$02D5C2CB
import { DistributionDocument } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

export class DistributionDocumentService {
    public static async GetDistributionDocumentCensusReportQuery(TERMID: string): Promise<Array<DistributionDocument.GetDistributionDocumentCensusReportQuery_Class>> {
        let url: string = "/api/DistributionDocumentService/GetDistributionDocumentCensusReportQuery";
        let input = { "TERMID": TERMID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DistributionDocument.GetDistributionDocumentCensusReportQuery_Class>>(url, input);
        return result;
    }
    public static async CensusReportNQL_DistributionDocument(TERMID: string): Promise<Array<DistributionDocument.CensusReportNQL_DistributionDocument_Class>> {
        let url: string = "/api/DistributionDocumentService/CensusReportNQL_DistributionDocument";
        let input = { "TERMID": TERMID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DistributionDocument.CensusReportNQL_DistributionDocument_Class>>(url, input);
        return result;
    }

    public static async ReGenerateMyDistributionDocument(ActionID: string): Promise<OutputForReGenerateMyDistributionDocument> {
        let url: string = '/api/DistributionDocumentService/ReGenerateMyDistributionDocument';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForReGenerateMyDistributionDocument>(url, input);
        return result;
    }
    public static async GetStockMaxLvlControl(materialObjectID: Guid,storeObjectId:Guid,amount:number): Promise<string> {
        let url: string = '/api/DistributionDocumentService/GetStockMaxLvlControl';
        let input = { 'materialObjectID': materialObjectID, 'storeObjectId': storeObjectId, 'amount': amount, };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

}

export class OutputForReGenerateMyDistributionDocument {
    public OutputMessage: string;
    public IsTheActionGenerated: boolean;
}