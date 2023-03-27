//$D49D4369
import { CostActionMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class CostActionMaterialService {
    public static async GetPreviousCostAction(MATERIALOBJECTID: Guid, ENDDATE: Date, STOREID: Guid): Promise<Array<CostActionMaterial.GetPreviousCostAction_Class>> {
        let url: string = '/api/CostActionMaterialService/GetPreviousCostAction';
        let input = { "MATERIALOBJECTID": MATERIALOBJECTID, "ENDDATE": ENDDATE, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<CostActionMaterial.GetPreviousCostAction_Class>>(url, input);
        return result;
    }
}