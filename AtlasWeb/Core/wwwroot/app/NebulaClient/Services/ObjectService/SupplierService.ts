//$984F24BF
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { SupplierTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

export class SupplierService {
    public static async SupplierDefFormNQL(injectionSQL: string): Promise<Array<Supplier.SupplierDefFormNQL_Class>> {
        let url: string = "/api/SupplierService/SupplierDefFormNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Supplier.SupplierDefFormNQL_Class>>(url, input);
        return result;
    }
    public static async GetSupplierRecordReportQuery(SUPPLIERTYPE: SupplierTypeEnum): Promise<Array<Supplier.GetSupplierRecordReportQuery_Class>> {
        let url: string = "/api/SupplierService/GetSupplierRecordReportQuery";
        let input = { "SUPPLIERTYPE": SUPPLIERTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Supplier.GetSupplierRecordReportQuery_Class>>(url, input);
        return result;
    }
}