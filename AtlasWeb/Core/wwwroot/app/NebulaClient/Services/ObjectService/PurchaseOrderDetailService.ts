//$B0952291
import { NeHttpService } from "Fw/Services/NeHttpService";
import { PurchaseOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class PurchaseOrderDetailService {
    public static async GetByStatus(STATUS: number): Promise<Array<PurchaseOrderDetail>> {
        let url: string = "/api/PurchaseOrderDetailService/GetByStatus";
        let input = { "STATUS": STATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PurchaseOrderDetail>>(url, input);
        return result;
    }
}